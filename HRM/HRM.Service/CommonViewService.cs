using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Entity;
using HRM.Data.Interfaces;
using HRM.Data;
using HRM.Facade.Interfaces;
using HRM.Facade;
using HRM.Entity.Facade;

namespace HRM.Service
{
    
    class CommonViewService : ICommonViewService
    {
        protected internal ICommonView repository;

        public CommonViewService()
        {
            repository = FacadeFactory.GetCommonView();
        }


        public bool AddBonusToEmployeeList(int departmentId, Bonuses bonus, string employeeIdsList)
        {
            return repository.AddBonusToEmployeeList(departmentId,bonus,employeeIdsList);
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

        public dynamic Test()
        {
            return repository.Test();
        }


        public  IEnumerable<EmployeeTotalSalary> CalculateAllEmployeeTotalSalary()
        {
            return  repository.CalculateAllEmployeeTotalSalary();
        }
    }
}
