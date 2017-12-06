using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
   public class Privilege
    {
       [Key]
        public int PrivilegeId { get; set; }
        public string PrivilegeName { get; set; }
    }
}
