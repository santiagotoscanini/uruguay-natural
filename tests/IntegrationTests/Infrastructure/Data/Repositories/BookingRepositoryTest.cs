using InfrastructureInterface.Data.Repositories;
using Infrastructure.Data.Repositories;
using Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Exceptions;

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
        private readonly Review _touristReview = new Review
        {
            Text = "Nice",
            NumberOfPoints = 3,
        };

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TourismContext> options = new DbContextOptionsBuilder<TourismContext>()
            .UseInMemoryDatabase(databaseName: "database_test")
            .Options;
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

            var bookingSaved = _bookingRepository.Add(booking);

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


            _bookingRepository.UpdateState(bookingStateInfo);


            Assert.AreEqual(bookingStateInfo.State, _bookingRepository.Get(_code).State);
            Assert.AreEqual(bookingStateInfo.Description, _bookingRepository.Get(_code).Description);
        }
        
        [TestMethod]
        public void UpdateBookingReviewTest()
        {
            var booking = new Booking
            {
                Code = _code,
                TouristReview = null,
            };
            var bookingWithReview = new Booking
            {
                Code = _code,
                TouristReview = _touristReview,
            };
            _bookingRepository.Add(booking);


            _bookingRepository.UpdateReview(bookingWithReview);


            Assert.AreEqual(_touristReview.Text, _bookingRepository.Get(_code).TouristReview.Text);
            Assert.AreEqual(_touristReview.NumberOfPoints, _bookingRepository.Get(_code).TouristReview.NumberOfPoints);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetBookingFailTest()
        {
            _bookingRepository.Get(_code);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void UpdateBookingFailTest()
        {
            var bookingStateInfo = new Booking
            {
                Code = _code,
                State = BookingState.EXPIRED,
                Description = _description,
            };

            _bookingRepository.UpdateState(bookingStateInfo);
        }

        [TestMethod]
        [ExpectedException(typeof (ObjectAlreadyExistException))]
        public void AddAlreadyExistBooking()
        {
            var booking = new Booking { Code = _code };
            var booking2 = new Booking { Code = _code };
            _bookingRepository.Add(booking);
            _bookingRepository.Add(booking2);
        }
    }
}
