using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity.Facade
{
    public class ProjectAndAllAssociatedEmployees
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public int DepartmentId { get; set; }
        public List<EmployeeIdAndName> ListOfEmployees { get; set; }
       

        public ProjectAndAllAssociatedEmployees()
        {
            ListOfEmployees = new List<EmployeeIdAndName>();
        }
    }
}
