using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_views.Entity
{
    public class HireRequest
    {
        [Key]
        public int HireRequestId { get; set; }
        public string DesignationName { get; set; }
        public int EmplyeeRequired { get; set; }
        public DateTime RequestDate { get; set; }
        public string Urgency { get; set; }
        public int HireRequestStatus { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
