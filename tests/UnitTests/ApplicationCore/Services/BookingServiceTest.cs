using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Moq;
using System.Collections.Generic;
using InfrastructureInterface.Data.Repositories;
using System.Linq;
using ApplicationCore.Services;
using Models.BookingModels;

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
        public void TestUpdateBooking()
        {
            var Booking = new Booking { Code = _bookingCode1, State = BookingState.EXPIRED };
            BookingStateInfoModel UpdateStateInfoModel = new BookingStateInfoModel() { Code = _bookingCode1, State = BookingState.EXPIRED };

            var Mock = new Mock<IBookingRepository>(MockBehavior.Strict);
            Mock.Setup(r => r.Update(UpdateStateInfoModel));
            Mock.Setup(r => r.Get(_bookingCode1)).Returns(Booking);
            var BookingService = new BookingService(Mock.Object);

            BookingService.Update(UpdateStateInfoModel);
            var modifiedBookingGetted = BookingService.Get(_bookingCode1);

            Mock.VerifyAll();
            Assert.AreEqual(UpdateStateInfoModel.State, modifiedBookingGetted.State);
        }
    }
}
