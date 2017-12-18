using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class SalaryPaymentsController : Controller
    {
        private ICommonViewServiceInterface Service = ServiceFactory.GetCommonViewService();
        // GET: SalaryPayment
        public ActionResult Index()
        {
            ViewBag.Salaries = Service.CalculateAllEmployeeTotalSalary();
            return View();
        }
    }
}
