using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Moq;
using System.Collections.Generic;
using InfrastructureInterface.Data.Repositories;
using System.Linq;
using ApplicationCore.Services;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class BookingServiceTest
    {
        private string _bookingCode1 = "booking_code_1";
        private string _bookingCode2 = "booking_code_2";

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
            var bookingService = new BookingService(mock.Object);

            IEnumerable<Booking> bookingsSaved = bookingService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(bookingsSaved.SequenceEqual(bookingsToReturn));
        }

        [TestMethod]
        public void TestAddBooking()
        {
            var bookingToAdd = new Booking { Code = _bookingCode1 };
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(bookingToAdd)).Returns(bookingToAdd);
            var bookingService = new BookingService(mock.Object);

            Booking bookingSaved = bookingService.Add(bookingToAdd);

            mock.VerifyAll();
            Assert.AreEqual(bookingToAdd, bookingSaved);
        }

        [TestMethod]
        public void TestGetBooking()
        {
            var bookingToGet = new Booking { Code = _bookingCode1 };
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Get(_bookingCode1)).Returns(bookingToGet);
            var bookingService = new BookingService(mock.Object);

            Booking bookingGetted = bookingService.Get(_bookingCode1);

            mock.VerifyAll();
            Assert.AreEqual(bookingToGet, bookingGetted);
        }

        [TestMethod]
        public void TestUpdateBooking()
        {
            var booking = new Booking { Code = _bookingCode1, State = BookingState.EXPIRED };
            var updateStateInfoModel = new Booking { Code = _bookingCode1, State = BookingState.EXPIRED };
            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Update(updateStateInfoModel));
            mock.Setup(r => r.Get(_bookingCode1)).Returns(booking);
            var bookingService = new BookingService(mock.Object);

            bookingService.Update(updateStateInfoModel);
            var modifiedBookingGetted = bookingService.Get(_bookingCode1);

            mock.VerifyAll();
            Assert.AreEqual(updateStateInfoModel.State, modifiedBookingGetted.State);
        }
    }
}
