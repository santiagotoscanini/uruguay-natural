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

        [HttpPut("{id}")]
        public IActionResult UpdateLodging([FromRoute] int id, [FromBody] LodgingUpdateCapacityModel lodgingUpdateCapacityModel)
        {
            _lodgingService.Update(lodgingUpdateCapacityModel.ToEntity(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLodging([FromRoute] int id)
        {
            _lodgingService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddLodging([FromBody] LodgingCreatingModel lodgingCreatingModel)
        {
            var lodging = _lodgingService.Add(lodgingCreatingModel.ToEntity(), lodgingCreatingModel.TouristPointId);
            return StatusCode((int) HttpStatusCode.Created, new LodgingModelOut(lodging));
        }
    }
}
