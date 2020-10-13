﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Moq;
using System.Collections.Generic;
using InfrastructureInterface.Data.Repositories;
using System.Linq;
using ApplicationCore.Services;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class AdministratorServiceTest
    {
        [TestMethod]
        public void TestAddAdmin()
        {
            var adminToAdd = new Administrator { Email = "ricas@cosas.com" };
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(adminToAdd)).Returns(adminToAdd);
            var adminService = new AdministratorService(mock.Object);

            Administrator adminSaved = adminService.Add(adminToAdd);

            mock.VerifyAll();
            Assert.AreEqual(adminToAdd, adminSaved);
        }

        [TestMethod]
        public void TestGetAllOk()
        {
            var adminsToReturn = new List<Administrator>
            {
                new Administrator { Email = "un_mail@adinet.com.uy" },
                new Administrator { Email = "otro_mail@adinet.com.uy" },
            };
            var mock = new Mock<IAdministratorRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(adminsToReturn);
            var adminService = new AdministratorService(mock.Object);

            IEnumerable<Administrator> adminsSaved = adminService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(adminsSaved.SequenceEqual(adminsToReturn));
        }
    }
}