using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Static_views.Controllers
{
    public class SalaryPaymentController : Controller
    {
        // GET: SalaryPayment
        public ActionResult Index()
        {
            ViewBag.Salaries = Data.DummyData.Salaries();
            return View();
        }

    }
}
