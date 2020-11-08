using System.Security.Authentication;
using Castle.Core.Internal;
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
            var loginOutModel = status.Value as LoginOutModel;

            mock.VerifyAll();
            Assert.AreEqual(_token, loginOutModel.Token);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCredentialException))]
        public void LoginFailTest()
        {
            var loginModel = new LoginModel
            {
                Email = _email,
                Password = _password,
            };

            var mock = new Mock<ISessionService>();
            mock.Setup(s => s.Login(_email, _password)).Throws(new InvalidCredentialException());
            var sessionController = new SessionController(mock.Object);
            
            sessionController.Login(loginModel);;
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
            var status = result as OkObjectResult;
            var logoutModelResult = status.Value as LogoutOutModel;

            mock.VerifyAll();
            Assert.AreEqual(200, status.StatusCode);
            Assert.IsFalse(logoutModelResult.Message.IsNullOrEmpty());
        }
    }
}
