using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace McTours.BusTrips
{
    public class BusTripSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } //DepartureName - ArrivalName 
        public DateTime Date { get; set; }
        public int LineCount { get; set; }
        public string VehicleName { get; set; } //Plaka Marka(Model)
        public SeatingType BusSeatingType { get; set; }
        public int BusSeatingLineCount { get; set; }
        public decimal TicketPrice { get; set; }
        public int EstimatedDuration { get; set; }
        public string VehicleMake { get; set; }
        public string DepartureCityName { get; set; }
        public string ArrivalCityName { get; set; }
        public int? BreakTimeDuration { get; set; }
        public string Route { get; set; }
    }
}
