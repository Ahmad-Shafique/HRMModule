using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Static_views.Entity
{
    public class EmployeePerformance
    {
        public int EmployeePerformanceId { get; set; }
        public string EmployeeName { get; set; }
        public int ProjectScore { get; set; }
        public int TrainingScore { get; set; }
        public int AttendanceScore { get; set; }
        public int AggregateScore { get; set; }

    }
}