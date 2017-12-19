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

namespace HRM.Controllers
{
    public class EmployeePrivilegesController : Controller
    {
        private HRMDbContext db = new HRMDbContext();

        // GET: EmployeePrivileges
        public  ActionResult> Index()
        {
            return View( db.EmployeePrivileges.ToList());
        }

        // GET: EmployeePrivileges/Details/5
        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePrivilege employeePrivilege =  db.EmployeePrivileges.Find(id);
            if (employeePrivilege == null)
            {
                return HttpNotFound();
            }
            return View(employeePrivilege);
        }

        // GET: EmployeePrivileges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeePrivileges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Create([Bind(Include = "EmployeePrivilegeId,EmployeeId,PrivilegeId")] EmployeePrivilege employeePrivilege)
        {
            if (ModelState.IsValid)
            {
                db.EmployeePrivileges.Add(employeePrivilege);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeePrivilege);
        }

        // GET: EmployeePrivileges/Edit/5
        public  ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePrivilege employeePrivilege =  db.EmployeePrivileges.Find(id);
            if (employeePrivilege == null)
            {
                return HttpNotFound();
            }
            return View(employeePrivilege);
        }

        // POST: EmployeePrivileges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Edit([Bind(Include = "EmployeePrivilegeId,EmployeeId,PrivilegeId")] EmployeePrivilege employeePrivilege)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeePrivilege).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeePrivilege);
        }

        // GET: EmployeePrivileges/Delete/5
        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePrivilege employeePrivilege =  db.EmployeePrivileges.Find(id);
            if (employeePrivilege == null)
            {
                return HttpNotFound();
            }
            return View(employeePrivilege);
        }

        // POST: EmployeePrivileges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            EmployeePrivilege employeePrivilege =  db.EmployeePrivileges.Find(id);
            db.EmployeePrivileges.Remove(employeePrivilege);
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
