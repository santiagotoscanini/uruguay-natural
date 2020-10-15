using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using Web.Filters;
using Web.Models.TouristPointModels;

namespace Web.Controllers
{
    [Route("api/v1/tourist-points")]
    public class TouristPointController : Controller
    {
        private ITouristPointService _touristPointService;

        public TouristPointController(ITouristPointService touristPointService)
        {
            _touristPointService = touristPointService;
        }

        /// <summary>
        /// Se agrega un punto turistico.
        /// </summary>
        /// <response code="201">Se creo exitosamente</response>
        ///<response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult AddTouristPoint([FromBody] TouristPointCreatingModel touristPointModel)
        {
            var touristPoint = _touristPointService.Add(touristPointModel.ToEntity(), touristPointModel.Categories);
            return StatusCode((int) HttpStatusCode.Created, new TouristPointModel(touristPoint));
        }

        /// <summary>
        /// Se obtienen los puntos turisticos filtrados por region y por categoria.
        /// </summary>
        /// <response code="200">Se obtuvieron exitosamente</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpGet]
        public IActionResult GetTouristPointFiltered([FromQuery(Name = "region")] string region, [FromQuery(Name = "category")] string category)
        {
            return Ok(_touristPointService.GetAllFilteredByRegionAndCategory(region, category).Select(t => new TouristPointModel(t)));
        }
    }
}
