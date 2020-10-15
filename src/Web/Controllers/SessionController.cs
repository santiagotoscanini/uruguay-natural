using Microsoft.AspNetCore.Mvc;
using SessionInterface;
using Web.Filters;
using Web.Models.Session;

namespace Web.Controllers
{
    [Route("api/v1/sessions")]
    public class SessionController : Controller
    {
        private ISessionService _sessions;

        public SessionController(ISessionService sessions) : base()
        {
            _sessions = sessions;
        }

        /// <summary>
        /// Ingresa a su cuenta un administrador.
        /// </summary>
        /// <response code="200">Ingreso exitosamente</response>
        /// <response code="400">Hay datos incorrectos</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var token = _sessions.Login(model.Email, model.Password);
            if (token == null)
            {
                return BadRequest("Invalid email or password.");
            }
            return Ok(new LoginOutModel { Token = token });
        }

        /// <summary>
        /// Cierra sesion un administrador.
        /// </summary>
        /// <response code="200">Se cerro sesion existosamente.</response>
        /// <response code="400">El usuario no estaba loggeado.</response>
        ///<response code="401">El usuario no se encuentra autorizado a realizar la consulta.</response>
        /// <response code="403">El usuario no se autentico con el perfil correspondiente para realizar la consulta</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpPost("logout")]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Logout([FromBody] LogoutModel model)
        {
            if (!_sessions.Logout(model.Token))
            {
                return BadRequest("Invalid logout, user was not logged.");
            }
            return Ok(new LogoutOutModel());
        }
    }
}
