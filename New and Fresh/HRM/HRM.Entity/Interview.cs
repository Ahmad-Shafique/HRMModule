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
        public DateTime Schedule { get; set; }
        public int HireThreadId { get; set; }
        public int NumberOfCandidatesAssigned { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
