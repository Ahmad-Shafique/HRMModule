using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public string MonthName { get; set; }
        public string Value { get; set; }
        public int MonthlyAbsence { get; set; }
    }
}
