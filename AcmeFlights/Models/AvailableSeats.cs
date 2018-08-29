using System;
using System.Collections.Generic;

namespace AcmeFlights.Models
{
    public partial class AvailableSeats
    {
        public DateTime Date { get; set; }
        public string FlightCode { get; set; }
        public int VacantSeats { get; set; }

        public Flights FlightCodeNavigation { get; set; }
    }
}
