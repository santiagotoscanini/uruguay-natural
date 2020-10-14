using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class TouristPointServiceTest
    {
        private int _id = 1;
        private int _id2 = 2;

        [TestMethod]
        public void TestGetAllOk()
        {
            var touristPointsToReturn = new List<TouristPoint>
            {
                new TouristPoint
                {
                    Id = _id,
                },
                new TouristPoint
                {
                    Id = _id2,
                },
            };
            var mock = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(touristPointToReturn);
            var touristPointService = new TouristPointService(mock.Object);

            IEnumerable<TouristPoint> touristPointsSaved = touristPointService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(touristPointsSaved.SequenceEqual(touristPointsToReturn));
        }

        [TestMethod]
        public void TestAddTouristPoint()
        {
            var touristPointToAdd = new TouristPoint
            {
                Id = _id,
            };

            var mock = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(touristPointToAdd)).Returns(touristPointToAdd);
            var touristPointService = new TouristPointService(mock.Object);

            TouristPoint touristPointSaved = touristPointService.Add(touristPointToAdd);

            mock.VerifyAll();
            Assert.AreEqual(touristPointToAdd, touristPointSaved);
        }
    }
}
