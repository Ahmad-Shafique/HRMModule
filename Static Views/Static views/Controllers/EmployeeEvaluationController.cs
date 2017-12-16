using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Static_views.Controllers
{
    public class EmployeeEvaluationController : Controller
    {
        // GET: EmployeeEvaluation
        public ActionResult Index()
        {
            ViewBag.Departments = Data.DummyData.Departments(); 
            return View();
        }

        public ActionResult EmployeeDisplay(int? DepartmentId)
        {
            ViewBag.Employees = Data.DummyData.EmployeePerformances();
            return View();
        }


    }
}
