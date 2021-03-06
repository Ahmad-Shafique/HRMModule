﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class EmployeeDesignation
    {
        [Key]
        public int EmployeeDesignationId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int DesignationId { get; set; }
    }
}
