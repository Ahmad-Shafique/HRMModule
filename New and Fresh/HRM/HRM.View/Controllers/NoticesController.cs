﻿using HRM.Entity;
using HRM.Entity.DevAccessory;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private IDomainService<NoticeEmployee> seenService = new ServiceFactory().Create<NoticeEmployee>();




        public ActionResult Index()
        {
            ViewBag.Notices =  service.GetAll();
            return View();
        }


        public  ActionResult Details(int? id)
        {
            NoticeEmployee noticeEmployee;
            IEnumerable<NoticeComment> comments;
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Output.WriteLine("Id found : " + id);
            Notice entity =  service.Get(id);
            //Output.WriteLine("Notice header is : " + entity.NoticeTitle);

            if (entity == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoticeTitle = entity.NoticeTitle;
            ViewBag.NoticeDate = entity.NoticeDate;
            ViewBag.NoticeDetails = entity.NoticeDetails;
            ViewBag.NoticeId = id;
            
            
            comments =  CommentService.GetAll();
            ViewBag.Comments = comments.Where(item => item.NoticeId == entity.NoticeId);

            noticeEmployee = new NoticeEmployee();
            noticeEmployee.EmployeeId = Int32.Parse(Session["Id"].ToString());
            noticeEmployee.NoticeId = id.Value;

            seenService.Insert(noticeEmployee);
            ViewBag.Seen = seenService.GetAll().Where(e => e.NoticeId == id.Value).ToList().Count;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(NoticeComment noticeComment)
        {
            if (noticeComment.Comment != null)
            {
                noticeComment.EmployeeId = Int32.Parse(Session["Id"].ToString());
                noticeComment.EmployeeName = Session["Name"].ToString();

                if (Debugger.IsAttached)
                {
                    Output.Write("Inside Notice comment section");
                    Output.Write("noticeComment contains: " + noticeComment.Comment + " : " + noticeComment.NoticeId
                        + " : " + noticeComment.EmployeeName);
                }

                CommentService.Insert(noticeComment);


            }

            return RedirectToAction("Details", noticeComment.NoticeId);
        }


        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "NoticeId,NoticeTitle,NoticeDetails")] Notice entity)
        {
            entity.NoticeDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                service.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }


        public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice entity =  service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "NoticeId,NoticeTitle,NoticeDetails,NoticeDate")] Notice entity)
        {
            if (ModelState.IsValid)
            {

                Notice temp =  service.Get(entity.NoticeId);
                 service.RemoveByEntity(temp);
                 service.Insert(entity);
            }
            /////// return View(Notice);
            return RedirectToAction("Index");
        }


        public  ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice entity =  service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult DeleteConfirmed(int id)
        {
            Notice entity =  service.Get(id);
             service.RemoveByEntity(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public  ActionResult SubmitComment(int noticeId, string comment)
        {
            NoticeComment noticeComment = new NoticeComment
            {



                // **************************************************************************   CHANGE LATER
                EmployeeId = 1,
                EmployeeName = "tEST eMPLOYEE",
                // **************************************************************************   CHANGE LATER



                NoticeId = noticeId,
                Comment = comment
            };
             CommentService.Insert(noticeComment);
            return RedirectToAction("Details",new { id = noticeId });
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


    }
}