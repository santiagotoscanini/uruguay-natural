using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Filters;
using Web.Models.AdministratorModel;
using Web.Models.AdministratorModels;

namespace Web.Controllers
{
    [Route("api/v1/administrators")]
    [ServiceFilter(typeof(AuthorizationAttributeFilter))]
    public class AdministratorController : Controller
    {
        private IAdministratorService _administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        /// <summary>
        /// Creates a new Administrator
        /// </summary>
        /// <response code="201">Created successfully.</response>
        /// <response code="400">Bad Request, there is another Administrator with the same email.</response>
        /// <response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        public IActionResult AddAdministrator([FromBody] AdministratorCreatingModel administratorModel)
        {
            var adminToReturn = new AdministratorBaseCreateModel(_administratorService.Add(administratorModel.ToEntity()));
            return StatusCode((int) HttpStatusCode.Created, adminToReturn);
        }

        /// <summary>
        /// Delete an administrator
        /// </summary>
        /// <response code="204">Removed successfully.</response>
        /// <response code="404">There is no administrator with that email.</response>
        /// <response code="401">User does not send a token, not Authenticated.</response>
        /// <response code="403">Not enough permissions, not Authorized.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete("{email}")]
        public IActionResult DeleteAdministrator([FromRoute] string email)
        {
            _administratorService.DeleteAdministrator(email);
            return NoContent();
        }

        /// <summary>
        /// Update Administrator details
        /// </summary>
        /// <response code="204">Updated successfully.</response>
        /// <response code="404">There is no administrator with that email.</response>
        /// <response code="401">User does not send a token, not Authenticated</response>
        /// <response code="403">Not enough permissions, not Authorized</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut("{email}")]
        public IActionResult UpdateAdministrator([FromRoute] string email, [FromBody] AdministratorUpdatingModel administratorUpdatingModel)
        {
            _administratorService.UpdateAdministrator(administratorUpdatingModel.ToEntity(email));
            return NoContent();
        }
    }
}
