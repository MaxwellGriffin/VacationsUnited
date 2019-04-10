using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationsUnited.Data;
using VacationsUnited.Models.SelectedDestination;

namespace VacationsUnited.Services
{
    public class SelectedDestinationService
    {
        private readonly Guid _userId;

        public SelectedDestinationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSelectedDestination(SelectedDestinationCreate model)
        {
            var entity =
                new SelectedDestination()
                {
                    Day = model.Day,
                    ItineraryID = model.ItineraryID,
                    DestinationID = model.DestinationID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SelectedDestinations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<SelectedDestinationListItem> GetSelectedDestinations(int itineraryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SelectedDestinations
                        .Where(e => e.ItineraryID == itineraryId)
                        .Select(
                            e =>
                                new SelectedDestinationListItem
                                {
                                    DestinationID = e.DestinationID,
                                    Day = e.Day,
                                    SelectedDestinationID = e.SelectedDestinationID
                                }
                        );

                return query.ToArray();
            }
        }

        public SelectedDestinationDetail GetSelectedDestinationById(int selectedDestinationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SelectedDestinations
                        .Single(e => e.SelectedDestinationID == selectedDestinationId);
                return
                    new SelectedDestinationDetail
                    {
                        DestinationID = entity.DestinationID,
                        SelectedDestinationID = entity.SelectedDestinationID,
                        Day = entity.Day,
                        ItineraryID = entity.ItineraryID
                    };
            }
        }

        public bool UpdateSelectedDestination(SelectedDestinationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SelectedDestinations
                        .Single(e => e.SelectedDestinationID == model.SelectedDestinationID);

                entity.Day = model.Day;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSelectedDestination(int selectedDestinationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SelectedDestinations
                        .Single(e => e.SelectedDestinationID == selectedDestinationId);

                ctx.SelectedDestinations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
