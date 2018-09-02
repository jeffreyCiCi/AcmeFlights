using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsCore.Models;

namespace FlightsCore.Interfaces
{
    public interface IFlightService
    {
        Task<List<AvailableFlight>> SearchAvailableFlightsAsync(DateTime startDate, DateTime endDate, int NumPax);
    }
}
