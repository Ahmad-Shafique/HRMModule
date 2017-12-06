using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class DepartmentDesignation
    {
        [Key]
        public int DepartmentDesignationId { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int DesignationId { get; set; }
    }
}
