using Entities;
using Exceptions;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationTests.Infrastructure.Data.Repositories
{
    [TestClass]
    public class GuestRepositoryTest
    {
        private IGuestRepository _guestRepository;
        private DbContext _context;

        private readonly string _name = "Baby";
        private readonly string _name2 = "Pop Singer";

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TourismContext> options = new DbContextOptionsBuilder<TourismContext>()
            .UseInMemoryDatabase(databaseName: "database_test")
            .Options;
            _context = new TourismContext(options);
            _guestRepository = new GuestRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllGuestsTest()
        {
            var guests = new List<Guest>
            {
                new Guest { Name = _name},
                new Guest { Name = _name2 },
            };
            guests.ForEach(r => _guestRepository.Add(r));

            var guestsSaved = _guestRepository.GetAll();

            Assert.IsTrue(guests.SequenceEqual(guestsSaved));
        }

        [TestMethod]
        public void SaveGuestTest()
        {
            var guest = new Guest { Name = _name };

            var guestSaved = _guestRepository.Add(guest);

            Assert.AreEqual(guest, guestSaved);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void AddAlreadyExistGuest()
        {
            var guest = new Guest { Name = _name };
            var guest2 = new Guest { Name = _name };
            _guestRepository.Add(guest);
            _guestRepository.Add(guest2);
        }
    }
}
