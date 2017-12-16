using HRM.Entity;
using Static_views.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Static_views.Data
{
    public class DummyData
    {

        public static List<TransportArea> TransportAreas()
        {
            List<TransportArea> areas = new List<TransportArea>();
            areas.Add(new TransportArea() { AreaName = "Mohakhali", AreaDemand = 50, TransportAreaId = 1, Description = "Desnse area" });
            areas.Add(new TransportArea() { AreaName = "Farmgate", AreaDemand = 10, TransportAreaId = 2, Description = "Sparse area" });
            areas.Add(new TransportArea() { AreaName = "Sadarghat", AreaDemand = 100, TransportAreaId = 3, Description = "Extremely desnse area" });

            return areas;
        }

        public static List<TransportVehicle> TransportVehicles()
        {
            return new List<TransportVehicle>()
            {
                new TransportVehicle(){ TransportVehicleId = 1, VehicleName = "V 1", DriverName = "", Capacity = 5 , status= "free"},
                new TransportVehicle(){ TransportVehicleId = 2, VehicleName = "V 10", DriverName = "", Capacity = 6 , status= "free"},
                new TransportVehicle(){ TransportVehicleId = 3, VehicleName = "V 11", DriverName = "", Capacity = 4 , status= "free"}
            };

        }

        public static List<Employee> Employees()
        {
            return new List<Employee>()
            {
                new Employee(){ EmployeeId= 1 , EmployeeName ="Shobuj" , AreaId = 1, DateofBirth = new DateTime(1993, 5, 10), Designation = "programmer" },
                new Employee(){ EmployeeId= 2 , EmployeeName ="Shaykat" , AreaId = 1, DateofBirth = new DateTime(1990, 5, 10), Designation = "designer"},
                new Employee(){ EmployeeId= 3 , EmployeeName ="Nawaz" , AreaId = 2, DateofBirth = new DateTime(2005, 5, 10), Designation = "tester"},
                new Employee(){ EmployeeId= 3 , EmployeeName ="Ahmed" , AreaId = 3, DateofBirth = new DateTime(2005, 5, 10), Designation = "tester"},
                new Employee(){ EmployeeId= 3 , EmployeeName ="Imran" , AreaId = 1, DateofBirth = new DateTime(2005, 5, 10), Designation = "tester"}
            };

        }

        public static List<Department> Departments()
        {
            return new List<Department>()
            {
                new Department(){ DepartmentId=1 , DepartmentName="IT"},
                new Department(){ DepartmentId=2 , DepartmentName="=HR"},
                new Department(){ DepartmentId=3 , DepartmentName="Sales"}
            };

        }

        public static List<Equipment> Equipments()
        {
            return new List<Equipment>()
            {
                new Equipment(){EquipmentId=1 , Name="PC"},
                new Equipment(){EquipmentId=2 , Name="Table"},
                new Equipment(){EquipmentId=3 , Name="Vaccum cleaner"}
            };
            
        }

        public static List<HireRequest> HireRequests()
        {
            return new List<HireRequest>()
            {
                new HireRequest(){HireRequestId=1 , DepartmentId=1, DesignationName="Developer", EmplyeeRequired=5, HireRequestStatus=0, Urgency="Urgent"},
                new HireRequest(){HireRequestId=2 , DepartmentId=2, DesignationName="HR admin", EmplyeeRequired=10, HireRequestStatus=0, Urgency="Future"},
                new HireRequest(){HireRequestId=3 , DepartmentId=3, DesignationName="Sales manager", EmplyeeRequired=15, HireRequestStatus=0, Urgency="Urgent"},
                new HireRequest(){HireRequestId=4 , DepartmentId=2, DesignationName="HR something", EmplyeeRequired=22, HireRequestStatus=0, Urgency="Past"}
            };

        }

        public static List<Interview> Interviews()
        {
            return new List<Interview>()
            {
                new Interview(){ InterviewId=1, Schedule=new DateTime(2017, 12, 29), StartTime=new DateTime(2017, 12, 29, 10, 30, 0), EndTime=new DateTime(2017, 12, 29, 12, 30, 0) },
                new Interview(){ InterviewId=1, Schedule=new DateTime(2018, 10, 25), StartTime=new DateTime(2018, 10, 25, 4, 30, 0), EndTime=new DateTime(2018, 10, 25, 5, 30, 0) },
                new Interview(){ InterviewId=1, Schedule=new DateTime(2017, 6, 15), StartTime=new DateTime(2017, 6, 15, 10, 30, 0), EndTime=new DateTime(2017, 6, 15, 11, 30, 0) },
            };
        }

        public static List<Interviewee> Interviewees()
        {
            return new List<Interviewee>()
            {
                new Interviewee(){ IntervieweeId=1, InterviewId=1, TemporaryCVId=1 },
                new Interviewee(){ IntervieweeId=2, InterviewId=1 , TemporaryCVId=2 }, 
                new Interviewee(){ IntervieweeId=3, InterviewId=2 , TemporaryCVId=3 }
            };
        }

        public static List<LeaveApplication> LeaveRecords()
        {
            return new List<LeaveApplication>()
            {
                new LeaveApplication() { LeaveApplicationId=1 , EmployeeId=1 , ApplicationsStatus=1},
                new LeaveApplication() { LeaveApplicationId=2 , EmployeeId=1 , ApplicationsStatus=1},
                new LeaveApplication() { LeaveApplicationId=3 , EmployeeId=1 , ApplicationsStatus=0},
                new LeaveApplication() { LeaveApplicationId=4 , EmployeeId=2 , ApplicationsStatus=0},
                new LeaveApplication() { LeaveApplicationId=5 , EmployeeId=2 , ApplicationsStatus=1},
            };
        }

        public static List<EmployeePerformance> EmployeePerformances()
        {
            return new List<EmployeePerformance>()
            {
                new EmployeePerformance(){ EmployeeName="Shaykat", ProjectScore=50, TrainingScore=60 , AttendanceScore=40, AggregateScore = 50 },
                new EmployeePerformance(){ EmployeeName="Shekhor", ProjectScore=60, TrainingScore=50 , AttendanceScore=70, AggregateScore = 60 }

            };
        }

        public static List<EmployeeSalary> Salaries()
        {
            return new List<EmployeeSalary>()
            {
                new EmployeeSalary(){ EmployeeName="Shekhor", TotalSalary = 5000},
                new EmployeeSalary(){ EmployeeName="Shaykat", TotalSalary = 3000}
            };

        }
    }
}