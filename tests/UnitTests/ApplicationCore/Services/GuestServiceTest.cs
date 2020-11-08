using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class GuestServiceTest
    {
        private Guest _guestAdult = new Guest { Name = "Adult" };
        private Guest _guestChild = new Guest { Name = "Child" };
        private Guest _guestBaby = new Guest { Name = "Baby" };

        [TestMethod]
        public void GetAllGuests()
        {
            var guestsToReturn = new List<Guest>
            {
                _guestAdult,
                _guestChild,
                _guestBaby
            };
            var mock = new Mock<IGuestRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(guestsToReturn);
            var guestService = new GuestService(mock.Object);

            IEnumerable<Guest> guestsSaved = guestService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(guestsSaved.SequenceEqual(guestsToReturn));   
        }
    }
}