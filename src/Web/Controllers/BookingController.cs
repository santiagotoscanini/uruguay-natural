using Microsoft.AspNetCore.Mvc;
using ApplicationCoreInterface.Services;
using Web.Models.BookingModels;
using System.Linq;
using Entities;

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
            return Ok(_bookingService.GetAll().Select(b => new BookingModel(b)));
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookingCreatingInfoModel bookingModel)
        {
            var Booking = _bookingService.Add(bookingModel.ToEntity());
            return CreatedAtRoute("GetBooking", new { id = Booking.Code }, new BookingBaseCreateInfoModel(Booking));
        }

        [HttpGet("{id}", Name = "GetBooking")]
        public IActionResult Get([FromRoute] string id)
        {
            var Booking = _bookingService.Get(id);
            return Ok(new BookingStateInfoModel(Booking)); 
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] BookingUpdateInfoModel booking)
        {
            _bookingService.Update(booking.ToEntity(id));
            return Ok();
        }
    }
}
    