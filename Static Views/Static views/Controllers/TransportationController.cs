using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Static_views.Controllers
{
    public class TransportationController : Controller
    {
        // GET: Transportation
        public ActionResult Index()
        {
            ViewBag.areas = Data.DummyData.TransportAreas();
            
            
            return View();
        }

        public ActionResult Area(int? AreaId)
        {
            ViewBag.Employees = Data.DummyData.Employees().Where(e => e.AreaId == AreaId);
            ViewBag.vehicles = Data.DummyData.TransportVehicles();
            TransportArea t = Data.DummyData.TransportAreas().SingleOrDefault(area => area.TransportAreaId == AreaId);
            if(t == null)
            {
                t = new TransportArea();
                t.AreaDemand = 50;
                t.AreaName = "Mohakhali";
            }
            ViewBag.AreaDemand = t.AreaDemand;
            ViewBag.CurrentCapacity = 5;
            ViewBag.AreaName = t.AreaName;



            return View();


        }

        //// GET: Transportation/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Transportation/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Transportation/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Transportation/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Transportation/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Transportation/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Transportation/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
