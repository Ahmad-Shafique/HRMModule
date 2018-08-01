using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class NoticeEmployee
    {
        [Key]
        public int NoticeEmployeeId { get; set; }
        [Required]
        public int NoticeId {get;set;}
        [Required]
        public int EmployeeId { get; set; }
    }
}
