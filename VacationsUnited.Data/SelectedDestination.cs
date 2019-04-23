using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsUnited.Data
{
    public class SelectedDestination
    {
        [Key]
        public int SelectedDestinationID { get; set; }
        public int Day { get; set; }
        public int ItineraryID { get; set; } //Foreign key
        public int DestinationID { get; set; } //Foreign key
    }
}
