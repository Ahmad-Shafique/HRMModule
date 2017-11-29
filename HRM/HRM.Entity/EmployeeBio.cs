using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeBio
    {
        public int EmployeeBioId { get; set; }
        public string EmployeeContactNo { get; set; }
        public string EmployeeAddress { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string Into { get; set; }
        public string Objectives { get; set; }
        public string Hobbies { get; set; }
        public string Interests { get; set; }
        public string Certificates { get; set; }
        public string JobExperience { get; set; }
        public string Eduction { get; set; }
        public int EmployeeId { get; set; }
    }
}
