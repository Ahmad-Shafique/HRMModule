using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Data;
using HRM.Entity;
using HRM.Service.Interfaces;
using HRM.Service;

namespace HRM.Controllers
{
    public class DepartmentDesignationsController : Controller
    {
        private IDomainService<DepartmentDesignation> service = new ServiceFactory().Create<DepartmentDesignation>();

        // GET: DepartmentDesignations
        public  ActionResult> Index()
        {
            return View( service.GetAll());

        }

        // GET: DepartmentDesignations/Details/5
        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentDesignation departmentDesignation =  service.Get(id);
            if (departmentDesignation == null)
            {
                return HttpNotFound();
            }
            return View(departmentDesignation);
        }

        // GET: DepartmentDesignations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentDesignations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Create([Bind(Include = "DepartmentDesignationId,DepartmentId,DesignationId")] DepartmentDesignation departmentDesignation)
        {
            if (ModelState.IsValid)
            {
                 service.Insert(departmentDesignation);
                return RedirectToAction("Index");
            }

            return View(departmentDesignation);
        }

        // GET: DepartmentDesignations/Edit/5
        public  ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentDesignation departmentDesignation =  service.Get(id);
            if (departmentDesignation == null)
            {
                return HttpNotFound();
            }
            return View(departmentDesignation);
        }

        // POST: DepartmentDesignations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Edit([Bind(Include = "DepartmentDesignationId,DepartmentId,DesignationId")] DepartmentDesignation departmentDesignation)
        {
            if (ModelState.IsValid)
            {
                DepartmentDesignation temp =  service.Get(departmentDesignation.DepartmentDesignationId);
                 service.RemoveByEntity(temp);
                 service.Insert(departmentDesignation);
            }
            return View(departmentDesignation);
        }

        // GET: DepartmentDesignations/Delete/5
        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentDesignation departmentDesignation =  service.Get(id);
            if (departmentDesignation == null)
            {
                return HttpNotFound();
            }
            return View(departmentDesignation);
        }

        // POST: DepartmentDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            DepartmentDesignation item =  service.Get(id);
             service.RemoveByEntity(item);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
