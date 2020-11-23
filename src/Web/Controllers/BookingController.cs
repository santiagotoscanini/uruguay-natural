using Microsoft.AspNetCore.Mvc;
using ApplicationCoreInterface.Services;
using Web.Models.BookingModels;
using System.Linq;
using Web.Filters;

namespace Web.Controllers
{
    [Route("api/v1/bookings")]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        /// <summary>
        /// Get Reservations
        /// </summary>
        /// <response code="200">They were successfully obtained.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        public IActionResult GetAllBookings()
        {
            return Ok(_bookingService.GetAll().Select(b => new BookingModel(b)));
        }

        /// <summary>
        /// Create reservation
        /// </summary>
        /// <response code="201">Created successfully.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        public IActionResult AddBooking([FromBody]BookingCreatingModel bookingModel)
        {
            var booking = _bookingService.Add(bookingModel.ToEntity());
            return CreatedAtRoute("GetBooking", new { id = booking.Code }, new BookingBaseCreateModel(booking));
        }

        /// <summary>
        /// Get reservation
        /// </summary>
        /// <response code="200">Obtained successfully.</response>
        /// <response code="404">Doesn't exist a booking with that code.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("{id}", Name = "GetBooking")]
        public IActionResult GetBookingById([FromRoute] string id)
        {
            var booking = _bookingService.Get(id);
            return Ok(new BookingStateInfoModel(booking)); 
        }

        /// <summary>
        /// Update booking state
        /// </summary>
        /// <response code="204">Updated successfully</response>
        ///<response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="404">Doesn't exist a booking with that code.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult UpdateBookingState([FromRoute] string id, [FromBody] BookingStateUpdateModel bookingState)
        {
            _bookingService.UpdateState(bookingState.ToEntity(id));
            return NoContent();
        }
        
        /// <summary>
        /// Update booking review
        /// </summary>
        /// <response code="204">Updated successfully</response>
        /// <response code="404">Doesn't exist a booking with that code.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut("{id}/reviews")]
        public IActionResult UpdateBookingReview([FromRoute] string id, [FromBody] BookingReviewUpdateModel bookingReview)
        {
            _bookingService.UpdateReview(bookingReview.ToEntity(id));
            return NoContent();
        }
    }
}