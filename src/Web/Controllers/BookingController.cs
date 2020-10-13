using Microsoft.AspNetCore.Mvc;
using ApplicationCoreInterface.Services;
using Web.Models.BookingModels;
using System.Linq;
using Web.Filters;
using System;

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
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult GetAllBookings()
        {
            return Ok(_bookingService.GetAll().Select(b => new BookingModel(b)));
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody]BookingCreatingModel bookingModel)
        {
            var booking = _bookingService.Add(bookingModel.ToEntity());
            return CreatedAtRoute("GetBooking", new { id = booking.Code }, new BookingBaseCreateModel(booking));
        }

        [HttpGet("{id}", Name = "GetBooking")]
        public IActionResult GetBookingById([FromRoute] string id)
        {
            var booking = _bookingService.Get(id);
            return Ok(new BookingStateInfoModel(booking)); 
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult UpdateBooking([FromRoute] string id, [FromBody] BookingUpdateInfoModel booking)
        {
            _bookingService.Update(booking.ToEntity(id));
            return Ok();
        }
    }
}
    