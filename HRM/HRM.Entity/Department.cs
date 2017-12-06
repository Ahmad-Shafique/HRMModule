using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Department
    {
     
        [Key]
        public int DepartmentId { get; set; }
        [Required,MaxLength(30)]
        public string DepartmentName {get;set;}
        [Required,MaxLength(30)]
        public string DepartmentLocation { get; set; }

        public string DepartmentDescription { get; set; }
        [Required]
        public int DepartmentHeadId { get; set; }
    }
}
