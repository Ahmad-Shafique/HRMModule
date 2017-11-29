using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeePerformenceMetric
    {
        public int EmployeePerformenceMetricId { get; set; }
        public int IllegalLeave { get; set; }
        public int ProjectMissedDateLineCount { get; set; }
        public int TotalProjects { get; set; }
        public int AverageProjectScore { get; set; }
        public int TotalTraining { get; set; }
        public int AverageTrainingScore { get; set; }
        public int Year { get; set; }
        public int EmployeeId { get; set; }
    }
}
