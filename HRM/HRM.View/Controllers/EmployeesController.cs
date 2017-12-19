using HRM.Entity;
using HRM.Service;
using HRM.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM.View.Controllers
{
    public class EmployeesController : Controller
    {
        private IDomainService<Employee> Service = new ServiceFactory().Create<Employee>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        // GET: Employee
        public  ActionResult Index()
        {
            return View();
        }

        //Action for displaying employees
        [HttpGet]
        public  ActionResult Display()
        {
            Console.WriteLine("*******************************   Entered display method");
            IEnumerable<Employee> empList =  Service.GetAll();
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
            List<Employee> empList = Service.GetAll().ToList().Where(x => x.EmployeeName.Contains(searchTerm)).ToList();
            return View(empList);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "EmployeeId,EmployeeName,EmployeeEmail,EmployeePassword,Salary,MGR,DateOfBirth")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                 Service.Insert(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }
    }
}
