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

        public System.Data.Entity.DbSet<HRM.Entity.EmployeeBio> EmployeeBios { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.LeaveApplication> LeaveApplications { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.LeaveApplicationCategory> LeaveApplicationCategories { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.SupportingDocument> SupportingDocuments { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.SalaryComponents> SalaryComponents { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.WorkDay> WorkDays { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.Training> Trainings { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.EmployeePerformanceMetric> EmployeePerformanceMetrics { get; set; }

        public System.Data.Entity.DbSet<HRM.Entity.RankHierarchy> RankHierarchies { get; set; }
    }
}
