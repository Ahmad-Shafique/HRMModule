using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Entity;
using HRM.View.Models;
using HRM.Service.Interfaces;
using HRM.Service;

namespace HRM.View.Controllers
{
    public class LeaveApplicationCategoriesController : Controller
    {
        private IDomainService<LeaveApplicationCategory> Service = new ServiceFactory().Create<LeaveApplicationCategory>();

        // GET: LeaveApplicationCategories
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        // GET: LeaveApplicationCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplicationCategory leaveApplicationCategory = Service.Get(id);
            if (leaveApplicationCategory == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplicationCategory);
        }

        // GET: LeaveApplicationCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveApplicationCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveApplicationCategoryId,LeaveApplicationCategoryName")] LeaveApplicationCategory leaveApplicationCategory)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(leaveApplicationCategory);
                return RedirectToAction("Index");
            }

            return View(leaveApplicationCategory);
        }

        // GET: LeaveApplicationCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplicationCategory leaveApplicationCategory = Service.Get(id);
            if (leaveApplicationCategory == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplicationCategory);
        }

        // POST: LeaveApplicationCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveApplicationCategoryId,LeaveApplicationCategoryName")] LeaveApplicationCategory leaveApplicationCategory)
        {
            if (ModelState.IsValid)
            {
                Service.Update(leaveApplicationCategory, leaveApplicationCategory.LeaveApplicationCategoryId);
                return RedirectToAction("Index");
            }
            return View(leaveApplicationCategory);
        }

        // GET: LeaveApplicationCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplicationCategory leaveApplicationCategory = Service.Get(id);
            if (leaveApplicationCategory == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplicationCategory);
        }

        // POST: LeaveApplicationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveApplicationCategory leaveApplicationCategory = Service.Get(id);
            Service.RemoveByEntity(leaveApplicationCategory);
            return RedirectToAction("Index");
        }
    }
}
