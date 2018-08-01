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
    public class BiographyController : Controller
    {
        IDomainService<EmployeeBio> Service = new ServiceFactory().Create<EmployeeBio>();

        //// GET: Biography
        //public ActionResult Index()
        //{
        //    return View(db.EmployeeBios.ToList());
        //}

        // GET: Biography/Details/5
        public ActionResult Details()
        {
            EmployeeBio employeeBio = Service.Get(Int32.Parse(Session["Id"].ToString()));
            if (employeeBio == null)
            {
                return HttpNotFound();
            }
            return View(employeeBio);
        }

        //// GET: Biography/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Biography/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "EmployeeBioId,EmployeeContactNo,EmployeeAddress,DateofBirth,HireDate,Intro,Objectives,Hobbies,Interests,Certificates,JobExperience,Eduction,EmployeeId,Image")] EmployeeBio employeeBio)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EmployeeBios.Add(employeeBio);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(employeeBio);
        //}

        // GET: Biography/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBio employeeBio = Service.Get(id);
            if (employeeBio == null)
            {
                return HttpNotFound();
            }
            return View(employeeBio);
        }

        // POST: Biography/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeBioId,EmployeeContactNo,EmployeeAddress,DateofBirth,HireDate,Intro,Objectives,Hobbies,Interests,Certificates,JobExperience,Eduction,EmployeeId,Image")] EmployeeBio employeeBio)
        {
            if (ModelState.IsValid)
            {
                Service.Update(employeeBio, employeeBio.EmployeeBioId);
                return RedirectToAction("Details");
            }
            return View(employeeBio);
        }
    }
}
