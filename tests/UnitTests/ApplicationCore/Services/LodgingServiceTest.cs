using Castle.Core.Internal;
using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class LodgingServiceTest
    {
        private readonly int _id = 1;
        private readonly int _id2 = 2;

        [TestMethod]
        public void TestGetAllOk()
        {
            var lodgingsToReturn = new List<Lodging>
            {
                new Lodging { Id = _id },
                new Lodging { Id = _id2 },
            };
            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(lodgingsToReturn);
            var lodgingService = new LodgingService(mock.Object);

            IEnumerable<Lodging> lodgingsSaved = lodgingService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(lodgingsSaved.SequenceEqual(lodgingsToReturn));
        }

        [TestMethod]
        public void TestAddLodging()
        {
            var lodgingToAdd = new Lodging { Id = _id };

            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(lodgingToAdd)).Returns(lodgingToAdd);
            var lodgingService = new LodgingService(mock.Object);

            Lodging lodgingSaved = lodgingService.Add(lodgingToAdd);

            mock.VerifyAll();
            Assert.AreEqual(lodgingToAdd, lodgingSaved);
        }

        [TestMethod]
        public void TestGetLodging()
        {
            var lodgingToGet = new Lodging { Id = _id };
            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetById(_id)).Returns(lodgingToGet);
            var lodgingService = new LodgingService(mock.Object);

            Lodging lodgingGetted = lodgingService.Get(_id);

            mock.VerifyAll();
            Assert.AreEqual(lodgingToGet, lodgingGetted);
        }

        [TestMethod]
        public void TestUpdateLodging()
        {
            var lodgingInfo = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 2,
            };

            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Update(lodgingInfo));
            mock.Setup(r => r.GetById(_id)).Returns(lodgingInfo);
            var lodgingService = new LodgingService(mock.Object);

            lodgingService.Update(lodgingInfo);
            var modifiedLodgingGetted = lodgingService.Get(_id);

            mock.VerifyAll();
            Assert.AreEqual(lodgingInfo.CurrentlyOccupiedPlaces, modifiedLodgingGetted.CurrentlyOccupiedPlaces);
        }

        [TestMethod]
        public void TestDeleteLodging()
        {
            var lodging = new Lodging
            {
                Id = _id,
            };

            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(lodging)).Returns(lodging);
            mock.Setup(r => r.Delete(_id));
            mock.Setup(r => r.GetAll()).Returns(new List<Lodging>());
            var lodgingService = new LodgingService(mock.Object);

            Lodging lodgingSaved = lodgingService.Add(lodging);
            lodgingService.Delete(lodging.Id);
            ICollection<Lodging> lodgings = lodgingService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(lodgings.IsNullOrEmpty());
        }
    }
}
