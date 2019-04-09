using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VacationsUnited.Services;

namespace VacationsUnited.WebAPI.Controllers
{
    [Authorize]
    public class GroupController : ApiController
    {
        public IHttpActionResult Get()
        {
            GroupService groupService = CreateGroupService();
            var groups = groupService.GetGroups();
            return Ok(groups);
        }

        private GroupService CreateGroupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var groupService = new GroupService(userId);
            return groupService;
        }
        
    }
}
