using System.Collections.Generic;
using System.Linq;
using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Models.LodgingModels;

namespace Web.Controllers
{
    [Route("api/v1/lodgings")]
    public class LodgingController : Controller
    {
        private ILodgingService _lodgingService;

        public LodgingController(ILodgingService bookingService)
        {
            _lodgingService = bookingService;
        }

        /// <summary>
        /// Update Lodging capacity
        /// </summary>
        /// <response code="204">Updated successfully.</response>
        /// <response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="404">Doesn't exist a lodging with that id.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(Filters.AuthorizationAttributeFilter))]
        public IActionResult UpdateLodging([FromRoute] int id,
            [FromBody] LodgingUpdateCapacityModel lodgingUpdateCapacityModel)
        {
            _lodgingService.Update(lodgingUpdateCapacityModel.ToEntity(id));
            return NoContent();
        }

        /// <summary>
        /// Delete a Lodging
        /// </summary>
        /// <response code="204">Deleted successfully.</response>
        ///<response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="404">Doesn't exist a lodging with that id.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(Filters.AuthorizationAttributeFilter))]
        public IActionResult DeleteLodging([FromRoute] int id)
        {
            _lodgingService.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Create a Lodging
        /// </summary>
        /// <response code="201">Created successfully.</response>
        ///<response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        [ServiceFilter(typeof(Filters.AuthorizationAttributeFilter))]
        public IActionResult AddLodging([FromBody] LodgingCreatingModel lodgingCreatingModel)
        {
            var lodging = _lodgingService.Add(lodgingCreatingModel.ToEntity(), lodgingCreatingModel.TouristPointId);
            return StatusCode((int) HttpStatusCode.Created, new LodgingModelOut(lodging));
        }

        /// <summary>
        /// Get Lodgings Filtered
        /// </summary>
        /// <response code="200">Obtained successfully.</response>
        /// <response code="400">Bad Request, the number of guests cannot be less than zero.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        public IActionResult GetLodgingsFiltered([FromQuery] LodgingFilterModel lodgingFilterModel)
        {
            var lodgingsAndPrices = _lodgingService.FilterLodgings(lodgingFilterModel.ToEntity());
            IEnumerable<LodgingFilteredModel> lodgingsToReturn =
                lodgingsAndPrices.Select(l => new LodgingFilteredModel(l.Key, l.Value)).ToList().AsEnumerable();
            return Ok(lodgingsToReturn);
        }

        /// <summary>
        /// Get Filtered by Tourist Point and Range of time
        /// </summary>
        /// <response code="200">Obtained successfully.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("reports")]
        public IActionResult GetLodgingsFilteredByTouristPointAndRange([FromQuery] LodgingFilterByTouristPointAndRangeModel lodgingFilterModel)
        {
            var lodgings = _lodgingService.GetFilteredByTouristPointAndRange(lodgingFilterModel.ToEntity());
            return Ok(lodgings.Select(l => new LodgingModelOut(l)));
        }
    }
}