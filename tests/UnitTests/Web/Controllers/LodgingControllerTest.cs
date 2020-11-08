using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers;
using Web.Models.LodgingModels;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class LodgingControllerTest
    {
        private int _id = 1;
        private int _actualCapacity = 2;
        private int _touristPointId = 1;
        private DateTime _checkInDate = DateTime.Now;
        private DateTime _checkOutDate = DateTime.Now;

        [TestMethod]
        public void UpdateLodgingTest()
        {
            var lodgingModel = new LodgingUpdateCapacityModel {ActualCapacity = _actualCapacity};
            Lodging lodging = lodgingModel.ToEntity(_id);

            var mockLodgingService = new Mock<ILodgingService>();
            mockLodgingService.Setup(l => l.Update(It.IsAny<Lodging>())).Returns(lodging);
            var lodgingController = new LodgingController(mockLodgingService.Object);

            var result = lodgingController.UpdateLodging(_id, lodgingModel);
            var status = result as NoContentResult;

            mockLodgingService.VerifyAll();
            Assert.AreEqual(204, status.StatusCode);
        }

        [TestMethod]
        public void DeleteLodgingTest()
        {
            var mockLodgingService = new Mock<ILodgingService>();
            mockLodgingService.Setup(l => l.Delete(_id));
            var lodgingController = new LodgingController(mockLodgingService.Object);

            var result = lodgingController.DeleteLodging(_id);
            var status = result as NoContentResult;

            mockLodgingService.VerifyAll();
            Assert.AreEqual(204, status.StatusCode);
        }

        [TestMethod]
        public void AddLodgingTest()
        {
            var touristPoint = new TouristPoint {Id = _touristPointId};
            var lodgingModel = new LodgingCreatingModel
            {
                Name = "Lod1",
                TouristPointId = _touristPointId
            };
            var lodging = new Lodging
            {
                Name = "Lod1",
                TouristPoint = touristPoint,
                Id = _id,
            };

            var mockLodgingService = new Mock<ILodgingService>();
            mockLodgingService.Setup(l => l.Add(It.IsAny<Lodging>(), _touristPointId)).Returns(lodging);
            var lodgingController = new LodgingController(mockLodgingService.Object);

            var result = lodgingController.AddLodging(lodgingModel);
            var status = result as ObjectResult;
            var lodgingSaved = status.Value as LodgingModelOut;

            Assert.AreEqual(201, status.StatusCode);
            Assert.AreEqual(_id, lodgingSaved.Id);
        }

        [TestMethod]
        public void GetLodgingsFilteredTest()
        {
            var lodgingFilterModel = new LodgingFilterModel
            {
                TouristPointId = _touristPointId,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfAdults = 1,
                NumberOfBabies = 0,
                NumberOfChildren = 0,
            };
            var lodging = new Lodging
            {
                Id = 1,
                CostPerNight = 10.0
            };
            var lodgingsAndPrices = new Dictionary<Lodging, double>();
            lodgingsAndPrices.Add(lodging, 10.0);
            var lodgingFilteredModel = new LodgingFilteredModel(lodging, 10.0);

            var mockLodgingService = new Mock<ILodgingService>();
            mockLodgingService.Setup(l => l.FilterLodgings(It.IsAny<LodgingToFilter>())).Returns(lodgingsAndPrices);
            var lodgingController = new LodgingController(mockLodgingService.Object);

            IActionResult result = lodgingController.GetLodgingsFiltered(lodgingFilterModel);
            var status = result as ObjectResult;
            var lodgings = status.Value as IEnumerable<LodgingFilteredModel>;

            Assert.AreEqual(200, status.StatusCode);
            var lodgingsExpected = new List<LodgingFilteredModel> {lodgingFilteredModel};
            Assert.IsTrue(lodgingsExpected.SequenceEqual(lodgings));
        }
    }
}
