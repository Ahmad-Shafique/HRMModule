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
            var result =  Service.CalculateAllEmployeeTotalSalary();
            var sortedByTotalSalary = result.OrderBy(item => -item.TotalSalary);
            var sortedByTotalBonus = result.OrderBy(item => -item.BonusSalary);
            string TSND = "";
            string TSVD = "";
            string TBND = "";
            string TBVD = "";
            int size, iterationNumber;

            ViewBag.EmployeeTotalSalary = sortedByTotalSalary;

            TSND += "[";
            TSVD += "[";
            size = sortedByTotalSalary.Count();
            iterationNumber = 0;
            foreach (var item in sortedByTotalSalary)
            {
                if (iterationNumber++ < size - 1)
                {
                    TSND += "\"" + item.EmployeeName + "\",";
                    TSVD += item.TotalSalary + ",";
                }
                else
                {
                    TSND += "\"" + item.EmployeeName + "\"";
                    TSVD += item.TotalSalary;
                }
                
            }
            TSND += "]";
            TSVD += "]";

            TBND += "[";
            TBVD += "[";
            foreach (var item in sortedByTotalSalary)
            {
                TBND += "\"" + item.EmployeeName + "\",";
                TBVD += item.BonusSalary + ",";
            }
            TBND += "]";
            TBVD += "]";


            ViewBag.totalSalaryChartNameData = TSND;
            ViewBag.totalSalaryChartValueData = TSVD;
            ViewBag.totalBonusChartNameData = TBND;
            ViewBag.totalBonusChartNameData = TBVD;
            Console.WriteLine("Result received");
            Console.WriteLine("aa*****************************");
            Console.WriteLine("aa*****************************");
            //return View(result);
            return View();
        }
    }
}
