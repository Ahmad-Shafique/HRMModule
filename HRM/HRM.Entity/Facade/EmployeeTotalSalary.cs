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
        public int TotalSalary { get; set; }
        public int BonusSalary { get; set; }
    }
}
