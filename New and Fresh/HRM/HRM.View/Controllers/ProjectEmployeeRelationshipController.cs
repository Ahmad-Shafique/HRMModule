using HRM.Data.Utilities;
using HRM.Entity;
using HRM.Entity.DevAccessory;
using HRM.Entity.Facade;
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
        private IEnumerable<ProjectAndAllAssociatedEmployees> projectList;

        public ProjectEmployeeRelationshipController()
        {
            try
            {
                int deptId = Int32.Parse(Session["Department"].ToString());
                projectList = CommonService.GetListOfAllProjectsAndTheirAssociatedEmployee().
                                            Where(e => e.DepartmentId == deptId
                                            );
            }catch(Exception e)
            {
                Output.Write(e);
            }



        }

        // GET: ProjectEmployeeRelationship
        public ActionResult Index()
        {
            if(projectList != null) return View(projectList);
            return View(new List<ProjectAndAllAssociatedEmployees>());
        }

        public ActionResult ShowProject(int? id)
        {
            foreach(var x in projectList)
            {
                Output.Write(x.ProjectId + " : " + x.ProjectTitle);
            }
            Output.Write("Required Id is : " + id.Value);

            ProjectAndAllAssociatedEmployees toView = projectList.First(e => e.ProjectId == id.Value);
            if(toView == null)
            {
                toView = new ProjectAndAllAssociatedEmployees();
            }

            if(toView.ListOfEmployees == null)
            {
                toView.ListOfEmployees = new List<EmployeeIdAndName>();
            }

            return View(toView);
        }

        public ActionResult AddToProject(int? ProjectId)
        {
            ViewBag.ProjectId = ProjectId;
            int DepartmentId=0;
            Int32.TryParse(Session["Department"].ToString(), out DepartmentId);
            IEnumerable<EmployeeIdNameDepartmentId> mainListOfEmployees = CommonService.GetEmployeeIdNameDepartmentIdList()
                .Where(e=> e.DepartmentId==DepartmentId);
            List<ProjectEmployee> projectEmployeeList = ProjecyEmployeeService.GetAll().Where(e => e.ProjectId == ProjectId.Value).ToList();
            foreach(ProjectEmployee item in projectEmployeeList)
            {
                mainListOfEmployees = mainListOfEmployees.Where(e => e.EmployeeId != item.EmployeeId);
            }

            // Get Employees from same department not involved in the project and pass to view
            // 
            return View(mainListOfEmployees);
        }

        public ActionResult AddToProjectConfirmed(int? ProjectId, int? EmployeeId)
        {
            Output.Write(ProjectId.Value + " : " + EmployeeId.Value);

            ProjectEmployee entity = new ProjectEmployee();
            entity.ProjectId = ProjectId.Value;
            entity.EmployeeId = EmployeeId.Value;
            ProjecyEmployeeService.Insert(entity);

            return RedirectToAction("AddToProject", new { ProjectId = ProjectId.Value });
        }

        public ActionResult RemoveFromProject(int? ProjectId, int? EmployeeId)
        {
            Output.Write(ProjectId + " : " + EmployeeId);
            ProjectEmployee entity = ProjecyEmployeeService.GetAll().First(e => e.ProjectId == ProjectId.Value
                                                                           && e.EmployeeId == EmployeeId.Value);
            ProjecyEmployeeService.RemoveByEntity(entity);

            return RedirectToAction("ShowProject", new { id = ProjectId.Value });
        }
    }
}