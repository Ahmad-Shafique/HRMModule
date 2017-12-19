using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class EmployeeEvaluationsController : Controller
    {
        private IDomainService<Department> DepartmentService = new ServiceFactory().Create<Department>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        // GET: EmployeeEvaluation
        public ActionResult Index()
        {
            ViewBag.Departments = DepartmentService.GetAll();
            return View();
        }

        public ActionResult EmployeeDisplay(int? DepartmentId)
        {
            ViewBag.Employees = CommonService.GetAllEmployeePerformance();
            return View();
        }
    }
}
