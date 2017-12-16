using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Entity;
using HRM.Data.Interfaces;
using HRM.Data;

namespace HRM.Service
{
    
    class CommonViewService : ICommonViewServiceInterface
    {
        protected internal ICommonViewRepository repository;

        public CommonViewService()
        {
            repository = RepositoryFactory.GetCommonViewRepository();
        }


        public Task<bool> AddBonusToEmployeeList(int departmentId, Bonuses bonus, string employeeIdsList)
        {
            return repository.AddBonusToEmployeeList(departmentId,bonus,employeeIdsList);
        }

        public Task<bool> AddDepartmentWideBonus(int departmentId, Bonuses bonus)
        {
            return repository.AddDepartmentWideBonus(departmentId, bonus);
        }

        public Task<bool> AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString)
        {
            return repository.AddEmployeesToTrainingProgram(trainingId, employeeIdsString);
        }

        public Task<bool> AddTrainingsToEmployee(int employeeId, string trainingIdsString)
        {
            return repository.AddTrainingsToEmployee(employeeId, trainingIdsString);
        }

        public Task<bool> ApproveHireRequests(string hireRequestIdsString)
        {
            return repository.ApproveHireRequests(hireRequestIdsString);
        }

        public Task<bool> AssignCandidatesToInterview(int interviewId, string candidateIdsList)
        {
            return repository.AssignCandidatesToInterview(interviewId, candidateIdsList);
        }

        public Task<bool> AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList)
        {
            return repository.AssignEquipmentsToADepartment(departmentId, equipmentIdsList);
        }

        public Task<bool> AssignTransportsToAnArea(int transportAreaId, string transportIdsList)
        {
            return repository.AssignTransportsToAnArea(transportAreaId, transportIdsList);
        }

        public dynamic CalculateAllEmployeeTotalSalary()
        {
            return repository.CalculateAllEmployeeTotalSalary();
        }

        public dynamic GetAllEmployeeDetails()
        {
            return repository.GetAllEmployeeDetails();
        }

        public dynamic GetAllEmployeePerformance()
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

        public dynamic GetEmployeeAndRelatedTraining(int employeeId)
        {
            return repository.GetEmployeeAndRelatedTraining(employeeId);
        }

        public dynamic GetTrainingAndRelatedEmployees(int trainingId)
        {
            return repository.GetTrainingAndRelatedEmployees(trainingId);
        }
    }
}
