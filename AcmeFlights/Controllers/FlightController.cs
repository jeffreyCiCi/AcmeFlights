using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcmeFlights.ViewModels;
using AcmeFlights.BusinessLayer;
using AcmeFlights.Filters;

namespace AcmeFlights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public IFlightService _service { get; set; }

        public FlightController(IFlightService fs)
        {
            _service = fs;
        }

        // GET: api/Flight
        [HttpGet]
        [Route("search")]
        [ModelValidationFilter]
        public async Task<ActionResult<List<AvailableSeatsViewModel>>> AvialableSeats([FromQuery]CheckFlightsViewModel vm)
        {
            // Since this class is decorated with [ApiController], so no need to validate model state manually
            try
            {
                var list = await _service.GetAvailableSeatsAsync(vm);
                
                if(list == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                else if(list.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(list);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
