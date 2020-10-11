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

        private readonly string _code = "test_code123";
        private readonly string _code2 = "test_code456";
        private readonly string _description = "This is a dummy description";

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TourismContext> options = new DbContextOptionsBuilder<TourismContext>().UseInMemoryDatabase(databaseName: "database_test").Options;
            _context = new TourismContext(options);
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
            var bookings = new List<Booking>
            { 
                new Booking { Code = _code },
                new Booking { Code = _code2 },
            };
            bookings.ForEach(b => _bookingRepository.Add(b));
            
            var bookingsSaved = _bookingRepository.GetAll();

            Assert.IsTrue(bookings.SequenceEqual(bookingsSaved));
        }

        [TestMethod]
        public void GetAllBookingsWithTourists()
        {
            var tourist1 = new Tourist { Id = 1 };
            var tourist2 = new Tourist { Id = 2 };
            var bookings = new List<Booking>
            {
                new Booking { Code = _code, Tourist = tourist1 },
                new Booking { Code = _code2, Tourist = tourist2 },
            };
            bookings.ForEach(b => _bookingRepository.Add(b));

            var bookingsSaved = _bookingRepository.GetAll();
            
            Assert.AreEqual(tourist1, bookingsSaved.First().Tourist);
            Assert.AreEqual(tourist2, bookingsSaved.Last().Tourist);
        }

        [TestMethod]
        public void SaveBookingTest()
        {
            var booking = new Booking { Code = _code };
            _bookingRepository.Add(booking);

            Booking bookingSaved = _bookingRepository.GetAll().First();

            Assert.AreEqual(booking, bookingSaved);
        }

        [TestMethod]
        public void GetBookingTest()
        {
            var tourist = new Tourist { Id = 1 };
            var booking = new Booking
            {
                Code = _code,
                Tourist = tourist,
            };
            _bookingRepository.Add(booking);
            
            Booking bookingGetted = _bookingRepository.Get(_code);

            Assert.AreEqual(tourist, bookingGetted.Tourist);
            Assert.AreEqual(booking, bookingGetted);
        }

        [TestMethod]
        public void UpdateBookingTest()
        {
            var booking = new Booking
            {
                Code = _code,
                State = BookingState.CREATED,
            };
            var bookingStateInfo = new Booking
            {
                Code = _code,
                State = BookingState.EXPIRED,
                Description = _description,
            };
            _bookingRepository.Add(booking);


            _bookingRepository.Update(bookingStateInfo);


            Assert.AreEqual(bookingStateInfo.State, _bookingRepository.Get(_code).State);
            Assert.AreEqual(bookingStateInfo.Description, _bookingRepository.Get(_code).Description);
        }
    }
}
