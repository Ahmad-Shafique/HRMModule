using HRM.Entity;
using HRM.Entity.DevAccessory;
using HRM.Entity.Facade;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class SalaryPaymentsController : Controller
    {
        private ICommonViewService Service = ServiceFactory.GetCommonViewService();
        private IDomainService<EmployeeSalary> SalaryPaymentService = new ServiceFactory().Create<EmployeeSalary>();
        // GET: SalaryPayment
        public ActionResult Index()
        {
            Console.WriteLine("Entered salary payments display");

            ViewBag.Employees = Service.Test();
            var result = Service.CalculateAllEmployeeTotalSalary();
            var sortedByTotalSalary = result.OrderBy(item => -item.TotalSalary);
            var sortedByTotalBonus = result.OrderBy(item => -item.BonusSalary);
            string TSND = "";
            string TSVD = "";
            string TBND = "";
            string TBVD = "";
            int size, iterationNumber;

            ViewBag.EmployeeTotalSalary = sortedByTotalSalary;

            //TSND += "[";
            //TSVD += "[";
            size = sortedByTotalSalary.Count();
            iterationNumber = 0;
            foreach (var item in sortedByTotalSalary)
            {
                if (iterationNumber >= 5) break;
                if (iterationNumber++ < size - 1)
                {
                    TSND += item.EmployeeName + ",";
                    //TSND += "\"" + item.EmployeeName + "\",";
                    TSVD += item.TotalSalary + ",";
                }
                else
                {
                    //TSND += "\"" + item.EmployeeName + "\"";
                    TSND += item.EmployeeName;
                    TSVD += item.TotalSalary;
                }
            }
            //TSND += "]";
            //TSVD += "]";

            TBND += "[";
            TBVD += "[";
            iterationNumber = 0;
            foreach (var item in sortedByTotalSalary)
            {
                if (iterationNumber >= 5) break;
                if (iterationNumber++ < size - 1)
                {
                    TBND += item.EmployeeName + ",";
                    //TSND += "\"" + item.EmployeeName + "\",";
                    TBVD += item.BonusSalary + ",";
                }
                else
                {
                    //TSND += "\"" + item.EmployeeName + "\"";
                    TBND += item.EmployeeName;
                    TBVD += item.BonusSalary;
                }
            }
            TBND += "]";
            TBVD += "]";


            ViewBag.totalSalaryChartNameData = TSND;
            ViewBag.totalSalaryChartValueData = TSVD;
            ViewBag.totalBonusChartNameData = TBND;
            ViewBag.totalBonusChartValueData = TBVD;
            Console.WriteLine("Result received");
            Console.WriteLine("aa*****************************");
            Console.WriteLine("aa*****************************");
            //return View(result);
            return View();
        }

        public ActionResult IndividualSalaryInfo(int? id)
        {
                ViewBag.Result = Service.CalculateAllEmployeeTotalSalary().Where(item => item.EmployeeId == id);
                ViewBag.SalaryComponents = new ServiceFactory().Create<SalaryComponents>().GetAll();
                
                return View();
        }

        public ActionResult PaySalary(int? id, int totalSalary)
        {
            if(id.HasValue)
            {
                
                EmployeeSalary employeeSalary = SalaryPaymentService.Get(id);
                employeeSalary.TotalSalary = totalSalary;

                if (Debugger.IsAttached)
                {
                    Output.Write("Id value for employeeSalary is : " + id.Value);
                }
               
                SalaryPaymentService.Update(employeeSalary, id.Value);
            }
            return RedirectToAction("Index");
        }
    }
}
