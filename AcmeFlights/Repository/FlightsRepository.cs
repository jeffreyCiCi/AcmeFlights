using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeFlights.Models;

namespace AcmeFlights.Repository
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly AcmeFlightsContext _ctx;

        public FlightsRepository(AcmeFlightsContext context)
        {
            _ctx = context;
        }

        public async Task<List<AvailableSeats>> GetAvailableFlightSeatsByDatesAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _ctx.AvailableSeats.Where(
                    a => a.Date >= startDate 
                    && a.Date <= endDate 
                    && a.VacantSeats > 0)
                    .ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Flights>> GetAllFlightsInfo()
        {
            try
            {
                return await _ctx.Flights.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

    }
}
