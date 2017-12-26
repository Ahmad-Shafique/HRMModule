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
    public class ChangeStatusController : Controller
    {
        private IDomainService<Employee> Service = new ServiceFactory().Create<Employee>();

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
            Employee emp = Service.Get(Id);
            emp.Status = Status;
            Service.Update(emp, emp.EmployeeId);
            return RedirectToAction("Index");
        }
    }
}