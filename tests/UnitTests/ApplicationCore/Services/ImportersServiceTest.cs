using System;
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
        private byte[] _byte = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAJkAAAD2CAYAAADF/iU1AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiUAABYlAUlSJPAAAGFwSURBVHhe7X0FgFVV9/2d7k6YYuju7hZJaQSUkAYBgaFrhhmGBkGRUFQUAwVbbOxCRUQEFAmRbpiu9d/r3DnD4/Hw933/jxEY3tHFfXPvuXH2WWfvfdrIy8uDHXYUJuwks6PQYSeZHYUOO8nsKHTYSWZHocNOMjsKHXaS2VHosJPMjkKHnWR2FDrsJLOj0GEnmR2FDjvJ7Ch02ElmR6HDTrL/Ebm5uQq2rtlhwk6y/wEkV05OjoKdaDeGnWT/H8gFkC2kyszKQlp6ukKW/FZky7OTzRp2kv0XyBXkCIkys7ORkZWJi5cuYcubb+HV11/HufPn5HwWMnOyhYS2779bYSfZf4HcvBxk5Yj2ykjH5StX8NjapxAcUQJB4RFIXrwIJ0+dQppcT8/JVEQjKW09526DnWT/BWgKM7IylHl85rnnERAcBmdHVzg5u8HZ3QNx06fh5OnTSM1MQ3aeaDS76VSwk+==");
        
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
            var touristPoint = new TouristPoint
            {
                Id = 4,
                Image = _byte
            };
            var lodging = new Lodging
            {
                Id = 5,
                Images = new List<byte[]>{_byte}
            };
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