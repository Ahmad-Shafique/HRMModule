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
                new Employee(){ EmployeeId= 3 , EmployeeName ="Nawaz" , AreaId = 2, DateofBirth = new DateTime(2005, 5, 10), Designation = "tester"}
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

    }
}