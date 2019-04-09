using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VacationsUnited.Data.Enums;

namespace VacationsUnited.Data
{
    public class Destination
    {
        [Key]
        public int DestinationID { get; set; }
        public Regions Region { get; set; }
        public TripTypes TripType { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int MinGuests { get; set; }
        public int MaxGuests { get; set; }
        public string Location { get; set; }
    }
}
