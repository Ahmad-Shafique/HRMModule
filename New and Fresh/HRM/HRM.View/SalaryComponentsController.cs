using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using HRM.View.Models;

namespace HRM.View
{
    public class SalaryComponentsController : Controller
    {
        private IDomainService<SalaryComponents> Service = new ServiceFactory().Create<SalaryComponents>();

        // GET: SalaryComponents
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        // GET: SalaryComponents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryComponents salaryComponents = Service.Get(id);
            if (salaryComponents == null)
            {
                return HttpNotFound();
            }
            return View(salaryComponents);
        }

        // GET: SalaryComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalaryComponentsId,ComponentName,ComponentValue,Type")] SalaryComponents salaryComponents)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(salaryComponents);
                return RedirectToAction("Index");
            }

            return View(salaryComponents);
        }

        // GET: SalaryComponents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryComponents salaryComponents = Service.Get(id);
            if (salaryComponents == null)
            {
                return HttpNotFound();
            }
            return View(salaryComponents);
        }

        // POST: SalaryComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalaryComponentsId,ComponentName,ComponentValue,Type")] SalaryComponents salaryComponents)
        {
            if (ModelState.IsValid)
            {
                SalaryComponents sc = Service.Get(salaryComponents.SalaryComponentsId);
                Service.Update(salaryComponents, sc.SalaryComponentsId);
                return RedirectToAction("Index");
            }
            return View(salaryComponents);
        }

        // GET: SalaryComponents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryComponents salaryComponents = Service.Get(id);
            if (salaryComponents == null)
            {
                return HttpNotFound();
            }
            return View(salaryComponents);
        }

        // POST: SalaryComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalaryComponents salaryComponents = Service.Get(id);
            Service.RemoveByEntity(salaryComponents);
            return RedirectToAction("Index");
        }


    }
}
