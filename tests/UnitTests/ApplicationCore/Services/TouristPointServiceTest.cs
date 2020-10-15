using ApplicationCore.Services;
using ApplicationCoreInterface.Services;
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

            ICategoryService mockCategoryService = new Mock<ICategoryService>(MockBehavior.Strict).Object;
            IRegionService mockRegionService = new Mock<IRegionService>(MockBehavior.Strict).Object;
            var mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockTouristPointRepository.Setup(r => r.GetAll()).Returns(touristPointsToReturn);
            var touristPointService = new TouristPointService(mockTouristPointRepository.Object, mockCategoryService, mockRegionService);

            IEnumerable<TouristPoint> touristPointsSaved = touristPointService.GetAll();

            mockTouristPointRepository.VerifyAll();
            Assert.IsTrue(touristPointsSaved.SequenceEqual(touristPointsToReturn));
        }

        [TestMethod]

        public void TestAddTouristPoint()
        {
            var mockRegionService = new Mock<IRegionService>(MockBehavior.Strict);
            mockRegionService.Setup(r => r.GetRegionByName(_region.Name)).Returns(_region);

            var categoryToReturn = new Category { Name = _category };
            var mockCategoryService = new Mock<ICategoryService>(MockBehavior.Strict);
            mockCategoryService.Setup(r => r.GetCategoryByName(_category)).Returns(categoryToReturn);

            var touristPointToAdd = new TouristPoint
            {
                Id = 0,
                Region = _region,
                TouristPointCategories = new List<TouristPointCategory>()
            };

            var touristPointCategoryToReturn = new TouristPointCategory
            {
                Id = 0,
                Category = categoryToReturn,
                TouristPoint = touristPointToAdd,
            };

            var mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockTouristPointRepository.Setup(r => r.Add(touristPointToAdd)).Returns(touristPointToAdd);
            var touristPointService = new TouristPointService(mockTouristPointRepository.Object, mockCategoryService.Object, mockRegionService.Object);


            ICollection<string> categoriesNames = new List<string> { _category };
            TouristPoint touristPointSaved = touristPointService.Add(touristPointToAdd, categoriesNames);

            mockRegionService.VerifyAll();
            mockCategoryService.VerifyAll();

            Assert.AreEqual(touristPointToAdd, touristPointSaved);
            Assert.AreEqual(touristPointCategoryToReturn, touristPointSaved.TouristPointCategories.First());
        }
    }
}
