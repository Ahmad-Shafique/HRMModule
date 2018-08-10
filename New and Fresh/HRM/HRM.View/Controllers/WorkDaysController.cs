using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Entity;
using HRM.Entity.DevAccessory;
using HRM.Service;
using HRM.Service.Interfaces;
using HRM.View.Models;

namespace HRM.View.Controllers
{
    public class WorkDaysController : Controller
    {
        private IDomainService<WorkDay> Service = new ServiceFactory().Create<WorkDay>();

        //private HRMViewContext db = new HRMViewContext();

        [HttpGet]
        public ActionResult StartWorkDay()
        {
            WorkDay workDay = new WorkDay();
            workDay.EmployeeId = Int32.Parse(Session["Id"].ToString());
            String stringifiedDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",
                                            CultureInfo.InvariantCulture);
            workDay.StartTime = DateTime.Parse(stringifiedDateTime);

            workDay.EndTime = DateTime.Parse("1800/1/1");
            workDay.ExtraTimeInMinutes = 0;
            Output.Write(workDay.EndTime);
            if (Service.Insert(workDay))
            {
                Session["WorkDay"] = true;
            }
            return RedirectToAction("Display", "Employees");
        }

        [HttpGet]
        public ActionResult EndWorkDay()
        {
            IEnumerable<WorkDay> workDays = Service.GetAll();
            workDays.Where(e => e.EmployeeId == Int32.Parse(Session["Id"].ToString()) &&
                                e.StartTime.Month == DateTime.Now.Month);
            List<WorkDay> expectedList = workDays.Where(e => e.StartTime.Day == DateTime.Now.Day).ToList();
            if(expectedList.Count == 0)
            {
                WorkDay workDay = workDays.First(e => e.StartTime.Day == DateTime.Now.Day - 1);
                if(workDay != null)
                {
                    workDay.EndTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",
                                            CultureInfo.InvariantCulture));
                    if (Service.Update(workDay, workDay.WorkDayId))
                    {
                        Session["WorkDay"] = false;
                    }
                }
                else
                {
                    Output.Write("Workday not found");
                }
            }
            else
            {
                WorkDay toUpdate = expectedList[0];
                toUpdate.EndTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",
                                            CultureInfo.InvariantCulture));
                Service.Update(toUpdate, toUpdate.WorkDayId);
            }

            return RedirectToAction("Display", "Employees");
        }

        //// GET: WorkDays
        //public ActionResult Index()
        //{
        //    return View(db.WorkDays.ToList());
        //}

        //// GET: WorkDays/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkDay workDay = db.WorkDays.Find(id);
        //    if (workDay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workDay);
        //}

        //// GET: WorkDays/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: WorkDays/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "WorkDayId,EmployeeId,StartTime,EndTime,ExtraTimeInMinutes")] WorkDay workDay)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.WorkDays.Add(workDay);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(workDay);
        //}

        //// GET: WorkDays/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkDay workDay = db.WorkDays.Find(id);
        //    if (workDay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workDay);
        //}

        //// POST: WorkDays/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "WorkDayId,EmployeeId,StartTime,EndTime,ExtraTimeInMinutes")] WorkDay workDay)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(workDay).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(workDay);
        //}

        //// GET: WorkDays/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WorkDay workDay = db.WorkDays.Find(id);
        //    if (workDay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(workDay);
        //}

        //// POST: WorkDays/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    WorkDay workDay = db.WorkDays.Find(id);
        //    db.WorkDays.Remove(workDay);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
