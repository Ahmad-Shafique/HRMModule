using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Static_views.Controllers
{
    public class LeaveRecordController : Controller
    {
        // GET: Leave
        public ActionResult Index()
        {
            ViewBag.LeaveRecord = Data.DummyData.LeaveRecords().Where(item => item.ApplicationsStatus == 1);
            return View();
        }





        //// GET: Leave/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Leave/Edit/5
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


    }
}
