using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class HireController : Controller
    {
        private IDomainService<HireRequest> HireRequestService = new ServiceFactory().Create<HireRequest>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        // GET: Hire
        public ActionResult Index()
        {
            IEnumerable<HireRequest> hireReqs = HireRequestService.GetAll();
            return View(hireReqs);
            //return View();
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
            return View(HireRequestService.GetAll());
        }


        // GET: HireRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HireRequest hireRequest = HireRequestService.Get(id);
            if (hireRequest == null)
            {
                return HttpNotFound();
            }
            return View(hireRequest);
        }

        // GET: HireRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HireRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HireRequestId,DesignationName,EmployeeRequired,RequestDate,Urgency,HireRequestStatus,DepartmentId")] HireRequest hireRequest)
        {
            if (ModelState.IsValid)
            {
                HireRequestService.Insert(hireRequest);
                return RedirectToAction("Index");
            }

            return View(hireRequest);
        }

        // GET: HireRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HireRequest hireRequest = HireRequestService.Get(id);
            if (hireRequest == null)
            {
                return HttpNotFound();
            }
            return View(hireRequest);
        }

        // POST: HireRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HireRequestId,DesignationName,EmployeeRequired,RequestDate,Urgency,HireRequestStatus,DepartmentId")] HireRequest hireRequest)
        {
            if (ModelState.IsValid)
            {
                HireRequestService.Update(hireRequest, hireRequest.HireRequestId);
                return RedirectToAction("Index");
            }
            return View(hireRequest);
        }

        // GET: HireRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HireRequest hireRequest = HireRequestService.Get(id);
            if (hireRequest == null)
            {
                return HttpNotFound();
            }
            return View(hireRequest);
        }

        // POST: HireRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HireRequest hireRequest = HireRequestService.Get(id);
            HireRequestService.RemoveByEntity(hireRequest);
            return RedirectToAction("Index");
        }
    }
}
