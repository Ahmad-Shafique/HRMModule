using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
   public class Notice
    {
       public int NoticeId {get;set;}
       public string NoticeTitle { get; set; }
       public string NoticeDetails { get; set; }
       public DateTime NoticeDate { get; set; }
       public int EmployeeId { get; set; }
       public Employee Employee { get; set; }
       public List<Comment> Comments { get; set; }
       public Notice()
       {
           Comments = new List<Comment>();
       }
    }
}
