using Microsoft.AspNetCore.Mvc;
using SessionInterface;
using Web.Models.Session;

namespace Web.Controllers
{
    [Route("api/sessions")]
    public class SessionController : Controller
    {
        private ISessionService _sessions;

        public SessionController(ISessionService sessions) : base()
        {
            _sessions = sessions;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var token = _sessions.Login(model.Email, model.Password);
            if (token == null)
            {
                return BadRequest("Invalid email or password.");
            }
            return Ok(token);
        }

        [HttpPost("Logout")]
        public IActionResult Logout([FromBody] LogoutModel model)
        {

            if (!_sessions.Logout(model.Token))
            {
                return BadRequest("Invalid logout, user was not logged.");
            }
            return Ok();
        }
    }
}
