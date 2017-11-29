using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeDesignation
    {
        public int EmployeeDesignationId { get; set; }
        public int EmployeeId { get; set; }
        public int DesignationId { get; set; }
    }
}
