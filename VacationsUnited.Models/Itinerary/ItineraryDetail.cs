using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsUnited.Models.Itinerary
{
    public class ItineraryDetail
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset ItineraryDate { get; set; }

        public string ItineraryName { get; set; }
    }
}
