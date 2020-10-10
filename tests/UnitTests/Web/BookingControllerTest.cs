using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Controllers;
using Web.Models.BookingModels;

namespace UnitTests.Web
{
    [TestClass]
    public class BookingControllerTest
    {
        private string _bookingCode1 = "booking_code_1";
        private string _bookingCode2 = "booking_code_2";
        private Tourist _tourist = new Tourist();
        private string _touristName = "Mark";
        private string _touristSurname = "Douglas";
        private string _touristEmail = "md@dummymail.com";
        private BookingState _state = BookingState.CREATED;
        private string _description = "This is a dummy description.";
        private DateTime _checkInDate = DateTime.Now;
        private DateTime _checkOutDate = DateTime.Now;
        private int _numberOfGuests = 3;
        private BookingState _state2 = BookingState.PENDING_OF_PAY;
        private string _description2 = "This is a other dummy description.";

        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            List<Booking> BookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Code = _bookingCode1,
                    Tourist = _tourist,
                    State = _state,
                    Description = _description,
                    CheckInDate = _checkInDate,
                    CheckOutDate = _checkOutDate,
                    NumberOfGuests = _numberOfGuests,
                },
                new Booking()
                {
                    Code = _bookingCode2,
                    Tourist = _tourist,
                    State = _state,
                    Description = _description,
                    CheckInDate = _checkInDate,
                    CheckOutDate = _checkOutDate,
                    NumberOfGuests = _numberOfGuests,
                }
            };

            var Mock = new Mock<IBookingService>(MockBehavior.Strict);
            Mock.Setup(m => m.GetAll()).Returns(BookingsToReturn);
            var Controller = new BookingController(Mock.Object);

            var Result = Controller.Get();
            var OkResult = Result as OkObjectResult;
            var Bookings = OkResult.Value as IEnumerable<BookingModel>;

            Mock.VerifyAll();
            Assert.IsTrue(BookingsToReturn.Select(b => new BookingModel(b)).SequenceEqual(Bookings));
        }

        [TestMethod]
        public void TestPostMovieOk()
        {
            BookingCreatingInfoModel BookingModel = new BookingCreatingInfoModel()
            {
                TouristName = _touristName,
                TouristSurname = _touristSurname,
                TouristEmail = _touristEmail,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };
            Booking BookingToReturn = new Booking()
            {
                Code = _bookingCode2,
                Tourist = _tourist,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };
            var Mock = new Mock<IBookingService>();
            Mock.Setup(m => m.Add(It.IsAny<Booking>())).Returns(BookingToReturn);
            var Controller = new BookingController(Mock.Object);

            var Result = Controller.Post(BookingModel);
            var Status = Result as CreatedAtRouteResult;
            var Content = Status.Value as BookingBaseCreateInfoModel;

            Mock.VerifyAll();
            Assert.AreEqual(Content, new BookingBaseCreateInfoModel(BookingToReturn));
        }

        [TestMethod]
        public void TestGetBookingOk()
        {
            Booking BookingToReturn = new Booking()
            {
                Code = _bookingCode2,
                Tourist = _tourist,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };

            var Mock = new Mock<IBookingService>(MockBehavior.Strict);
            Mock.Setup(m => m.Get(_bookingCode2)).Returns(BookingToReturn);
            var Controller = new BookingController(Mock.Object);

            var Result = Controller.Get(_bookingCode2);
            var OkResult = Result as OkObjectResult;
            var Booking = OkResult.Value as BookingStateInfoModel;

            Mock.VerifyAll();
            Assert.AreEqual(new BookingStateInfoModel(BookingToReturn), Booking);
        }

        [TestMethod]
        public void TestPutBookingOk()
        {
            Booking BookingToReturn = new Booking()
            {
                Code = _bookingCode2,
                Tourist = _tourist,
                State = _state2,
                Description = _description2,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };
            BookingUpdateInfoModel UpdateInfoBooking = new BookingUpdateInfoModel()
            {
                State = _state2,
                Description = _description2,
            };
            Booking StateInfoBooking = new Booking()
            {
                Code = _bookingCode2,
                State = _state2,
                Description = _description2,
            };

            var Mock = new Mock<IBookingService>(MockBehavior.Strict);
            Mock.Setup(m => m.Update(StateInfoBooking));
            Mock.Setup(m => m.Get(_bookingCode2)).Returns(BookingToReturn);
            var Controller = new BookingController(Mock.Object);

            Controller.Put(_bookingCode2, UpdateInfoBooking);
            var Result = Controller.Get(_bookingCode2);
            var OkResult = Result as OkObjectResult;
            var Booking = OkResult.Value as BookingStateInfoModel;

            Mock.VerifyAll();
            Assert.AreEqual(StateInfoBooking.State, Booking.State);
            Assert.AreEqual(StateInfoBooking.Description, Booking.Description);
        }
    }
}
