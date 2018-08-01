using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.Facade
{
    public class EmployeePromotion 
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SalaryRankId { get; set; }
        public string RankName { get; set; }
        public int BasicSalary { get; set; }
        public int RecommendationStatus { get; set; }
    }
}
