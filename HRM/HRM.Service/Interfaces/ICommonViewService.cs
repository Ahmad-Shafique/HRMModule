using HRM.Entity;
using HRM.Entity.Accessory;
using HRM.Entity.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Service.Interfaces
{
    public interface ICommonViewService
    {
        LoginObject Authenticate(int id, string password);
        IEnumerable<TrainingAndRelatedEmployees> GetTrainingAndRelatedEmployees(int trainingId);
        IEnumerable<EmployeeAndRelatedTrainings> GetEmployeeAndRelatedTraining(int employeeId);
        IEnumerable<EmployeeAndBio> GetAllEmployeeDetails();
        bool AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString);
        bool AddTrainingsToEmployee(int employeeId, string trainingIdsString);
        bool ApproveHireRequests(string hireRequestIdsString);
        IEnumerable<EmployeePerformance> GetAllEmployeePerformance();
        bool AddDepartmentWideBonus(int departmentId, Bonuses bonus);
        bool AddBonusToEmployeeList(int departmentId, Bonuses bonus, string employeeIdsList);
        bool AssignBonusToEmployee(Bonuses bonus, int EmployeeId);
        bool AssignTransportsToAnArea(int transportAreaId, string transportIdsList);
        IEnumerable<TransportVehicle> GetAvailableTransport();
        bool AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList);
        bool AssignCandidatesToInterview(int interviewId, string candidateIdsList);
        IEnumerable<TemporaryCV> GetAllUnassignedTemporaryCVs();
        IEnumerable<EmployeeTotalSalary> CalculateAllEmployeeTotalSalary();
        dynamic Test();
        IEnumerable<EmployeePromotion> GetEmployeePromotionView();
    }
}
