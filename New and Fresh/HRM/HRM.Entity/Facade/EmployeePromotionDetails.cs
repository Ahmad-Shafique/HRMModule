using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.Facade
{
    public class EmployeePromotionDetails
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SalaryRankId { get; set; }
        public int NextSalaryRankId { get; set; }
        public string RankName { get; set; }
        public string NextRankName { get; set; }
        public int BasicSalary { get; set; }
        public int NextBasicSalary { get; set; }
        public int RecommendationStatus { get; set; }
        public bool promotionAvailable { get; set; }
    }
}
