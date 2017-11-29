using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class SupportingDocument
    {
        public int SupportingDocument { get; set; }
        public string SupportingDocumentName { get; set; }
        public string SupportingDocumentLink { get; set; }
        public int LeaveApplicationId { get; set; }
        public LeaveApplication LeaveApplication { get; set; }
    }
}
