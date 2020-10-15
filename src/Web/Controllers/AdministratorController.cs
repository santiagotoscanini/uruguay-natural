using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult AddAdministrator([FromBody] AdministratorCreatingModel administratorModel)
        {
            var adminToReturn = new AdministratorBaseCreateModel(_administratorService.Add(administratorModel.ToEntity()));
            return Ok(adminToReturn);
        }

        [HttpDelete("{email}")]
        public IActionResult DeleteAdministrator([FromRoute] string email)
        {
            _administratorService.DeleteAdministrator(email);
            return NoContent();
        }

        [HttpPut("{email}")]
        public IActionResult UpdateAdministrator([FromRoute] string email, [FromBody] AdministratorUpdatingModel administratorUpdatingModel)
        {
            _administratorService.UpdateAdministrator(administratorUpdatingModel.ToEntity(email));
            return NoContent();
        }
    }
}
