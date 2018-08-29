using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeFlights.Models;

namespace AcmeFlights.Repository
{
    public interface IFlightsRepository
    {
        Task<List<AvailableSeats>> GetAvailableFlightSeatsByDatesAsync(DateTime startDate, DateTime endDate);

        Task<List<Flights>> GetAllFlightsInfo();
    }
}
