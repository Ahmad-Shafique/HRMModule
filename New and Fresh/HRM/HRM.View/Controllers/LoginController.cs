using HRM.Entity;
using HRM.Entity.Accessory;
using HRM.Entity.DevAccessory;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            int id, xyz;
            string password;
            bool idPresent;

            idPresent = Int32.TryParse(collection["Id"], out xyz);

            if (idPresent && collection["Password"] != null)
            {
                id = Int32.Parse(collection["Id"]);
                password = collection["Password"];

                

                var obj = Service.Authenticate(id, password);

                if (obj.Id != 0)
                {
                    if (obj.ViewAccessCode > 0)
                    {
                        Session["Id"] = obj.Id;
                        Session["Name"] = obj.Name;
                        Session["Image"] = obj.Image;
                        Session["Token"] = obj.Token;
                        Session["DisplayAccess"] = obj.ViewAccessCode;
                        Session["HireDate"] = obj.HireDate.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                        //Output.Write("Hire date is: " + Session["HireDate"].ToString());
                        Session["EmployeeBioId"] = obj.EmployeeBioId;
                        Session["WorkDay"] = obj.Working;
                        Session["Department"] = obj.DepartmentId;
                        if (obj.ViewAccessCode == 2)
                        {
                            Session["DepartmentId"] = obj.DepartmentId;
                        }
                        if (obj.ViewAccessCode == 1) return RedirectToAction("Index", "Notices");
                        else return RedirectToAction("Display", "Employees");
                    }
                    else
                    {
                        Output.Write("Insufficient privilege");
                    }

                }
                else
                {
                    Output.Write("Unable to log in !!!");
                }
            }
            else
            {
                Output.WriteLine("Incorrect username or password");
            }


            
            return RedirectToAction("Index");
        }


        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }



        
    }
}
