using HRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Interfaces
{
    public interface ICommonViewRepository
    {
        dynamic GetTrainingAndRelatedEmployees(int trainingId);
        dynamic GetEmployeeAndRelatedTraining(int employeeId);
        dynamic GetAllEmployeeDetails();
        Task<bool> AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString);
        Task<bool> AddTrainingsToEmployee(int employeeId, string trainingIdsString);
        Task<bool> ApproveHireRequests(string hireRequestIdsString);
        dynamic GetAllEmployeePerformance();
        Task<bool> AddDepartmentWideBonus(int departmentId, Bonuses bonus);
        Task<bool> AddBonusToEmployeeList(int departmentId, Bonuses bonus, string employeeIdsList);
        Task<bool> AssignTransportsToAnArea(int transportAreaId, string transportIdsList);
        IEnumerable<TransportVehicle> GetAvailableTransport();
        Task<bool> AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList);
        Task<bool> AssignCandidatesToInterview(int interviewId, string candidateIdsList);
        IEnumerable<TemporaryCV> GetAllUnassignedTemporaryCVs();
    }
}
