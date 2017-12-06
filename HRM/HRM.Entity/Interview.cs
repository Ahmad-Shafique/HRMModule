using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Interview
    {
        [Key]
        public int InterviewId {get;set;}
        public string Schedule { get; set; }
        public int HireThreadId { get; set; }
    }
}
