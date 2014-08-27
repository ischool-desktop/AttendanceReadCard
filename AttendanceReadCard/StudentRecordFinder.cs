using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Threading;
using System.Threading.Tasks;
using FISCA;

namespace AttendanceReadCard
{
    internal class StudentRecordFinder
    {
        private Dictionary<string, Dictionary<string, StudentRecord>> Students { get; set; }

        private Exception LoadDataError { get; set; }

        private ManualResetEvent Wait = new ManualResetEvent(true);

        public StudentRecordFinder()
        {
            LoadDataError = null;

            Wait.Reset();

            Task task = Task.Factory.StartNew(() => LoadData(),
                new CancellationToken(),
                TaskCreationOptions.None,
                TaskScheduler.Default);
        }

        private void LoadData()
        {
            try
            {
                Students = new Dictionary<string, Dictionary<string, StudentRecord>>();

                Dictionary<string, ClassRecord> classes = new Dictionary<string, ClassRecord>();

                foreach (ClassRecord cr in Class.SelectAll())
                    classes.Add(cr.ID, cr);

                foreach (StudentRecord sr in Student.SelectAll())
                {
                    if (sr.Status == StudentRecord.StudentStatus.一般 ||
                        sr.Status == StudentRecord.StudentStatus.延修)
                    {
                        //沒有班級不處理。
                        if (string.IsNullOrWhiteSpace(sr.RefClassID))
                            continue;

                        //沒有座號不處理。
                        if (string.IsNullOrWhiteSpace(sr.SeatNo + ""))
                            continue;

                        ClassRecord cr = classes[sr.RefClassID];

                        if (!Students.ContainsKey(cr.Name))
                            Students.Add(cr.Name, new Dictionary<string, StudentRecord>());

                        if (!Students[cr.Name].ContainsKey(sr.SeatNo + ""))
                            Students[cr.Name].Add(sr.SeatNo + "", sr);
                    }
                }
            }
            catch (Exception ex)
            {
                LoadDataError = ex;
                RTOut.WriteError(ex);
            }
            finally
            {
                Wait.Set();
            }
        }

        public StudentRecord Find(string className, string seatNo)
        {
            Wait.WaitOne();

            if (LoadDataError != null)
                throw LoadDataError;

            if (Students.ContainsKey(className))
            {
                if (Students[className].ContainsKey(seatNo))
                    return Students[className][seatNo];
                else
                    return null;
            }
            else
                return null;
        }
    }
}
