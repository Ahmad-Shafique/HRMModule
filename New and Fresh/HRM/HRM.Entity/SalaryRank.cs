using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class SalaryRank
    {
        [Key]
        public int SalaryRankId { get; set; }
        public string RankName { get; set; }
        public int RankValue { get; set; }
    }
}
