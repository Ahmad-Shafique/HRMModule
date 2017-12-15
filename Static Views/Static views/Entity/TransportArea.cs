using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Static_views
{
    public class TransportArea
    {
        public int TransportAreaId { get; set; }
        public string AreaName { get; set; }
        public string Description { get; set; }
        public int AreaDemand { get; set; }
    }
}