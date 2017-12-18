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
    public class EquipmentsController : Controller
    {
        private IDomainService<Department> DepartmentService = new ServiceFactory().Create<Department>();
        private IDomainService<Equipment> EquipmentService = new ServiceFactory().Create<Equipment>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        // GET: Equipments
        public ActionResult Index()
        {
            ViewBag.Departments = DepartmentService.GetAll().Result;
            return View();
        }

        public ActionResult Equip(int? Id)
        {
            ViewBag.Equipments = EquipmentService.GetAll().Result;
            Department dept = DepartmentService.GetAll().Result.SingleOrDefault(item => item.DepartmentId == Id);
            ViewBag.DepartmentName = dept.DepartmentName;

            return View();
        }
    }
}
