using McTours.Business.Services;
using McTours.BusTrips;
using McTours.Passengers;
using McTours.Tickets;
using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly PassengerService _passengerService = new PassengerService();
        private readonly BusTripService _busTripService = new BusTripService();
        private readonly TicketService _ticketService = new TicketService();    


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BusTripTicketReview(int busTripId, int seatNumber, int passengerId)
        {
            var busTrip = _busTripService.GetById(busTripId);
            var passenger = _passengerService.GetById(passengerId);

            var ticketReview = new TicketReview()
            {
                BusTripId = busTripId,
                SeatNumber = seatNumber,
                PassengerId = passengerId,
                Price = busTrip.TicketPrice,
                PassengerFirstName = passenger.FirstName,
                PassengerLastName = passenger.LastName,
            };

            return PartialView(ticketReview);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(TicketDto ticketDto)
        {
            var commandResult = _ticketService.Create(ticketDto);
            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
              
            }
            else
            {
              
                TempData["ResultMessage"] = commandResult.Message;
               
            }
            return RedirectToAction("Tickets", "BusTrips", new {id=ticketDto.BusTripId});
        }

    }

}
