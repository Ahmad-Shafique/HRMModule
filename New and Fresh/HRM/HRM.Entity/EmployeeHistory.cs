using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeHistory
    {
        [Key]
        public int EmployeeHistoryId { get; set; }
        public string ColumnName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EmployeetId { get; set; }
    }
}
