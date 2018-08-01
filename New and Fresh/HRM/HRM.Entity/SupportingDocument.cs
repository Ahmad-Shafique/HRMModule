using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class SupportingDocument
    {
        [Key]
        public int SupportingDocumentId { get; set; }
        public string SupportingDocumentName { get; set; }
        public string SupportingDocumentLink { get; set; }
       [Required]
        public int LeaveApplicationId { get; set; }
    }
}
