using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Salgrade
    {
        public int SalgradeId { get; set; }
        public string GradeName { get; set; }
        public int LowSalary { get; set; }
        public int HighSalary { get; set; }

    }
}
