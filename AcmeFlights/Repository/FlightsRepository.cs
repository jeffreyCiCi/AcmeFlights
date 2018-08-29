﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeFlights.Models;

namespace AcmeFlights.Repository
{
    public class FlightsRepository : IFlightsRepository
    {
        public async Task<List<AvailableSeats>> GetAvailableFlightSeatsByDatesAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var ctx = new AcmeFlightsContext())
                {
                    return await ctx.AvailableSeats.Where(
                        a => a.Date >= startDate 
                        && a.Date <= endDate 
                        && a.VacantSeats > 0)
                        .ToListAsync();
                }
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
                using (var ctx = new AcmeFlightsContext())
                {
                    return await ctx.Flights.ToListAsync();
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
