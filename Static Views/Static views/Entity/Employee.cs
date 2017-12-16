using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Static_views.Entity
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int AreaId { get; set; }
        public string Designation { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}