using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Employee_EmployeeSalary
    {
        [Key]
        public int Employee_EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeSalaryId { get; set; }
        public string SalaryMonth { get; set; }
        public int Year { get; set; }
    }
}
