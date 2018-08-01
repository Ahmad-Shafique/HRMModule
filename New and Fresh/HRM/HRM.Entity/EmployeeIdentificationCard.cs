using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeIdentificationCard
    {
        [Key]
        public int EmployeeIdentificationCardId { get; set; }
        public int EmployeeId { get; set; }
        public string CardHolderName { get; set; }
        public string CardHolderImage { get; set; }
        public DateTime CardExpiry { get; set; }
    }
}
