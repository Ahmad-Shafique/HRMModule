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
    }
}
