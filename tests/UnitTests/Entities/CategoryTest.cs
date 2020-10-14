using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class CategoryTest
    {
        private string _name = "City";
        private string _name2 = "Beach";

        [TestMethod]
        public void CreateEmptyCategory()
        {
            var category = new Category();

            Assert.IsNull(category.Name);
        }

        [TestMethod]
        public void CreateRegionWithData()
        {
            var category = new Category
            {
                Name = _name,
            };

            Assert.AreEqual(category.Name, _name);
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
