using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
   public  class Interviewee
    {
       [Key]
       public int IntervieweeId { get; set; }
       public int InterviewId { get; set; }
       public int TemporaryCVId { get; set; }
    }
}
