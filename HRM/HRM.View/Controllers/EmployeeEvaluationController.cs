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
    public class EmployeeEvaluationController : Controller
    {
        private IDomainService<Department> DepartmentService = new ServiceFactory().Create<Department>();
        private ICommonViewServiceInterface CommonService = ServiceFactory.GetCommonViewService();
        // GET: EmployeeEvaluation
        public ActionResult Index()
        {
            ViewBag.Departments = DepartmentService.GetAll().Result;
            return View();
        }

        public ActionResult EmployeeDisplay(int? DepartmentId)
        {
            ViewBag.Employees = CommonService.GetAllEmployeePerformance();
            return View();
        }
    }
}
