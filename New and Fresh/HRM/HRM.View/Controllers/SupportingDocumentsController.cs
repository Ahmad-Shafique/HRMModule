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
    public class SupportingDocumentsController : Controller
    {
        public static int MainId;
        private IDomainService<SupportingDocument> Service = new ServiceFactory().Create<SupportingDocument>();

        // GET: SupportingDocuments
        public ActionResult Index(int? MainId)
        {
            if(MainId != null) SupportingDocumentsController.MainId = Int32.Parse(MainId.ToString());
            return View(Service.GetAll().Where(item => item.LeaveApplicationId == SupportingDocumentsController.MainId));
        }

        // GET: SupportingDocuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportingDocument supportingDocument = Service.Get(id);
            if (supportingDocument == null)
            {
                return HttpNotFound();
            }
            return View(supportingDocument);
        }

        // GET: SupportingDocuments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupportingDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupportingDocumentId,SupportingDocumentName,SupportingDocumentLink,LeaveApplicationId")] SupportingDocument supportingDocument)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(supportingDocument);
                return RedirectToAction("Index");
            }

            return View(supportingDocument);
        }

        // GET: SupportingDocuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportingDocument supportingDocument = Service.Get(id);
            if (supportingDocument == null)
            {
                return HttpNotFound();
            }
            return View(supportingDocument);
        }

        // POST: SupportingDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupportingDocumentId,SupportingDocumentName,SupportingDocumentLink,LeaveApplicationId")] SupportingDocument supportingDocument)
        {
            if (ModelState.IsValid)
            {
                Service.Update(supportingDocument, supportingDocument.SupportingDocumentId);
                return RedirectToAction("Index");
            }
            return View(supportingDocument);
        }

        // GET: SupportingDocuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportingDocument supportingDocument = Service.Get(id);
            if (supportingDocument == null)
            {
                return HttpNotFound();
            }
            return View(supportingDocument);
        }

        // POST: SupportingDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupportingDocument supportingDocument = Service.Get(id);
            Service.RemoveByEntity(supportingDocument);
            return RedirectToAction("Index");
        }
    }
}
