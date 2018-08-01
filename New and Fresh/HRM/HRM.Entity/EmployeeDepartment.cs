using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeDepartment
    {
        [Key]
        public int EmployeeDepartmentId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
