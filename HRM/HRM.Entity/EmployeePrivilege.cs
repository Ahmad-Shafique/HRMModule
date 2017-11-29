using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeePrivilege
    {
        public int EmployeePrivilegeId { get; set; }
        public int EmployeeId { get; set; }
        public int PrivilegeId { get; set; }
    }
}
