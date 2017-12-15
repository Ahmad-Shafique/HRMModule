using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string MonthName { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public int MonthlyAbsence { get; set; }
    }
}
