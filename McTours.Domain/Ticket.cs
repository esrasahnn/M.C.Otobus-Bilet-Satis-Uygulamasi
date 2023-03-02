﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McTours.Domain
{
    public  class Ticket
    {
        public int Id { get; set; } 
        public int BusTripId { get; set; }  
        public int PassengerId { get; set; }    
        public short SeatNumber{ get; set;}
        public DateTime Date { get; set; }
        public int Price { get; set;}
        public BusTrip BusTrip { get; set; }    
        public Passenger Passenger { get; set; }

    }
}
