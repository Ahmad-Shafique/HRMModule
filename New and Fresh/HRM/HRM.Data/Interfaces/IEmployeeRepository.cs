﻿using HRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Data.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //extra method for employee class
    }
}
