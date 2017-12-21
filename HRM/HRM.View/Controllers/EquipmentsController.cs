using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        public  ActionResult Index()
        {
            ViewBag.Departments = DepartmentService.GetAll();
            return View();
        }

        public  ActionResult Equip(int? Id)
        {
            ViewBag.Equipments = EquipmentService.GetAll();
            Department dept =  DepartmentService.Get(Id);
            ViewBag.DepartmentName = dept.DepartmentName;
            ViewBag.DepartmentId = dept.DepartmentId;

            return View();
        }

        public ActionResult Manage()
        {

            return View(EquipmentService.GetAll());
        }

        // GET: Equipments1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = EquipmentService.Get(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // GET: Equipments1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipments1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipmentId,EquipmentTypeId,Status,BuyPrice")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                EquipmentService.Insert(equipment);
                return RedirectToAction("Manage");
            }

            return View(equipment);
        }

        // GET: Equipments1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = EquipmentService.Get(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipmentId,EquipmentTypeId,Status,BuyPrice")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                EquipmentService.Update(equipment, equipment.EquipmentId);
                return RedirectToAction("Manage");
            }
            return View(equipment);
        }

        // GET: Equipments1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipment equipment = EquipmentService.Get(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        // POST: Equipments1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = EquipmentService.Get(id);
            EquipmentService.RemoveByEntity(equipment);
            return RedirectToAction("Manage");
        }
    }
}
