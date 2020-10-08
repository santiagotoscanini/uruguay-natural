using InfrastructureInterface.Data.Repositories;
using Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace IntegrationTests.Infrastructure.Data.Repositories
{
    [TestClass]
    public class BookingRepositoryTest
    {
        private IBookingRepository _bookingRepository;
        private DbContext _context;
        private DbContextOptions<TourismContext> _options;

        private readonly string _code = "test_code123";
        private readonly string _code_2 = "test_code456";

        [TestInitialize]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<TourismContext>().UseInMemoryDatabase(databaseName: "database_test").Options;
            _context = new TourismContext(_options);
            _bookingRepository = new BookingRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllBookingsTest()
        {
            List<Booking> bookings = new List<Booking>() { 
                new Booking() { Code = _code },
                new Booking() { Code = _code_2 }
            };

            bookings.ForEach(b => _bookingRepository.Add(b));
            var bookingsSaved = _bookingRepository.GetAll();

            Assert.IsTrue(bookings.SequenceEqual(bookingsSaved));
        }

        [TestMethod]
        public void SaveBookingTest()
        {
            Booking booking = new Booking() { Code = _code };

            _bookingRepository.Add(booking);
            Booking bookingSaved = _bookingRepository.GetAll().First();

            Assert.IsTrue(bookingSaved.Equals(booking));
        }

        [TestMethod]
        public void GetBookingTest()
        {
            Booking booking = new Booking() { Code = _code };

            _bookingRepository.Add(booking);
            Booking bookingGetted = _bookingRepository.Get(_code);

            Assert.IsTrue(bookingGetted.Equals(booking));
        }

        [TestMethod]
        public void UpdateBookingTest()
        {
            Booking booking = new Booking() { Code = _code, State = BookingState.CREATED };

            Booking bookingSaved = _bookingRepository.Add(booking);
            bookingSaved.State = BookingState.EXPIRED;
            _bookingRepository.Update(bookingSaved);

            Assert.AreEqual(bookingSaved.State, _bookingRepository.Get(_code).State);
        }
    }
}
