using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsWeb.ViewModels
{
    public class CheckFlightsViewModel
    {
        [DataType( DataType.Date )]
        public DateTime StartDate { get; set; }

        [DataType( DataType.Date )]
        public DateTime EndDate { get; set;}

        //[Range(1,10)]
        public int NumberOfPax { get; set; }
    }
}
