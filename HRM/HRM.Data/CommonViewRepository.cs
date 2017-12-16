using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Entity;
using HRM.Data;
using HRM.Data.Interfaces;

namespace HRM.Data
{
    public class CommonViewRepository
    {
        dynamic GetTrainingAndRelatedEmployees(int trainingId)
        {
            IEnumerable<Training> trainingList = new TrainingRepository().GetAll().Result;
            IEnumerable<Employee> employeeList = new EmployeeRepository().GetAll().Result;
            IEnumerable<TrainingEmployee> trainingEmployeeList = new TrainingEmployeeRepository().GetAll().Result;

            try
            {
                var result = from training in trainingList
                             join combo in trainingEmployeeList on training.TrainingId equals combo.TrainingId
                             join employee in employeeList on combo.EmployeeId equals employee.EmployeeId
                             select new
                             {
                                 TrainingId = training.TrainingId,
                                 TrainingName = training.TrainingName,
                                 EmployeeName = employee.EmployeeName
                             };
                return result.Where(item =>
                                        item.TrainingId == trainingId);


            }
            catch (Exception e)
            {
                Console.WriteLine("Error in combining training and employee : " + e);
                return new List<dynamic>();
            }
        }


        dynamic GetEmployeeAndRelatedTraining(int employeeId)
        {
            IEnumerable<Training> trainingList = new TrainingRepository().GetAll().Result;
            IEnumerable<Employee> employeeList = new EmployeeRepository().GetAll().Result;
            IEnumerable<TrainingEmployee> trainingEmployeeList = new TrainingEmployeeRepository().GetAll().Result;

            try
            {
                var result = from emp in  employeeList
                             join combo in trainingEmployeeList on emp.EmployeeId equals combo.EmployeeId
                             join train in trainingList on combo.TrainingId equals train.TrainingId
                             select new
                             {
                                 EmployeeId = emp.EmployeeId,
                                 EmployeeName = emp.EmployeeName,
                                 TrainingName = train.TrainingName
                             };
                return result.Where(item =>
                                        item.EmployeeId == employeeId);


            }
            catch (Exception e)
            {
                Console.WriteLine("Error in combining training and employee : " + e);
                return new List<dynamic>();
            }
        }


        async Task<bool> AddEmployeesToTrainingProgram(int trainingId , List<int> employeeIdList)
        {
            try
            {
                TrainingEmployeeRepository comboRepo = new TrainingEmployeeRepository();
                foreach(int id in employeeIdList)
                {
                    TrainingEmployee item = new TrainingEmployee();
                    item.TrainingId = trainingId;
                    item.EmployeeId = id;

                    await comboRepo.Insert(item);
                }

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Encountered error while adding employees to training: " + e);
                return false;
            }
            
        }

        async Task<bool> AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString)
        {
            try
            {
                var tempIdList = employeeIdsString.Split(',');
                List<int> idList = new List<int>();
                foreach (string s in tempIdList)
                {
                    idList.Add(Int32.Parse(s));
                }
                return await AddEmployeesToTrainingProgram(trainingId, idList);

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }



    }
}
