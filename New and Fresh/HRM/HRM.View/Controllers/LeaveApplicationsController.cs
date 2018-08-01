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
    public class LeaveApplicationsController : Controller
    {
        private IDomainService<LeaveApplication> Service = new ServiceFactory().Create<LeaveApplication>();

        // GET: LeaveApplications
        public ActionResult Index()
        {
            IEnumerable<LeaveApplication> data = Service.GetAll();
            return View(data.Where(item => item.EmployeeId == Int32.Parse(Session["Id"].ToString())));
        }

        // GET: LeaveApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = Service.Get(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaveApplicationId,LeaveApplicationCategoryId,ApplicationDescription,LeaveApplicationDuration,StartDate,EndtDate,Applydate,ApplicationsStatus,EmployeeId")] LeaveApplication leaveApplication)
        {
            if (ModelState.IsValid)
            {
                leaveApplication.EmployeeId = Int32.Parse(Session["Id"].ToString());
                Service.Insert(leaveApplication);
                return RedirectToAction("Index");
            }

            return View(leaveApplication);
        }

        // GET: LeaveApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = Service.Get(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplication);
        }

        // POST: LeaveApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaveApplicationId,LeaveApplicationCategoryId,ApplicationDescription,LeaveApplicationDuration,StartDate,EndtDate,Applydate,ApplicationsStatus,EmployeeId")] LeaveApplication leaveApplication)
        {
            if (ModelState.IsValid)
            {
                Service.Update(leaveApplication, leaveApplication.LeaveApplicationId);
                return RedirectToAction("Index");
            }
            return View(leaveApplication);
        }

        // GET: LeaveApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveApplication leaveApplication = Service.Get(id);
            if (leaveApplication == null)
            {
                return HttpNotFound();
            }
            return View(leaveApplication);
        }

        // POST: LeaveApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveApplication leaveApplication = Service.Get(id);
            Service.RemoveByEntity(leaveApplication);
            return RedirectToAction("Index");
        }


        public ActionResult LeaveApproval()
        {
            IEnumerable<LeaveApplication> data = Service.GetAll();
            return View(data.Where(item => item.ApplicationsStatus != 1));
        }

        public ActionResult Approve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LeaveApplication leaveApplication = Service.Get(id);
            leaveApplication.ApplicationsStatus = 1;
            Service.Update(leaveApplication, leaveApplication.LeaveApplicationId);

            return RedirectToAction("LeaveApproval");
        }
    }
}
