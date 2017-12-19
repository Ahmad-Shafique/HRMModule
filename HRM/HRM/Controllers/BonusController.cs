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
    public class BonusController : Controller
    {
        private IDomainService<Bonus> service = new ServiceFactory().Create<Bonus>();

        // GET: Bonus
        public  ActionResult> Index()
        {
            return View( service.GetAll());
        }

        // GET: Bonus/Details/5
        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus =  service.Get(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // GET: Bonus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bonus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Create([Bind(Include = "BonusId,BonusValue,BonusTime")] Bonus bonus)
        {
            if (ModelState.IsValid)
            {
                 service.Insert(bonus);
                return RedirectToAction("Index");
            }

            return View(bonus);
        }

        // GET: Bonus/Edit/5
        public  ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus =  service.Get(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // POST: Bonus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Edit([Bind(Include = "BonusId,BonusValue,BonusTime")] Bonus bonus)
        {
            if (ModelState.IsValid)
            {
                Bonus temp =  service.Get(bonus.BonusId);
                 service.RemoveByEntity(temp);
                 service.Insert(bonus);
            }
            ////////return View(bonus);
            return RedirectToAction("Index");
        }

        // GET: Bonus/Delete/5
        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bonus bonus =  service.Get(id);
            if (bonus == null)
            {
                return HttpNotFound();
            }
            return View(bonus);
        }

        // POST: Bonus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            Bonus item =  service.Get(id);
             service.RemoveByEntity(item);
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
