using Static_views.Data;
using Static_views.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Static_views.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //Action for displaying employees
        [HttpGet]
        public ActionResult Display()
        {
            List<Employee> empList = DummyData.Employees();
            return View(empList);
        }
        
    }
}