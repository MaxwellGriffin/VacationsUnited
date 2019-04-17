using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationsUnited.Data;
using VacationsUnited.Models.Itinerary;

namespace VacationsUnited.Services
{
    public class ItineraryService
    {
        private readonly Guid _userId;

        public ItineraryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItinerary (ItineraryCreate model)
        {
            var entity = new Itinerary()
            {
                ItineraryDate = model.ItineraryDate,
                ItineraryName = model.ItineraryName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Itinerarys.Add(entity);
                return
                    ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItineraryListItem> GetItinerarysByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Itinerarys.Where(c => c.OwnerID == id).Select(c => new ItineraryListItem
                {
                    ItineraryID = c.ItineraryID,
                    ItineraryDate = c.ItineraryDate,
                    ItineraryName = c.ItineraryName 
                });
                return query.ToArray();
            }
        }

        public IEnumerable<ItineraryListItem> GetItinerarys()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Itinerarys
                    .Select(e =>
                new ItineraryListItem
                {
                    ItineraryID = e.ItineraryID,
                    ItineraryDate = e.ItineraryDate,
                    ItineraryName = e.ItineraryName
                }
                );
                return query.ToArray();
            }
        }

        public ItineraryDetail GetItineraryByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Itinerarys.FirstOrDefault(c => c.ItineraryID == id);
                var model = new ItineraryDetail
                {
                    ItineraryID = entity.ItineraryID,
                    ItineraryDate = entity.ItineraryDate,
                    ItineraryName = entity.ItineraryName
                };
                return model;
            }
        }

        public bool EditItinerary(ItineraryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Itinerarys.FirstOrDefault(c => c.ItineraryID == model.ItineraryID);

                entity.ItineraryDate = model.ItineraryDate;
                entity.ItineraryName = model.ItineraryName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteItinerary(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Itinerarys.Single(c => c.ItineraryID == id);

                ctx.Itinerarys.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
