using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRM.Data;
using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;

namespace HRM.Controllers
{
    public class EmployeeSalariesController : Controller
    {
        private IDomainService<EmployeeSalary> service = new ServiceFactory().Create<EmployeeSalary>();


        public async Task<ActionResult> Index()
        {
            return View(await service.GetAll());
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary entity = await service.Get(id);

            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        // ****************************************************************************************************************************************************************
        public async Task<ActionResult> Create([Bind(Include = "EmployeeSalaryId,EmployeeId,BasicSalary,TotalSalary,SalaryMonth,Year,status,BonusId,BonusValue")] EmployeeSalary employeeSalary)
        {
            if (ModelState.IsValid)
            {
                await service.Insert(employeeSalary);
                return RedirectToAction("Index");
            }

            return View(employeeSalary);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary entity = await service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // ******************************************************************************************************************************************************************
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeSalaryId,EmployeeId,BasicSalary,TotalSalary,SalaryMonth,Year,status,BonusId,BonusValue")] EmployeeSalary employeeSalary)
        {
            if (ModelState.IsValid)
            {
                // **********************************************************************************************************************************************************
                EmployeeSalary temp = await service.Get(employeeSalary);
                await service.RemoveByEntity(temp);
                await service.Insert(employeeSalary);
            }
            /////// return View(EmployeeSalary);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSalary entity = await service.Get(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeSalary entity = await service.Get(id);
            await service.RemoveByEntity(entity);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
