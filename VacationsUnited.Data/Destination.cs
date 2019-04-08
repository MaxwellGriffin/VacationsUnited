using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsUnited.Data
{
    class Destination
    {
        public int DestinationID { get; set; }
        public Regions Region { get; set; }
        public TripTypes TripType { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int MinGuests { get; set; }
        public int MaxGuests { get; set; }
        public string Location { get; set; }

        public enum TripTypes
        {
            Family = 0,
            Girls = 1,
            Boys = 2,
            Individual = 3,
            Couples = 4
        };

        public enum Regions
        {
            Northeast = 0,
            Southeast = 1,
            Southwest = 2,
            West = 3,
            Midwest = 4
        };
    }
}
