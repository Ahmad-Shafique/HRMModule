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
    public class CompanyPoliciesController : Controller
    {
        private IDomainService<CompanyPolicy> Service = new ServiceFactory().Create<CompanyPolicy>();

        // GET: CompanyPolicies
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        // GET: CompanyPolicies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyPolicy companyPolicy = Service.Get(id);
            if (companyPolicy == null)
            {
                return HttpNotFound();
            }
            return View(companyPolicy);
        }

        // GET: CompanyPolicies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyPolicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyPolicyId,PolicyName,PolicyDescription")] CompanyPolicy companyPolicy)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(companyPolicy);
                return RedirectToAction("Index");
            }

            return View(companyPolicy);
        }

        // GET: CompanyPolicies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyPolicy companyPolicy = Service.Get(id);
            if (companyPolicy == null)
            {
                return HttpNotFound();
            }
            return View(companyPolicy);
        }

        // POST: CompanyPolicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyPolicyId,PolicyName,PolicyDescription")] CompanyPolicy companyPolicy)
        {
            if (ModelState.IsValid)
            {
                Service.Update(companyPolicy, companyPolicy.CompanyPolicyId);
                return RedirectToAction("Index");
            }
            return View(companyPolicy);
        }

        // GET: CompanyPolicies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyPolicy companyPolicy =Service.Get(id);
            if (companyPolicy == null)
            {
                return HttpNotFound();
            }
            return View(companyPolicy);
        }

        // POST: CompanyPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyPolicy companyPolicy = Service.Get(id);
            Service.RemoveByEntity(companyPolicy);
            return RedirectToAction("Index");
        }


        public ActionResult ViewPolicies()
        {
            return View(Service.GetAll());
        }

    }
}
