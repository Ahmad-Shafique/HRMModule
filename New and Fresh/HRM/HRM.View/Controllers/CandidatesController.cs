using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class CandidatesController : Controller
    {
        IDomainService<TemporaryCV> CandidatesService = new ServiceFactory().Create<TemporaryCV>();
        // GET: TemporaryCVs
        public ActionResult Index()
        {
            return View(CandidatesService.GetAll());
        }

        // GET: TemporaryCVs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryCV temporaryCV = CandidatesService.Get(id);
            if (temporaryCV == null)
            {
                return HttpNotFound();
            }
            return View(temporaryCV);
        }

        // GET: TemporaryCVs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TemporaryCVs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemporaryCVId,CandidateName,CVLink,IntervieweeScore,HireThreadId,Status")] TemporaryCV temporaryCV)
        {
            if (ModelState.IsValid)
            {
                CandidatesService.Insert(temporaryCV);
                return RedirectToAction("Index");
            }

            return View(temporaryCV);
        }

        // GET: TemporaryCVs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryCV temporaryCV = CandidatesService.Get(id);
            if (temporaryCV == null)
            {
                return HttpNotFound();
            }
            return View(temporaryCV);
        }

        // POST: TemporaryCVs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TemporaryCVId,CandidateName,CVLink,IntervieweeScore,HireThreadId,Status")] TemporaryCV temporaryCV)
        {
            if (ModelState.IsValid)
            {
                CandidatesService.Update(temporaryCV, temporaryCV.TemporaryCVId);
                return RedirectToAction("Index");
            }
            return View(temporaryCV);
        }

        // GET: TemporaryCVs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryCV temporaryCV = CandidatesService.Get(id);
            if (temporaryCV == null)
            {
                return HttpNotFound();
            }
            return View(temporaryCV);
        }

        // POST: TemporaryCVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemporaryCV temporaryCV = CandidatesService.Get(id);
            CandidatesService.RemoveByEntity(temporaryCV);
            return RedirectToAction("Index");
        }
    }
}