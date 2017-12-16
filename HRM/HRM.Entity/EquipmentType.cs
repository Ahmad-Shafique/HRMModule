using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    class EquipmentType
    {
        public int EquipmentTypeId { get; set; }
        public string TypeName { get; set; }
        public string Model { get; set; }
        public int TotalNumberPresent { get; set; }
        public int TotalNumberAssigned { get; set; }
    }
}
