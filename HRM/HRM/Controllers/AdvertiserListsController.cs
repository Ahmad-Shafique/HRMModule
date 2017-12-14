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
        public async Task<ActionResult> Index()
        {
            //return View(await db.AdvertiserLists.ToListAsync());
            return View(await service.GetAll());
        }

        // GET: AdvertiserLists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertiserList advertiserList = await service.Get(id);
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
        public async Task<ActionResult> Create([Bind(Include = "AdvertiserListId,AdvertiserName,Description,ContactInfo")] AdvertiserList advertiserList)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(advertiserList);
                return RedirectToAction("Index");
            }

            return View(advertiserList);
        }

        // GET: AdvertiserLists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            Console.WriteLine(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertiserList advertiserList = await service.Get(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "AdvertiserListId,AdvertiserName,Description,ContactInfo")] AdvertiserList advertiserList)
        {
            if (ModelState.IsValid)
            {
                //AdvertiserList temp = await service.Get(advertiserList.AdvertiserListId);
                //await service.RemoveByEntity(temp);
                //await service.Insert(advertiserList);

                await service.Update(advertiserList,advertiserList.AdvertiserListId);


                return RedirectToAction("Index");
            }
            return View(advertiserList);
        }

        // GET: AdvertiserLists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvertiserList advertiserList = await service.Get(id);
            if (advertiserList == null)
            {
                return HttpNotFound();
            }
            return View(advertiserList);
        }

        // POST: AdvertiserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AdvertiserList item = await service.Get(id);
            bool x = await service.RemoveByEntity(item);
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
