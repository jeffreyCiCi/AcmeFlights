using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeFlights.ViewModels;

namespace AcmeFlights.BusinessLayer
{
    public interface IFlightService
    {
        Task<List<AvailableSeatsViewModel>> GetAvailableSeatsAsync(CheckFlightsViewModel vm);
    }
}
