using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class SalaryComponents
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; }
        public int ComponentValue { get; set; }
        public string Type { get; set; }
    }
}
