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
        /// Login
        /// </summary>
        /// <response code="200">Successfully logged in.</response>
        /// <response code="400">Invalid credentials.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var token = _sessions.Login(model.Email, model.Password);
            return Ok(new LoginOutModel { Token = token });
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <response code="200">Successfully logged out.</response>
        /// <response code="401">User does not send a token, not Authenticated</response>
        /// <response code="403">Not enough permissions, not Authorized</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost("logout")]
        [ServiceFilter(typeof(AuthorizationAttributeFilter))]
        public IActionResult Logout([FromBody] LogoutModel model)
        {
            _sessions.Logout(model.Token);
            return Ok(new LogoutOutModel());
        }
    }
}
