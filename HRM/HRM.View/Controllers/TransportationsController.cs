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
    public class TransportationsController : Controller
    {
        private IDomainService<TransportArea> AreaService = new ServiceFactory().Create<TransportArea>();
        private IDomainService<TransportVehicle> VehicleService = new ServiceFactory().Create<TransportVehicle>();
        private IDomainService<Employee> EmployeeService = new ServiceFactory().Create<Employee>();
        private ICommonViewService CommonService = ServiceFactory.GetCommonViewService();
        // GET: Transportation
        public ActionResult Index()
        {
            ViewBag.areas = AreaService.GetAll();


            return View();
        }

        public ActionResult Area(int? AreaId)
        {
            //ViewBag.Employees = EmployeeService.GetAll().Where(e => e.AreaId == AreaId);
            ViewBag.Employees = EmployeeService.GetAll();
            ViewBag.vehicles = VehicleService.GetAll();
            //TransportArea t = Data.DummyData.TransportAreas().SingleOrDefault(area => area.TransportAreaId == AreaId);
            TransportArea t = AreaService.GetAll().SingleOrDefault(area => area.TransportAreaId == AreaId);
            if (t == null)
            {
                t = new TransportArea();
                t.AreaDemand = 50;
                t.AreaName = "Mohakhali";
            }
            ViewBag.AreaDemand = t.AreaDemand;
            ViewBag.CurrentCapacity = 5;
            ViewBag.AreaName = t.AreaName;



            return View();


        }
    }
}
