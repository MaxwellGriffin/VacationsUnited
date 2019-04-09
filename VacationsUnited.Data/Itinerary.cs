using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsUnited.Data
{
    public class Itinerary
    {
        [Key]
        public int ItineraryID { get; set; }
        public Guid OwnerID { get; set; }
        public int GroupID { get; set; }
        public int DestinationId { get; set; }
        public DateTimeOffset ItineraryDate {get; set;}
        public string ItineraryName { get; set; }
    }
}