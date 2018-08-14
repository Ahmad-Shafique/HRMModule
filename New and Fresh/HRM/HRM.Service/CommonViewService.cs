using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Entity;
using HRM.Facade.Interfaces;
using HRM.Facade;
using HRM.Entity.Facade;
using HRM.DataAccessController.Interfaces;
using HRM.DataAccessController;
using HRM.Entity.Accessory;

namespace HRM.Service
{
    
    class CommonViewService : ICommonViewService
    {
        protected internal IBaseCommonViewAccess repository;

        public CommonViewService()
        {
            repository = UserSelector<Employee>.GetCommonViewAccess(ServiceFactory.token);
        }

        public LoginObject Authenticate(int id, string password)
        {
            return repository.Authenticate(id, password);
        }


        public bool AddBonusToEmployeeList(int departmentId, Bonuses bonus, string employeeIdsList)
        {
            return repository.AddBonusToEmployeeList(departmentId,bonus,employeeIdsList);
        }

        public bool AssignBonusToEmployee(Bonuses bonus, int EmployeeId)
        {
            return repository.AssignBonusToEmployee(bonus, EmployeeId);
        }

        public bool AddDepartmentWideBonus(int departmentId, Bonuses bonus)
        {
            return repository.AddDepartmentWideBonus(departmentId, bonus);
        }

        public bool AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString)
        {
            return repository.AddEmployeesToTrainingProgram(trainingId, employeeIdsString);
        }

        public bool AddTrainingsToEmployee(int employeeId, string trainingIdsString)
        {
            return repository.AddTrainingsToEmployee(employeeId, trainingIdsString);
        }

        public bool ApproveHireRequests(string hireRequestIdsString)
        {
            return repository.ApproveHireRequests(hireRequestIdsString);
        }

        public bool AssignCandidatesToInterview(int interviewId, string candidateIdsList)
        {
            return repository.AssignCandidatesToInterview(interviewId, candidateIdsList);
        }

        public bool AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList)
        {
            return repository.AssignEquipmentsToADepartment(departmentId, equipmentIdsList);
        }

        public bool AssignTransportsToAnArea(int transportAreaId, string transportIdsList)
        {
            return repository.AssignTransportsToAnArea(transportAreaId, transportIdsList);
        }

        

        public IEnumerable<EmployeeAndBio> GetAllEmployeeDetails()
        {
            return repository.GetAllEmployeeDetails();
        }

        public IEnumerable<EmployeePerformance> GetAllEmployeePerformance()
        {
            return repository.GetAllEmployeePerformance();
        }

        public IEnumerable<TemporaryCV> GetAllUnassignedTemporaryCVs()
        {
            return repository.GetAllUnassignedTemporaryCVs();
        }

        public IEnumerable<TransportVehicle> GetAvailableTransport()
        {
            return repository.GetAvailableTransport();
        }

        public IEnumerable<EmployeeAndRelatedTrainings> GetEmployeeAndRelatedTraining(int employeeId)
        {
            return repository.GetEmployeeAndRelatedTraining(employeeId);
        }

        public IEnumerable<TrainingAndRelatedEmployees> GetTrainingAndRelatedEmployees(int trainingId)
        {
            return repository.GetTrainingAndRelatedEmployees(trainingId);
        }

        public dynamic Test()
        {
            return repository.Test();
        }


        public  IEnumerable<EmployeeTotalSalary> CalculateAllEmployeeTotalSalary()
        {
            return  repository.CalculateAllEmployeeTotalSalary();
        }

        public IEnumerable<EmployeePromotion> GetEmployeePromotionView()
        {
            return repository.GetEmployeePromotionView();
        }

        public List<ProjectAndAllAssociatedEmployees> GetListOfAllProjectsAndTheirAssociatedEmployee()
        {
            return repository.GetListOfAllProjectsAndTheirAssociatedEmployee();
        }

    }
}
