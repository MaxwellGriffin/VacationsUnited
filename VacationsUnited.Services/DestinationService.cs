using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationsUnited.Data;
using VacationsUnited.Models;

namespace VacationsUnited.Services
{
    public class DestinationService
    {
        private readonly Guid _userId;

        public DestinationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDestination(DestinationCreate model)
        {
            var entity =
                new Destination()
                {
                    Name = model.Name,
                    Region = model.Region,
                    TripType = model.TripType,
                    Price = model.Price,
                    MinGuests = model.MinGuests,
                    MaxGuests = model.MaxGuests,
                    Location = model.Location
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Destinations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<DestinationListItem> GetDestinations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Destinations
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new DestinationListItem
                                {
                                    DestinationID = e.DestinationID,
                                    Name = e.Name,
                                    Location = e.Location
                                }
                        );

                return query.ToArray();
            }
        }

        public DestinationDetail GetDestinationById(int destinationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Destinations
                        .Single(e => e.DestinationID == destinationId);
                return
                    new DestinationDetail
                    {
                        DestinationID = entity.DestinationID,
                        Name = entity.Name,
                        Location = entity.Location,
                        Region = entity.Region,
                        TripType = entity.TripType,
                        Price = entity.Price,
                        MinGuests = entity.MinGuests,
                        MaxGuests = entity.MaxGuests
                    };
            }
        }

        public bool UpdateDestination(DestinationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Destinations
                        .Single(e => e.DestinationID == model.DestinationID);

                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.MinGuests = model.MinGuests;
                entity.MaxGuests = model.MaxGuests;
                entity.Price = model.Price;
                entity.Region = model.Region;
                entity.TripType = model.TripType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDestination(int destinationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Destinations
                        .Single(e => e.DestinationID == destinationId);

                ctx.Destinations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}