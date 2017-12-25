using HRM.Entity;
using HRM.Entity.Accessory;
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
        //IDomainService<Employee> Service = new ServiceFactory().Create<Employee>();
        ICommonViewService Service = ServiceFactory.GetCommonViewService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerifyUser(FormCollection collection)
        {
            var obj = Service.Authenticate(Int32.Parse(collection["Id"]), collection["Password"]);

            if (obj.Id  != 0 )
            {
                if (obj.ViewAccessCode>0)
                {
                    Session["Id"] = obj.Id;
                    Session["Name"] = obj.Name;
                    Session["Image"] = obj.Image;
                    Session["Token"] = obj.Token;
                    Session["DisplayAccess"] = obj.ViewAccessCode;
                    return RedirectToAction("Display", "Employees");
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


            //Employee employee = Service.Get(collection["Id"]);
            //if (employee.EmployeeId == Int32.Parse(collection["Id"]) && (employee.EmployeePassword == collection["Password"]))
            //{
            //    if (employee.Status == "active" || employee.Status == "onLeave")
            //    {
            //        Session["Id"] = employee.EmployeeId;
            //        Session["Name"] = employee.EmployeeName;
            //        return RedirectToAction("Display", "Employees");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Insufficient privilege");
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Unable to log in !!!");
            //}
            return RedirectToAction("Index");
        }



        
    }
}
