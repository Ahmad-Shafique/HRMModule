using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class LeaveApplicationCategory
    {
        [Key]
        public int LeaveApplicationCategoryId { get; set; }
        public string LeaveApplicationCategoryName { get; set; }
    }
}
