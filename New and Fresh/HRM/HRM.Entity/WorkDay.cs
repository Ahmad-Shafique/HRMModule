using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    [Table("WorkDay")]
    public class WorkDay
    {
        [Key]
        public int WorkDayId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int ExtraTimeInMinutes { get; set; }

    }
}
