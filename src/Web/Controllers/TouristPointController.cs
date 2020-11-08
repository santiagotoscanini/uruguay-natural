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
        /// Create tourist point
        /// </summary>
        /// <response code="201">Created successfully.</response>
        ///<response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult AddTouristPoint([FromBody] TouristPointCreatingModel touristPointModel)
        {
            var touristPoint = _touristPointService.Add(touristPointModel.ToEntity(), touristPointModel.Categories);
            return StatusCode((int) HttpStatusCode.Created, new TouristPointModel(touristPoint));
        }

        /// <summary>
        /// Get Tourist Point
        /// </summary>
        /// <response code="200">They were successfully obtained.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        public IActionResult GetTouristPointFiltered([FromQuery(Name = "region")] string region, [FromQuery(Name = "category")] string category)
        {
            return Ok(_touristPointService.GetAllFilteredByRegionAndCategory(region, category).Select(t => new TouristPointModel(t)));
        }
    }
}
