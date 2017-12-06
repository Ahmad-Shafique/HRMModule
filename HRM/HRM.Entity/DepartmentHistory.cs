using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class DepartmentHistory
    {
        [Key]
        public int DepartmentHistoryId { get; set; }
        [Required,MaxLength(100)]
        public string ColumnName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Date { get; set; }
        public int DepartmentId { get; set; }
    }
}
