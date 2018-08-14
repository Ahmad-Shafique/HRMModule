using HRM.DataAccessController.Interfaces;
using HRM.Entity;
using HRM.Entity.Accessory;
using HRM.Entity.Facade;
using HRM.Facade;
using HRM.Facade.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    class BaseCommonViewAccess : IBaseCommonViewAccess
    {
        
        protected internal ICommonView repository;

        protected internal BaseCommonViewAccess()
        {
            repository = FacadeFactory.GetCommonView();
        }

        public virtual LoginObject Authenticate(int id, string password)
        {
            return repository.Authenticate(id, password);
        }


        public virtual bool AddBonusToEmployeeList(int departmentId, Bonuses bonus, string employeeIdsList)
        {
            return repository.AddBonusToEmployeeList(departmentId, bonus, employeeIdsList);
        }

        public virtual bool AssignBonusToEmployee(Bonuses bonus, int EmployeeId)
        {
            return repository.AssignBonusToEmployee(bonus, EmployeeId);
        }

        public virtual bool AddDepartmentWideBonus(int departmentId, Bonuses bonus)
        {
            return repository.AddDepartmentWideBonus(departmentId, bonus);
        }

        public virtual bool AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString)
        {
            return repository.AddEmployeesToTrainingProgram(trainingId, employeeIdsString);
        }

        public virtual bool AddTrainingsToEmployee(int employeeId, string trainingIdsString)
        {
            return repository.AddTrainingsToEmployee(employeeId, trainingIdsString);
        }

        public virtual bool ApproveHireRequests(string hireRequestIdsString)
        {
            return repository.ApproveHireRequests(hireRequestIdsString);
        }

        public virtual bool AssignCandidatesToInterview(int interviewId, string candidateIdsList)
        {
            return repository.AssignCandidatesToInterview(interviewId, candidateIdsList);
        }

        public virtual bool AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList)
        {
            return repository.AssignEquipmentsToADepartment(departmentId, equipmentIdsList);
        }

        public virtual bool AssignTransportsToAnArea(int transportAreaId, string transportIdsList)
        {
            return repository.AssignTransportsToAnArea(transportAreaId, transportIdsList);
        }



        public virtual IEnumerable<EmployeeAndBio> GetAllEmployeeDetails()
        {
            return repository.GetAllEmployeeDetails();
        }

        public virtual IEnumerable<EmployeePerformance> GetAllEmployeePerformance()
        {
            return repository.GetAllEmployeePerformance();
        }

        public virtual IEnumerable<TemporaryCV> GetAllUnassignedTemporaryCVs()
        {
            return repository.GetAllUnassignedTemporaryCVs();
        }

        public virtual IEnumerable<TransportVehicle> GetAvailableTransport()
        {
            return repository.GetAvailableTransport();
        }

        public virtual IEnumerable<EmployeeAndRelatedTrainings> GetEmployeeAndRelatedTraining(int employeeId)
        {
            return repository.GetEmployeeAndRelatedTraining(employeeId);
        }

        public virtual IEnumerable<TrainingAndRelatedEmployees> GetTrainingAndRelatedEmployees(int trainingId)
        {
            return repository.GetTrainingAndRelatedEmployees(trainingId);
        }

        public virtual dynamic Test()
        {
            return repository.Test();
        }


        public virtual IEnumerable<EmployeeTotalSalary> CalculateAllEmployeeTotalSalary()
        {
            return repository.CalculateAllEmployeeTotalSalary();
        }

        public virtual IEnumerable<EmployeePromotion> GetEmployeePromotionView()
        {
            return repository.GetEmployeePromotionView();
        }

        public List<ProjectAndAllAssociatedEmployees> GetListOfAllProjectsAndTheirAssociatedEmployee()
        {
            return repository.GetListOfAllProjectsAndTheirAssociatedEmployee();
        }
    }
}
