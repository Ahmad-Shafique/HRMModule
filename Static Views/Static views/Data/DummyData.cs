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
                new Employee(){ EmployeeId= 1 , EmployeeName ="Shobuj" , AreaId = 1},
                new Employee(){ EmployeeId= 2 , EmployeeName ="Shaykat" , AreaId = 1},
                new Employee(){ EmployeeId= 3 , EmployeeName ="Nawaz" , AreaId = 2}
            };

        }

    }
}