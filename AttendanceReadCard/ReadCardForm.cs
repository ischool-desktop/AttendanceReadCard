using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA;
using System.Xml.Linq;
using InternalLib;
using K12.Data;

namespace AttendanceReadCard
{
    public partial class ReadCardForm : BaseForm
    {
        /// <summary>
        /// 讀卡設定。
        /// </summary>
        private CardSetup Setup { get; set; }

        private StudentRecordFinder StuFinder = new StudentRecordFinder();

        private ClassAttendance Classes = new ClassAttendance();

        private Dictionary<AttendanceKey, AttendanceRecord> CurrentAttData;

        public ReadCardForm()
        {
            InitializeComponent();
        }

        private void ReadCardForm_Load(object sender, EventArgs e)
        {
            #region Init 相關資料
            try
            {
                Setup = new CardSetup();

                intSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
                intSemester.Value = int.Parse(K12.Data.School.DefaultSemester);

                int i = 0;
                foreach (string period in Program.PeriodNameList)
                {
                    DataGridViewColumn dgvcolumn = dgvAttendance.Columns["p" + i];

                    if (!Setup.PeriodMapping.ContainsKey(period))
                        dgvcolumn.Visible = false;
                    else
                    {
                        dgvcolumn.Visible = true;
                        dgvcolumn.HeaderText = Setup.PeriodMapping[period];
                        dgvcolumn.Tag = "Period";
                    }

                    i++;
                }

                dgvAttendance.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        #region 讀卡流程主要程式
        private void btnBeginRead_Click(object sender, EventArgs e)
        {
            try
            {
                Setup = new CardSetup();

                CardReadingForm crf = new CardReadingForm(Setup);
                crf.ShowDialog();

                Clipboard.SetText(crf.XmlResult.ToString());

                XElement srcdata = crf.XmlResult;

                //XElement srcdata = XElement.Load("ExampleData.xml");

                foreach (XElement attData in srcdata.Elements("AttendanceData"))
                {
                    string className = attData.ElementText("ClassName");
                    string dateTime = attData.ElementText("DateTime");

                    ClassDateTime cdt = new ClassDateTime(className, dateTime);

                    if (Classes.ContainsKey(cdt))
                        Classes.Remove(cdt);

                    Classes.Add(cdt, new List<CardAttendance>());

                    foreach (XElement attrecord in attData.Elements("Attendance"))
                    {
                        //沒有資料就讀下一筆。
                        if (!attrecord.HasElements) continue;

                        string seatNo = attrecord.AttributeText("SeatNo");

                        CardAttendance card_att = new CardAttendance();
                        card_att.DateTime = dateTime;
                        card_att.ClassName = className;
                        card_att.SeatNo = seatNo;
                        card_att.XmlData = attrecord;
                        card_att.FillStudentInfo(StuFinder);

                        Classes[cdt].Add(card_att);

                        foreach (XElement period in attrecord.Elements("Period"))
                        {
                            string pname = period.AttributeText("Name");
                            string reason = period.AttributeText("Reason");
                            int index = Setup.PeriodIndex[pname];

                            card_att.Periods[index] = reason;
                        }
                    }
                }

                dgvAttendance.DataSource = Classes.GetBindingList();

                List<string> studentid_list = GroupStudentID();
                //將資料庫中的缺曠記錄讀出來。
                CurrentAttData = GetAttendanceInDB(studentid_list);

                bool hasStudentNotFound = false;
                foreach (DataGridViewRow row in dgvAttendance.Rows)
                {
                    CardAttendance ca = row.DataBoundItem as CardAttendance;

                    if (ca.SRecord == null)
                    {
                        DataGridViewCellStyle style = row.DefaultCellStyle.Clone();
                        style.BackColor = Color.Red;
                        style.ForeColor = Color.Wheat;
                        row.DefaultCellStyle = style;
                        hasStudentNotFound = true;
                    }
                }

                if (hasStudentNotFound)
                {
                    MessageBox.Show("有部份班級座號找不到對應的學生，該資料將不被處理與儲存。\n\n(資料被標記為紅色)", "ischool");
                }
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Format("新增的資料將存儲到 {0} 學年度 {1} 學期，您確定？", intSchoolYear.Value, intSemester.Value);

                DialogResult dr = MessageBox.Show(msg, "ischool", MessageBoxButtons.YesNo);

                if (dr == System.Windows.Forms.DialogResult.No)
                    return;

                List<string> studentid_list = GroupStudentID();
                //將資料庫中的缺曠記錄讀出來。
                CurrentAttData = GetAttendanceInDB(studentid_list);

                List<AttendanceRecord> insert_list = new List<AttendanceRecord>();
                List<AttendanceRecord> update_list = new List<AttendanceRecord>();

                foreach (CardAttendance ca in Classes.GetList())
                {
                    if (ca.SRecord == null)
                        continue;

                    AttendanceKey ak = new AttendanceKey(ca.SRecord.ID, ca.DateTime);

                    if (CurrentAttData.ContainsKey(ak))
                        update_list.Add(GenerateUpdateRecord(ca, CurrentAttData[ak]));
                    else
                        insert_list.Add(GenerateInsertRecord(ca));
                }

                Attendance.Update(update_list);
                Attendance.Insert(insert_list);

                Classes = new ClassAttendance();
                dgvAttendance.DataSource = Classes.GetBindingList();
                MessageBox.Show("儲存完成。");
            }
            catch (Exception ex)
            {
                RTOut.WriteError(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private AttendanceRecord GenerateInsertRecord(CardAttendance ca)
        {
            AttendanceRecord ar = new AttendanceRecord();

            ar.SchoolYear = intSchoolYear.Value;
            ar.Semester = intSemester.Value;
            ar.RefStudentID = ca.SRecord.ID;
            ar.OccurDate = DateTime.Parse(ca.DateTime);

            foreach (XElement each in ca.XmlData.Elements("Period"))
            {
                AttendancePeriod ap = new AttendancePeriod();
                ap.AbsenceType = each.AttributeText("Reason");
                ap.Period = each.AttributeText("Name");

                ar.PeriodDetail.Add(ap);
            }

            return ar;
        }

        private AttendanceRecord GenerateUpdateRecord(CardAttendance ca, AttendanceRecord attendanceRecord)
        {
            foreach (XElement each in ca.XmlData.Elements("Period"))
            {
                AttendancePeriod apnew = new AttendancePeriod();
                apnew.AbsenceType = each.AttributeText("Reason");
                apnew.Period = each.AttributeText("Name");

                AttendancePeriod apold = null;
                foreach (AttendancePeriod ap in attendanceRecord.PeriodDetail)
                {
                    if (ap.Period == apnew.Period)
                    {
                        apold = ap;

                        if (Setup.OverrideData) //要覆蓋的話。
                            apold.AbsenceType = apnew.AbsenceType; //找到就直接改掉。

                        break;
                    }
                }

                if (apold == null)
                    attendanceRecord.PeriodDetail.Add(apnew); //沒找到就新增。
            }

            return attendanceRecord;
        }

        private static Dictionary<AttendanceKey, AttendanceRecord> GetAttendanceInDB(List<string> studentid_list)
        {
            Dictionary<AttendanceKey, AttendanceRecord> attendances = new Dictionary<AttendanceKey, AttendanceRecord>();
            foreach (AttendanceRecord each in Attendance.SelectByStudentIDs(studentid_list))
            {
                string dtString = each.OccurDate.ToString("yyyy/MM/dd");
                AttendanceKey ak = new AttendanceKey(each.RefStudentID, dtString);

                attendances.Add(ak, each);
            }
            return attendances;
        }

        private struct AttendanceKey
        {
            public AttendanceKey(string studentID, string dateTime)
                : this()
            {
                StudentID = studentID;

                DateTime dt = DateTime.Parse(dateTime);

                DateTimeString = dt.ToString("yyyy/MM/dd");
            }

            public string StudentID { get; set; }

            public string DateTimeString { get; set; }
        }

        /// <summary>
        /// 取得學生編號清單，並保持唯一性。
        /// </summary>
        /// <returns></returns>
        private List<string> GroupStudentID()
        {
            List<string> studentid_list = new List<string>();

            foreach (CardAttendance each in Classes.GetList())
            {
                if (each.SRecord == null)
                    continue;

                studentid_list.Add(each.SRecord.ID);
            }
            studentid_list = studentid_list.Distinct().ToList();
            return studentid_list;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.Rows.Count > 0)
            {
                string msg = "資料未儲存，確定要離開？";
                DialogResult dr = MessageBox.Show(msg, "ischool", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                    Close();
            }
            else
                Close();
        }

        private void dgvAttendance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];
            if (dgvAttendance.Columns[e.ColumnIndex].Tag + "" != "Period")
                return;

            string period = dgvAttendance.Columns[e.ColumnIndex].HeaderText;
            CardAttendance ca = row.DataBoundItem as CardAttendance;

            if (ca.SRecord != null)
            {
                AttendanceKey ak = new AttendanceKey(ca.SRecord.ID, ca.DateTime);
                if (CurrentAttData.ContainsKey(ak))
                {
                    foreach (AttendancePeriod ap in CurrentAttData[ak].PeriodDetail)
                    {
                        if (ap.Period == period)
                        {
                            if (ap.AbsenceType == e.Value + "")
                                continue; //如果資料一樣，就不處理。

                            e.CellStyle.ForeColor = Color.Blue;
                            row.Cells[e.ColumnIndex].ToolTipText = string.Format("原資料：「{0}」", ap.AbsenceType);
                        }
                    }
                }
            }
        }

        private void dgvAttendance_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAttendance.SelectedRows)
                row.Selected = false;
        }
    }
}
