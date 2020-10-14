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
    public class RegionRepositoryTest
    {
        private IRegionRepository _regionRepository;
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
            _regionRepository = new RegionRepository(_context);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllRegionsTest()
        {
            var regions = new List<Region>
            {
                new Region { Name = _name },
                new Region { Name = _name2 },
            };
            regions.ForEach(r => _regionRepository.Add(r));

            var regionsSaved = _regionRepository.GetAll();

            Assert.IsTrue(regions.SequenceEqual(regionsSaved));
        }

        [TestMethod]
        public void SaveRegionTest()
        {
            var region = new Region { Name = _name };

            var regionSaved = _regionRepository.Add(region);

            Assert.AreEqual(region, regionSaved);
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void AddAlreadyExistRegion()
        {
            var region = new Region { Name = _name };
            var region2 = new Region { Name = _name };
            _regionRepository.Add(region);
            _regionRepository.Add(region2);
        }
    }
}
