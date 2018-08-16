using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using HRM.View.Models;

namespace HRM.View.Controllers
{
    public class RankHierarchiesController : Controller
    {
        IDomainService<RankHierarchy> Service = new ServiceFactory().Create<RankHierarchy>();
        IDomainService<Department> DepartmentService = new ServiceFactory().Create<Department>();
        IDomainService<SalaryRank> SalaryRankService = new ServiceFactory().Create<SalaryRank>();

        // GET: RankHierarchies
        public ActionResult Index()
        {
            ViewBag.Departments = DepartmentService.GetAll();
            ViewBag.SalaryRanks = SalaryRankService.GetAll();

            return View(Service.GetAll());
        }

        // GET: RankHierarchies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RankHierarchy rankHierarchy = Service.Get(id);
            if (rankHierarchy == null)
            {
                return HttpNotFound();
            }
            return View(rankHierarchy);
        }

        // GET: RankHierarchies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RankHierarchies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RankHierarchyId,DepartmentId,SalaryRankId,NextSalaryRankId")] RankHierarchy rankHierarchy)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(rankHierarchy);
                return RedirectToAction("Index");
            }

            return View(rankHierarchy);
        }

        // GET: RankHierarchies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RankHierarchy rankHierarchy = Service.Get(id);
            if (rankHierarchy == null)
            {
                return HttpNotFound();
            }
            return View(rankHierarchy);
        }

        // POST: RankHierarchies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RankHierarchyId,DepartmentId,SalaryRankId,NextSalaryRankId")] RankHierarchy rankHierarchy)
        {
            if (ModelState.IsValid)
            {
                Service.Update(rankHierarchy, rankHierarchy.RankHierarchyId);
                return RedirectToAction("Index");
            }
            return View(rankHierarchy);
        }

        // GET: RankHierarchies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RankHierarchy rankHierarchy = Service.Get(id);
            if (rankHierarchy == null)
            {
                return HttpNotFound();
            }
            return View(rankHierarchy);
        }

        // POST: RankHierarchies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RankHierarchy rankHierarchy = Service.Get(id);
            Service.RemoveByEntity(rankHierarchy);
            return RedirectToAction("Index");
        }

    }
}
