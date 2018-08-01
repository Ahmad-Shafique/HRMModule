using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class BudgetsController : Controller
    {
        // GET: Budget
        public ActionResult Index()
        {
            return View();
        }
    }
}