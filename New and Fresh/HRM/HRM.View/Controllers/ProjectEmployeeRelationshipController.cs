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
    public class ProjectEmployeeRelationshipController : Controller
    {

        private IDomainService<ProjectEmployee> ProjectService = new ServiceFactory().Create<ProjectEmployee>();
        private IDomainService<ProjectEmployee> ProjecyEmployeeService = new ServiceFactory().Create<ProjectEmployee>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();

        // GET: ProjectEmployeeRelationship
        public ActionResult Index()
        {

            return View();
        }
    }
}