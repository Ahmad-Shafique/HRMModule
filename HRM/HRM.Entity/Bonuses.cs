using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Bonuses
    {
        public int BonusesId { get; set; }
        public int BonusId { get; set; }
        public int BonusValue { get; set; }
        public string BonusDescription { get; set; }
        public DateTime BonusesDate { get; set; }
    }
}
