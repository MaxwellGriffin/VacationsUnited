using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VacationsUnited.Data.Enums;

namespace VacationsUnited.Models
{
    public class DestinationCreate
    {
        public string Name { get; set; }
        public Regions Region { get; set; }
        public TripTypes TripType { get; set; }
        public decimal Price { get; set; }
        public int MinGuests { get; set; }
        public int MaxGuests { get; set; }
        public string Location { get; set; }
    }
}