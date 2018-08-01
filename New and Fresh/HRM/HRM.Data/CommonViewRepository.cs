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
    class CommonViewRepository: ICommonViewRepository
    {
        public virtual dynamic GetTrainingAndRelatedEmployees(int trainingId)
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


        public virtual dynamic GetEmployeeAndRelatedTraining(int employeeId)
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


        public virtual async Task<bool> AddEmployeesToTrainingProgram(int trainingId , List<int> employeeIdList)
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

        public virtual async Task<bool> AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString)
        {
            try
            {
                var tempIdList = employeeIdsString.Trim().Split(',');
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


        public virtual async Task<bool> AddTrainingsToEmployee(int employeeId, List<int> trainingList)
        {
            try
            {
                TrainingEmployeeRepository comboRepo = new TrainingEmployeeRepository();
                foreach (int id in trainingList)
                {
                    TrainingEmployee item = new TrainingEmployee();
                    item.EmployeeId = employeeId;
                    item.TrainingId = id;

                    await comboRepo.Insert(item);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Encountered error while adding employees to training: " + e);
                return false;
            }

        }

        public virtual async Task<bool> AddTrainingsToEmployee(int employeeId, string trainingIdsString)
        {
            try
            {
                var tempIdList = trainingIdsString.Trim().Split(',');
                List<int> idList = new List<int>();
                foreach (string s in tempIdList)
                {
                    if(s.Trim() != "" && s!=null  )
                    idList.Add(Int32.Parse(s));
                }
                return await AddEmployeesToTrainingProgram(employeeId, idList);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public virtual dynamic GetAllEmployeeDetails()
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            EmployeeBioRepository empBioRepo = new EmployeeBioRepository();
            return from emp in empRepo.GetAll().Result
                   join empBio in empBioRepo.GetAll().Result on emp.EmployeeId equals empBio.EmployeeId
                   select new
                    {
                        EmployeeId = emp.EmployeeId,
                        EmployeeName = emp.EmployeeName,
                        EmployeeEmail = emp.EmployeeEmail,
                        EmployeePassword = emp.EmployeePassword,
                        Salary = emp.Salary,
                        MGR = emp.MGR,

                        EmployeeContactNo = empBio.EmployeeContactNo,
                        EmployeeAddress = empBio.EmployeeAddress,
                        DateofBirth = empBio.DateofBirth,
                        HireDate = empBio.HireDate,
                        Intro = empBio.Intro,
                        Objectives = empBio.Objectives,
                        Hobbies = empBio.Hobbies,
                        Interests = empBio.Interests,
                        Certificates = empBio.Certificates,
                        JobExperience = empBio.JobExperience,
                        Image  = empBio.Image
                    };
        }


        public virtual async Task<bool> ApproveHireRequests(string hireRequestIdsString)
        {
            try
            {
                var tempIdsList = hireRequestIdsString.Trim().Split(',');
                HireRequestRepository hireRepo = new HireRequestRepository();
                foreach(var item in tempIdsList)
                {
                    if(item.Trim() != null && item.Trim() != "")
                    {
                        int key = int.Parse(item);
                        HireRequest tempReq = await hireRepo.Get(key);
                        tempReq.HireRequestStatus = 1;
                        await hireRepo.Update(tempReq, key);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }


        public virtual dynamic GetAllEmployeePerformance()
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            EmployeePerformanceMetricRepository empBioRepo = new EmployeePerformanceMetricRepository();
            return from emp in empRepo.GetAll().Result
                   join empPerf in empBioRepo.GetAll().Result on emp.EmployeeId equals empPerf.EmployeeId
                   select new
                   {
                       EmployeeId = emp.EmployeeId,
                       EmployeeName = emp.EmployeeName,

                       ProjectScore = empPerf.AverageProjectScore,
                       TrainingScore = empPerf.AverageTrainingScore,
                       AttendanceScore = 100,
                       AggregateScore = (empPerf.AverageProjectScore + empPerf.AverageTrainingScore + 100) /3
                   };
        }


        public virtual async Task<bool> AddDepartmentWideBonus(int departmentId, Bonuses bonus)
        {
            
            try
            {
                EmployeeSalaryRepository empSalRepo = new EmployeeSalaryRepository();
                BonusRepository bonusRepo = new BonusRepository();
                BonusesRepository bonusesRepo = new BonusesRepository();

                var salaryBonus = from empSal in empSalRepo.GetAll().Result
                                  join bon in bonusRepo.GetAll().Result on empSal.BonusId equals bon.BonusId
                                  select new
                                  {
                                      BonusId = empSal.BonusId
                                  };

                foreach(var item in salaryBonus)
                {
                    Bonuses bonusesItem = new Bonuses();
                    bonusesItem.BonusId = item.BonusId;
                    bonusesItem.BonusValue = bonus.BonusValue;
                    bonusesItem.BonusDescription = bonus.BonusDescription;
                    bonusesItem.BonusesDate = bonus.BonusesDate;
                    await bonusesRepo.Insert(bonusesItem);

                    Bonus tempBonus = bonusRepo.Get(item.BonusId).Result;
                    tempBonus.BonusValue += bonus.BonusValue;
                    await bonusRepo.Update(tempBonus, item.BonusId);
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public virtual async Task<bool> AddBonusToEmployeeList (int departmentId, Bonuses bonus , string employeeIdsList)
        {

            try
            {
                EmployeeSalaryRepository empSalRepo = new EmployeeSalaryRepository();
                BonusRepository bonusRepo = new BonusRepository();
                BonusesRepository bonusesRepo = new BonusesRepository();

                var idList = employeeIdsList.Trim().Split(',');

                var salaryBonus = from empSal in empSalRepo.GetAll().Result
                                  join bon in bonusRepo.GetAll().Result on empSal.BonusId equals bon.BonusId
                                  select new
                                  {
                                      EmployeeId = empSal.EmployeeId,
                                      BonusId = empSal.BonusId
                                  };

                salaryBonus = salaryBonus.Where(item => idList.Contains(item.EmployeeId.ToString()));

                foreach (var item in salaryBonus)
                {
                    Bonuses bonusesItem = new Bonuses
                    {
                        BonusId = item.BonusId,
                        BonusValue = bonus.BonusValue,
                        BonusDescription = bonus.BonusDescription,
                        BonusesDate = bonus.BonusesDate
                    };
                    await bonusesRepo.Insert(bonusesItem);

                    Bonus tempBonus = bonusRepo.Get(item.BonusId).Result;
                    tempBonus.BonusValue += bonus.BonusValue;
                    await bonusRepo.Update(tempBonus, item.BonusId);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public virtual async Task<bool> AssignTransportsToAnArea(int transportAreaId, string transportIdsList)
        {
            try
            {
                TransportAreaVehicleRepository tAVRepo = new TransportAreaVehicleRepository();
                TransportVehicleRepository tVRepo = new TransportVehicleRepository();
                TransportAreaRepository TARepo = new TransportAreaRepository();
                var idList = transportIdsList.Trim().Split(',');
                int newCapacity = 0;
                foreach(var tempId in idList)
                {
                    if(tempId != null && tempId.Trim() != "")
                    {
                        int id = Int32.Parse(tempId);

                        await tAVRepo.Insert(new TransportAreaVehicle
                        {
                            TransportAreaId = transportAreaId,
                            TransportVehicleId = id
                        });

                        TransportVehicle temp = tVRepo.Get(id).Result;
                        temp.status = "assigned";
                        await tVRepo.Update(temp, id);
                        newCapacity += temp.Capacity;
                    }
                }

                TransportArea tempArea = TARepo.Get(transportAreaId).Result;
                tempArea.AssignedCapacity += newCapacity;
                await TARepo.Update(tempArea, tempArea.TransportAreaId);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public virtual IEnumerable<TransportVehicle> GetAvailableTransport()
        {
            return new TransportVehicleRepository().GetAll().Result.Where(item => (item.status == "free" || item.status == "available" || item.status == null || item.status.Trim() == ""));
        }


        public virtual async Task<bool> AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList)
        {
            EquipmentRepository eRepo = new EquipmentRepository();
            EquipmentAndDepartmentRepository eDRepo = new EquipmentAndDepartmentRepository();
            try
            {
                
                var idList = equipmentIdsList.Trim().Split(',');
                foreach (var tempId in idList)
                {
                    if (tempId != null && tempId.Trim() != "")
                    {
                        int id = Int32.Parse(tempId);

                        await eDRepo.Insert(new EquipmentAndDepartment
                        {
                            DepartmentId = departmentId,
                            EquipmentId = id
                        });

                        Equipment temp = eRepo.Get(id).Result;
                        temp.Status = "assigned";
                        await eRepo.Update(temp, id);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public virtual async Task<bool> AssignCandidatesToInterview(int interviewId, string candidateIdsList)
        {

            try
            {
                InterviewRepository iRepo = new InterviewRepository();
                IntervieweeRepository iCRepo = new IntervieweeRepository();
                TemporaryCVRepository tCVRepo = new TemporaryCVRepository();
                var idList = candidateIdsList.Trim().Split(',');
                int newCapacity = 0;
                foreach (var tempId in idList)
                {
                    if (tempId != null && tempId.Trim() != "")
                    {
                        int id = Int32.Parse(tempId);

                        await iCRepo.Insert(new Interviewee
                        {
                            InterviewId = interviewId,
                            IntervieweeId = id
                        });

                        TemporaryCV temp = tCVRepo.Get(id).Result;
                        temp.Status = "assigned";
                        await tCVRepo.Update(temp, id);
                        newCapacity += 1;
                    }
                }

                Interview tempInter = iRepo.Get(interviewId).Result;
                tempInter.NumberOfCandidatesAssigned += newCapacity;
                await iRepo.Update(tempInter, tempInter.InterviewId);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public virtual IEnumerable<TemporaryCV> GetAllUnassignedTemporaryCVs()
        {
            return new TemporaryCVRepository().GetAll().Result.Where(item => (item.Status == "free" || item.Status == "available" || item.Status == null || item.Status.Trim()==""));
        }


        public virtual async Task<dynamic> CalculateAllEmployeeTotalSalary()
        {

            

            IEnumerable<SalaryComponents> salCList = await new SalaryComponentsRepository().GetAll();

            IEnumerable<EmployeeSalary> empSalList = await new EmployeeSalaryRepository().GetAll();

            List<EmployeeSalary> newEmpSalList = new List<EmployeeSalary>();
            foreach (EmployeeSalary empSalItem in empSalList)
            {
                foreach (SalaryComponents sC in salCList)
                {
                    if (sC.Type.Trim() == "credit")
                    {
                        empSalItem.TotalSalary -= (empSalItem.BasicSalary * sC.ComponentValue);
                    }
                    else if (sC.Type.Trim() == "debit")
                    {
                        empSalItem.TotalSalary += (empSalItem.BasicSalary * sC.ComponentValue);
                    }


                }

                newEmpSalList.Add(empSalItem);
            }
            IEnumerable<EmployeeSalary> ienumerableEmpSal = newEmpSalList;

            var resultList = from emp in new EmployeeRepository().GetAll().Result
                             join empSal in ienumerableEmpSal on emp.EmployeeId equals empSal.EmployeeId
                             join salBonus in new BonusRepository().GetAll().Result on empSal.BonusId equals salBonus.BonusId
                             select new
                             {
                                 EmployeeId = emp.EmployeeId,
                                 EmployeeName = emp.EmployeeName,
                                 TotalSalary = empSal.TotalSalary + salBonus.BonusValue,
                                 BonusSalary = salBonus.BonusValue
                             };

            return resultList;

        }







    }
}
