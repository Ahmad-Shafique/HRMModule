using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeDepartment
    {
        public int EmployeeDepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
    }
}
