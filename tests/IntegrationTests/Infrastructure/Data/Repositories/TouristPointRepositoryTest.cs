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
    public class TouristPointRepositoryTest
    {
        private ITouristPointRepository _touristPointRepository;
        private DbContext _context;

        private ICollection<TouristPointCategory> _touristPointCategories = new List<TouristPointCategory>
        {
            new TouristPointCategory
            {
                Id = 1,
            },
            new TouristPointCategory
            {
                Id = 2,
            }
        };

        private Region _region = new Region
        {
            Name = "North"
        };

        private string _name = "Punta Cana";
        private string _description = "PC is a nice place";
        private string _image = "aaaaabb223";
        private int _id = 1;
        private int _id2 = 2;

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TourismContext> options = new DbContextOptionsBuilder<TourismContext>()
            .UseInMemoryDatabase(databaseName: "database_test")
            .Options;
            _context = new TourismContext(options);
            _touristPointRepository = new TouristPointRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllTouristPointsTest()
        {
            var touritsPoints = new List<TouristPoint>
            {
                new TouristPoint
                {
                    TouristPointCategories = _touristPointCategories,
                    Region = _region,
                    Name = _name,
                    Description = _description,
                    Image = _image,
                    Id = _id
                },
                new TouristPoint
                {
                    TouristPointCategories = _touristPointCategories,
                    Region = _region,
                    Name = _name,
                    Description = _description,
                    Image = _image,
                    Id = _id2
                },

            };

            touritsPoints.ForEach(b => _touristPointRepository.Add(b));

            var touristPointsSaved = _touristPointRepository.GetAll();

            Assert.IsTrue(touritsPoints.SequenceEqual(touristPointsSaved));
        }

        [TestMethod]
        public void SaveTouristPointTest()
        {
            var touristPoint = new TouristPoint
            {
                TouristPointCategories = _touristPointCategories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id
            };

            var touristPointSaved = _touristPointRepository.Add(touristPoint);

            Assert.AreEqual(touristPoint, touristPointSaved);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void AddAlreadyExistTouristPoint()
        {
            var touristPoint = new TouristPoint 
            { 
                Id = _id 
            };
            var touristPoint2 = new TouristPoint 
            { 
                Id = _id 
            };
            _touristPointRepository.Add(touristPoint);
            _touristPointRepository.Add(touristPoint2);
        }
    }
}
