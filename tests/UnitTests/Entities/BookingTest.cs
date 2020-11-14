using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using System;

namespace UnitTests.Entities
{
    [TestClass]
    public class BookingTest
    {
        private Tourist _tourist = new Tourist { Id = 1 };
        private string _code = "XLR8";
        private BookingState _state = BookingState.CREATED;
        private string _description = "This is a dummy description.";
        private DateTime _checkInDate = DateTime.Now;
        private DateTime _checkOutDate = DateTime.Now;
        private int _totalNumberOfGuests = 3;
        private Lodging _lodging = new Lodging();
        private NumberOfGuests _numberOfGuests= new NumberOfGuests();
        private int _price = 3;

            [TestMethod]
        public void CreateEmptyBooking()
        {
            var booking = new Booking();

            Assert.IsNull(booking.Tourist);
            Assert.IsNull(booking.Code);
            Assert.AreEqual((BookingState)0, booking.State);
            Assert.IsNull(booking.Description);
            Assert.AreEqual(new DateTime(), booking.CheckInDate);
            Assert.AreEqual(new DateTime(), booking.CheckOutDate);
            Assert.IsNull(booking.NumberOfGuests);
            Assert.AreEqual(0, booking.TotalNumberOfGuests);
            Assert.IsNull(booking.Lodging);
            Assert.AreEqual(0.0, booking.Price);
        }

        [TestMethod]
        public void CreateBookingWithData()
        {
            var booking = new Booking
            {
                Tourist = _tourist,
                Code = _code,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
                TotalNumberOfGuests = _totalNumberOfGuests,
                Lodging = _lodging,
                Price = _price
            };

            Assert.AreEqual(booking.Tourist, _tourist);
            Assert.AreEqual(booking.Code, _code);
            Assert.AreEqual(booking.State, _state);
            Assert.AreEqual(booking.Description, _description);
            Assert.AreEqual(booking.CheckInDate, _checkInDate);
            Assert.AreEqual(booking.CheckOutDate, _checkOutDate);
            Assert.AreEqual(booking.NumberOfGuests, _numberOfGuests);
            Assert.AreEqual(booking.TotalNumberOfGuests, _totalNumberOfGuests);
            Assert.AreEqual(booking.Lodging, _lodging);
            Assert.AreEqual(_price, booking.Price);
        }

        [TestMethod]
        public void EqualsOk()
        {
            var booking1 = new Booking
            {
                Tourist = _tourist,
                Code = _code,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
                TotalNumberOfGuests = _totalNumberOfGuests,
                Lodging = _lodging,
            };
            var booking2 = new Booking
            {
                Tourist = _tourist,
                Code = _code,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
                TotalNumberOfGuests = _totalNumberOfGuests,
                Lodging = _lodging,
            };

            Assert.AreEqual(booking1, booking2);
        }

        [TestMethod]
        public void EqualsFails()
        {
            var booking1 = new Booking
            {
                Tourist = _tourist,
                Code = _code,
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
                Lodging = _lodging,
            };
            var booking2 = new Booking
            {
                Tourist = _tourist,
                Code = "another_code",
                State = _state,
                Description = _description,
                CheckInDate = _checkInDate,
                CheckOutDate = _checkOutDate,
                NumberOfGuests = _numberOfGuests,
                Lodging = _lodging,
            };

            Assert.AreNotEqual(booking1, booking2);
        }
    }
}
