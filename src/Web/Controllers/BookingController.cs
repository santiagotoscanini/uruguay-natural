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
        /// Obtiene las reservas.
        /// </summary>
        /// <response code="200">Se obtuvieron exitosamente</response>
        /// <response code="500">Ocrrio un error en el servidor</response>
        [HttpGet]
        public IActionResult GetAllBookings([FromQuery(Name = "tourist-point")] string touristPoint)
        {
            return Ok(_bookingService.GetAll().Select(b => new BookingModel(b)));
        }

        /// <summary>
        /// Se crea una nueva reserva.
        /// </summary>
        /// <response code="201">Se creo exitosamente</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpPost]
        public IActionResult AddBooking([FromBody]BookingCreatingModel bookingModel)
        {
            var booking = _bookingService.Add(bookingModel.ToEntity());
            return CreatedAtRoute("GetBooking", new { id = booking.Code }, new BookingBaseCreateModel(booking));
        }

        /// <summary>
        /// Se obtiene una reserva por su codigo.
        /// </summary>
        /// <response code="200">Se obtuvo existosamente</response>
        /// <response code="404">No existe una reserva con ese codigo</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpGet("{id}", Name = "GetBooking")]
        public IActionResult GetBookingById([FromRoute] string id)
        {
            var booking = _bookingService.Get(id);
            return Ok(new BookingStateInfoModel(booking)); 
        }

        /// <summary>
        /// Se actualiza el estado de una reserva.
        /// </summary>
        /// <response code="204">Se modifico existosamente</response>
        ///<response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="404">No existe una reserva con ese codigo</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult UpdateBooking([FromRoute] string id, [FromBody] BookingUpdateInfoModel booking)
        {
            _bookingService.Update(booking.ToEntity(id));
            return NoContent();
        }
    }
}
    