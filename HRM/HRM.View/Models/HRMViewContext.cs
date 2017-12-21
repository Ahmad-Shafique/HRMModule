﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRM.View.Models
{
    public class HRMViewContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HRMViewContext() : base("name=HRMViewContext")
        {
        }

        public System.Data.Entity.DbSet<HRM.Entity.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.Notice> Notices { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.Equipment> Equipments { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.HireRequest> HireRequests { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.TemporaryCV> TemporaryCVs { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.TransportArea> TransportAreas { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.TransportVehicle> TransportVehicles { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.CompanyPolicy> CompanyPolicies { get; set; }
    }
}