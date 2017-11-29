using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class LeaveApplication
    {
        public int LeaveApplicationId { get; set; }
        public int LeaveApplicationCategoryId { get; set; }
        public string ApplicationDescription { get; set; }
        public int LeaveApplicationDuration { get; set; }
        public LeaveApplicationCategory LeaveApplicationCategory { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public DateTime Applydate { get; set; }
        public int ApplicationsStatus { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public List<SupportingDocument> SupportingDocuments { get; set; }
        public LeaveApplication()
        {
            SupportingDocuments = new List<SupportingDocument>();
        }


    }
}
