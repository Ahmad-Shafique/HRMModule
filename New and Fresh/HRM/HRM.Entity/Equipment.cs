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
        public int EquipmentTypeId { get; set; }
        public string Status { get; set; }
        public int BuyPrice { get; set; }
        
    }
}
