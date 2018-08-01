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

namespace HRM.View
{
    public class ProfileController : Controller
    {
        private HRMViewContext db = new HRMViewContext();

        // GET: Profile
        public ActionResult Index()
        {
            return View(db.EmployeeBios.ToList());
        }

        // GET: Profile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBio employeeBio = db.EmployeeBios.Find(id);
            if (employeeBio == null)
            {
                return HttpNotFound();
            }
            return View(employeeBio);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeBioId,EmployeeContactNo,EmployeeAddress,DateofBirth,HireDate,Intro,Objectives,Hobbies,Interests,Certificates,JobExperience,Eduction,EmployeeId,Image")] EmployeeBio employeeBio)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeBios.Add(employeeBio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeBio);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBio employeeBio = db.EmployeeBios.Find(id);
            if (employeeBio == null)
            {
                return HttpNotFound();
            }
            return View(employeeBio);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeBioId,EmployeeContactNo,EmployeeAddress,DateofBirth,HireDate,Intro,Objectives,Hobbies,Interests,Certificates,JobExperience,Eduction,EmployeeId,Image")] EmployeeBio employeeBio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeBio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeBio);
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBio employeeBio = db.EmployeeBios.Find(id);
            if (employeeBio == null)
            {
                return HttpNotFound();
            }
            return View(employeeBio);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeBio employeeBio = db.EmployeeBios.Find(id);
            db.EmployeeBios.Remove(employeeBio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
