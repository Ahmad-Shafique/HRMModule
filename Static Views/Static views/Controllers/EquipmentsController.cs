using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRM.Entity;

namespace Static_views.Controllers
{
    public class EquipmentsController : Controller
    {
        // GET: Equipments
        public ActionResult Index()
        {
            ViewBag.Departments = Data.DummyData.Departments();
            return View();
        }

        public ActionResult Equip(int? Id)
        {
            ViewBag.Equipments = Data.DummyData.Equipments();
            Department dept = Data.DummyData.Departments().SingleOrDefault(item => item.DepartmentId == Id);
            ViewBag.DepartmentName = dept.DepartmentName;

            return View();
        }

    }
}
