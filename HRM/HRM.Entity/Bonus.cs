using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Bonus
    {
        public int BonusId { get; set; }
        public int BonusValue { get; set; }
        public DateTime BonusTime { get; set; }

        public List<Bonuses> Bonuses { get; set; }

        public Bonus()
        {
            Bonuses  = new List<Bonuses>();
        }
    }
}
