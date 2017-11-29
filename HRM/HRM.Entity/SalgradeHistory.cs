using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class SalgradeHistory
    {
        public int SalgradeHistoryId { get; set; }
        public string ColumnName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Date { get; set; }
        public int SalgradetId { get; set; }
    }
}
