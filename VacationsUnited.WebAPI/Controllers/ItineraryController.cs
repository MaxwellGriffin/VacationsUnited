using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VacationsUnited.Models.Itinerary;
using VacationsUnited.Services;

namespace VacationsUnited.WebAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ItineraryController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ItineraryService itineraryService = CreateItineraryService();
            var itinerarys = itineraryService.GetItinerarys();
            return Ok(itinerarys);
        }

        private ItineraryService CreateItineraryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var itineraryService = new ItineraryService(userId);
            return itineraryService;
        }

        public IHttpActionResult Get(int id)
        {
            ItineraryService itineraryService = CreateItineraryService();
            var itinerary = itineraryService.GetItineraryByID(id);
            return Ok(itinerary);
        }

        public IHttpActionResult Post(ItineraryCreate itinerary)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateItineraryService();

            if (!service.CreateItinerary(itinerary))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ItineraryEdit itinerary)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateItineraryService();

            if (!service.EditItinerary(itinerary))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateItineraryService();

            if (!service.DeleteItinerary(id))
                return InternalServerError();

            return Ok();
        }


    }


}
