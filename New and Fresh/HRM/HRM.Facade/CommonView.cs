using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Entity;
using HRM.Data;
using HRM.Facade.Interfaces;
using HRM.Data.Interfaces;
using HRM.Entity.Facade;
using HRM.Entity.Accessory;
using HRM.Entity.DevAccessory;
using System.Diagnostics;

namespace HRM.Facade
{
    class CommonView: ICommonView
    {

        public virtual LoginObject Authenticate(int id, string password)
        {
            IEnumerable<Employee> employeeList = new RepositoryFactory().Create<Employee>().GetAll();
            IEnumerable<EmployeeBio> employeeBioList = new RepositoryFactory().Create<EmployeeBio>().GetAll();
            IEnumerable<EmployeePrivilege> employeePrivilegeList = new RepositoryFactory().Create<EmployeePrivilege>().GetAll();
            IEnumerable<EmployeeDepartment> employeeDepartmentList = new RepositoryFactory().Create<EmployeeDepartment>().GetAll();
            List<WorkDay> workDaysList = new RepositoryFactory().Create<WorkDay>().GetAll().ToList();

            if (Debugger.IsAttached)
            {
                foreach(var obj in employeeList)
                {
                    Output.Write("Employee list: ");
                    Output.Write(obj.EmployeeId + " : " + obj.EmployeeName + " : " + obj.EmployeePassword);
                }

                foreach (var obj in employeeBioList)
                {
                    Output.Write("Employee Bio list: ");
                    Output.Write(obj.EmployeeId + " : " + obj.EmployeeContactNo );
                }

                foreach (var obj in employeePrivilegeList)
                {
                    Output.Write("Employee privilege list: ");
                    Output.Write(obj.EmployeePrivilegeId + " : " + obj.EmployeeId + " : " + obj.PrivilegeId);
                }

                foreach (var obj in employeeDepartmentList)
                {
                    Output.Write("Employee department list: ");
                    Output.Write(obj.DepartmentId + " : " + obj.EmployeeId );
                }

            }
            

            try
            {
                LoginObject returnable = new LoginObject(0, null, null, null, 0, DateTime.Now,0,0, false) ;
                var result = from emp in employeeList
                             join empBio in employeeBioList on emp.EmployeeId equals empBio.EmployeeId
                             join empPriv in employeePrivilegeList on emp.EmployeeId equals empPriv.EmployeeId
                             join empDept in employeeDepartmentList on emp.EmployeeId equals empDept.EmployeeId 
                             select new
                             {
                                 Id = emp.EmployeeId,
                                 Password = emp.EmployeePassword,
                                 Name = emp.EmployeeName,
                                 Image = empBio.Image,
                                 privilege = empPriv.PrivilegeId,
                                 HireDate = empBio.HireDate,
                                 DepartmentId = empDept.DepartmentId,
                                 EmployeeBioId = empBio.EmployeeBioId
                             };

                if (Debugger.IsAttached)
                {
                    Output.Write("Combined list: ");
                    foreach (var item in result)
                    {

                        Output.Write("Id: " + item.Id + " \nPassword: " +
                            item.Password + " \nName: " + item.Name + " \nPrivilegeCode: " + item.privilege);
                    }
                }
                
                var finalResult = result.Where(item => item.Id == id && item.Password == password);
                if(finalResult != null)
                {
                    foreach(var item in finalResult)
                    {
                        Token token = new Token
                        {
                            Id = item.Id,
                            PrivilegeToken = item.privilege.ToString()
                        };
                        returnable = new LoginObject(item.Id, item.Name, item.Image, token, item.privilege, item.HireDate, item.DepartmentId, item.EmployeeBioId, false);
                    }
                    
                }
                if(workDaysList.Count > 0)
                {
                    workDaysList = workDaysList.Where(e => e.EmployeeId == returnable.Id).ToList();
                    if(workDaysList.Count > 0)
                    {
                        workDaysList = workDaysList.Where(e => e.StartTime.Month == DateTime.Now.Month && e.StartTime.Day == DateTime.Now.Day).ToList();
                        if (workDaysList[0] != null && workDaysList[0].StartTime != null)
                        {
                            returnable.Working = true;
                        }
                    }
                    
                }
                
                
                return returnable;
            }
            catch(Exception e)
            {
                Output.WriteLine(e);
                return new LoginObject(0, null, null, null, 0, DateTime.Now, 0, 0, false);
            }
        }

        public virtual IEnumerable<TrainingAndRelatedEmployees> GetTrainingAndRelatedEmployees(int trainingId)
        {
            
            IEnumerable<Training> trainingList = new RepositoryFactory().Create<Training>().GetAll();
            IEnumerable<Employee> employeeList = new RepositoryFactory().Create<Employee>().GetAll();
            IEnumerable<TrainingEmployee> trainingEmployeeList = new TrainingEmployeeRepository().GetAll();

            try
            {
                var result = from training in trainingList
                             join combo in trainingEmployeeList on training.TrainingId equals combo.TrainingId
                             join employee in employeeList on combo.EmployeeId equals employee.EmployeeId
                             select new TrainingAndRelatedEmployees
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
                return new List<TrainingAndRelatedEmployees>();
            }
        }


        public virtual IEnumerable<EmployeeAndRelatedTrainings> GetEmployeeAndRelatedTraining(int employeeId)
        {
            IEnumerable<Training> trainingList = new RepositoryFactory().Create<Training>().GetAll();
            IEnumerable<Employee> employeeList = new RepositoryFactory().Create<Employee>().GetAll();
            IEnumerable<TrainingEmployee> trainingEmployeeList = new RepositoryFactory().Create<TrainingEmployee>().GetAll();

            try
            {
                var result = from emp in  employeeList
                             join combo in trainingEmployeeList on emp.EmployeeId equals combo.EmployeeId
                             join train in trainingList on combo.TrainingId equals train.TrainingId
                             select new EmployeeAndRelatedTrainings
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
                return new List<EmployeeAndRelatedTrainings>();
            }
        }


        public virtual  bool AddEmployeesToTrainingProgram(int trainingId , List<int> employeeIdList)
        {
            try
            {
                IRepository<TrainingEmployee> comboRepo = new RepositoryFactory().Create<TrainingEmployee>();
                foreach(int id in employeeIdList)
                {
                    TrainingEmployee item = new TrainingEmployee();
                    item.TrainingId = trainingId;
                    item.EmployeeId = id;

                     comboRepo.Insert(item);
                }

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Encountered error while adding employees to training: " + e);
                return false;
            }
            
        }

        public virtual  bool AddEmployeesToTrainingProgram(int trainingId, string employeeIdsString)
        {
            try
            {
                var tempIdList = employeeIdsString.Trim().Split(',');
                List<int> idList = new List<int>();
                foreach (string s in tempIdList)
                {
                    idList.Add(Int32.Parse(s));
                }
                return  AddEmployeesToTrainingProgram(trainingId, idList);

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }


        public virtual  bool AddTrainingsToEmployee(int employeeId, List<int> trainingList)
        {
            try
            {
                IRepository<TrainingEmployee> comboRepo = new RepositoryFactory().Create<TrainingEmployee>();
                foreach (int id in trainingList)
                {
                    TrainingEmployee item = new TrainingEmployee();
                    item.EmployeeId = employeeId;
                    item.TrainingId = id;

                     comboRepo.Insert(item);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Encountered error while adding employees to training: " + e);
                return false;
            }

        }

        public virtual  bool AddTrainingsToEmployee(int employeeId, string trainingIdsString)
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
                return  AddEmployeesToTrainingProgram(employeeId, idList);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public virtual IEnumerable<EmployeeAndBio> GetAllEmployeeDetails()
        {
            IRepository<Employee> empRepo = new RepositoryFactory().Create<Employee>();
            IRepository<EmployeeBio> empBioRepo = new RepositoryFactory().Create<EmployeeBio>();
            return from emp in empRepo.GetAll()
                   join empBio in empBioRepo.GetAll() on emp.EmployeeId equals empBio.EmployeeId
                   select new EmployeeAndBio
                    {
                        EmployeeId = emp.EmployeeId,
                        EmployeeName = emp.EmployeeName,
                        EmployeeEmail = emp.EmployeeEmail,
                        EmployeePassword = emp.EmployeePassword,
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
                        Education = empBio.Eduction,
                        Image  = empBio.Image
                    };
        }


        public virtual  bool ApproveHireRequests(string hireRequestIdsString)
        {
            try
            {
                var tempIdsList = hireRequestIdsString.Trim().Split(',');
                IRepository<HireRequest> hireRepo = new RepositoryFactory().Create<HireRequest>();
                foreach (var item in tempIdsList)
                {
                    if(item.Trim() != null && item.Trim() != "")
                    {
                        int key = int.Parse(item);
                        HireRequest tempReq =  hireRepo.Get(key);
                        tempReq.HireRequestStatus = 1;
                         hireRepo.Update(tempReq, key);
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


        public virtual IEnumerable<EmployeePerformance> GetAllEmployeePerformance()
        {
            try
            {
                IRepository<Employee> empRepo = new RepositoryFactory().Create<Employee>();
                IRepository<EmployeePerformanceMetric> empBioRepo = new RepositoryFactory().Create<EmployeePerformanceMetric>();
                IRepository<EmployeeDepartment> empDeptRepo = new RepositoryFactory().Create<EmployeeDepartment>();
                IRepository<EmployeeSalary> empSalary = new RepositoryFactory().Create<EmployeeSalary>();
                return from emp in empRepo.GetAll()
                       join empDept in empDeptRepo.GetAll() on emp.EmployeeId equals empDept.EmployeeId
                       join empPerf in empBioRepo.GetAll() on emp.EmployeeId equals empPerf.EmployeeId
                       join empSal in empSalary.GetAll() on emp.EmployeeId equals empSal.EmployeeId
                       select new EmployeePerformance
                       {
                           EmployeeId = emp.EmployeeId,
                           EmployeeName = emp.EmployeeName,

                           ProjectScore = empPerf.AverageProjectScore,
                           TrainingScore = empPerf.AverageTrainingScore,
                           AttendanceScore = 100,
                           AggregateScore = (empPerf.AverageProjectScore + empPerf.AverageTrainingScore + 100) / 3,

                           DepartmentId = empDept.EmployeeDepartmentId,

                           EmployeeSalaryId = empSal.EmployeeSalaryId
                       };
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return new List<EmployeePerformance>();
            }
            
        }


        public virtual  bool AddDepartmentWideBonus(int departmentId, Bonuses bonus)
        {
            
            try
            {
                IRepository<EmployeeSalary> empSalRepo = new RepositoryFactory().Create<EmployeeSalary>();
                IRepository<Bonus> bonusRepo = new RepositoryFactory().Create<Bonus>();
                IRepository<Bonuses> bonusesRepo = new RepositoryFactory().Create<Bonuses>();

                var salaryBonus = from empSal in empSalRepo.GetAll()
                                  join bon in bonusRepo.GetAll() on empSal.BonusId equals bon.BonusId
                                  select new
                                  {
                                      BonusId = empSal.BonusId
                                  };

                foreach(var item in salaryBonus)
                {
                    Bonuses bonusesItem = new Bonuses
                    {
                        BonusId = item.BonusId,
                        BonusValue = bonus.BonusValue,
                        BonusDescription = bonus.BonusDescription,
                        BonusesDate = bonus.BonusesDate
                    };
                     bonusesRepo.Insert(bonusesItem);

                    Bonus tempBonus = bonusRepo.Get(item.BonusId);
                    tempBonus.BonusValue += bonus.BonusValue;
                     bonusRepo.Update(tempBonus, item.BonusId);
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public virtual  bool AddBonusToEmployeeList (int departmentId, Bonuses bonus , string employeeIdsList)
        {

            try
            {
                EmployeeSalaryRepository empSalRepo = new EmployeeSalaryRepository();
                BonusRepository bonusRepo = new BonusRepository();
                BonusesRepository bonusesRepo = new BonusesRepository();

                var idList = employeeIdsList.Trim().Split(',');

                var salaryBonus = from empSal in empSalRepo.GetAll()
                                  join bon in bonusRepo.GetAll() on empSal.BonusId equals bon.BonusId
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
                     bonusesRepo.Insert(bonusesItem);

                    Bonus tempBonus = bonusRepo.Get(item.BonusId);
                    tempBonus.BonusValue += bonus.BonusValue;
                     bonusRepo.Update(tempBonus, item.BonusId);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public virtual bool AssignBonusToEmployee(Bonuses bonus, int EmployeeId)
        {

            try
            {
                EmployeeSalaryRepository empSalRepo = new EmployeeSalaryRepository();
                BonusRepository bonusRepo = new BonusRepository();
                BonusesRepository bonusesRepo = new BonusesRepository();


                var salaryBonus = from empSal in empSalRepo.GetAll()
                                  join bon in bonusRepo.GetAll() on empSal.BonusId equals bon.BonusId
                                  select new
                                  {
                                      EmployeeId = empSal.EmployeeId,
                                      BonusId = empSal.BonusId
                                  };

                salaryBonus = salaryBonus.Where(item => item.EmployeeId == EmployeeId);

                foreach (var item in salaryBonus)
                {
                    Bonuses bonusesItem = new Bonuses
                    {
                        BonusId = item.BonusId,
                        BonusValue = bonus.BonusValue,
                        BonusDescription = bonus.BonusDescription,
                        BonusesDate = bonus.BonusesDate
                    };
                    bonusesRepo.Insert(bonusesItem);

                    Bonus tempBonus = bonusRepo.Get(item.BonusId);
                    tempBonus.BonusValue += bonus.BonusValue;
                    bonusRepo.Update(tempBonus, item.BonusId);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public virtual  bool AssignTransportsToAnArea(int transportAreaId, string transportIdsList)
        {
            try
            {
                IRepository<TransportAreaVehicle> tAVRepo = new RepositoryFactory().Create<TransportAreaVehicle>();
                IRepository<TransportVehicle> tVRepo = new RepositoryFactory().Create<TransportVehicle>();
                IRepository<TransportArea> TARepo = new RepositoryFactory().Create<TransportArea>();
                var idList = transportIdsList.Trim().Split(',');
                int newCapacity = 0;
                foreach(var tempId in idList)
                {
                    if(tempId != null && tempId.Trim() != "")
                    {
                        int id = Int32.Parse(tempId);

                         tAVRepo.Insert(new TransportAreaVehicle
                        {
                            TransportAreaId = transportAreaId,
                            TransportVehicleId = id
                        });

                        TransportVehicle temp = tVRepo.Get(id);
                        temp.status = "assigned";
                         tVRepo.Update(temp, id);
                        newCapacity += temp.Capacity;
                    }
                }

                TransportArea tempArea = TARepo.Get(transportAreaId);
                tempArea.AssignedCapacity += newCapacity;
                 TARepo.Update(tempArea, tempArea.TransportAreaId);
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
            return new RepositoryFactory().Create<TransportVehicle>().GetAll().Where(item => (item.status == "free" || item.status == "available" || item.status == null || item.status.Trim() == ""));
        }


        public virtual  bool AssignEquipmentsToADepartment(int departmentId, string equipmentIdsList)
        {
            IRepository<Equipment> eRepo = new RepositoryFactory().Create<Equipment>();
            IRepository<EquipmentAndDepartment> eDRepo = new RepositoryFactory().Create<EquipmentAndDepartment>();
            try
            {
                
                var idList = equipmentIdsList.Trim().Split(',');
                foreach (var tempId in idList)
                {
                    if (tempId != null && tempId.Trim() != "")
                    {
                        int id = Int32.Parse(tempId);

                         eDRepo.Insert(new EquipmentAndDepartment
                        {
                            DepartmentId = departmentId,
                            EquipmentId = id
                        });

                        Equipment temp = eRepo.Get(id);
                        temp.Status = "assigned";
                        eRepo.Update(temp, id);
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


        public virtual  bool AssignCandidatesToInterview(int interviewId, string candidateIdsList)
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

                         iCRepo.Insert(new Interviewee
                        {
                            InterviewId = interviewId,
                            IntervieweeId = id
                        });

                        TemporaryCV temp = tCVRepo.Get(id);
                        temp.Status = "assigned";
                         tCVRepo.Update(temp, id);
                        newCapacity += 1;
                    }
                }

                Interview tempInter = iRepo.Get(interviewId);
                tempInter.NumberOfCandidatesAssigned += newCapacity;
                 iRepo.Update(tempInter, tempInter.InterviewId);
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
            return new TemporaryCVRepository().GetAll().Where(item => (item.Status == "free" || item.Status == "available" || item.Status == null || item.Status.Trim()==""));
        }



        //public virtual  IEnumerable<EmployeeTotalSalary> CalculateAllEmployeeTotalSalary()
        //{
        //    IEnumerable<SalaryComponents> salCList =  new RepositoryFactory().Create<SalaryComponents>().GetAll();

        //    IEnumerable<EmployeeSalary> empSalList =  new RepositoryFactory().Create<EmployeeSalary>().GetAll();

        //    IEnumerable<SalaryRank> salRankList = new RepositoryFactory().Create<SalaryRank>().GetAll();

        //    List<EmployeeSalary> newEmpSalList = new List<EmployeeSalary>();

        //    Dictionary<int, int> salRankValues = new Dictionary<int, int>();
        //    foreach(SalaryRank item in salRankList)
        //    {
        //        salRankValues.Add(item.SalaryRankId, item.RankValue);
        //    }

            
        //    foreach (EmployeeSalary empSalItem in empSalList)
        //    {
        //        foreach (SalaryComponents sC in salCList)
        //        {
        //            int basicSalary = salRankValues.ContainsKey(empSalItem.SalaryRankId) ? salRankValues[empSalItem.SalaryRankId]:10000 ;
        //            if (sC.Type.Trim() == "credit")
        //            {
        //                empSalItem.TotalSalary -= (basicSalary * sC.ComponentValue/100);
        //            }
        //            else if (sC.Type.Trim() == "debit")
        //            {
        //                empSalItem.TotalSalary += (basicSalary * sC.ComponentValue/100);
        //            }


        //        }

        //        newEmpSalList.Add(empSalItem);
        //    }
        //    IEnumerable<EmployeeSalary> ienumerableEmpSal = newEmpSalList;

        //    IEnumerable<EmployeeTotalSalary> resultList = from emp in new EmployeeRepository().GetAll()
        //                                                  join empSal in ienumerableEmpSal on emp.EmployeeId equals empSal.EmployeeId
        //                                                  join salRank in new RepositoryFactory().Create<SalaryRank>().GetAll() on empSal.SalaryRankId equals salRank.SalaryRankId
        //                                                  join salBonus in new BonusRepository().GetAll() on empSal.BonusId equals salBonus.BonusId
        //                     select new EmployeeTotalSalary
        //                     {
        //                         EmployeeId = emp.EmployeeId,
        //                         EmployeeName = emp.EmployeeName,
        //                         TotalSalary = empSal.TotalSalary + salBonus.BonusValue,
        //                         BonusSalary = salBonus.BonusValue,
        //                         BasicSalary = salRank.RankValue

        //                     };


        //    return resultList;

        //}

        public virtual IEnumerable<EmployeeTotalSalary> CalculateAllEmployeeTotalSalary()
        {
            ICollection<SalaryComponents> salCList = new RepositoryFactory().Create<SalaryComponents>().GetAll().ToList();

            IEnumerable<EmployeeSalary> empSalList = new RepositoryFactory().Create<EmployeeSalary>().GetAll();

            IEnumerable<Employee> employeeList = new RepositoryFactory().Create<Employee>().GetAll();

            List<EmployeeTotalSalary> returnableResult = new List<EmployeeTotalSalary>();

            int numberOfSalaryComponents = salCList.Count;


            var result = from emp in employeeList
                         join empSal in empSalList on emp.EmployeeId equals empSal.EmployeeId
                         select new EmployeeTotalSalary
                         {
                             EmployeeId = emp.EmployeeId,
                             EmployeeName = emp.EmployeeName,
                             SalaryRank = empSal.SalaryRankId,
                             BasicSalary = empSal.BasicSalary,
                             BonusSalary = empSal.BonusValue,
                             TotalSalary = empSal.TotalSalary,
                             EmployeeSalaryId = empSal.EmployeeSalaryId
                         };

            if (Debugger.IsAttached)
            {
                Output.Write("Total salaries before adding components: ");
                foreach(var item in result)
                {
                    Output.Write(item.EmployeeId + " : " + item.EmployeeName + " : " + item.TotalSalary);
                }
            }



            foreach (EmployeeTotalSalary empTotSal in result)
            {

                if(empTotSal.TotalSalary == 0)
                {
                    empTotSal.Paid = false;
                    
                    Output.Write("In total salary update loop");

                    double total = empTotSal.BasicSalary + empTotSal.BonusSalary;

                    Output.Write("total salary before update: " + total);

                    foreach (SalaryComponents sC in salCList)
                    {
                        double component = sC.ComponentValue * empTotSal.BasicSalary;
                        double value = component / 100;
                        Output.Write("Salary component is: " + sC.ComponentName + " : " + sC.ComponentValue + " : " + sC.Type);
                        Output.Write("component is: " + component + " \nvalue is: " + value);
                        if (sC.Type.Trim() == "credit")
                        {
                            total -= value;
                        }
                        else if (sC.Type.Trim() == "debit")
                        {
                            total += value;
                        }

                        Output.Write("total value now: " + total);

                    }


                    empTotSal.TotalSalary = (int)total;

                    Output.Write("Updated total salary: " + empTotSal.TotalSalary);

                }
                else
                {
                    empTotSal.Paid = true;
                }

                returnableResult.Add(empTotSal);

            }

            if (Debugger.IsAttached)
            {
                Output.Write("Total salaries after adding components: ");
                foreach (var item in returnableResult)
                {
                    Output.Write(item.EmployeeId + " : " + item.EmployeeName + " : " + item.TotalSalary);
                }
            }



            return returnableResult;

        }



        public virtual  dynamic Test()
        {
            return  new RepositoryFactory().Create<Employee>().GetAll();
        }



        public virtual IEnumerable<EmployeePromotion> GetEmployeePromotionView()
        {
            IEnumerable<EmployeePromotion> resultBasic = from emp in new RepositoryFactory().Create<Employee>().GetAll()
                         join empSal in new RepositoryFactory().Create<EmployeeSalary>().GetAll() on emp.EmployeeId equals empSal.EmployeeId
                         join salRank in new RepositoryFactory().Create<SalaryRank>().GetAll() on empSal.SalaryRankId equals salRank.SalaryRankId
                         select new EmployeePromotion
                         {
                             EmployeeId = emp.EmployeeId,
                             EmployeeName = emp.EmployeeName,
                             SalaryRankId = empSal.SalaryRankId,
                             BasicSalary = salRank.RankValue,
                             RankName = salRank.RankName
                         };

            IEnumerable<EmployeePerformance> performance = GetAllEmployeePerformance();
            List<EmployeePromotion> finalResult = new List<EmployeePromotion>();

            var joinedList = from res in resultBasic
                             join perf in performance on res.EmployeeId equals perf.EmployeeId
                             select new
                             {
                                 EmployeeId = res.EmployeeId,
                                 EmployeeName = res.EmployeeName,
                                 SalaryRankId = res.SalaryRankId,
                                 BasicSalary = res.BasicSalary,
                                 RankName = res.RankName,
                                 AggregateScore = perf.AggregateScore
                             };

            foreach(var item in joinedList)
            {
                EmployeePromotion empPromo = new EmployeePromotion()
                {
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    SalaryRankId = item.SalaryRankId,
                    BasicSalary = item.BasicSalary,
                    RankName = item.RankName
                };
                if (item.AggregateScore > 70) empPromo.RecommendationStatus = 1;
                else if (item.AggregateScore < 30) empPromo.RecommendationStatus = 0;
                else empPromo.RecommendationStatus = -1;

                finalResult.Add(empPromo);
            }


            return finalResult;
        }



        //public virtual IEnumerable<EmployeeAndBio> GetEmployeeTotalSalary()
        //{
        //    IRepository<Employee> empRepo = new RepositoryFactory().Create<Employee>();
        //    IRepository<EmployeeBio> empBioRepo = new RepositoryFactory().Create<EmployeeBio>();
        //    return from emp in empRepo.GetAll()
        //           join empBio in empBioRepo.GetAll() on emp.EmployeeId equals empBio.EmployeeId
        //           select new EmployeeAndBio
        //           {
        //               EmployeeId = emp.EmployeeId,
        //               EmployeeName = emp.EmployeeName,
        //               EmployeeEmail = emp.EmployeeEmail,
        //               EmployeePassword = emp.EmployeePassword,
        //               MGR = emp.MGR,

        //               EmployeeContactNo = empBio.EmployeeContactNo,
        //               EmployeeAddress = empBio.EmployeeAddress,
        //               DateofBirth = empBio.DateofBirth,
        //               HireDate = empBio.HireDate,
        //               Intro = empBio.Intro,
        //               Objectives = empBio.Objectives,
        //               Hobbies = empBio.Hobbies,
        //               Interests = empBio.Interests,
        //               Certificates = empBio.Certificates,
        //               JobExperience = empBio.JobExperience,
        //               Education = empBio.Eduction,
        //               Image = empBio.Image
        //           };
        //}



    }
}
