using HRM.Entity;
using HRM.Entity.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DataAccessController
{
    class NoCommonViewAccess : BaseCommonViewAccess
    {
        public override bool AddBonusToEmployeeList(int departmentId, Bonuses bonus, string employeeIdsList)
        {
            return true;
        }

        public override bool AssignBonusToEmployee(Bonuses bonus, int EmployeeId)
        {
            return true;
        }

        public override bool AddDepartmentWideBonus(int departmentId, Bonuses bonus)
        {
            return true;
        }

        public override bool AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString)
        {
            return true;
        }

        public override bool AddTrainingsToEmployee(int employeeId, string trainingIdsString)
        {
            return true;
        }

        public override bool ApproveHireRequests(string hireRequestIdsString)
        {
            return true;
        }

        public override bool AssignCandidatesToInterview(int interviewId, string candidateIdsList)
        {
            return true;
        }

        public override bool AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList)
        {
            return true;
        }

        public override bool AssignTransportsToAnArea(int transportAreaId, string transportIdsList)
        {
            return true;
        }



        public override IEnumerable<EmployeeAndBio> GetAllEmployeeDetails()
        {
            return new List<EmployeeAndBio>();
        }

        public override IEnumerable<EmployeePerformance> GetAllEmployeePerformance()
        {
            return new List<EmployeePerformance>();
        }

        public override IEnumerable<TemporaryCV> GetAllUnassignedTemporaryCVs()
        {
            return new List<TemporaryCV>();
        }

        public override IEnumerable<TransportVehicle> GetAvailableTransport()
        {
            return new List<TransportVehicle>();
        }

        public override IEnumerable<EmployeeAndRelatedTrainings> GetEmployeeAndRelatedTraining(int employeeId)
        {
            return new List<EmployeeAndRelatedTrainings>();
        }

        public override IEnumerable<TrainingAndRelatedEmployees> GetTrainingAndRelatedEmployees(int trainingId)
        {
            return new List<TrainingAndRelatedEmployees>();
        }

        public override dynamic Test()
        {
            return repository.Test();
        }


        public override IEnumerable<EmployeeTotalSalary> CalculateAllEmployeeTotalSalary()
        {
            return new List<EmployeeTotalSalary>();
        }

        public override IEnumerable<EmployeePromotion> GetEmployeePromotionView()
        {
            return new List<EmployeePromotion>();
        }
    }
}
