
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class RegionTest
    {
        private string _name = "Nidalee";
        private string _name2 = "Ada";

        [TestMethod]
        public void CreateEmptyRegion()
        {
            var region = new Region();

            Assert.IsNull(region.Name);
        }

        [TestMethod]
        public void CreateRegionWithData()
        {
            var region = new Region
            {
                Name = _name,
            };

            Assert.AreEqual(region.Name, _name);
        }

        [TestMethod]
        public void EqualsOk()
        {
            var region1 = new Region
            {
                Name = _name,
            };
            var region2 = new Region
            {
                Name = _name,
            };

            Assert.AreEqual(region1, region2);
        }

        [TestMethod]
        public void EqualsFails()
        {
            var region1 = new Region
            {
                Name = _name,
            };
            var region2 = new Region
            {
                Name = _name2,
            };

            Assert.AreNotEqual(region1, region2);
        }
    }
}
