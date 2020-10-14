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
    public class CategoryRepositoryTest
    {
        private ICategoryRepository _categoryRepository;
        private DbContext _context;

        private readonly string _name = "test_name123";
        private readonly string _name2 = "test_name456";

        [TestInitialize]
        public void Setup()
        {
            DbContextOptions<TourismContext> options = new DbContextOptionsBuilder<TourismContext>()
            .UseInMemoryDatabase(databaseName: "database_test")
            .Options;
            _context = new TourismContext(options);
            _categoryRepository = new CategoryRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllCategoriesTest()
        {
            var categories = new List<Category>
            {
                new Category { Name = _name },
                new Category { Name = _name2 },
            };
            categories.ForEach(r => _categoryRepository.Add(r));

            var categoriesSaved = _categoryRepository.GetAll();

            Assert.IsTrue(categories.SequenceEqual(categoriesSaved));
        }

        [TestMethod]
        public void SaveCategoryTest()
        {
            var category = new Category { Name = _name };

            var categorySaved = _categoryRepository.Add(category);

            Assert.AreEqual(category, categorySaved);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void AddAlreadyExistCategory()
        {
            var category = new Category { Name = _name };
            var category2 = new Category { Name = _name };
            _categoryRepository.Add(category);
            _categoryRepository.Add(category2);
        }

        [TestMethod]
        public void GetCategoryByNameOk()
        {
            var category = new Category { Name = _name };

            _categoryRepository.Add(category);
            var categorySaved = _categoryRepository.GetByName(_name);

            Assert.AreEqual(category, categorySaved);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetCategoryFailTest()
        {
            _categoryRepository.GetByName(_name);
        }
    }
}
