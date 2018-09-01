using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsCore.Models;

namespace FlightsCore.Interfaces
{
    public interface IFlightsRepository
    {
        Task<List<AvailableSeats>> GetAvailableFlightsByDatesAsync(DateTime startDate, DateTime endDate);
    }
}
