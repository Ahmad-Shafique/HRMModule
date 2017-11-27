using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int EmployeeId { get; set; }
        public int Noticeid { get; set; }
        public Employee Employee { get; set; }
        public Notice Notice { get; set; }
    }
}
