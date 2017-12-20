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
    public class LoginController : Controller
    {
        IDomainService<Employee> Service = new ServiceFactory().Create<Employee>();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerifyUser(FormCollection collection)
        {
            Employee employee = Service.Get(collection["Id"]);
            if(employee.EmployeeId == Int32.Parse(collection["Id"])  &&  (employee.EmployeePassword == collection["Password"])){
                if(employee.Status == "active" || employee.Status == "onLeave")
                {
                    Session["Id"] = employee.EmployeeId;
                    Session["Name"] = employee.EmployeeName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Console.WriteLine("Insufficient privilege");
                }

            }
            else
            {
                Console.WriteLine("Unable to log in !!!");
            }
            return RedirectToAction("Index");
        }



        
    }
}
