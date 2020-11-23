using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Services;
using ApplicationCoreInterface.Services;
using Entities;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class ImportersServiceTest
    {
        [TestMethod]
        public void GetNamesTest()
        {
            var mockTouristPointService = new Mock<ITouristPointService>().Object;
            var mockLodgingService = new Mock<ILodgingService>().Object;
            
            var service = new ImporterService(mockTouristPointService, mockLodgingService);

            var importers = service.GetNames();
            
            Assert.AreEqual(1, importers.Count());
        }
        
        [TestMethod]
        public void ImportLodgingsTest()
        {
            var touristPoint = new TouristPoint{Id = 4};
            var lodging = new Lodging{Id = 5};
            var path = "path dummy";
            var mockTouristPointService = new Mock<ITouristPointService>();
            mockTouristPointService.Setup(t => 
                t.Add(It.IsAny<TouristPoint>(), It.IsAny<ICollection<string>>())).Returns(touristPoint);
            var mockLodgingService = new Mock<ILodgingService>();
            mockLodgingService.Setup(l => 
                l.Add(It.IsAny<Lodging>(), It.IsAny<int>())).Returns(lodging);
            
            var service = new ImporterService(mockTouristPointService.Object, mockLodgingService.Object);

            var importers = service.GetNames();
            service.Import(importers.First(), path);
            
            mockLodgingService.VerifyAll();
            mockTouristPointService.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void ImportLodgingsTestFail()
        {
            var path = "path dummy";
            var mockTouristPointService = new Mock<ITouristPointService>().Object;
            var mockLodgingService = new Mock<ILodgingService>().Object;
            
            var service = new ImporterService(mockTouristPointService, mockLodgingService);
            
            service.Import("dummy name", path);
        }
    }
}