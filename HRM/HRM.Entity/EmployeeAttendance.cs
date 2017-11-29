using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeAttendance
    {
        public int EmployeeAttendanceId { get; set; }
        public int Employeeid { get; set; }
        public int AttendanceId { get; set; }
    }
}
