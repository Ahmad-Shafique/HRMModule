﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class LeaveApplication
    {
        [Key]
        public int LeaveApplicationId { get; set; }
        [Required]
        public int LeaveApplicationCategoryId { get; set; }
        public string ApplicationDescription { get; set; }
        public int LeaveApplicationDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public DateTime Applydate { get; set; }
        public int ApplicationsStatus { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
