using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Static_views.Entity
{
    public class TransportVehicle
    {
        public int TransportVehicleId { get; set; }
        public string VehicleName { get; set; }
        public string DriverName { get; set; }
        public int Capacity { get; set; }
        public string status { get; set; }
    }
}