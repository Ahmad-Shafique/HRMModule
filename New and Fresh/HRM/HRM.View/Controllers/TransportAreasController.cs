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
    public class TransportAreasController : Controller
    {
        private IDomainService<TransportArea> Service = new ServiceFactory().Create<TransportArea>();




        // GET: TransportAreas
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        // GET: TransportAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportArea transportArea = Service.Get(id);
            if (transportArea == null)
            {
                return HttpNotFound();
            }
            return View(transportArea);
        }

        // GET: TransportAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportAreaId,AreaName,Description,AreaDemand,AssignedCapacity")] TransportArea transportArea)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(transportArea);
                return RedirectToAction("Index");
            }

            return View(transportArea);
        }

        // GET: TransportAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportArea transportArea = Service.Get(id);
            if (transportArea == null)
            {
                return HttpNotFound();
            }
            return View(transportArea);
        }

        // POST: TransportAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportAreaId,AreaName,Description,AreaDemand,AssignedCapacity")] TransportArea transportArea)
        {
            if (ModelState.IsValid)
            {
                Service.Update(transportArea, transportArea.TransportAreaId);
                return RedirectToAction("Index");
            }
            return View(transportArea);
        }

        // GET: TransportAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportArea transportArea = Service.Get(id);
            if (transportArea == null)
            {
                return HttpNotFound();
            }
            return View(transportArea);
        }

        // POST: TransportAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportArea transportArea = Service.Get(id);
            Service.RemoveByEntity(transportArea);
            return RedirectToAction("Index");
        }

    }
}
