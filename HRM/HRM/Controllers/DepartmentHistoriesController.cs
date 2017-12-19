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
        public  ActionResult> Index()
        {
            return View( service.GetAll());
        }

        // GET: DepartmentHistories/Details/5
        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentHistory departmentHistory =  service.Get(id);
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
        public  ActionResult> Create([Bind(Include = "DepartmentHistoryId,ColumnName,PreviousValue,NewValue,Date,DepartmentId")] DepartmentHistory departmentHistory)
        {
            if (ModelState.IsValid)
            {
                 service.Insert(departmentHistory);
                return RedirectToAction("Index");
            }

            return View(departmentHistory);
        }

        // GET: DepartmentHistories/Edit/5
        public  ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentHistory departmentHistory =  service.Get(id);
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
        public  ActionResult> Edit([Bind(Include = "DepartmentHistoryId,ColumnName,PreviousValue,NewValue,Date,DepartmentId")] DepartmentHistory departmentHistory)
        {
            if (ModelState.IsValid)
            {
                DepartmentHistory temp =  service.Get(departmentHistory.DepartmentHistoryId);
                 service.RemoveByEntity(temp);
                 service.Insert(departmentHistory);
            }
            return RedirectToAction("Index");
        }

        // GET: DepartmentHistories/Delete/5
        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentHistory departmentHistory =  service.Get(id);
            if (departmentHistory == null)
            {
                return HttpNotFound();
            }
            return View(departmentHistory);
        }

        // POST: DepartmentHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            DepartmentHistory item =  service.Get(id);
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
