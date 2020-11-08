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
        /// Get regions
        /// </summary>
        /// <response code="200">They were successfully obtained.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            return Ok(_regionService.GetAll().Select(r => new RegionModel(r)));
        }
    }
}
