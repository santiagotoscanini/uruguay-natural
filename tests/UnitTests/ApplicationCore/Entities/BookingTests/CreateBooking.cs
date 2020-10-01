using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationCore.Entities;
using System;

namespace tests.UnitTests.ApplicationCore.Entities.BookingTests
{
    [TestClass]
    public class CreateBooking
    {
        private Tourist _tourist = new Tourist();
        private string _code = "XLR8";
        private BookingState _state = BookingState.CREATED;
        private string _description = "This is a dummy description.";
        private DateTime _checkInDate = DateTime.Now;
        private DateTime _checkOutDate = DateTime.Now;
        private int _numberOfGuests = 3;

        [TestMethod]
        public void CreateEmptyBooking()
        {
            Booking booking = new Booking();

            Assert.IsNull(booking.Tourist);
            Assert.IsNull(booking.Code);
            Assert.AreEqual((BookingState)0, booking.State);
            Assert.IsNull(booking.Description);
            Assert.AreEqual(new DateTime(), booking.CheckInDate);
            Assert.AreEqual(new DateTime(), booking.CheckOutDate);
            Assert.AreEqual(0, booking.NumberOfGuests);
        }

        [TestMethod]
        public void CreateBookingWithData()
        {
            Booking booking = new Booking
            {
                Tourist = _tourist,
                Code = _code,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
            };

            Assert.AreEqual(booking.Tourist, _tourist);
            Assert.AreEqual(booking.Code, _code);
            Assert.AreEqual(booking.State, _state);
            Assert.AreEqual(booking.Description, _description);
            Assert.AreEqual(booking.CheckInDate, _checkInDate);
            Assert.AreEqual(booking.CheckOutDate, _checkOutDate);
            Assert.AreEqual(booking.NumberOfGuests, _numberOfGuests);
        }
    }
}
