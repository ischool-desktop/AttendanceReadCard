﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AttendanceReadCard
{
    internal class ClassAttendance : Dictionary<ClassDateTime, List<CardAttendance>>
    {
        public List<CardAttendance> GetList()
        {
            List<CardAttendance> result = new List<CardAttendance>();

            foreach (List<CardAttendance> each in Values)
                result.AddRange(each);

            return result;
        }

        public BindingList<CardAttendance> GetBindingList()
        {
            return new BindingList<CardAttendance>(GetList());
        }
    }

    internal struct ClassDateTime
    {
        public ClassDateTime(string cn, string dt)
            : this()
        {
            ClassName = cn;
            DateTime = dt;
        }

        public string ClassName { get; set; }

        public string DateTime { get; set; }
    }
}
