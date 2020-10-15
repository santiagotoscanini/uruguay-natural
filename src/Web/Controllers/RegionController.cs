using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Models.RegionModels;

namespace Web.Controllers
{
    [Route("api/v1/regions")]
    public class RegionController : Controller
    {
        private IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        /// <summary>
        /// Obtener las regiones.
        /// </summary>
        /// <response code="200">Se obtuvieron exitosamente</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            return Ok(_regionService.GetAll().Select(r => new RegionModel(r)));
        }
    }
}
