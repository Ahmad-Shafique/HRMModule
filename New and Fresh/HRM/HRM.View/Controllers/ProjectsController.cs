using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Data.Utilities;
using HRM.Entity;
using HRM.Entity.DevAccessory;
using HRM.Service;
using HRM.Service.Interfaces;
using HRM.View.Models;

namespace HRM.View.Controllers
{
    public class SuccessRate
    {
        public int projectId { get; set; }
        [Required,Range(0,100)]
        public int successRate { get; set; }
    }

    public class ProjectsController : Controller
    {
        private IDomainService<Project> Service = new ServiceFactory().Create<Project>();

        // GET: Projects
        public ActionResult Index()
        {
            int deptId=0;
            DateTime minVal = new CheckRange().GetMinimumDateRange();
            Int32.TryParse(Session["Department"].ToString(), out deptId);
            return View(Service.GetAll().Where(e=>e.DepartmentId==deptId && e.EndDate==minVal));
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = Service.Get(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,ProjectName,ProjectDescription,StartDate,EndDate,SuccessRate")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.EndDate = new CheckRange().GetMinimumDateRange();
                project.SuccessRate = 0;
                project.DepartmentId = Int32.Parse(Session["Department"].ToString());
                Service.Insert(project);
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = Service.Get(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,ProjectName,ProjectDescription,StartDate,EndDate,SuccessRate")] Project project)
        {
            if (ModelState.IsValid)
            {
                Service.Update(project, project.ProjectId);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = Service.Get(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = Service.Get(id);
            Service.RemoveByEntity(project);
            return RedirectToAction("Index");
        }

        public ActionResult CompleteProject(int? id)
        {
            ViewBag.ProjectId = id.Value;
            SuccessRate s = new SuccessRate();
            s.projectId = id.Value;
            return View(s);
        }

        [HttpPost]
        public ActionResult CompleteProject(SuccessRate success)
        {
            Output.Write(success.projectId + " : " + success.successRate);
            Project entity = Service.Get(success.projectId);
            entity.EndDate = DateTime.Now;
            entity.SuccessRate = success.successRate;
            Service.Update(entity, entity.ProjectId);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult CompleteProjectConfirmed(SuccessRate success)
        {
            Output.Write(success.projectId + " : " + success.successRate);
            Project entity = Service.Get(success.projectId);
            entity.EndDate = DateTime.Now;
            entity.SuccessRate = success.successRate;
            Service.Update(entity, entity.ProjectId);
            return RedirectToAction("Index");
        }
    }
}
