using HRM.Entity;
using HRM.Entity.DevAccessory;
using HRM.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class ChangeStatusController : Controller
    {
        // GET: ChangeStatus
        public ActionResult Index()
        {
            ViewBag.Employees = new ServiceFactory().Create<Employee>().GetAll();
            return View();
        }

        public ActionResult ChangeStatus(int? Id)
        {
            Employee emp = new ServiceFactory().Create<Employee>().Get(Id);
            ViewBag.EmployeeName = emp.EmployeeName;
            ViewBag.EmployeeId = emp.EmployeeId;
            ViewBag.Status = emp.Status;
            ViewBag.DateOfBirth = emp.DateofBirth;
            ViewBag.Email = emp.EmployeeEmail;
            ViewBag.ManagerId = emp.MGR;
            return View();
        }

        public ActionResult Change(int Id, string Status)
        {
            Employee emp = new ServiceFactory().Create<Employee>().Get(Id);
            emp.Status = Status;

            if (Debugger.IsAttached)
            {
                Output.Write("Inside ChangeStatus controller, employee is: ");
                Output.Write(emp.EmployeeId + " : " + emp.EmployeeName + " : " + emp.Status);
            }

            new ServiceFactory().Create<Employee>().Update(emp, emp.EmployeeId);
            return RedirectToAction("Index");
        }
    }
}