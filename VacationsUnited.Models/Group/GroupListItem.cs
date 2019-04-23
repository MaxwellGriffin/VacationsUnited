using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VacationsUnited.Data.Enums;

namespace VacationsUnited.Models.Group.models
{
    public class GroupListItem
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public TripTypes TripType { get; set; }
        public int GuestCount { get; set; }
        
        
        
    }
}
