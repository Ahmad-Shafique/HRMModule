using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class LeaveApplicationCategory
    {
        public int LeaveApplicationCategoryId { get; set; }
        public string LeaveApplicationCategoryName { get; set; }
        public List<LeaveApplication> LeaveApplications { get; set; }
        public LeaveApplicationCategory()
        {
            LeaveApplications = new List<LeaveApplication>();
        }
    }
}
