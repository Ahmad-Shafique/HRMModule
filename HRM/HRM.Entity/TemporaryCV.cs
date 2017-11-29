using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class TemporaryCV
    {
        public int TemporaryCVId { get; set; }
        public string CVLink { get; set; }
        public int IntervieweeScore { get; set; }
        public int HireThreadId { get; set; }
        public HireThread HireThread { get; set; }
    }
}
