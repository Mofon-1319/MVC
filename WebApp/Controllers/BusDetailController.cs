using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.DAL;
using WebApp.Entity;

namespace WebApp.Controllers
{
    public class BusDetailController : Controller
    {
        // GET: BusDetail
        BusRepository busRepository = new BusRepository();
        public ViewResult Index()
        {

            IEnumerable<BusEntity> busList = busRepository.Display();
            return View(busList);
        }
        public ViewResult BusDetailsDisplay()
        {

            IEnumerable<BusEntity> busList = busRepository.Display();
            ViewBag.BusDetail = busList;
            return View();
        }

        public ActionResult ViewDetails()
        {
            BusRepository busRepository = new BusRepository();
            IEnumerable<BusEntity> bus = busRepository.Display();
            ViewData["BusDetail"] = bus;
            return View();
        }
        public ActionResult ViewAllDetails()
        {
            IEnumerable<BusEntity> bus = busRepository.Display();
            TempData["Bus"] = bus;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateUpdate()
        {
            BusEntity busEntity = new BusEntity();
            TryUpdateModel(busEntity);
            busRepository.AddBus(busEntity);
            TempData["Message"] = "Bus Added";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string type)
        {
            BusEntity bus = busRepository.GetBus(type);
            return View(bus);
        }
        public ActionResult Delete(string type)
        {
            busRepository.DeleteBus(type);
            TempData["Message"] = "Bus deleted";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ActionName("Update")]
        public ActionResult UpdateTry()
        {
            BusEntity busEntity = new BusEntity();
            UpdateModel(busEntity);
            busRepository.UpdateBus(busEntity);
            TempData["Message"] = "Bus Updated";
            return RedirectToAction("Index");
        }
    }
}