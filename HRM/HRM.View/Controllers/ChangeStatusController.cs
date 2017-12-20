using HRM.Entity;
using HRM.Service;
using System;
using System.Collections.Generic;
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
            ViewBag.Employee = emp;
            return View();
        }

        public ActionResult Change(int Id, string Status)
        {
            Employee emp = new ServiceFactory().Create<Employee>().Get(Id);
            emp.Status = Status;
            new ServiceFactory().Create<Employee>().Update(emp, emp.EmployeeId);
            return RedirectToAction("Index");
        }
    }
}