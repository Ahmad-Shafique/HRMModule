﻿using HRM.Entity;
using HRM.Service;
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
        [HttpGet]
        public ActionResult Index(int? Id)
        {
            if(Id == null) return RedirectToAction("EmployeeDisplay", "EmployeeEvaluations");
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Bonuses bonus = new Bonuses
            {
                BonusValue = Int32.Parse(form["BonusAmount"]),
                BonusDescription = form["BonusReason"]
            };
            new ServiceFactory().Create<Employee>().GetAll();
            ServiceFactory.GetCommonViewService().AssignBonusToEmployee(bonus, Int32.Parse(form["EmpId"]));
            return RedirectToAction("EmployeeDisplay", "EmployeeEvaluations");
        }

    }
}
