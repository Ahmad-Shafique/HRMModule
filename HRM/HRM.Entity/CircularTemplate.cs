using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class CircularTemplate
    {
        [Key]
        public int CircularTemplateId { get; set; }
        [Required]
        public string TemplateName { get; set; }
        [Required]
        public string Template { get; set; }
    }
}
