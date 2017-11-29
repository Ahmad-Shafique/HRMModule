using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class HireThread
    {
        public int HireThreadId { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int HireThreadStatus { get; set; }
        public int HireRequestId { get; set; }
    }
}
