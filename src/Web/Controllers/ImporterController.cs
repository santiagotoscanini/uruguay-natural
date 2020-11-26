using System.Net;
using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;
using Web.Models.ImporterModel;

namespace Web.Controllers
{
    [Route("api/v1/importers")]
    [ServiceFilter(typeof(AuthorizationAttributeFilter))]
    public class ImporterController : Controller
    {
        private IImporterService _importerService;

        public ImporterController(IImporterService importerService)
        {
            _importerService = importerService;
        }
        
        /// <summary>
        /// Get names of importers
        /// </summary>
        /// <response code="200">Obtained successfully.</response>
        /// <response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        public IActionResult GetImporters()
        {
            return Ok(_importerService.GetNames());
        }
        
        /// <summary>
        /// Save lodgings using the selected importer
        /// </summary>
        /// <response code="201">Created successfully.</response>
        ///<response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="404">Doesn't exist a importer with that name.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        [ServiceFilter(typeof(Filters.AuthorizationAttributeFilter))]
        public IActionResult ImportLodgings([FromBody] ImporterBaseModel importerBaseModel)
        {
            _importerService.Import(importerBaseModel.Name, importerBaseModel.FilePath);
            return StatusCode((int) HttpStatusCode.Created);
        }
    }
}