using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeSalary
    {
        [Key]
        public int EmployeeSalaryId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required, Range(10000, 300000)]
        public int BasicSalary { get; set; }
        [Required, Range(10000, 300000)]
        public int TotalSalary { get; set; }
        public string SalaryMonth { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }
        public int BonusId { get; set; }
        public int BonusValue { get; set; }
        public int SalaryRankId { get; set; }

    }
}
