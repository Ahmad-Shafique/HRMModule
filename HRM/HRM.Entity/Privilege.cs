using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
   public class Privilege
    {
        public int PrivilegeId { get; set; }
        public string PrivilegeName { get; set; }
        public List<Employee> Employees { get; set; }

        public Privilege()
        {
            Employees = new List<Employee>();
        }
      
    }
}
