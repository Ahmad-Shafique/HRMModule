using HRM.Entity;
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
    public class EmployeePromotionController : Controller
    {
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        private IDomainService<SalaryComponents> SalaryComponentsService = new ServiceFactory().Create<SalaryComponents>();
        private IDomainService<EmployeeSalary> SalaryService = new ServiceFactory().Create<EmployeeSalary>();

        public ActionResult Index()
        {
            ViewBag.Employees = CommonService.GetEmployeePromotionView().OrderBy(item => -item.RecommendationStatus);
            ViewBag.SalaryComponents = SalaryComponentsService.GetAll();
            
            return View();
        }

        public ActionResult Promote(int? Id)
        {
            EmployeeSalary empSal = SalaryService.Get(Id);
            empSal.SalaryRankId += 1;
            SalaryService.Update(empSal, empSal.EmployeeSalaryId);
            return RedirectToAction("Index");
        }
    }
}
