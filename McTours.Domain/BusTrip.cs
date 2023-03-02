using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public class BusTrip
    {
        public BusTrip()
        {
            //Bizim uygulamamız küçük veri olduğu için List daha mantıklı fakat HashSet örneği oluşsun diye. 
            Tickets=new HashSet<Ticket>();   
        }
     
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public int EstimatedDuration { get; set; }
        public decimal TicketPrice { get; set; }
        public string Name
        {
            get
            {
                return string.Concat(
                    DepartureCity.Name,
                    " - ",
                    ArrivalCity.Name,
                    " / ",
                    Date.ToString("dd.MM.yyyy HH:mm"));
            }
        }
        //readonly property sadece get metodu var yani
        public bool HasBreakTime => BreakTimeDuration != null;
        //public bool HasBreakTime => BreakTimeDuration.HasValue;
      
        public int? BreakTimeDuration { get; set; }

        public Vehicle Vehicle { get; set; }
        public City DepartureCity { get; set; }
        public City ArrivalCity { get; set; }

        public ICollection<Ticket> Tickets { get; } 

    }
}
