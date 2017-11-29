using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class ProjectEmployee
    {
        public int ProjectEmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
    }
}
