using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Entities
{
    [TestClass]
    public class CategoryTest
    {
        private string _name = "City";
        private string _name2 = "Beach";
        private ICollection<TouristPointCategory> _categoryTouristPoints = new List<TouristPointCategory>
        {
            new TouristPointCategory
            {
                Id = 1
            },
            new TouristPointCategory
            {
                Id = 2
            }
        };


        [TestMethod]
        public void CreateEmptyCategory()
        {
            var category = new Category();

            Assert.IsNull(category.Name);
            Assert.IsTrue(category.CategoryTouristPoints.SequenceEqual(new List<TouristPointCategory>()));
        }

        [TestMethod]
        public void CreateRegionWithData()
        {
            var category = new Category
            {
                Name = _name,
                CategoryTouristPoints = _categoryTouristPoints
            };

            Assert.AreEqual(_name, category.Name);
            Assert.IsTrue(_categoryTouristPoints.SequenceEqual(category.CategoryTouristPoints));
        }

        [TestMethod]
        public void EqualsOk()
        {
            var category1 = new Category
            {
                Name = _name,
            };
            var category2 = new Category
            {
                Name = _name,
            };

            Assert.AreEqual(category1, category2);
        }

        [TestMethod]
        public void EqualsFails()
        {
            var category1 = new Category
            {
                Name = _name,
            };
            var category2 = new Category
            {
                Name = _name2,
            };

            Assert.AreNotEqual(category1, category2);
        }
    }
}
