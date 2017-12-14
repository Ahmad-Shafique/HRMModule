using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class TransportArea
    {
        [Key]
        public int TransportAreaId { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }
        public int AreaDemand { get; set; }
    }
}
