using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Salgrade
    {
        [Key]
        public int SalgradeId { get; set; }
        public string GradeName { get; set; }
        [Required, Range(10000, 300000)]
        public int LowSalary { get; set; }
        [Required, Range(10000, 300000)]
        public int HighSalary { get; set; }
    }
}
