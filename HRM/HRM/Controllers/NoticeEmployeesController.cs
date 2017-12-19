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
    public class NoticeEmployeesController : Controller
    {
        private IDomainService<NoticeEmployee> service = new ServiceFactory().Create<NoticeEmployee>();


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
            NoticeEmployee entity =  service.Get(id);

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
        public  ActionResult> Create([Bind(Include = "NoticeEmployeeId,NoticeId,EmployeeId")] NoticeEmployee entity)
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
            NoticeEmployee entity =  service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // ******************************************************************************************************************************************************************
        public  ActionResult> Edit([Bind(Include = "NoticeEmployeeId,NoticeId,EmployeeId")] NoticeEmployee entity)
        {
            if (ModelState.IsValid)
            {
                // **********************************************************************************************************************************************************
                NoticeEmployee temp =  service.Get(entity.NoticeEmployeeId);
                 service.RemoveByEntity(temp);
                 service.Insert(entity);
            }
            /////// return View(NoticeEmployee);
            return RedirectToAction("Index");
        }


        public  ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticeEmployee entity =  service.Get(id);
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
            NoticeEmployee entity =  service.Get(id);
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
