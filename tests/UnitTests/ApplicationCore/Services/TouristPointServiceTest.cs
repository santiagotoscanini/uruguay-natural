using ApplicationCore.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class TouristPointServiceTest
    {
        private int _id = 1;
        private int _id2 = 2;
        private string _category = "Playa";
        private Region _region = new Region { Name = "Norte" };

        [TestMethod]
        public void TestGetAllOk()
        {
            var touristPointsToReturn = new List<TouristPoint>
            {
                new TouristPoint
                {
                    Id = _id,
                },
                new TouristPoint
                {
                    Id = _id2,
                },
            };
            var mockCategoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict).Object;
            var mockTouristPointCategoryRepository = new Mock<ITouristPointCategoryRepository>(MockBehavior.Strict).Object;
            var mockRegionRepository = new Mock<IRegionRepository>(MockBehavior.Strict).Object;
            var mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockTouristPointRepository.Setup(r => r.GetAll()).Returns(touristPointsToReturn);
            var touristPointService = new TouristPointService(mockTouristPointRepository.Object, mockTouristPointCategoryRepository, mockCategoryRepository, mockRegionRepository);

            IEnumerable<TouristPoint> touristPointsSaved = touristPointService.GetAll();

            mockTouristPointRepository.VerifyAll();
            Assert.IsTrue(touristPointsSaved.SequenceEqual(touristPointsToReturn));
        }

        [TestMethod]
        public void TestAddTouristPoint()
        {
            var regionsToReturn = new List<Region> { _region };
            var mockRegionRepository = new Mock<IRegionRepository>(MockBehavior.Strict);
            mockRegionRepository.Setup(r => r.GetAll()).Returns(regionsToReturn);

            var touristPointToAdd = new TouristPoint
            {
                Id = 0,
                Region = _region,
                TouristPointCategories = new List<TouristPointCategory>()
            };
            var mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockTouristPointRepository.Setup(r => r.Add(touristPointToAdd)).Returns(touristPointToAdd);

            var categoryToReturn = new Category { Name = _category };
            var mockCategoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mockCategoryRepository.Setup(r => r.GetByName(_category)).Returns(categoryToReturn);

            var touristPointCategoryToReturn = new TouristPointCategory
            {
                Id = 0,
                Category = categoryToReturn,
                TouristPoint = touristPointToAdd,
            };
            var mockTouristPointCategoryRepository = new Mock<ITouristPointCategoryRepository>(MockBehavior.Strict);

            var touristPointService = new TouristPointService(mockTouristPointRepository.Object, mockTouristPointCategoryRepository.Object, mockCategoryRepository.Object, mockRegionRepository.Object);

            ICollection<string> categoriesNames = new List<string> { _category };
            TouristPoint touristPointSaved = touristPointService.Add(touristPointToAdd, categoriesNames);

            mockTouristPointRepository.VerifyAll();
            mockCategoryRepository.VerifyAll();
            mockRegionRepository.VerifyAll();

            Assert.AreEqual(touristPointToAdd, touristPointSaved);
            Assert.AreEqual(touristPointCategoryToReturn, touristPointSaved.TouristPointCategories.First());
        }
    }
}
