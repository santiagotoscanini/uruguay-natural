using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
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

        [HttpPost]
        public IActionResult AddTouristPoint([FromBody] TouristPointCreatingModel touristPointModel)
        {
            var touristPoint = _touristPointService.Add(touristPointModel.ToEntity(), touristPointModel.Categories);
            return StatusCode((int) HttpStatusCode.Created, new TouristPointModel(touristPoint));
        }

        [HttpGet]
        public IActionResult GetTouristPointFiltered([FromQuery(Name = "region")] string region, [FromQuery(Name = "category")] string category)
        {
            return Ok(_touristPointService.GetAllFilteredByRegionAndCategory(region, category).Select(t => new TouristPointModel(t)));
        }
    }
}
