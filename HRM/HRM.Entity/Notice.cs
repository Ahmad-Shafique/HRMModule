using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
   public class Notice
    {
       [Key]
       public int NoticeId {get;set;}
       [Required]
       public string NoticeTitle { get; set; }
       [Required]
       public string NoticeDetails { get; set; }
       [Required]
       public DateTime NoticeDate { get; set; }
    }
}
