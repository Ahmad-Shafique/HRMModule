using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public int Salary { get; set; }
        public int MGR { get; set; }
        public string DepartmentId { get; set; }
        public int EmployeeBioId { get; set; }

        public EmployeeBio EmployeeBio { get; set; }
        public List<Designation> Designations { get; set; }
        public List<Department> Departments { get; set; }
        public List<LeaveApplication> LeaveApplications { get;set; }

        public List<Privilege> Previleges { get;set; }
        public List<Notice> Notices { get; set; }
        public List<Project> Projects { get; set; }
        public List<Training> Trainings { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<EmployeeHistory> EmployeeHistory { get; set; }
        public List<EmployeePerformenceMetric> PerformenceHisory { get; set; }
        public Employee()
        {
            Departments = new List<Department>();
            Designations = new List<Designation>();
            Previleges = new List<Privilege>();
            LeaveApplications = new List<LeaveApplication>();
            Notices = new List<Notice>();
            Projects = new List<Project>();
            Trainings = new List<Training>();
            Attendances = new List<Attendance>();
            EmployeeHistory = new List<EmployeeHistory>();
            PerformenceHisory = new List<EmployeePerformenceMetric>();
        }
    }
}
