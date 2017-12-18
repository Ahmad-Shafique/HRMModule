using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class SalaryPaymentsController : Controller
    {
        private ICommonViewService Service = ServiceFactory.GetCommonViewService();
        // GET: SalaryPayment
        public async Task<ActionResult> Index()
        {
            Console.WriteLine("Entered salary payments display");

            ViewBag.Employees = await Service.Test();
            //ViewBag.Salaries = await Service.CalculateAllEmployeeTotalSalary();
            return View();
        }
    }
}
