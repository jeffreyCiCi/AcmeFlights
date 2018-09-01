using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightsCore.Interfaces;
using FlightsCore.Models;

namespace Infrastructure.Repository
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly AcmeFlightsContext _ctx;

        public FlightsRepository(AcmeFlightsContext context)
        {
            _ctx = context;
        }

        public async Task<List<AvailableSeats>> GetAvailableFlightsByDatesAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _ctx.AvailableSeats
                    .Where(s => s.Date >= startDate && s.Date <= endDate && s.VacantSeats > 0)
                    .Join(_ctx.Flights,
                    s => s.FlightCode,
                    f => f.FlightCode,
                    (s, f) =>
                    new AvailableSeats
                    {
                        Date = s.Date.AddHours(f.DepartureTime.Hours).AddMinutes(f.DepartureTime.Minutes),
                        FlightCode = s.FlightCode,
                        VacantSeats = s.VacantSeats
                    }).ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
