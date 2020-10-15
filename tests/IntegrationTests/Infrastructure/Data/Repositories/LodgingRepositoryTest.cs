using Entities;
using Exceptions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.Infrastructure.Data.Repositories
{
    [TestClass]
    public class LodgingRepositoryTest
    {
        private ILodgingRepository _lodgingRepository;
        private DbContext _context;

        private readonly int _id = 1;
        private readonly int _id2 = 2;
        private TouristPoint _touristPoint = new TouristPoint
        {
            TouristPointCategories = new List<TouristPointCategory>(),
            Region = new Region
            {
                Name = "Norte",
            },
            Name = "Rocha",
            Description = "Good place",
            Image = "sfafg222",
            Id = 2,
        };

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TourismContext> options = new DbContextOptionsBuilder<TourismContext>()
            .UseInMemoryDatabase(databaseName: "database_test")
            .Options;
            _context = new TourismContext(options);
            _lodgingRepository = new LodgingRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllLodgingsTest()
        {
            var lodgings = new List<Lodging>
            {
                new Lodging { Id = _id },
                new Lodging { Id = _id2 },
            };
            lodgings.ForEach(b => _lodgingRepository.Add(b));

            var lodgingsSaved = _lodgingRepository.GetAll();

            Assert.IsTrue(lodgings.SequenceEqual(lodgingsSaved));
        }

        [TestMethod]
        public void SaveLodgingTest()
        {
            var lodging = new Lodging { Id = _id };

            var lodgingSaved = _lodgingRepository.Add(lodging);

            Assert.AreEqual(lodging, lodgingSaved);
        }

        [TestMethod]
        public void GetLodgingTest()
        {
            var Lodging = new Lodging
            {
                Id = _id,
            };
            _lodgingRepository.Add(Lodging);

            Lodging LodgingGetted = _lodgingRepository.Get(_id);

            Assert.AreEqual(Lodging.TouristPoint, _touristPoint);
            Assert.AreEqual(Lodging, LodgingGetted);
        }

        [TestMethod]
        public void UpdateLodgingTest()
        {
            var lodging = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 0,
                MaximumSize = 2,
            };
            var lodgingInfo = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 2,
                MaximumSize = 2,
            };


            _lodgingRepository.Add(lodging);

            _lodgingRepository.Update(lodgingInfo);


            Assert.AreEqual(lodgingInfo.CurrentlyOccupiedPlaces, _lodgingRepository.Get(_id).CurrentlyOccupiedPlaces);
            Assert.AreEqual(lodgingInfo.MaximumSize, _lodgingRepository.Get(_id).MaximumSize);
        }

        [TestMethod]
        public void DeleteLodging()
        {
            var lodging = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 0,
                MaximumSize = 2,
            };

            Lodging savedLodging = _lodgingRepository.Add(lodging);
            bool wasDeleted = _lodgingRepository.Delete(savedLodging.Id);

            Assert.IsTrue(wasDeleted);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetLodgingFailTest()
        {
            _lodgingRepository.Get(_id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void UpdateLodgingFailTest()
        {
            var lodgingStateInfo = new Lodging
            {
                Id = _id
            };

            _lodgingRepository.Update(lodgingStateInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void AddAlreadyExistLodging()
        {
            var lodging = new Lodging { Id = _id };
            var lodging2 = new Lodging { Id = _id };
            _lodgingRepository.Add(lodging);
            _lodgingRepository.Add(lodging2);
        }
    }
}
