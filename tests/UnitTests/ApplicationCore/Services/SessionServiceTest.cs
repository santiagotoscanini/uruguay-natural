using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ApplicationCore.Services;
using System.Collections.Generic;

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
                    Password =_password,
                },
            };

            Mock<IAdministratorRepository> mock = new Mock<IAdministratorRepository>();
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
            Mock<IAdministratorRepository> mock = new Mock<IAdministratorRepository>();
            var sessionService = new SessionService(mock.Object);

            var isCorrectToken = sessionService.IsCorrectToken(_token);

            mock.VerifyAll();
            Assert.IsFalse(isCorrectToken);
        }

        [TestMethod]
        public void LoginFailTest()
        {
            IList<Administrator> admins = new List<Administrator>();
            Mock<IAdministratorRepository> mock = new Mock<IAdministratorRepository>();
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

            Mock<IAdministratorRepository> mock = new Mock<IAdministratorRepository>();
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
            Mock<IAdministratorRepository> mock = new Mock<IAdministratorRepository>();
            var sessionService = new SessionService(mock.Object);

            var isLoggedOut = sessionService.Logout(_token);

            mock.VerifyAll();
            Assert.IsFalse(isLoggedOut);
        }
    }
}
