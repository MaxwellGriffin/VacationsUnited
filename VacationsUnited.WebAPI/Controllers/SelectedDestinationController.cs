using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VacationsUnited.Models.SelectedDestination;
using VacationsUnited.Services;

namespace VacationsUnited.WebAPI.Controllers
{
    [Authorize]
    public class SelectedDestinationController : ApiController
    {
        public IHttpActionResult GetAll(int itineraryId)
        {
            SelectedDestinationService selectedDestinationService = CreateSelectedDestinationService();
            var selectedDestinations = selectedDestinationService.GetSelectedDestinations(itineraryId);
            return Ok(selectedDestinations);
        }

        public IHttpActionResult Get(int id)
        {
            SelectedDestinationService selectedDestinationService = CreateSelectedDestinationService();
            var selectedDestination = selectedDestinationService.GetSelectedDestinationById(id);
            return Ok(selectedDestination);
        }

        public IHttpActionResult Post(SelectedDestinationCreate selectedDestination)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSelectedDestinationService();

            if (!service.CreateSelectedDestination(selectedDestination))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SelectedDestinationEdit selectedDestination)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSelectedDestinationService();

            if (!service.UpdateSelectedDestination(selectedDestination))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateSelectedDestinationService();

            if (!service.DeleteSelectedDestination(id))
                return InternalServerError();

            return Ok();
        }

        private SelectedDestinationService CreateSelectedDestinationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var selectedDestinationService = new SelectedDestinationService(userId);
            return selectedDestinationService;
        }
    }
}