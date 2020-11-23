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
                Category = new Category { Name = "test" }
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
        private byte[] _image = new byte[1];
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

        [TestMethod]
        public void GetTouristPointFilteredByRegionAndCategory()
        {
            var touristPoint = new TouristPoint
            {
                Id = _id,
                Region = _region
            };
            var touristPoint2 = new TouristPoint
            {
                Id = _id + 1,
                TouristPointCategories = _touristPointCategories,
                Region = new Region
                {
                    Name = _region.Name + "X"
                }
            };

            _touristPointRepository.Add(touristPoint);
            _touristPointRepository.Add(touristPoint2);

            TouristPoint touristPointByRegion = _touristPointRepository.GetFilteredByRegionAndCategory(
                _region.Name,
                null
                ).First();
            TouristPoint touristPointByCategory = _touristPointRepository.GetFilteredByRegionAndCategory(
                null,
                touristPoint2.TouristPointCategories.First().Category.Name
                ).First();
            
            Assert.AreEqual(touristPoint, touristPointByRegion);
            Assert.AreEqual(touristPoint2, touristPointByCategory);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetTouristPointFailTest()
        {
            _touristPointRepository.GetById(_id);
        }
        
        [TestMethod]
        public void GetTouristPointTest()
        {
            var touristPoint = new TouristPoint
            {
                Id = _id
            };
            _touristPointRepository.Add(touristPoint);
            TouristPoint touristPointSaved = _touristPointRepository.GetById(_id);
            
            Assert.AreEqual(touristPointSaved.Id, _id);
        }
    }
}