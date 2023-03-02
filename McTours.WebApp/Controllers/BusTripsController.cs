using McTours.Business.Services;
using McTours.BusTrips;
using McTours.Vehicles;
using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class BusTripsController : Controller
    {

        private readonly BusTripService _busTripService=new BusTripService();
        private readonly VehicleService _vehicleService=new VehicleService();
        private readonly CityService _cityService = new CityService();

        public IActionResult Index()
        {
            var busTrips = _busTripService.GetSummaries();
            return View(busTrips);
        }

        public IActionResult Create()
        {
            LoadModels();
            return View();
        }



        [HttpPost]
        public IActionResult Create(BusTripsDto busTripsDto)
        {
            var commandResult = _busTripService.Create(busTripsDto);
            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadModels();
                TempData["ResultMessage"] =commandResult.Message;
                return View();
            }
        }
        public IActionResult Delete(BusTripsDto busTrip)
        {
            var result = _busTripService.Delete(busTrip);

            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
            }
            else
            {
                TempData["ResultMessage"] = result.Message;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var vehicle = _busTripService.GetById(id);
            if (vehicle != null)
            {
                LoadModels();
                return View(vehicle);
            }
            else
            {
                ViewData["ErrorMessage"] = $"{id} ID'li kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(BusTripsDto busTrip)
        {
            var result = _busTripService.Update(busTrip);

            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadModels();

                TempData["ResultMessage"] = result.Message;
                return View(busTrip);
            }
        }

        //Seyahat ekranından bilet satışı yapılacak haliyle bilet ile ilgili kontrol seyahat controllerda yapılır aynı şekilde bilete ait seyahat bilgileri de seyahat servisinden gelir

        // BusTrips/10/Tickets
        [Route("[controller]/{id}/[action]")]
        public IActionResult Ticket(int id)
        {
            var vehicle = _busTripService.GetSummaryById(id);
            if (vehicle != null)
            {
                return View(vehicle);
            }
            else
            {
                ViewData["ErrorMessage"] = $"{id} ID'li kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }
        private void LoadModels()
        {
            ViewBag.VehicleList = new SelectList(_busTripService.GetVehicle(), "Id", "VehicleName");
            ViewBag.DepartureCityList = new SelectList(_cityService.GetAll(), "Id", "Name");
            ViewBag.ArrivalCityList = new SelectList(_cityService.GetAll(), "Id", "Name");
        }
    }
}
