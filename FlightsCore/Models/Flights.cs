using System;
using System.Collections.Generic;

namespace FlightsCore.Models
{
    public partial class Flights
    {
        public Flights()
        {
            AvailableSeats = new HashSet<AvailableSeats>();
        }

        public string FlightCode { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int Capacity { get; set; }

        public ICollection<AvailableSeats> AvailableSeats { get; set; }
    }
}
