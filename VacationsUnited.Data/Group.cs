using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VacationsUnited.Data.Enums;

namespace VacationsUnited.Data
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        public TripTypes TripType { get; set; }
        public int GuestCount { get; set; }
        public Guid OwnerID { get; set; }
        public string Name { get; set; }
    }
}
