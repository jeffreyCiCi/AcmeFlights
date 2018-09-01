using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsCore.Interfaces;
using FlightsCore.Models;

namespace DomainServices.BusinessLogic
{
    public class FlightService : IFlightService
    {
        IFlightsRepository _repo;

        public FlightService(IFlightsRepository flightRepo)
        {
            _repo = flightRepo;
        }

        public async Task<List<AvailableFlight>> SearchAvailableFlightsAsync(DateTime startDate, DateTime endDate, int numPax)
        {
            try
            {
                // retrieve necessary data from reopository
                var availableSeatsList = await _repo.GetAvailableFlightsByDatesAsync(startDate, endDate);

                List<AvailableFlight> resultList = null;
                if (availableSeatsList != null)
                {
                    resultList = availableSeatsList.Where(s => s.VacantSeats >= numPax)
                        .Select(s => new AvailableFlight
                        {
                            FlightCode = s.FlightCode,
                            FlightDateTime = s.Date
                        }).ToList();
                }

                return resultList;
            }
            catch
            {
                return null;
            }
        }
    }
}
