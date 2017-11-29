using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class DepartmentDesignation
    {
        public int DepartmentDesignationId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
    }
}
