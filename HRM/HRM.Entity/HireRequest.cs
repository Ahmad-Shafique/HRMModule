using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class HireRequest
    {
        public int HireRequestId { get; set; }
        public string DesignationName { get; set; }
        public int EmplyeeRequired { get; set; }
        public DateTime RequestDate { get; set; }
        public string Urgency { get; set; }
        public int HireRequestStatus { get; set; }
        public int DepartmentId { get; set; }
    }
}
