using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class HireController : Controller
    {
        private IDomainService<HireRequest> HireRequestService = new ServiceFactory().Create<HireRequest>();
        private IDomainService<Equipment> EquipmentService = new ServiceFactory().Create<Equipment>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        // GET: Hire
        public ActionResult Index()
        {
            //IEnumerable<HireRequest> hireReqs = HireRequestService.GetAll();
            //return View(hireReqs);
            return View();
        }

        //[HttpPost]
        //public ActionResult ConfirmHires(FormCollection form)
        //{
        //    //the "commaSeperated" holds the comma included string from the checkbox
        //    string commaSeperated = form["approved"];
        //    string[] approvedIdString = commaSeperated.Split(',');
        //    List<int> approvedIds = new List<int>();

        //    //the following loop converts to int all seperated ids and creates a list
        //    //foreach (string s in approvedIdString)
        //    //{
        //    //    int x;
        //    //    Int32.TryParse(s, out x);
        //    //    approvedIds.Add(x);
        //    //}
        //    //return View(approvedIds);
        //    return View();
        //}

        public ActionResult ConfirmHires()
        {
            return View();
        }
    }
}
