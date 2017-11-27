using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class DepartmentHistory
    {
        public int DepartmentHistoryId { get; set; }
        public string ColumnName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Date { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
