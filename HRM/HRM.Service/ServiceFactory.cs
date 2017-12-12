using HRM.Entity;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Service
{
    public class ServiceFactory
    {
        private readonly IDictionary<Type, Type> Repositories = new Dictionary<Type, Type>();

        public ServiceFactory()
        {
            Repositories.Add(typeof(AdvertiserList), typeof(AdvertiserListService));
            Repositories.Add(typeof(Attendance), typeof(AttendanceService));
            Repositories.Add(typeof(Bonuses), typeof(BonusesService));
            Repositories.Add(typeof(Bonus), typeof(BonusService));
            Repositories.Add(typeof(CircularTemplate), typeof(CircularTemplateService));
            Repositories.Add(typeof(Comment), typeof(CommentService));
            Repositories.Add(typeof(DepartmentHistory), typeof(DepartmentHistoryService));
            Repositories.Add(typeof(Department), typeof(DepartmentService));
            Repositories.Add(typeof(DepartmentDesignation), typeof(DepartmentDesignationService));
            Repositories.Add(typeof(Designation), typeof(DesignationService));
            Repositories.Add(typeof(EmployeeBio), typeof(EmployeeBioService));
            Repositories.Add(typeof(EmployeeHistory), typeof(EmployeeHistoryService));
            Repositories.Add(typeof(EmployeePerformanceMetric), typeof(EmployeePerformanceMetricService));
            Repositories.Add(typeof(Employee), typeof(EmployeeService));
            Repositories.Add(typeof(EmployeeSalary), typeof(EmployeeSalaryService));
            Repositories.Add(typeof(HireRequest), typeof(HireRequestService));
            Repositories.Add(typeof(HireThread), typeof(HireThreadService));
            Repositories.Add(typeof(Interviewee), typeof(IntervieweeService));
            Repositories.Add(typeof(Interview), typeof(InterviewService));
            Repositories.Add(typeof(LeaveApplication), typeof(LeaveApplicationService));
            Repositories.Add(typeof(NoticeEmployee), typeof(NoticeEmployeeService));
            Repositories.Add(typeof(Notice), typeof(NoticeService));
            Repositories.Add(typeof(Privilege), typeof(PrivilegeService));
            Repositories.Add(typeof(Project), typeof(ProjectService));
            Repositories.Add(typeof(SalaryComponents), typeof(SalaryComponentsService));
            Repositories.Add(typeof(SalgradeHistory), typeof(SalgradeHistoryService));
            Repositories.Add(typeof(Salgrade), typeof(SalgradeService));
            Repositories.Add(typeof(SupportingDocument), typeof(SupportingDocumentService));
            Repositories.Add(typeof(TemporaryCV), typeof(TemporaryCVService));
            Repositories.Add(typeof(Training), typeof(TrainingService));
        }

        public IDomainService<TEntity> Create<TEntity>() where TEntity : class
        {
            Type type = Repositories[typeof(TEntity)];
            return Activator.CreateInstance(type) as IDomainService<TEntity>;
        }
    }
}
