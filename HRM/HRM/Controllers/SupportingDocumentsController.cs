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
using HRM.Service;
using HRM.Service.Interfaces;

namespace HRM.Controllers
{
    public class SupportingDocumentsController : Controller
    {
        private IDomainService<SupportingDocument> service = new ServiceFactory().Create<SupportingDocument>();


        public  ActionResult> Index()
        {
            return View( service.GetAll());
        }


        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportingDocument entity =  service.Get(id);

            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        // ****************************************************************************************************************************************************************
        public  ActionResult> Create([Bind(Include = "SupportingDocumentId,SupportingDocumentName,SupportingDocumentLink,LeaveApplicationId")] SupportingDocument entity)
        {
            if (ModelState.IsValid)
            {
                 service.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }


        public  ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportingDocument entity =  service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // ******************************************************************************************************************************************************************
        public  ActionResult> Edit([Bind(Include = "SupportingDocumentId,SupportingDocumentName,SupportingDocumentLink,LeaveApplicationId")] SupportingDocument entity)
        {
            if (ModelState.IsValid)
            {
                // **********************************************************************************************************************************************************
                SupportingDocument temp =  service.Get(entity.SupportingDocumentId);
                 service.RemoveByEntity(temp);
                 service.Insert(entity);
            }
            /////// return View(SupportingDocument);
            return RedirectToAction("Index");
        }


        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupportingDocument entity =  service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            SupportingDocument entity =  service.Get(id);
             service.RemoveByEntity(entity);
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
