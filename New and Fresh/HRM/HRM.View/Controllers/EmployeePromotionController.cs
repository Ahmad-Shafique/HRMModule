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
        private IDomainService<SalaryRank> SalaryRankService = new ServiceFactory().Create<SalaryRank>();


        public ActionResult Index()
        {
            ViewBag.Employees = CommonService.GetEmployeePromotionView().OrderBy(item => -item.RecommendationStatus);
            ViewBag.SalaryComponents = SalaryComponentsService.GetAll();
            
            return View();
        }

        public ActionResult PromotionLanding(int? Id, string Name)
        {
            var employeeSalary = SalaryService.GetAll().Single(item => item.EmployeeId == Id);
            var Ranks = SalaryRankService.GetAll();
            //ViewBag.Salary = employeeSalary;
            ViewBag.Id = Id;
            ViewBag.SalaryRanks = Ranks;
            SalaryRank Rank = Ranks.Single(item => item.SalaryRankId == employeeSalary.SalaryRankId);
            ViewBag.RankName = Rank.RankName;
            ViewBag.RankValue = Rank.RankValue;
            ViewBag.Name = Name;

            return View();

        }


        public ActionResult Promote (int? Id, int SalaryRankId)
        {
            EmployeeSalary empSal = SalaryService.GetAll().Single(item => item.EmployeeId == Id);
            empSal.SalaryRankId = SalaryRankId;
            SalaryService.Update(empSal, empSal.EmployeeSalaryId);

            return RedirectToAction("Index");
        }

    }
}
