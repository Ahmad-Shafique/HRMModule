using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeBio
    {
        [Key]
        public int EmployeeBioId { get; set; }
        [Required, MaxLength(11), MinLength(11), RegularExpression("^[0-9]*$", ErrorMessage = "*cell no contains only digits")]
        public string EmployeeContactNo { get; set; }
        [Required]
        public string EmployeeAddress { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public string Intro { get; set; }
        public string Objectives { get; set; }
        public string Hobbies { get; set; }
        public string Interests { get; set; }
        public string Certificates { get; set; }
        public string JobExperience { get; set; }
        public string Eduction { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public string Image { get; set; }
    }
}
