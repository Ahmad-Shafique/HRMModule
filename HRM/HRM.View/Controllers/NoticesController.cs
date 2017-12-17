using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class NoticesController : Controller
    {
        private IDomainService<Notice> service = new ServiceFactory().Create<Notice>();
        private IDomainService<NoticeComment> CommentService = new ServiceFactory().Create<NoticeComment>();


        public async Task<ActionResult> Index()
        {
            ViewBag.Notices = await service.GetAll();
            return View();
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Console.WriteLine("Id found : " + id);
            Notice entity = await service.Get(id);
            Console.WriteLine("Notice header is : " + entity.NoticeTitle);

            if (entity == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoticeTitle = entity.NoticeTitle;
            ViewBag.NoticeDate = entity.NoticeDate;
            ViewBag.NoticeDetails = entity.NoticeDetails;
            
            IEnumerable<NoticeComment> comments = await CommentService.GetAll();
            ViewBag.Comments = comments.Where(item => item.NoticeId == entity.NoticeId);
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        // ****************************************************************************************************************************************************************
        public async Task<ActionResult> Create([Bind(Include = "NoticeId,NoticeTitle,NoticeDetails,NoticeDate")] Notice entity)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice entity = await service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // ******************************************************************************************************************************************************************
        public async Task<ActionResult> Edit([Bind(Include = "NoticeId,NoticeTitle,NoticeDetails,NoticeDate")] Notice entity)
        {
            if (ModelState.IsValid)
            {
                // **********************************************************************************************************************************************************
                Notice temp = await service.Get(entity.NoticeId);
                await service.RemoveByEntity(temp);
                await service.Insert(entity);
            }
            /////// return View(Notice);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice entity = await service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Notice entity = await service.Get(id);
            await service.RemoveByEntity(entity);
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