using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeFlights.ViewModels
{
    public class CheckFlightsViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public int NumberOfPax { get; set; }
    }
}
