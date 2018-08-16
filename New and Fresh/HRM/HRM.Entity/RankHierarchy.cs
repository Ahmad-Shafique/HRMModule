using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class RankHierarchy
    {
        [Key]
        public int RankHierarchyId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int SalaryRankId { get; set; }
        public int NextSalaryRankId { get; set; }
    }
}
