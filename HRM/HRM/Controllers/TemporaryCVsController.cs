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
    public class TemporaryCVsController : Controller
    {
        private IDomainService<TemporaryCV> service = new ServiceFactory().Create<TemporaryCV>();


        public async Task<ActionResult> Index()
        {
            return View(await service.GetAll());
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryCV entity = await service.Get(id);

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
        public async Task<ActionResult> Create([Bind(Include = "TemporaryCVId,CVLink,IntervieweeScore,HireThreadId")] TemporaryCV entity)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryCV entity = await service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // ******************************************************************************************************************************************************************
        public async Task<ActionResult> Edit([Bind(Include = "TemporaryCVId,CVLink,IntervieweeScore,HireThreadId")] TemporaryCV entity)
        {
            if (ModelState.IsValid)
            {
                // **********************************************************************************************************************************************************
                TemporaryCV temp = await service.Get(entity.TemporaryCVId);
                await service.RemoveByEntity(temp);
                await service.Insert(entity);
            }
            /////// return View(TemporaryCV);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemporaryCV entity = await service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TemporaryCV entity = await service.Get(id);
            await service.RemoveByEntity(entity);
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
