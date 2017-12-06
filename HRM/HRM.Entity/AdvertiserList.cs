using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class AdvertiserList
    {
        [Key]
        public int AdvertiserListId { get; set; }
        [Required,MaxLength(30)]
        public string AdvertiserName { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public string ContactInfo { get; set; }
    }
}
