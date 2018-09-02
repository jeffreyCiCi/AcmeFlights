using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightsWeb.ViewModels;
using FlightsCore.Interfaces;
using FlightsWeb.Filters;

namespace FlightsWeb.Controllers
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
        [HttpPost]
        [Route("search")]
        [ModelValidationFilter]
        public async Task<ActionResult<AvailableFlightsViewModel>> AvialableFlightsAsync([FromBody]CheckFlightsViewModel vm)
        {
            // Since this class is decorated with [ApiController], so no need to validate model state manually
            try
            {
                var list = await _service.SearchAvailableFlightsAsync(vm.StartDate, vm.EndDate, vm.NumberOfPax);
                
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
