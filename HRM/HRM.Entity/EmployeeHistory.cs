using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeHistory
    {
        public int EmployeeHistoryId { get; set; }
        public string ColumnName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Date { get; set; }
        public int EmployeetId { get; set; }

        public Employee Employee { get; set; }
    }
}
