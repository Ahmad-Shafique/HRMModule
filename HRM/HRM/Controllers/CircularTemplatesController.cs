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
    public class CircularTemplatesController : Controller
    {
        private IDomainService<CircularTemplate> service = new ServiceFactory().Create<CircularTemplate>();

        // GET: CircularTemplates
        public  ActionResult> Index()
        {
            return View( service.GetAll());
        }

        // GET: CircularTemplates/Details/5
        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CircularTemplate circularTemplate =   service.Get(id);
            if (circularTemplate == null)
            {
                return HttpNotFound();
            }
            return View(circularTemplate);
        }

        // GET: CircularTemplates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CircularTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Create([Bind(Include = "CircularTemplateId,TemplateName,Template")] CircularTemplate circularTemplate)
        {
            if (ModelState.IsValid)
            {
                 service.Insert(circularTemplate);
                return RedirectToAction("Index");
            }

            return View(circularTemplate);
        }

        // GET: CircularTemplates/Edit/5
        public  ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CircularTemplate circularTemplate =  service.Get(id);
            if (circularTemplate == null)
            {
                return HttpNotFound();
            }
            return View(circularTemplate);
        }

        // POST: CircularTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Edit([Bind(Include = "CircularTemplateId,TemplateName,Template")] CircularTemplate circularTemplate)
        {
            if (ModelState.IsValid)
            {
                CircularTemplate temp =  service.Get(circularTemplate.CircularTemplateId);
                 service.RemoveByEntity(temp);
                 service.Insert(circularTemplate);
            }
            return View(circularTemplate);
        }

        // GET: CircularTemplates/Delete/5
        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CircularTemplate circularTemplate =  service.Get(id);
            if (circularTemplate == null)
            {
                return HttpNotFound();
            }
            return View(circularTemplate);
        }

        // POST: CircularTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            CircularTemplate circularTemplate =  service.Get(id);
             service.RemoveByEntity(circularTemplate);
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
