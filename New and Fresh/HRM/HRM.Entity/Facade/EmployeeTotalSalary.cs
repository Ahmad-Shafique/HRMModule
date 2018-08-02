using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.Facade
{
    public class EmployeeTotalSalary
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SalaryRank { get; set; }
        public int BasicSalary { get; set; }
        public int[] SalaryComponents { get; set; }
        public int BonusSalary { get; set; }
        public int TotalSalary { get; set; }
        public int EmployeeSalaryId { get; set; }
        public bool Paid { get; set; }
    }
}
