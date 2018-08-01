using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EquipmentAndDepartment
    {
        [Key]
        public int EquipmentAndDepartmentId { get; set; }
        public int EquipmentId { get; set; }
        public int DepartmentId { get; set; }
    }
}
