using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VacationsUnited.Models;
using VacationsUnited.Services;

namespace ElevenDestination.WebAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class DestinationController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            DestinationService destinationService = CreateDestinationService();
            var destinations = destinationService.GetDestinations();
            return Ok(destinations);
        }

        public IHttpActionResult Get(int id)
        {
            DestinationService destinationService = CreateDestinationService();
            var destination = destinationService.GetDestinationById(id);
            return Ok(destination);
        }

        public IHttpActionResult Post(DestinationCreate destination)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDestinationService();

            if (!service.CreateDestination(destination))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(DestinationEdit destination)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDestinationService();

            if (!service.UpdateDestination(destination))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDestinationService();

            if (!service.DeleteDestination(id))
                return InternalServerError();

            return Ok();
        }

        private DestinationService CreateDestinationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var destinationService = new DestinationService(userId);
            return destinationService;
        }
    }
}