
using Entities;
using Infrastructure.Data;
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

        private ICollection<Category> _categories = new List<Category>
        {
            new Category
            {
                Name = "Beach"
            },
            new Category
            {
                Name = "History"
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
                    Categories = _categories,
                    Region = _region,
                    Name = _name,
                    Description = _description,
                    Image = _image,
                    Id = _id
                },
                new TouristPoint
                {
                    Categories = _categories,
                    Region = _region,
                    Name = _name,
                    Description = _description,
                    Image = _image,
                    Id = _id2
                },

            };

            touritsPoints.ForEach(b => _touritsPointRepository.Add(b));

            var touristPointsSaved = _touritsPointRepository.GetAll();

            Assert.IsTrue(touritsPoints.SequenceEqual(touritsPointsSaved));
        }
    }
}
