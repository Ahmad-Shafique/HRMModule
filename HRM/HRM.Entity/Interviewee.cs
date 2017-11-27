using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
   public  class Interviewee
    {
       public int IntervieweeId { get; set; }
       public int InterviewId { get; set; }
       public Interview Interview { get; set; }
       public int TemporaryCVId { get; set; }
       public TemporaryCV TemporaryCV { get; set; }
    }
}
