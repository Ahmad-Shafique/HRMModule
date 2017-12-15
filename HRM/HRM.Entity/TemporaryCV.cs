using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class TemporaryCV
    {
        [Key]
        public int TemporaryCVId { get; set; }
        public string CandidateName { get; set; }
        public string CVLink { get; set; }
        public int IntervieweeScore { get; set; }
        [Required]
        public int HireThreadId { get; set; }
    }
}
