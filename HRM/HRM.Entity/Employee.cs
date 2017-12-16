using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required,MaxLength(30)]
        public string EmployeeName { get; set; }
        [Required, MaxLength(50)]
        [RegularExpression(@"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$", ErrorMessage = "*Invalid Email")]
        public string EmployeeEmail { get; set; }

        [Required, MaxLength(20), MinLength(6)]
        public string EmployeePassword { get; set; }
        [Required, Range(10000, 300000)]
        public int Salary { get; set; }
        public int MGR { get; set; }

        public DateTime DateofBirth { get; set; }

    }
}
