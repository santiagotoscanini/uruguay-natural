using Microsoft.AspNetCore.Mvc;
using ApplicationCoreInterface.Services;
using System;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {

        private IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookingService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookingModel bookingModel)
        {
            var booking = _bookingService.Add(bookingModel.ToEntity());
            return CreatedAtRoute("GetName", new {id = booking.Code}, booking);
        }
    }
}
    