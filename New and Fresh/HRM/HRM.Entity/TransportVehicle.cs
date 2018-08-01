using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class TransportVehicle
    {  
        [Key]
        public int TransportVehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public int Capacity { get; set; }
        public string status { get; set; }

    }
}
