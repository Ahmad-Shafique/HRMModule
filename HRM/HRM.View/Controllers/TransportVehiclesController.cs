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
    public class TransportVehiclesController : Controller
    {
        private IDomainService<TransportVehicle> Service = new ServiceFactory().Create<TransportVehicle>();


        // GET: TransportVehicles
        public ActionResult Index()
        {
            return View(Service.GetAll());
        }

        // GET: TransportVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportVehicle transportVehicle = Service.Get(id);
            if (transportVehicle == null)
            {
                return HttpNotFound();
            }
            return View(transportVehicle);
        }

        // GET: TransportVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportVehicleId,VehicleNumber,DriverName,Capacity,status")] TransportVehicle transportVehicle)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(transportVehicle);
                return RedirectToAction("Index");
            }

            return View(transportVehicle);
        }

        // GET: TransportVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportVehicle transportVehicle = Service.Get(id);
            if (transportVehicle == null)
            {
                return HttpNotFound();
            }
            return View(transportVehicle);
        }

        // POST: TransportVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportVehicleId,VehicleNumber,DriverName,Capacity,status")] TransportVehicle transportVehicle)
        {
            if (ModelState.IsValid)
            {
                Service.Update(transportVehicle, transportVehicle.TransportVehicleId);
                return RedirectToAction("Index");
            }
            return View(transportVehicle);
        }

        // GET: TransportVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransportVehicle transportVehicle = Service.Get(id);
            if (transportVehicle == null)
            {
                return HttpNotFound();
            }
            return View(transportVehicle);
        }

        // POST: TransportVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransportVehicle transportVehicle = Service.Get(id);
            Service.RemoveByEntity(transportVehicle);
            return RedirectToAction("Index");
        }
    }
}
