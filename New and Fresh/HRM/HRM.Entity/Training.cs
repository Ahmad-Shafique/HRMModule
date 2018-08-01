using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Training
    {
        [Key]
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        [MaxLength(1024)]
        public string TrainingDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SuccessRate { get; set; }
    }
}
