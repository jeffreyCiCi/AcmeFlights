using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeFlights.ViewModels;
using AcmeFlights.Repository;

namespace AcmeFlights.BusinessLayer
{
    public class FlightService : IFlightService
    {
        IFlightsRepository _repo;

        public FlightService(IFlightsRepository flightRepo)
        {
            _repo = flightRepo;
        }

        public async Task<List<AvailableSeatsViewModel>> GetAvailableSeatsAsync(CheckFlightsViewModel vm)
        {
            try
            {
                // retrieve necessary data from reopository
                var seatsList = await _repo.GetAvailableFlightSeatsByDatesAsync(vm.StartDate, vm.EndDate);
                var flightList = await _repo.GetAllFlightsInfo();

                // join to convert to AvailableSeatsViewModel
                if (seatsList != null && flightList != null)
                {
                    return seatsList.Join(
                        flightList, 
                        s => s.FlightCode, 
                        f => f.FlightCode,
                        (s, f) => new AvailableSeatsViewModel
                        {
                            FlightCode = s.FlightCode,
                            FlightDateTime = s.Date.AddHours(f.DepartureTime.Hours).AddMinutes(f.DepartureTime.Minutes)
                        }).ToList();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
