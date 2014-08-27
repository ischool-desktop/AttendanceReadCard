using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.Configuration;
using FISCA;
using System.Xml;
using System.Xml.Linq;
using InternalLib;
using System.Xml.XPath;

namespace AttendanceReadCard
{
    /// <summary>
    /// 學生出缺席讀卡設定。
    /// </summary>
    public class CardSetup
    {
        public CardSetup()
        {
            try
            {
                Campus.Configuration.Config.App.Sync("學生出缺席讀卡設定");
                ConfigData cd = Campus.Configuration.Config.App["學生出缺席讀卡設定"];

                LateString = cd["遲"];
                AbsenceString = cd["缺"];

                if (cd["OverrideOption"] == "覆蓋現有資料")
                    OverrideData = true;
                else
                    OverrideData = false; //預設是這個選項。

                if (string.IsNullOrWhiteSpace(LateString))
                    throw new Exception("讀卡設定缺少設定「遲」的對應缺曠類別。");

                if (string.IsNullOrWhiteSpace(AbsenceString))
                    throw new Exception("讀卡設定缺少設定「缺」的對應缺曠類別。");

                //節次對照表。
                PeriodMapping = new Dictionary<string, string>();
                PeriodIndex = new Dictionary<string, int>();

                int index = -1;
                foreach (string period in Program.PeriodNameList)
                {
                    index++;

                    if (PeriodMapping.ContainsKey(period))
                        throw new Exception("節次對照設定有重覆！");

                    if (string.IsNullOrWhiteSpace(cd[period]))
                        continue;

                    PeriodMapping.Add(period, cd[period]);
                    PeriodIndex.Add(cd[period], index);
                }

                //讀取班級對照表。
                XmlElement xmlclassmap = cd.GetXml("ClassNameMap", null);

                XElement xclassmap;
                if (xmlclassmap != null)
                    xclassmap = XElement.Parse(xmlclassmap.OuterXml);
                else
                    xclassmap = new XElement("Map");

                ClassMapping = new Dictionary<string, string>();
                foreach (XElement cls in xclassmap.Elements("Class"))
                {
                    string classname = cls.Attribute("ClassName").Value;
                    string cardname = cls.Attribute("CardName").Value;

                    if (string.IsNullOrWhiteSpace(cardname))
                        continue;

                    if (ClassMapping.ContainsKey(cardname))
                        throw new Exception("班級對照表有重覆的代碼設定！");

                    ClassMapping.Add(cardname, classname);
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                throw new Exception("讀取讀卡設定錯誤:" + ex.Message, ex);
            }
        }

        /// <summary>
        /// 讀卡的班級名稱對照表。
        /// </summary>
        public Dictionary<string, string> ClassMapping { get; private set; }

        /// <summary>
        /// 讀卡節次對照表,卡片上的節次對照系統中的節次。
        /// </summary>
        public Dictionary<string, string> PeriodMapping { get; private set; }

        /// <summary>
        /// 節次的索引位置，用於決定要顯示在那個欄位上。
        /// </summary>
        public Dictionary<string, int> PeriodIndex { get; private set; }

        /// <summary>
        /// 卡片上的「遲」的對應字串。
        /// </summary>
        public string LateString { get; private set; }

        /// <summary>
        /// 卡片上的「缺」對應字串。
        /// </summary>
        public string AbsenceString { get; private set; }

        /// <summary>
        /// 是否覆蓋現有資料。
        /// </summary>
        public bool OverrideData { get; private set; }

        /// <summary>
        /// 依據設定轉換讀卡上的資料。
        /// </summary>
        /// <param name="xCardData"></param>
        /// <returns></returns>
        public XElement TransformData(XElement xCardData)
        {
            XElement source = xCardData;
            XElement result = new XElement("AttendanceData");

            //班級代碼。
            string cn = source.ElementText("GradeYear") + source.ElementText("ClassName");
            if (!ClassMapping.ContainsKey(cn))
                throw new Exception(string.Format("未定義的班級讀卡代碼：{0}", cn));

            result.Add(new XElement("ClassName", ClassMapping[cn]));

            //日期
            string dt = string.Format("{0}/{1}/{2}",
                source.ElementText("Year"),
                source.ElementText("Month"),
                source.ElementText("Day"));

            result.Add(new XElement("DateTime", dt));

            foreach (XElement attendance in source.Elements("Attendance"))
            {
                XElement newattendance = new XElement("Attendance");
                newattendance.SetAttributeValue("SeatNo", attendance.AttributeText("SeatNo"));

                foreach (XElement period in attendance.Elements("Period"))
                {
                    XElement newperiod = new XElement("Period");

                    string cardPeriod = period.AttributeText("Name");

                    if (!PeriodMapping.ContainsKey(cardPeriod)) //沒設定就讀不到。
                        continue;

                    string periodTitle = PeriodMapping[cardPeriod];

                    if (string.IsNullOrWhiteSpace(periodTitle)) //沒設定就讀不到。
                        continue;

                    newperiod.SetAttributeValue("Name", periodTitle);

                    XElement reason = period.XPathSelectElement("Reason[.='缺']");

                    if (reason != null) //不是「缺」
                        newperiod.SetAttributeValue("Reason", AbsenceString);
                    else //就是「遲」
                        newperiod.SetAttributeValue("Reason", LateString);

                    newattendance.Add(newperiod);
                }
                result.Add(newattendance);
            }

            return result;
        }
    }
}
