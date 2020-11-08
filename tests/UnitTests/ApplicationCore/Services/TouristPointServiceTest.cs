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
        private TouristPointCategory _touristPointCategory = new TouristPointCategory
        {
            Id = 1,
            Category = new Category(){ Name = "Playa" }
        };

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
            mockTouristPointRepository.VerifyAll();

            Assert.AreEqual(touristPointToAdd, touristPointSaved);
            Assert.AreEqual(touristPointCategoryToReturn, touristPointSaved.TouristPointCategories.First());
        }
        
        
        [TestMethod]
        public void TestGetFilteredByRegionAndCategoryTouristPoint()
        {
            var mockRegionService = new Mock<IRegionService>(MockBehavior.Strict).Object;
            var mockCategoryService = new Mock<ICategoryService>(MockBehavior.Strict).Object;
            var touristPointCategories = new List<TouristPointCategory> {_touristPointCategory};

            var touristPoint = new TouristPoint
            {
                Id = 0,
                Region = _region,
                TouristPointCategories = touristPointCategories
            };

            var mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockTouristPointRepository.Setup(r => r.GetFilteredByRegionAndCategory(_region.Name, _category)).Returns(new List<TouristPoint>{ touristPoint});
            var touristPointService = new TouristPointService(mockTouristPointRepository.Object, mockCategoryService, mockRegionService);

            touristPointService.GetAllFilteredByRegionAndCategory(_region.Name, _category);

            mockTouristPointRepository.VerifyAll();

            Assert.AreEqual(touristPoint.Region, _region);
            Assert.AreEqual(touristPoint.TouristPointCategories, touristPointCategories);
        }
        
        [TestMethod]
        public void TestGetTouristPoint()
        {
            var touristPointToGet = new TouristPoint { Id = _id };
            var mock = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetById(_id)).Returns(touristPointToGet);
            var touristPointService = new TouristPointService(mock.Object, new Mock<ICategoryService>().Object, new Mock<IRegionService>().Object);

            TouristPoint touristPointSaved = touristPointService.GetTouristPointById(_id);

            mock.VerifyAll();
            Assert.AreEqual(touristPointToGet, touristPointSaved);
        }
    }
}
