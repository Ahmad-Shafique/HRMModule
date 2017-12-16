using Static_views.Data;
using Static_views.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Static_views.Controllers
{
    public class HireController : Controller
    {
        // GET: Hire
        public ActionResult Index()
        {
            List<HireRequest> hireReqs = DummyData.HireRequests();
            return View(hireReqs);
        }

        [HttpPost]
        public ActionResult ConfirmHires(FormCollection form)
        {
            //the "commaSeperated" holds the comma included string from the checkbox
            string commaSeperated = form["approved"];
            string[] approvedIdString = commaSeperated.Split(',');
            List<int> approvedIds = new List<int>();

            //the following loop converts to int all seperated ids and creates a list
            foreach(string s in approvedIdString)
            {
                int x;
                Int32.TryParse(s, out x);
                approvedIds.Add(x);
            }
            return View(approvedIds);
        }
    }
}