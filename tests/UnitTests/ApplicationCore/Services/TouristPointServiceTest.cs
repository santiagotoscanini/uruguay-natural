﻿using ApplicationCore.Services;
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
            var mockCategoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            var mockTouristPointCategoryRepository = new Mock<ITouristPointCategoryRepository>(MockBehavior.Strict);
            var mock = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(touristPointsToReturn);
            var touristPointService = new TouristPointService(mock.Object, mockTouristPointCategoryRepository.Object, mockCategoryRepository.Object);

            IEnumerable<TouristPoint> touristPointsSaved = touristPointService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(touristPointsSaved.SequenceEqual(touristPointsToReturn));
        }

        [TestMethod]
        public void TestAddTouristPoint()
        {
            var touristPointToAdd = new TouristPoint
            {
                Id = _id,
            };

            ICollection<string> categoriesNames = new List<string>
            {
                _category
            };

            var categoryToReturn = new Category 
            {
                Name = _category
            };

            var tourisPointCategoryToReturn = new TouristPointCategory
            {
                Id = 0,
                Category = categoryToReturn,
                TouristPoint = touristPointToAdd
            };

            var mockTouristPointRepository = new Mock<ITouristPointRepository>(MockBehavior.Strict);
            mockTouristPointRepository.Setup(r => r.Add(touristPointToAdd)).Returns(touristPointToAdd);

            var mockCategoryRepository = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mockCategoryRepository.Setup(r => r.GetByName(_category)).Returns(categoryToReturn);

            var mockTouristPointCategoryRepository = new Mock<ITouristPointCategoryRepository>(MockBehavior.Strict);
            mockTouristPointCategoryRepository.Setup(r => r.Add(tourisPointCategoryToReturn)).Returns(tourisPointCategoryToReturn);

            var touristPointService = new TouristPointService(mockTouristPointRepository.Object, mockTouristPointCategoryRepository.Object, mockCategoryRepository.Object);

            TouristPoint touristPointSaved = touristPointService.Add(touristPointToAdd, categoriesNames);

            mockTouristPointRepository.VerifyAll();
            mockCategoryRepository.VerifyAll();
            mockTouristPointCategoryRepository.VerifyAll();

            Assert.AreEqual(touristPointToAdd, touristPointSaved);
            Assert.AreEqual(tourisPointCategoryToReturn, touristPointSaved.TouristPointCategories.First());
        }
    }
}
