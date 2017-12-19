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
    public class AdvertiserListsController : Controller
    {
        //private HRMDbContext db = new HRMDbContext();

        private IDomainService<AdvertiserList> service = new ServiceFactory().Create<AdvertiserList>();

        // GET: AdvertiserLists
        public  ActionResult> Index()
        {
            //return View( db.AdvertiserLists.ToList());
            return View( service.GetAll());
        }

        // GET: AdvertiserLists/Details/5
        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertiserList advertiserList =  service.Get(id);
            if (advertiserList == null)
            {
                return HttpNotFound();
            }
            return View(advertiserList);
        }

        // GET: AdvertiserLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertiserLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Create([Bind(Include = "AdvertiserListId,AdvertiserName,Description,ContactInfo")] AdvertiserList advertiserList)
        {
            if (ModelState.IsValid)
            {
                 service.Insert(advertiserList);
                return RedirectToAction("Index");
            }

            return View(advertiserList);
        }

        // GET: AdvertiserLists/Edit/5
        public  ActionResult> Edit(int? id)
        {
            Console.WriteLine(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertiserList advertiserList =  service.Get(id);
            if (advertiserList == null)
            {
                return HttpNotFound();
            }
            return View(advertiserList);
        }

        // POST: AdvertiserLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult> Edit([Bind(Include = "AdvertiserListId,AdvertiserName,Description,ContactInfo")] AdvertiserList advertiserList)
        {
            if (ModelState.IsValid)
            {
                //AdvertiserList temp =  service.Get(advertiserList.AdvertiserListId);
                // service.RemoveByEntity(temp);
                // service.Insert(advertiserList);

                 service.Update(advertiserList,advertiserList.AdvertiserListId);


                return RedirectToAction("Index");
            }
            return View(advertiserList);
        }

        // GET: AdvertiserLists/Delete/5
        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertiserList advertiserList =  service.Get(id);
            if (advertiserList == null)
            {
                return HttpNotFound();
            }
            return View(advertiserList);
        }

        // POST: AdvertiserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            AdvertiserList item =  service.Get(id);
            bool x =  service.RemoveByEntity(item);
            return RedirectToAction("Index");
        }

        /*
         * Find out what it does
         * 
         * */
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
