using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VacationsUnited.WebAPI.Controllers
{
    [Authorize]
    public class ItineraryController : Controller
    {
        // GET: Itinerary

            public IHttpActionResult Get()
        {
            ItineraryService itineraryService = CreateItineraryService();
            var itineraries = itineraryService.GetItineraries();
            return (itineraries);

        }

        private ItineraryService CreateItineraryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var itineraryService = new ItineraryService(userId);
            return itineraryService;
        }
    }
}