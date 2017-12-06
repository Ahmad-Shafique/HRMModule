using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class ProjectEmployee
    {
        [Key]
        public int ProjectEmployeeId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
