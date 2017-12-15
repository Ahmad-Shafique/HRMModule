using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; } 
        public string Model { get; set; }
        public int TotalNumberPresent { get; set; }
        public int AvailableNumber { get; set; }
        
    }
}
