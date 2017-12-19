using HRM.Entity;
using HRM.Entity.Facade;
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
        public  ActionResult Index()
        {
            Console.WriteLine("Entered salary payments display");

            ViewBag.Employees = Service.Test();
            ViewBag.EmployeeTotalSalary =  Service.CalculateAllEmployeeTotalSalary();
            Console.WriteLine("Result received");
            Console.WriteLine("aa*****************************");
            Console.WriteLine("aa*****************************");
            //return View(result);
            return View();
        }
    }
}
