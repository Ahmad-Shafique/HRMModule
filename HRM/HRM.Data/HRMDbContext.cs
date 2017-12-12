using HRM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data
{
    public class HRMDbContext : DbContext
    {
        private static HRMDbContext instance;



        public DbSet<AdvertiserList> AdvertiserLists { get; set; }
     	public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Bonuses> LBonuses { get; set; }
        public DbSet<CircularTemplate> CircularTemplates { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<NoticeEmployee> NoticeEmployees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentDesignation> DepartmentDesignations { get; set; }
        public DbSet<DepartmentHistory> DepartmentHistories { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        public DbSet<EmployeeBio> EmployeeBios { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EmployeeDesignation> EmployeeDesignations { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistories { get; set; }
        public DbSet<EmployeePerformanceMetric> EmployeePerformanceMetrics { get;set;}
        public DbSet<EmployeePrivilege> EmployeePrivileges { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<HireRequest> HireRequests { get; set; }
        public DbSet<HireThread> HireThreads { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Interviewee> Interviewees{ get; set;}
        public DbSet<LeaveApplication> LeaveApplications { get;set;}
        public DbSet<LeaveApplicationCategory> LeaveApplicationCategories { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<SalaryComponents> SalaryComponents { get; set; }
        public DbSet<Salgrade> Salgrades { get; set; }
        public DbSet<SalgradeHistory> SalgradeHistories{ get; set; }
        public DbSet<SupportingDocument> SupportingDocuments { get; set; }
        public DbSet<TemporaryCV> TemporaryCVs { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingEmployee> TrainingEmployees { get; set; }

        

        public static HRMDbContext GetInstance()
        {
            if(instance == null)
            {
                instance = new HRMDbContext();

            }
            return instance;
        }

        public HRMDbContext()
        {
            //var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            //Database.SetInitializer(new DropCreateDatabaseAlways<HRMDbContext>());
        }



    }
}
