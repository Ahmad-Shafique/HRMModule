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
    public class TrainingEmployeesController : Controller
    {
        private IDomainService<TrainingEmployee> service = new ServiceFactory().Create<TrainingEmployee>();


        public  ActionResult> Index()
        {
            return View( service.GetAll());
        }


        public  ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingEmployee entity =  service.Get(id);

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
        public  ActionResult> Create([Bind(Include = "TrainingEmployeeId,TrainingId,EmployeeId")] TrainingEmployee entity)
        {
            if (ModelState.IsValid)
            {
                 service.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }


        public  ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingEmployee entity =  service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // ******************************************************************************************************************************************************************
        public  ActionResult> Edit([Bind(Include = "TrainingEmployeeId,TrainingId,EmployeeId")] TrainingEmployee entity)
        {
            if (ModelState.IsValid)
            {
                // **********************************************************************************************************************************************************
                TrainingEmployee temp =  service.Get(entity.TrainingEmployeeId);
                 service.RemoveByEntity(temp);
                 service.Insert(entity);
            }
            /////// return View(TrainingEmployee);
            return RedirectToAction("Index");
        }


        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingEmployee entity =  service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult> DeleteConfirmed(int id)
        {
            TrainingEmployee entity =  service.Get(id);
             service.RemoveByEntity(entity);
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
