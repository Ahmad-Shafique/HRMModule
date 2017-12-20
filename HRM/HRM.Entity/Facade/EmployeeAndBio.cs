using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.Facade
{
    public class EmployeeAndBio
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public int MGR { get; set; }

        public string EmployeeContactNo { get; set; }
        public string EmployeeAddress { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string Intro { get; set; }
        public string Objectives { get; set; }
        public string Hobbies { get; set; }
        public string Interests { get; set; }
        public string Certificates { get; set; }
        public string JobExperience { get; set; }
        public string Education { get; set; }
        public string Image { get; set; }
    }
}
