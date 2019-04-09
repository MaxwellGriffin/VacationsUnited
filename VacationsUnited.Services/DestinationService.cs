using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationsUnited.Data;

namespace VacationsUnited.Services
{
    public class DestinationService
    {
        private readonly Guid _userId;

        public DestinationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(DestinationCreate model)
        {
            var entity =
                new Destination()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}