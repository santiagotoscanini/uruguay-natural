using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Moq;
using System.Collections.Generic;
using InfrastructureInterface.Data.Repositories;
using System.Linq;
using ApplicationCore.Services;
using System;
using Exceptions;
using ApplicationCoreInterface.Services;
using Castle.Core;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class BookingServiceTest
    {
        private string _bookingCode1 = "booking_code_1";
        private string _bookingCode2 = "booking_code_2";
        private DateTime _bookingCheckin = new DateTime(2020, 11, 02);
        private DateTime _bookingCheckin2 = new DateTime(2020, 12, 05);
        private DateTime _bookingCheckout = new DateTime(2020, 12, 02);
        private int _numberOfAdults = 2;
        private int _totalNumberOfGuest = 2;
        private double _costPerNight = 1.0;
        private double _totalPrice = 30.0;
        private int _maximunSize = 100;
        private int _occupedPlaces = 12;

        [TestMethod]
        public void TestGetAllOk()
        {
            var bookingsToReturn = new List<Booking>
            {
                new Booking
                {
                    Code = _bookingCode1,
                },
                new Booking
                {
                    Code = _bookingCode2,
                },
            };
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(bookingsToReturn);
            var mockLodgingService = new Mock<ILodgingService>(MockBehavior.Strict);
            mockLodgingService.Setup(r => r.GetById(0)).Returns(new Lodging());
            var mockPriceCalculatorService = new Mock<IPriceCalculatorService>().Object;
            var bookingService = new BookingService(mock.Object, mockLodgingService.Object, mockPriceCalculatorService);

            IEnumerable<Booking> bookingsSaved = bookingService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(bookingsSaved.SequenceEqual(bookingsToReturn));
        }

        [TestMethod]
        public void TestAddBooking()
        {
            var bookingToAdd = new Booking
            { 
                Code = _bookingCode1,
                CheckInDate = _bookingCheckin,
                CheckOutDate = _bookingCheckout,
                Lodging = new Lodging { Id = 0, CostPerNight = _costPerNight},
                NumberOfGuests = new NumberOfGuests{ NumberOfAdults = _numberOfAdults },
                TotalNumberOfGuests = _totalNumberOfGuest,
                Price = _totalPrice,
            };
            var bookingToReturn = new Booking 
            { 
                Code = _bookingCode1,
                CheckInDate = _bookingCheckin,
                CheckOutDate = _bookingCheckout,
                Lodging = new Lodging { Id = 0, CostPerNight = _costPerNight},
                Price = _totalPrice,
                TotalNumberOfGuests = _totalNumberOfGuest,
            };
            var lodging = new Lodging
            {
                CurrentlyOccupiedPlaces = _occupedPlaces,
                MaximumSize = _maximunSize,
                CostPerNight = _costPerNight
            };
            
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(bookingToAdd)).Returns(bookingToReturn);
            var mockLodgingService = new Mock<ILodgingService>(MockBehavior.Strict);
            mockLodgingService.Setup(r => r.GetById(0)).Returns(lodging);
            mockLodgingService.Setup(r => r.Update(It.IsAny<Lodging>())).Returns(lodging);
            var mockPriceCalculatorService = new Mock<IPriceCalculatorService>();
            mockPriceCalculatorService.Setup(p => p.CalculatePrice(
                    It.IsAny<NumberOfGuests>(), _costPerNight))
                .Returns(_totalPrice);
            var bookingService = new BookingService(mock.Object, mockLodgingService.Object,
                mockPriceCalculatorService.Object);

            Booking bookingSaved = bookingService.Add(bookingToAdd);

            mock.VerifyAll();
            Assert.AreEqual(bookingToReturn, bookingSaved);
        }

        [TestMethod]
        public void TestGetBooking()
        {
            var bookingToGet = new Booking { Code = _bookingCode1 };
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Get(_bookingCode1)).Returns(bookingToGet);
            var mockLodgingService = new Mock<ILodgingService>().Object;
            var mockPriceCalculatorService = new Mock<IPriceCalculatorService>().Object;
            var bookingService = new BookingService(mock.Object, mockLodgingService, mockPriceCalculatorService);

            Booking bookingGetted = bookingService.Get(_bookingCode1);

            mock.VerifyAll();
            Assert.AreEqual(bookingToGet, bookingGetted);
        }

        [TestMethod]
        public void TestUpdateBookingState()
        {
            var booking = new Booking { Code = _bookingCode1, State = BookingState.EXPIRED };
            var updateStateInfoModel = new Booking { Code = _bookingCode1, State = BookingState.EXPIRED };
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.UpdateState(updateStateInfoModel));
            mock.Setup(r => r.Get(_bookingCode1)).Returns(booking);
            var mockLodgingService = new Mock<ILodgingService>(MockBehavior.Strict);
            mockLodgingService.Setup(r => r.GetById(0)).Returns(new Lodging());
            var mockPriceCalculatorService = new Mock<IPriceCalculatorService>().Object;
            var bookingService = new BookingService(mock.Object, mockLodgingService.Object, mockPriceCalculatorService);

            bookingService.UpdateState(updateStateInfoModel);
            var modifiedBookingGetted = bookingService.Get(_bookingCode1);

            mock.VerifyAll();
            Assert.AreEqual(updateStateInfoModel.State, modifiedBookingGetted.State);
        }
        
        [TestMethod]
        public void TestUpdateBookingReview()
        {
            var review = new Review{ Text = "Nice" };
            var lodging = new Lodging
            {
                Id = 0,
                NumberOfStars = 1,
                ReviewsCount = 1,
            };
            var booking = new Booking { Code = _bookingCode1, TouristReview = null, Lodging = lodging};
            var bookingWithReview = new Booking { Code = _bookingCode1, TouristReview = review, Lodging = lodging};
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.UpdateReview(booking));
            mock.Setup(r => r.Get(_bookingCode1)).Returns(booking);
            
            var mockLodgingService = new Mock<ILodgingService>(MockBehavior.Strict);
            mockLodgingService.Setup(r => r.GetById(lodging.Id)).Returns(lodging);
            mockLodgingService.Setup(r => r.Update(lodging)).Returns(lodging);
            
            var bookingService = new BookingService(mock.Object, mockLodgingService.Object, new Mock<IPriceCalculatorService>().Object);

            bookingService.UpdateReview(bookingWithReview);
            var modifiedBookingFetched = bookingService.Get(_bookingCode1);

            mock.VerifyAll();
            Assert.AreEqual(review.Text, modifiedBookingFetched.TouristReview.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void TestUpdateBookingSecondReview()
        {
            var review = new Review{ Text = "Nice" };
            var lodging = new Lodging
            {
                Id = 0,
                NumberOfStars = 1,
                ReviewsCount = 0,
            };
            var booking = new Booking { Code = _bookingCode1, TouristReview = review, Lodging = lodging};
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.UpdateReview(booking));
            mock.Setup(r => r.Get(_bookingCode1)).Returns(booking);
            
            var mockLodgingService = new Mock<ILodgingService>(MockBehavior.Strict);
            mockLodgingService.Setup(r => r.GetById(lodging.Id)).Returns(lodging);
            mockLodgingService.Setup(r => r.Update(lodging)).Returns(lodging);
            
            var bookingService = new BookingService(mock.Object, mockLodgingService.Object, new Mock<IPriceCalculatorService>().Object);

            bookingService.UpdateReview(booking);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeValuesException))]
        public void TestAddBookingWithWrongDates()
        {
             var bookingToAdd = new Booking
            { 
                CheckInDate = _bookingCheckin2,
                CheckOutDate = _bookingCheckout,
                Lodging = new Lodging { Id = 0, CostPerNight = _costPerNight},
                NumberOfGuests = new NumberOfGuests{NumberOfAdults = _numberOfAdults},
                TotalNumberOfGuests = _totalNumberOfGuest,
            };
            var bookingToReturn = new Booking 
            { 
                Code = _bookingCode1,
                CheckInDate = _bookingCheckin2,
                CheckOutDate = _bookingCheckout,
                Lodging = new Lodging { Id = 0, CostPerNight = _costPerNight},
                Price = _totalPrice,
                TotalNumberOfGuests = _totalNumberOfGuest,
            };
            var lodging = new Lodging { CurrentlyOccupiedPlaces = _occupedPlaces };

            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(bookingToReturn)).Returns(bookingToReturn);
            var mockLodgingService = new Mock<ILodgingService>(MockBehavior.Strict);
            mockLodgingService.Setup(r => r.GetById(0)).Returns(lodging);
            mockLodgingService.Setup(r => r.Update(lodging)).Returns(lodging);
            var mockPriceCalculatorService = new Mock<IPriceCalculatorService>();
            mockPriceCalculatorService.Setup(p => p.CalculatePrice(It.IsAny<NumberOfGuests>(), 1.0)).Returns(30.0);
            var bookingService = new BookingService(mock.Object, mockLodgingService.Object, mockPriceCalculatorService.Object);

            bookingService.Add(bookingToAdd);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeValuesException))]
        public void TestAddBookingToLodgingWithoutCapacity()
        {
            var bookingToAdd = new Booking
            { 
                CheckInDate = _bookingCheckin,
                CheckOutDate = _bookingCheckout,
                Lodging = new Lodging { Id = 0, CostPerNight = _costPerNight},
                NumberOfGuests = new NumberOfGuests{NumberOfAdults = _numberOfAdults},
                TotalNumberOfGuests = _totalNumberOfGuest,
            };
            var bookingToReturn = new Booking 
            { 
                Code = _bookingCode1,
                CheckInDate = _bookingCheckin,
                CheckOutDate = _bookingCheckout,
                Lodging = new Lodging { Id = 0, CostPerNight = _costPerNight},
                Price = _totalPrice,
                TotalNumberOfGuests = _totalNumberOfGuest,
            };
            var lodging = new Lodging
            {
                CurrentlyOccupiedPlaces = _maximunSize,
                MaximumSize = _maximunSize
            };

            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(bookingToReturn)).Returns(bookingToReturn);
            var mockLodgingService = new Mock<ILodgingService>(MockBehavior.Strict);
            mockLodgingService.Setup(r => r.GetById(0)).Returns(lodging);
            mockLodgingService.Setup(r => r.Update(lodging)).Returns(lodging);
            var mockPriceCalculatorService = new Mock<IPriceCalculatorService>();
            mockPriceCalculatorService.Setup(p => p.CalculatePrice(It.IsAny<NumberOfGuests>(), 1.0)).Returns(30.0);
            var bookingService = new BookingService(mock.Object, mockLodgingService.Object, mockPriceCalculatorService.Object);

            bookingService.Add(bookingToAdd);
        }
    }
}
