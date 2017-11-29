using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeSalary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int BasicSalary { get; set; }
        public int TotalSalary { get; set; }
        public string SalaryMonth { get; set; }
        public int Year { get; set; }
        public int status { get; set; }
        public int BonusId { get; set; }
        public int BonusValue { get; set; }

    }
}
