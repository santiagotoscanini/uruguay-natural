using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Models.LodgingModels;

namespace Web.Controllers
{
    [Route("api/v1/lodgings")]
    [ServiceFilter(typeof(Filters.AuthorizationAttributeFilter))]
    public class LodgingController : Controller
    {
        private ILodgingService _lodgingService;

        public LodgingController(ILodgingService bookingService)
        {
            _lodgingService = bookingService;
        }

        /// <summary>
        /// Se actualiza la capacidad actual de un hospedaje.
        /// </summary>
        /// <response code="204">Se actualizo existosamente</response>
        ///<response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="404">No existe un hospedaje con ese id</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpPut("{id}")]
        public IActionResult UpdateLodging([FromRoute] int id, [FromBody] LodgingUpdateCapacityModel lodgingUpdateCapacityModel)
        {
            _lodgingService.Update(lodgingUpdateCapacityModel.ToEntity(id));
            return NoContent();
        }

        /// <summary>
        /// Se elimina el hospedaje.
        /// </summary>
        /// <response code="204">Se elimino existosamente</response>
        ///<response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="404">No existe un hospedaje con ese id</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteLodging([FromRoute] int id)
        {
            _lodgingService.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Se agrega un hospedaje.
        /// </summary>
        /// <response code="201">Se creo exitosamente</response>
        ///<response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpPost]
        public IActionResult AddLodging([FromBody] LodgingCreatingModel lodgingCreatingModel)
        {
            var lodging = _lodgingService.Add(lodgingCreatingModel.ToEntity(), lodgingCreatingModel.TouristPointId);
            return StatusCode((int) HttpStatusCode.Created, new LodgingModelOut(lodging));
        }
    }
}
