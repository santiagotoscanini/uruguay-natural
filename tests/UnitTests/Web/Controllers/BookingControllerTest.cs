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

namespace UnitTests.Web.Controllers
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
        private string _description2 = "This is another dummy description.";

        [TestMethod]
        public void TestGetAllBookingsOk()
        {
            var bookingsToReturn = new List<Booking>
            {
                new Booking
                {
                    Code = _bookingCode1,
                    Tourist = _tourist,
                    State = _state,
                    Description = _description,
                    CheckInDate = _checkInDate,
                    CheckOutDate = _checkOutDate,
                    NumberOfGuests = _numberOfGuests,
                },
                new Booking
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
            var mock = new Mock<IBookingService>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(bookingsToReturn);
            var controller = new BookingController(mock.Object);

            IActionResult result = controller.GetAllBookings();
            var okResult = result as OkObjectResult;
            var bookings = okResult.Value as IEnumerable<BookingModel>;

            mock.VerifyAll();
            Assert.IsTrue(bookingsToReturn.Select(b => new BookingModel(b)).SequenceEqual(bookings));
        }

        [TestMethod]
        public void TestPostBookingOk()
        {
            var bookingModel = new BookingCreatingModel
            {
                TouristName = _touristName,
                TouristSurname = _touristSurname,
                TouristEmail = _touristEmail,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };
            var bookingToReturn = new Booking
            {
                Code = _bookingCode2,
                Tourist = _tourist,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };
            var mock = new Mock<IBookingService>();
            mock.Setup(m => m.Add(It.IsAny<Booking>())).Returns(bookingToReturn);
            var controller = new BookingController(mock.Object);

            IActionResult result = controller.AddBooking(bookingModel);
            var status = result as CreatedAtRouteResult;
            var content = status.Value as BookingBaseCreateModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new BookingBaseCreateModel(bookingToReturn));
        }

        [TestMethod]
        public void TestGetBookingOk()
        {
            var bookingToReturn = new Booking
            {
                Code = _bookingCode2,
                Tourist = _tourist,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };
            var mock = new Mock<IBookingService>(MockBehavior.Strict);
            mock.Setup(m => m.Get(_bookingCode2)).Returns(bookingToReturn);
            var controller = new BookingController(mock.Object);

            IActionResult result = controller.GetBookingById(_bookingCode2);
            var okResult = result as OkObjectResult;
            var booking = okResult.Value as BookingStateInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(new BookingStateInfoModel(bookingToReturn), booking);
        }

        [TestMethod]
        public void TestPutBookingOk()
        {
            var bookingToReturn = new Booking
            {
                Code = _bookingCode2,
                Tourist = _tourist,
                State = _state2,
                Description = _description2,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };
            var updateInfoBooking = new BookingUpdateInfoModel
            {
                State = _state2,
                Description = _description2,
            };
            var stateInfoBooking = new Booking
            {
                Code = _bookingCode2,
                State = _state2,
                Description = _description2,
            };
            var mock = new Mock<IBookingService>(MockBehavior.Strict);
            mock.Setup(m => m.Update(stateInfoBooking));
            mock.Setup(m => m.Get(_bookingCode2)).Returns(bookingToReturn);
            var controller = new BookingController(mock.Object);

            controller.UpdateBooking(_bookingCode2, updateInfoBooking);
            IActionResult result = controller.GetBookingById(_bookingCode2);
            var okResult = result as OkObjectResult;
            var booking = okResult.Value as BookingStateInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(stateInfoBooking.State, booking.State);
            Assert.AreEqual(stateInfoBooking.Description, booking.Description);
        }
    }
}
