using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Data.Interfaces;
using HRM.Entity;

namespace HRM.Data
{
    public class RepositoryFactory
    {
        private readonly IDictionary<Type, Type> Repositories = new Dictionary<Type, Type>();

        public RepositoryFactory()
        {
            Repositories.Add(typeof(AdvertiserList), typeof(AdvertiserListRepository));
            Repositories.Add(typeof(Attendance), typeof(AttendanceRepository));
            Repositories.Add(typeof(Bonuses), typeof(BonusesRepository));
            Repositories.Add(typeof(Bonus), typeof(BonusRepository));
            Repositories.Add(typeof(CircularTemplate), typeof(CircularTemplateRepository));
            Repositories.Add(typeof(DepartmentHistory), typeof(DepartmentHistoryRepository));
            Repositories.Add(typeof(Department), typeof(DepartmentRepository));
            Repositories.Add(typeof(DepartmentDesignation), typeof(DepartmentDesignationRepository));
            Repositories.Add(typeof(Designation), typeof(DesignationRepository));
            Repositories.Add(typeof(EmployeeBio), typeof(EmployeeBioRepository));
            Repositories.Add(typeof(EmployeeHistory), typeof(EmployeeHistoryRepository));
            Repositories.Add(typeof(EmployeePerformanceMetric), typeof(EmployeePerformanceMetricRepository));
            Repositories.Add(typeof(Employee), typeof(EmployeeRepository));
            Repositories.Add(typeof(EmployeeDepartment), typeof(EmployeeDepartmentRepository));
            Repositories.Add(typeof(EmployeeAttendance), typeof(EmployeeAttendanceRepository));
            Repositories.Add(typeof(EmployeeSalary), typeof(EmployeeSalaryRepository));
            Repositories.Add(typeof(HireRequest), typeof(HireRequestRepository));
            Repositories.Add(typeof(HireThread), typeof(HireThreadRepository));
            Repositories.Add(typeof(Interviewee), typeof(IntervieweeRepository));
            Repositories.Add(typeof(Interview), typeof(InterviewRepository));
            Repositories.Add(typeof(LeaveApplication), typeof(LeaveApplicationRepository));
            //Repositories.Add(typeof(NoticeEmployee), typeof(NoticeEmployeeRepository));
            Repositories.Add(typeof(Notice), typeof(NoticeRepository));
            Repositories.Add(typeof(Privilege), typeof(PrivilegeRepository));
            Repositories.Add(typeof(Project), typeof(ProjectRepository));
            Repositories.Add(typeof(SalaryComponents), typeof(SalaryComponentsRepository));
            Repositories.Add(typeof(SalgradeHistory), typeof(SalgradeHistoryRepository));
            Repositories.Add(typeof(Salgrade), typeof(SalgradeRepository));
            Repositories.Add(typeof(SupportingDocument), typeof(SupportingDocumentRepository));
            Repositories.Add(typeof(TemporaryCV), typeof(TemporaryCVRepository));
            Repositories.Add(typeof(Training), typeof(TrainingRepository));
            Repositories.Add(typeof(Equipment), typeof(Equipment));
            Repositories.Add(typeof(TransportArea), typeof(TransportAreaRepository));
            Repositories.Add(typeof(NoticeComment), typeof(NoticeCommentRepository));
            Repositories.Add(typeof(TrainingEmployee), typeof(TrainingEmployeeRepository));


        }

        public IRepository<TEntity> Create<TEntity>() where TEntity : class
        {
            Type type = Repositories[typeof(TEntity)];
            return Activator.CreateInstance(type) as IRepository<TEntity>;
        }

    }
}
