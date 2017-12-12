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
        public async Task<ActionResult> Index()
        {
            return View(await service.GetAll());

        }

        // GET: DepartmentDesignations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentDesignation departmentDesignation = await service.Get(id);
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
        public async Task<ActionResult> Create([Bind(Include = "DepartmentDesignationId,DepartmentId,DesignationId")] DepartmentDesignation departmentDesignation)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(departmentDesignation);
                return RedirectToAction("Index");
            }

            return View(departmentDesignation);
        }

        // GET: DepartmentDesignations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentDesignation departmentDesignation = await service.Get(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "DepartmentDesignationId,DepartmentId,DesignationId")] DepartmentDesignation departmentDesignation)
        {
            if (ModelState.IsValid)
            {
                DepartmentDesignation temp = await service.Get(departmentDesignation.DepartmentDesignationId);
                await service.RemoveByEntity(temp);
                await service.Insert(departmentDesignation);
            }
            return View(departmentDesignation);
        }

        // GET: DepartmentDesignations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentDesignation departmentDesignation = await service.Get(id);
            if (departmentDesignation == null)
            {
                return HttpNotFound();
            }
            return View(departmentDesignation);
        }

        // POST: DepartmentDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DepartmentDesignation item = await service.Get(id);
            await service.RemoveByEntity(item);
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
