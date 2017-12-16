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
    public class InterviewsController : Controller
    {
        private IDomainService<Interview> InterviewService = new ServiceFactory().Create<Interview>();
        private IDomainService<Interviewee> IntervieweeService = new ServiceFactory().Create<Interviewee>();
        // GET: Interviews
        public ActionResult Index()
        {
            ViewBag.Interviews = InterviewService.GetAll().Result;
            ViewBag.Interviewees = IntervieweeService.GetAll().Result;
            return View();
        }
    }
}
