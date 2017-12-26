using HRM.Entity;
using HRM.Entity.Facade;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class EmployeesController : Controller
    {
        private IDomainService<Employee> Service = new ServiceFactory().Create<Employee>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        private IDomainService<EmployeeDepartment> EmployeeDepartmentService = new ServiceFactory().Create<EmployeeDepartment>();
        // GET: Employee
        public  ActionResult Index()
        {
            return RedirectToAction("Display");
        }

        //Action for displaying employees
        [HttpGet]
        public  ActionResult Display()
        {
            Console.WriteLine("*******************************   Entered display method");
            IEnumerable<Employee> empList =  Service.GetAll();
            if(Session["DisplayAccess"].ToString() == ViewAccessCodes.DepartmentHeadViewCode)
            {
                int DepartmentId = Int32.Parse(Session["DepartmentId"].ToString());
                IEnumerable<EmployeeDepartment> empDeptList = EmployeeDepartmentService.GetAll().Where(item => item.DepartmentId == DepartmentId);
                List<int> IdsList = new List<int>();
                foreach(EmployeeDepartment item in empDeptList)
                {
                    if (item.DepartmentId == DepartmentId) IdsList.Add(item.EmployeeId);
                }
                List<Employee> filteredList = new List<Employee>();
                foreach(Employee emp in empList)
                {
                    if (IdsList.Contains(emp.EmployeeId)) filteredList.Add(emp);
                }

                return View(filteredList);
            }
            
            Console.WriteLine("Recieved list from db : " + empList);
            return View(empList);
        }

        [HttpPost]
        public ActionResult Display(FormCollection form)
        {
            string searchTerm = form["searchTerm"];
            if (searchTerm == "")
            {
                return RedirectToAction("Display");
            }

            //search and return employees with the 'serachTerm' name
            IEnumerable<Employee> empList = Service.GetAll().Where(x => x.EmployeeName.Contains(searchTerm)).ToList();
            return View(empList);
        }






        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Service.Get(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,EmployeeEmail,EmployeePassword,MGR,DateofBirth,Status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Service.Insert(employee);
                var employeeList = Service.GetAll().Where(item => item.EmployeeEmail == employee.EmployeeEmail);
                foreach(var items in employeeList)
                {
                    EmployeeBio employeeBio = new EmployeeBio
                    {
                        EmployeeAddress = "No address given",
                        DateofBirth = items.DateofBirth,
                        HireDate = DateTime.Now,
                        EmployeeId = items.EmployeeId
                    };

                    new ServiceFactory().Create<EmployeeBio>().Insert(employeeBio);
                }

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Service.Get(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeName,EmployeeEmail,EmployeePassword,MGR,DateofBirth,Status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                Service.Update(employee, employee.EmployeeId);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = Service.Get(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = Service.Get(id);
            Service.RemoveByEntity(employee);
            return RedirectToAction("Index");
        }

        //public ActionResult IndividualDisplay(int? id)
        //{
        //    ViewBag.Employee = CommonService.GetAllEmployeeDetails().Where(Item => Item.EmployeeId == id);
        //    return View();
        //}



    }
}
