﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName {get;set;}
        public string DepartmentLocation { get; set; }
        public string DepartmentDescription { get; set; }
        public int DepartmentHeadId { get; set; }
    }
}
