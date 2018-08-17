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
    public class EmployeePromotionController : Controller
    {
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        private IDomainService<SalaryComponents> SalaryComponentsService = new ServiceFactory().Create<SalaryComponents>();
        private IDomainService<EmployeeSalary> SalaryService = new ServiceFactory().Create<EmployeeSalary>();
        private IDomainService<SalaryRank> SalaryRankService = new ServiceFactory().Create<SalaryRank>();


        public ActionResult Index()
        {
            IEnumerable<EmployeePromotion> employeePromotions = CommonService.GetEmployeePromotionView().OrderBy(item => -item.RecommendationStatus);
            int currentUserId = Int32.Parse(Session["Id"].ToString());
            employeePromotions = employeePromotions.Where(e => e.EmployeeId != currentUserId);
            ViewBag.Employees = employeePromotions;
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

            EmployeeSalary empSal = SalaryService.GetAll().First(item => item.EmployeeId == Id);
            SalaryRank salaryRank = SalaryRankService.Get(SalaryRankId);
            empSal.SalaryRankId = salaryRank.SalaryRankId;
            empSal.BasicSalary = salaryRank.RankValue;
            try
            {
                SalaryService.Update(empSal, empSal.EmployeeSalaryId);
            }
            catch(Exception e)
            {
                Output.Write(e);
            }
            

            return RedirectToAction("Index");
        }

    }
}
