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
    }
}
