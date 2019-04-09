using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationsUnited.Data;
using VacationsUnited.Models.Group.models;

namespace VacationsUnited.Services
{
    public class GroupService
    {
        private readonly Guid _userID;

        public GroupService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateGroup(GroupCreate model)
        {
            var group = new Group()
            {
                OwnerID = _userID,
                Name = model.Name,
                TripType = model.TripType,
                Region = model.Region,
                GuestCount = model.GuestCount,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Groups.Add(group);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GroupListItem> GetGroupsByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Groups.Where(c => c.OwnerID == id).Select(c => new GroupListItem
                {
                    Name = c.Name,
                    TripType = c.TripType,
                    GuestCount = c.GuestCount,
                    Region = c.Region
                });

                return query.ToArray();
            }
        }

        public IEnumerable<GroupListItem> GetGroups()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Groups
                    .Select(e =>
                    new GroupListItem
                    {
                        Name = e.Name,
                        TripType = e.TripType,
                        GuestCount = e.GuestCount,
                        Region = e.Region,

                    }

                 );
                return query.ToArray();
                    
            }
        }

        public GroupDetails GetGroupByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Groups.FirstOrDefault(c => c.GroupID == id);
                var model = new GroupDetails
                {
                    Name = entity.Name,
                    TripType = entity.TripType,
                    GuestCount = entity.GuestCount,
                    Region = entity.Region,
                };
                return model;

            }
        }

        public bool EditGroup(GroupEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Groups.FirstOrDefault(c => c.GroupID == model.GroupID);

                entity.Name = model.Name;
                entity.TripType = model.TripType;
                entity.GuestCount = model.GuestCount;
                entity.Region = model.Region;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGroup(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Groups.Single(c => c.GroupID == id);

                ctx.Groups.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
