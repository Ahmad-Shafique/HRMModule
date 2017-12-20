using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.Facade
{
    public class EmployeePerformance
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ProjectScore { get; set; }
        public int TrainingScore { get; set; }
        public int AttendanceScore { get; set; }
        public int AggregateScore { get; set; }
        public int DepartmentId { get; set; }
    }
}
