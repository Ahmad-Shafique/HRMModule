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
        public async Task<ActionResult> Index()
        {
            return View(await service.GetAll());
        }

        // GET: CircularTemplates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CircularTemplate circularTemplate =  await service.Get(id);
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
        public async Task<ActionResult> Create([Bind(Include = "CircularTemplateId,TemplateName,Template")] CircularTemplate circularTemplate)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(circularTemplate);
                return RedirectToAction("Index");
            }

            return View(circularTemplate);
        }

        // GET: CircularTemplates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CircularTemplate circularTemplate = await service.Get(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "CircularTemplateId,TemplateName,Template")] CircularTemplate circularTemplate)
        {
            if (ModelState.IsValid)
            {
                CircularTemplate temp = await service.Get(circularTemplate.CircularTemplateId);
                await service.RemoveByEntity(temp);
                await service.Insert(circularTemplate);
            }
            return View(circularTemplate);
        }

        // GET: CircularTemplates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CircularTemplate circularTemplate = await service.Get(id);
            if (circularTemplate == null)
            {
                return HttpNotFound();
            }
            return View(circularTemplate);
        }

        // POST: CircularTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CircularTemplate circularTemplate = await service.Get(id);
            await service.RemoveByEntity(circularTemplate);
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
