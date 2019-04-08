using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VacationsUnited.Data.Destination;

namespace VacationsUnited.Data
{
    class Group
    {
        public TripTypes TripType { get; set; }
        public Regions Region { get; set; }
        public int GuestCount { get; set; }
        public Guid OwnerID { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; }
    }
}
