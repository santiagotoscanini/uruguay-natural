using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.Infrastructure.Data.Repositories
{
    [TestClass]
    public class TouristPointCategoryRepositoryTest
    {
        private TouristPointCategoryRepository _touristPointCategoryRepository;
        private DbContext _context;

        private readonly TouristPoint _touristPoint = new TouristPoint { Id = 1 };
        private readonly Category _category = new Category { Name = "test_name123" };

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TouristsPointCategoryContext> options = new DbContextOptionsBuilder<TouritsPointCategoryContext>()
            .UseInMemoryDatabase(databaseName: "database_test")
            .Options;
            _context = new TouritsPointCategoryContext(options);
            _touristPointCategoryRepository = new TouristPointCategoryRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void AddTouristPointCategoryTest()
        {
            var touristPointCategoryToAdd = new TouristPointCategory
            {
                Category = _category,
                TouristPoint = _touristPoint,
                Id = 1
            };

            TouristPointCategory touristPointCategory = _touristPointCategoryRepository.Add(touristPointCategoryToAdd);

            Assert.AreEqual(touristPointCategoryToAdd, touristPointCategory);
        }
    }
}
