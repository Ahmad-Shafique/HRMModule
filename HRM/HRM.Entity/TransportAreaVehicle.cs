using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class TransportAreaVehicle
    {
        [Key]
        public int TransportAreaVehicleId { get; set; }
        public int TranspoertAreaId { get; set; }
        public int TransportVehicleId { get; set; }

    }
}
