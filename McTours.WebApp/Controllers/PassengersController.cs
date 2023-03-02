using McTours.Business.Services;
using McTours.BusTrips;
using McTours.Passengers;
using McTours.VehicleDefinitions;
using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class PassengersController : Controller
    {
        private readonly PassengerService _passengerService= new PassengerService();    
       
        public IActionResult Index()
        {
            var passengers=_passengerService.GetAll();
            return View(passengers);
        }

        // Passengers/SearchPassengers
        public IActionResult SearchPassengers()
        {
            //Return view demek view ı döndür varsa layout unu da ekle döndür demek
            //return View();
            return PartialView();
            //PartialView layout kabul etmez
        }
        //TODO: burayı yaptıktan sonra ara butonuna js ile eventhandler ekle

        [HttpPost]
        public IActionResult SearchPassengers(SearchPassengerModel searchPassengerModel)
        {
            var passengers = _passengerService.SearchPassengers(searchPassengerModel);

            return Json(passengers);
        }

        public IActionResult Create()
        {
            ViewBag.Passengers = _passengerService.GetAll();
            ViewBag.GenderSelectedList = EnumHelper.GenderGetAll();
            return View(new PassengerDto());
        }

        [HttpPost]
        public IActionResult Create(PassengerDto passengerDto)
        {
            var commandResult = _passengerService.Create(passengerDto);
            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Passengers = _passengerService.GetAll();
                ViewBag.GenderSelectedList = EnumHelper.GenderGetAll();
                TempData["ResultMessage"] = commandResult.Message;
                return View(passengerDto);
            }
        }


        public IActionResult Update(int id)
        {
            var passenger = _passengerService.GetById(id);
            if (passenger != null)
            {
                ViewBag.GenderSelectedList = EnumHelper.GenderGetAll();
                return View(passenger);
            }
            else
            {
                TempData["ErrorMessage"] = $"{id} ID'li Kayıt bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(PassengerDto passenger)
        {
            var commandResult = _passengerService.Update(passenger);

            if (commandResult.IsSuccess)
            {
                TempData["SuccessMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.GenderSelectedList = EnumHelper.GenderGetAll();
                ViewData[Keys.ErrorMessage] = commandResult.Message;
                return View(passenger);
            }
        }
        public IActionResult Delete(int id)
        {
            var passenger = _passengerService.GetById(id);
            if (passenger != null)
            {
                ViewBag.GenderSelectedList = EnumHelper.GenderGetAll();
            }
            else
            {
                TempData["ErrorMessage"] = $"{id} ID'li kayıt bulunamadı !";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(PassengerDto passenger)
        {
            var commandResult = _passengerService.Delete(passenger);
            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
            }
            else
            {
                TempData[Keys.ErrorMessage] = commandResult.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
