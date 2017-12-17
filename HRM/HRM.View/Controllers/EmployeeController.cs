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
    public class EmployeeController : Controller
    {
        private IDomainService<Employee> Service = new ServiceFactory().Create<Employee>();
        private ICommonViewServiceInterface CommonService = ServiceFactory.GetCommonViewService();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //Action for displaying employees
        [HttpGet]
        public async Task<ActionResult> Display()
        {
            Console.WriteLine("*******************************   Entered display method");
            IEnumerable<Employee> empList = await Service.GetAll();
            Console.WriteLine("Recieved list from db : " + empList);
            return View(empList);
        }

        [HttpPost]
        public ActionResult Display(FormCollection form)
        {
            string searchTerm = form["searchTerm"];
            if (searchTerm == "")
            {
                return RedirectToAction("/Display");
            }

            //search and return employees with the 'serachTerm' name
            List<Employee> empList = Service.GetAll().Result.ToList().Where(x => x.EmployeeName.Contains(searchTerm)).ToList();
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
        public async Task<ActionResult> Create([Bind(Include = "EmployeeId,EmployeeName,EmployeeEmail,EmployeePassword,Salary,MGR,DateOfBirth")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await Service.Insert(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }
    }
}
