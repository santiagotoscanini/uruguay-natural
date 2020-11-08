using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ApplicationCore.Services;
using System.Collections.Generic;
using System.Security.Authentication;
using ApplicationCoreInterface.Services;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class SessionServiceTest
    {

        private string _token = "token01";
        private string _email = "admin@amail.com";
        private string _password = "password01";

        [TestMethod]
        public void IsCorrectTokenTest()
        {
            IList<Administrator> administrators = new List<Administrator>
            {
                new Administrator
                {
                    Email = _email,
                    Password = _password,
                },
            };

            Mock<IAdministratorService> mock = new Mock<IAdministratorService>();
            mock.Setup(s => s.GetAll()).Returns(administrators);
            var sessionService = new SessionService(mock.Object);

            string token = sessionService.Login(_email, _password);
            var isCorrectToken = sessionService.IsCorrectToken(token);

            mock.VerifyAll();
            Assert.IsTrue(isCorrectToken);
        }

        [TestMethod]
        public void IsCorrectTokenFailTest()
        {
            Mock<IAdministratorService> mock = new Mock<IAdministratorService>();
            var sessionService = new SessionService(mock.Object);

            var isCorrectToken = sessionService.IsCorrectToken(_token);

            mock.VerifyAll();
            Assert.IsFalse(isCorrectToken);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCredentialException))]
        public void LoginFailTest()
        {
            IList<Administrator> admins = new List<Administrator>();
            Mock<IAdministratorService> mock = new Mock<IAdministratorService>();
            mock.Setup(s => s.GetAll()).Returns(admins);
            var sessionService = new SessionService(mock.Object);

            string token = sessionService.Login(_email, _password);

            mock.VerifyAll();
            Assert.IsNull(token);
        }


        [TestMethod]
        public void LogoutTest()
        {
            IList<Administrator> administrators = new List<Administrator>
            {
                new Administrator
                {
                    Email = _email,
                    Password =_password,
                },
            };

            Mock<IAdministratorService> mock = new Mock<IAdministratorService>();
            mock.Setup(s => s.GetAll()).Returns(administrators);
            var sessionService = new SessionService(mock.Object);

            string token = sessionService.Login(_email, _password);
            var isLoggedOut = sessionService.Logout(token);

            mock.VerifyAll();
            Assert.IsTrue(isLoggedOut);
        }


        [TestMethod]
        public void LogoutFailTest()
        {
            Mock<IAdministratorService> mock = new Mock<IAdministratorService>();
            var sessionService = new SessionService(mock.Object);

            var isLoggedOut = sessionService.Logout(_token);

            mock.VerifyAll();
            Assert.IsFalse(isLoggedOut);
        }
    }
}
