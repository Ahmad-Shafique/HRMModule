using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName {get;set;}
        public string DepartmentLocation { get; set; }
        public string DepartmentDescription { get; set; }
        public int DepartmentHeadId { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Designation> Designations { get; set; }
        public List<HireRequest> HireRequests { get; set; }
        public List<DepartmentHistory> DepartmentHistory { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
            Designations = new List<Designation>();
            HireRequests = new List<HireRequest>();
            DepartmentHistory = new List<DepartmentHistory>();
        }



    }
}
