using System;
using ApplicationCore.Services;
using ApplicationCoreInterface.Services;
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
        private DateTime _bookingCheckin = new DateTime(2020, 11, 02);
        private DateTime _bookingCheckout = new DateTime(2020, 12, 02);
        private string _touristPointName = "Punta del este";
        private double _costPerNight = 1.0;
        private int _numberOfAdults = 1;
        private int _totalNumberOfGuests = 1;
        private int _touristPointId = 1;
        private double _totalPrice = 30.0;
        private int _occupedPlaces = 2;

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
            var mockPriceCalculatedService = new Mock<IPriceCalculatorService>().Object;
            var lodgingService = new LodgingService(mock.Object, new Mock<ITouristPointService>().Object,
                mockPriceCalculatedService);

            IEnumerable<Lodging> lodgingsSaved = lodgingService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(lodgingsSaved.SequenceEqual(lodgingsToReturn));
        }

        [TestMethod]
        public void TestAddLodging()
        {
            var touristPoint = new TouristPoint { Name = _touristPointName };
            var lodgingToAdd = new Lodging
            {
                Id = _id,
                TouristPoint = touristPoint,
            };

            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(lodgingToAdd)).Returns(lodgingToAdd);

            var touristPointServiceMock = new Mock<ITouristPointService>();
            touristPointServiceMock.Setup(tp => tp.GetAll()).Returns(new List<TouristPoint>() { touristPoint });
            var mockPriceCalculatedService = new Mock<IPriceCalculatorService>().Object;

            var lodgingService = new LodgingService(mock.Object, touristPointServiceMock.Object, mockPriceCalculatedService);

            Lodging lodgingSaved = lodgingService.Add(lodgingToAdd, 0);

            mock.VerifyAll();
            Assert.AreEqual(lodgingToAdd, lodgingSaved);
        }

        [TestMethod]
        public void TestGetLodging()
        {
            var lodgingToGet = new Lodging
            {
                Id = _id, 
                CostPerNight = _costPerNight,
            };
            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetById(_id)).Returns(lodgingToGet);
            var mockPriceCalculatedService = new Mock<IPriceCalculatorService>().Object;
            var lodgingService = new LodgingService(mock.Object, new Mock<ITouristPointService>().Object,
                mockPriceCalculatedService);

            Lodging lodgingGetted = lodgingService.GetById(_id);

            mock.VerifyAll();
            Assert.AreEqual(lodgingToGet, lodgingGetted);
        }

        
        [TestMethod]
        public void TestGetFilteredLodging()
        {
            var lodgingToGet = new Lodging
            {
                Id = _id, 
                CostPerNight = _costPerNight,
            };
            var lodgingFilter = new LodgingToFilter
            {
                TouristPointId = _touristPointId,
                CheckInDate = _bookingCheckin,
                CheckOutDate = _bookingCheckout,
                NumberOfGuests = new NumberOfGuests{ NumberOfAdults = _numberOfAdults },
                TotalNumberOfGuests = _totalNumberOfGuests
                
            };
            var lodgingsFilter = new List<Lodging>{lodgingToGet};
            var lodgingsAndPricesFilter = new Dictionary<Lodging, double>();
            lodgingsAndPricesFilter.Add(lodgingToGet, _totalPrice);
            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.FilterLodgings(lodgingFilter)).Returns(lodgingsFilter);
            var mockPriceCalculatedService = new Mock<IPriceCalculatorService>();
            mockPriceCalculatedService.Setup(p => p.CalculatePrice(
                It.IsAny<NumberOfGuests>(), _costPerNight)).Returns(_costPerNight);
            var lodgingService = new LodgingService(mock.Object, new Mock<ITouristPointService>().Object,
                mockPriceCalculatedService.Object);

            Dictionary<Lodging, double> lodgingsGetted = lodgingService.FilterLodgings(lodgingFilter);

            mock.VerifyAll();
            Assert.IsTrue(lodgingsAndPricesFilter.SequenceEqual(lodgingsGetted));
        }
        
        [TestMethod]
        public void TestUpdateLodging()
        {
            var lodgingInfo = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = _occupedPlaces,
            };

            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Update(lodgingInfo)).Returns(lodgingInfo);
            var mockPriceCalculatedService = new Mock<IPriceCalculatorService>().Object;
            var lodgingService = new LodgingService(mock.Object, new Mock<ITouristPointService>().Object,
                mockPriceCalculatedService);

            var modifiedLodgingGetted = lodgingService.Update(lodgingInfo);

            mock.VerifyAll();
            Assert.AreEqual(lodgingInfo.CurrentlyOccupiedPlaces, modifiedLodgingGetted.CurrentlyOccupiedPlaces);
        }

        [TestMethod]
        public void TestDeleteLodging()
        {
            var lodging = new Lodging { Id = _id };

            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(lodging)).Returns(lodging);
            mock.Setup(r => r.Delete(_id));
            mock.Setup(r => r.GetAll()).Returns(new List<Lodging>());

            var touristPointServiceMock = new Mock<ITouristPointService>();
            touristPointServiceMock.Setup(tp => tp.GetAll()).Returns(new List<TouristPoint>());
            var mockPriceCalculatedService = new Mock<IPriceCalculatorService>().Object;
            var lodgingService = new LodgingService(mock.Object, touristPointServiceMock.Object,
                mockPriceCalculatedService);

            Lodging lodgingSaved = lodgingService.Add(lodging, 0);
            lodgingService.Delete(lodging.Id);
            IEnumerable<Lodging> lodgings = lodgingService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(lodgings.IsNullOrEmpty());
        }

        [TestMethod]
        public void TestGetLodgingsFilteredByTouristPointAndRage()
        {
            var lodgingToFilter = new LodgingToFilter
            {
                CheckInDate = _bookingCheckin,
                CheckOutDate = _bookingCheckout,
                TouristPointId = _touristPointId,
            };
            var touristPoint = new TouristPoint{Id = _touristPointId};
            var booking = new Booking
            {
                CheckInDate = _bookingCheckin,
                CheckOutDate = _bookingCheckout,
            };
            var booking2 = new Booking
            {
                CheckInDate = new DateTime(2020, 10, 02),
                CheckOutDate = new DateTime(2020, 11, 01),
            };
            var lodging = new Lodging
            {
                TouristPoint = touristPoint,
                Bookings = new List<Booking>
                {
                    booking,
                    booking2
                }
            };
            var lodging2 = new Lodging
            {
                TouristPoint = touristPoint,
                Bookings = new List<Booking>
                {
                    booking2
                }
            };
            var lodging3 = new Lodging
            {
                TouristPoint = new TouristPoint{Id = 11},
            };
            var lodgings = new List<Lodging>
            {
                lodging,
                lodging2,
                lodging3
            };
            var mock = new Mock<ILodgingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(lodgings);
            var mockTouristPointService = new Mock<ITouristPointService>().Object;
            var mockPriceCalculator = new Mock<IPriceCalculatorService>().Object;
            
            var lodgingService = new LodgingService(mock.Object, mockTouristPointService, mockPriceCalculator);

            var filteredLodgings = lodgingService.GetFilteredByTouristPointAndRange(lodgingToFilter);
            
            mock.VerifyAll();
            Assert.AreEqual(lodging, filteredLodgings.First());
            Assert.AreEqual(1, filteredLodgings.Count());
        }
    }
}
