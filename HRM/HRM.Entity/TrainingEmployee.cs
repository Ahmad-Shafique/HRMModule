using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class TrainingEmployee
    {
        [Key]
        public int TrainingEmployeeId { get; set; }
        [Required]
        public int TrainingId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
