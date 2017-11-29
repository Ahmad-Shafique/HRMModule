using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        public string TrainingDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SuccessRate { get; set; }

        public List<Employee> Employees { get; set; }

        public Training()
        {
            Employees = new List<Employee>();
        }
    }
}
