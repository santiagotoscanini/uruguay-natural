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
            IEnumerable<Booking> bookingsToReturn = new List<Booking>()
            {
                new Booking()
                {
                    Code = _bookingCode1,
                },
                new Booking()
                {
                    Code = _bookingCode2,
                }
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
            Booking bookingToAdd = new Booking() { Code = _bookingCode1 };

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
            Booking bookingToGet = new Booking() { Code = _bookingCode1 };

            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Get(_bookingCode1)).Returns(bookingToGet);
            var bookingService = new BookingService(mock.Object);

            Booking bookingGetted = bookingService.Get(_bookingCode1);

            mock.VerifyAll();
            Assert.AreEqual(bookingToGet, bookingGetted);
        }

        [TestMethod]
        public void TestSaveModifiedBooking()
        {
            Booking modifiedBooking = new Booking() { Code = _bookingCode1, State = BookingState.ACCEPTED };

            var mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Update(modifiedBooking));
            mock.Setup(r => r.Get(_bookingCode1)).Returns(modifiedBooking);
            var bookingService = new BookingService(mock.Object);

            bookingService.Update(modifiedBooking);
            Booking modifiedBookingGetted = bookingService.Get(_bookingCode1);

            mock.VerifyAll();
            Assert.AreEqual(modifiedBooking, modifiedBookingGetted);
        }
    }
}
