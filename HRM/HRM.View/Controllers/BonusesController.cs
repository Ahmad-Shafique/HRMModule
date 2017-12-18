using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class BonusesController : Controller
    {
        // GET: Bonuses
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bonuses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bonuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bonuses/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bonuses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bonuses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bonuses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bonuses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
