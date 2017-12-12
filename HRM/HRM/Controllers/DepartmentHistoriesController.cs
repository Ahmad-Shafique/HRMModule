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
    public class DepartmentHistoriesController : Controller
    {
        private IDomainService<DepartmentHistory> service = new ServiceFactory().Create<DepartmentHistory>();

        // GET: DepartmentHistories
        public async Task<ActionResult> Index()
        {
            return View(await service.GetAll());
        }

        // GET: DepartmentHistories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentHistory departmentHistory = await service.Get(id);
            if (departmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(departmentHistory);
        }

        // GET: DepartmentHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DepartmentHistoryId,ColumnName,PreviousValue,NewValue,Date,DepartmentId")] DepartmentHistory departmentHistory)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(departmentHistory);
                return RedirectToAction("Index");
            }

            return View(departmentHistory);
        }

        // GET: DepartmentHistories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentHistory departmentHistory = await service.Get(id);
            if (departmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(departmentHistory);
        }

        // POST: DepartmentHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DepartmentHistoryId,ColumnName,PreviousValue,NewValue,Date,DepartmentId")] DepartmentHistory departmentHistory)
        {
            if (ModelState.IsValid)
            {
                DepartmentHistory temp = await service.Get(departmentHistory.DepartmentHistoryId);
                await service.RemoveByEntity(temp);
                await service.Insert(departmentHistory);
            }
            return RedirectToAction("Index");
        }

        // GET: DepartmentHistories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentHistory departmentHistory = await service.Get(id);
            if (departmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(departmentHistory);
        }

        // POST: DepartmentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DepartmentHistory item = await service.Get(id);
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
