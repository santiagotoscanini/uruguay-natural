using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SessionInterface;
using Web.Controllers;
using Web.Models.Session;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class SessionControllerTest
    {
        private string _email = "nida@mail.com";
        private string _password = "bonberoandtadedust";
        private string _token = "token01";
        private string _tokenFail = null;

        [TestMethod]
        public void LoginTest()
        {
            var loginModel = new LoginModel
            { 
                Email = _email,
                Password = _password,
            };

            var mock = new Mock<ISessionService>();
            mock.Setup(s => s.Login(_email, _password)).Returns(_token);
            var sessionController = new SessionController(mock.Object);

            IActionResult result = sessionController.Login(loginModel);
            var status = result as OkObjectResult;
            var generatedToken = status.Value as string;

            mock.VerifyAll();
            Assert.AreEqual(_token, generatedToken);
        }

        [TestMethod]
        public void LoginFailTest()
        {
            var loginModel = new LoginModel
            {
                Email = _email,
                Password = _password,
            };

            var mock = new Mock<ISessionService>();
            mock.Setup(s => s.Login(_email, _password)).Returns(_tokenFail);
            var sessionController = new SessionController(mock.Object);

            IActionResult result = sessionController.Login(loginModel);
            var status = result as BadRequestObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(400, status.StatusCode);
        }

        [TestMethod]
        public void LogoutTest()
        {
            var logoutModel = new LogoutModel
            {
                Token = _token,
            };

            var mock = new Mock<ISessionService>();
            mock.Setup(s => s.Logout(_token)).Returns(true);
            var sessionController = new SessionController(mock.Object);

            IActionResult result = sessionController.Logout(logoutModel);
            var status = result as OkResult;

            mock.VerifyAll();
            Assert.AreEqual(200, status.StatusCode);
        }

        [TestMethod]
        public void LogoutFailTest()
        {
            var logoutModel = new LogoutModel
            {
                Token = _token,
            };

            var mock = new Mock<ISessionService>();
            mock.Setup(s => s.Logout(_token)).Returns(false);
            var sessionController = new SessionController(mock.Object);

            IActionResult result = sessionController.Logout(logoutModel);
            var status = result as BadRequestObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(400, status.StatusCode);
        }

    }
}
