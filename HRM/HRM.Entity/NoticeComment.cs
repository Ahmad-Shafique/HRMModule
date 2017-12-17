using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class NoticeComment
    {
        [Key]
        public int NoticeCommentId { get; set; }
        public int NoticeId { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeName { get; set; }
        public string Comment { get; set; }
    }
}
