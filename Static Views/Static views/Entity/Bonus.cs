using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Bonus
    {
        [Key]
        public int BonusId { get; set; }
        [Required]
        public int BonusValue { get; set; }
        [Required]
        public DateTime BonusTime { get; set; }
    }
}
