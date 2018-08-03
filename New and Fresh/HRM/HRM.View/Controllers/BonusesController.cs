using HRM.Entity;
using HRM.Entity.DevAccessory;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class BonusesController : Controller
    {
        private static int EmployeeSalaryId;
        private IDomainService<EmployeeSalary> employeeSalaryService = new ServiceFactory().Create<EmployeeSalary>();
        private IDomainService<Bonus> mainBonusService = new ServiceFactory().Create<Bonus>();
        private IDomainService<Bonuses> bonusComponentService = new ServiceFactory().Create<Bonuses>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();

        // GET: Bonuses
        [HttpGet]
        public ActionResult Index(int? Id)
        {
            if(!Id.HasValue) return RedirectToAction("EmployeeDisplay", "EmployeeEvaluations");
            ViewBag.Id = Id;
            BonusesController.EmployeeSalaryId = Id.Value;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Output.Write("Employee Salary Id is: " + BonusesController.EmployeeSalaryId);
            EmployeeSalary employeeSalary = employeeSalaryService.Get(BonusesController.EmployeeSalaryId);
            Bonus mainBonus = mainBonusService.Get(employeeSalary.BonusId);
            int bonusAmount = Int32.Parse(form["BonusAmount"]);
            Bonuses bonus = new Bonuses
            {
                BonusId = mainBonus.BonusId,
                BonusValue = bonusAmount,
                BonusDescription = form["BonusReason"]
            };

            Output.Write("Employee Salary Id is: " + employeeSalary.EmployeeSalaryId);
            Output.Write("Bonus id is: " + mainBonus.BonusId);
            Output.Write("Bonus amount is: " + bonusAmount);

            mainBonus.BonusValue += bonusAmount;
            mainBonusService.Update(mainBonus, mainBonus.BonusId);

            bonusComponentService.Insert(bonus);

            //new ServiceFactory().Create<Employee>().GetAll();
            //ServiceFactory.GetCommonViewService().AssignBonusToEmployee(bonus, Int32.Parse(form["EmpId"]));


            return RedirectToAction("EmployeeDisplay", "EmployeeEvaluations");
        }

    }
}
