using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Bonuses
    {
        [Key]
        public int BonusesId { get; set; }
        [Required]
        public int BonusId { get; set; }
        [Required]
        public int BonusValue { get; set; }
        [Required]
        public string BonusDescription { get; set; }
       [Required]
        public DateTime BonusesDate { get; set; }
    }
}
