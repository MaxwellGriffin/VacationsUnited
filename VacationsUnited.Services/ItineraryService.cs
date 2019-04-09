using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationsUnited.Services
{
    class ItineraryService
    {
        private readonly Guid _userId;

        public ItineraryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItinerary (ItineraryCreate model)
        {
            var entity = new ItineraryService()
            {
                ItineraryID = model.ItineraryID,
                OwnerID = model.OwnerID,
                GroupID = model.GroupID,
                DestinationId = model.DestinationId,
                Date = model.Date,
                Name = model.Name
            };



        }

    }
}
