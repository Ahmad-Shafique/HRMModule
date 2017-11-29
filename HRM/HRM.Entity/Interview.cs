using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Interview
    {
        public int InterviewId {get;set;}
        public string Schedule { get; set; }
        public int HireThreadId { get; set; }
    }
}
