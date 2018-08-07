using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class WorkDay
    {
        [Key]
        public int WorkDayId;

        [Required]
        public int EmployeeId;

        public DateTime StartTime;
        public DateTime EndTime;
    }
}
