using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class TouristPointCategoryTest
    {
        private readonly int _id = 1;
        private readonly int _id2 = 2;
        private readonly TouristPoint _touristPoint = new TouristPoint { Id = 1 };
        private readonly Category _category = new Category { Name = "test_name123" };

        [TestMethod]
        public void CreateEmptyTouristPointCategory()
        {
            var touristPointCategory = new TouristPointCategory();

            Assert.IsNull(touristPointCategory.Category);
            Assert.IsNull(touristPointCategory.TouristPoint);
            Assert.AreEqual(0, touristPointCategory.Id);
        }

        [TestMethod]
        public void CreateTouristPointCategoryWithData()
        {
            var touristPointCategory = new TouristPointCategory
            {
                TouristPoint = _touristPoint,
                Category = _category,
                Id = _id
            };

            Assert.AreEqual(_touristPoint, touristPointCategory.TouristPoint);
            Assert.AreEqual(_category, touristPointCategory.Category);
            Assert.AreEqual(_id, touristPointCategory.Id);
        }

        [TestMethod]
        public void EqualsOk()
        {
            var touristPointCategory1 = new TouristPointCategory
            {
                TouristPoint = _touristPoint,
                Category = _category,
                Id = _id
            };
            var touristPointCategory2 = new TouristPointCategory
            {
                TouristPoint = _touristPoint,
                Category = _category,
                Id = _id
            };

            Assert.AreEqual(touristPointCategory1, touristPointCategory2);
        }

        [TestMethod]
        public void EqualsFails()
        {
            var touristPointCategory1 = new TouristPointCategory
            {
                TouristPoint = _touristPoint,
                Category = _category,
                Id = _id
            };
            var touristPointCategory2 = new TouristPointCategory
            {
                TouristPoint = _touristPoint,
                Category = _category,
                Id = _id2
            };

            Assert.AreNotEqual(touristPointCategory1, touristPointCategory2);
        }
    }
}
