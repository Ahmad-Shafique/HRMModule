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
    public class BonusesController : Controller
    {
        private IDomainService<Bonuses> service = new ServiceFactory().Create<Bonuses>();

        // GET: Bonuses
        public async Task<ActionResult> Index()
        {
            return View(await service.GetAll());
        }

        // GET: Bonuses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonuses bonuses = await service.Get(id);
            if (bonuses == null)
            {
                return HttpNotFound();
            }
            return View(bonuses);
        }

        // GET: Bonuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bonuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BonusesId,BonusId,BonusValue,BonusDescription,BonusesDate")] Bonuses bonuses)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(bonuses);
                return RedirectToAction("Index");
            }

            return View(bonuses);
        }

        // GET: Bonuses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonuses bonuses = await service.Get(id);
            if (bonuses == null)
            {
                return HttpNotFound();
            }
            return View(bonuses);
        }

        // POST: Bonuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BonusesId,BonusId,BonusValue,BonusDescription,BonusesDate")] Bonuses bonuses)
        {
            if (ModelState.IsValid)
            {
                Bonuses temp = await service.Get(bonuses.BonusesId);
                await service.RemoveByEntity(temp);
                await service.Insert(bonuses);
            }
            return View(bonuses);
        }

        // GET: Bonuses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonuses bonuses = await service.Get(id);
            if (bonuses == null)
            {
                return HttpNotFound();
            }
            return View(bonuses);
        }

        // POST: Bonuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bonuses item = await service.Get(id);
            bool x = await service.RemoveByEntity(item);
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
