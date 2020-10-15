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
        /// Crea un nuevo Administrador.
        /// </summary>
        /// <response code="201">Se creo exitosamente</response>
        /// <response code="400">Ya hay un administrador registrado con ese email</response>
        /// <response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="500">Ocrrio un error en el servidor</response>
        [HttpPost]
        public IActionResult AddAdministrator([FromBody] AdministratorCreatingModel administratorModel)
        {
            var adminToReturn = new AdministratorBaseCreateModel(_administratorService.Add(administratorModel.ToEntity()));
            return StatusCode((int) HttpStatusCode.Created, adminToReturn);
        }

        /// <summary>
        /// Elimina un Administrador.
        /// </summary>
        /// <response code="204">Se elimino exitosamente</response>
        /// <response code="404">No existe el administrador con ese email</response>
        /// <response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="500">Ocrrio un error en el servidor</response>
        [HttpDelete("{email}")]
        public IActionResult DeleteAdministrator([FromRoute] string email)
        {
            _administratorService.DeleteAdministrator(email);
            return NoContent();
        }

        /// <summary>
        /// Actualiza los datos de un Administrador.
        /// </summary>
        /// <response code="204">Se actualizo exitosamente</response>
        /// <response code="404">No existe el administrador con ese email</response>
        /// <response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="500">Ocrrio un error en el servidor</response>
        [HttpPut("{email}")]
        public IActionResult UpdateAdministrator([FromRoute] string email, [FromBody] AdministratorUpdatingModel administratorUpdatingModel)
        {
            _administratorService.UpdateAdministrator(administratorUpdatingModel.ToEntity(email));
            return NoContent();
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
