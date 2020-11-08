using Entities;
using Exceptions;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Lodging {Id = _id},
                new Lodging {Id = _id2},
            };
            lodgings.ForEach(b => _lodgingRepository.Add(b));

            var lodgingsSaved = _lodgingRepository.GetAll();

            Assert.IsTrue(lodgings.SequenceEqual(lodgingsSaved));
        }

        [TestMethod]
        public void SaveLodgingTest()
        {
            var lodging = new Lodging {Id = _id};

            var lodgingSaved = _lodgingRepository.Add(lodging);

            Assert.AreEqual(lodging, lodgingSaved);
        }

        [TestMethod]
        public void GetLodgingTest()
        {
            var lodging = new Lodging
            {
                Id = _id,
                TouristPoint = _touristPoint
            };
            _lodgingRepository.Add(lodging);

            Lodging lodgingGetted = _lodgingRepository.GetById(_id);

            Assert.AreEqual(lodging.TouristPoint, _touristPoint);
            Assert.AreEqual(lodging, lodgingGetted);
        }

        [TestMethod]
        public void UpdateLodgingTest()
        {
            var lodging = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 0,
            };
            var lodgingInfo = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 2,
            };


            _lodgingRepository.Add(lodging);

            _lodgingRepository.Update(lodgingInfo);


            Assert.AreEqual(lodgingInfo.CurrentlyOccupiedPlaces,
                _lodgingRepository.GetById(_id).CurrentlyOccupiedPlaces);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteLodging()
        {
            var lodging = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 0,
                MaximumSize = 2,
            };

            Lodging savedLodging = _lodgingRepository.Add(lodging);
            _lodgingRepository.Delete((int) savedLodging.Id);

            _lodgingRepository.GetById(_id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetLodgingFailTest()
        {
            _lodgingRepository.GetById(_id);
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
            var lodging = new Lodging {Id = _id};
            var lodging2 = new Lodging {Id = _id};
            _lodgingRepository.Add(lodging);
            _lodgingRepository.Add(lodging2);
        }

        [TestMethod]
        public void GetLodgingsTest()
        {
            var lodgings = _lodgingRepository.GetAll();
            Assert.IsTrue(lodgings.SequenceEqual(new List<Lodging>()));
        }

        [TestMethod]
        public void FilterLodgingTest()
        {
            var lodging1 = new Lodging
            {
                Id = _id,
                CurrentlyOccupiedPlaces = 1,
                MaximumSize = 3,
                TouristPoint = _touristPoint
            };
            var lodging2 = new Lodging
            {
                Id = _id2,
                CurrentlyOccupiedPlaces = 1,
                MaximumSize = 5,
                TouristPoint = _touristPoint
            };

            _lodgingRepository.Add(lodging1);
            _lodgingRepository.Add(lodging2);

            LodgingToFilter lodgingToFilter = new LodgingToFilter
            {
                TotalNumberOfGuests = 4,
                TouristPointId = _touristPoint.Id
            };

            IEnumerable<Lodging> lodgingsFiltered = _lodgingRepository.FilterLodgings(lodgingToFilter);
            IEnumerable<Lodging> expectedResult = new List<Lodging> {lodging2};

            Assert.IsTrue(lodgingsFiltered.SequenceEqual(expectedResult));
        }
    }
}