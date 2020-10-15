using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Entities
{
    [TestClass]
    public class RegionTest
    {
        private string _name = "Nidalee";
        private string _name2 = "Ada";
        private ICollection<TouristPoint> _touristPoints = new List<TouristPoint>
        {
            new TouristPoint
            {
                Id = 1,
            },
            new TouristPoint
            {
                Id = 2,
            },
        };

        [TestMethod]
        public void CreateEmptyRegion()
        {
            var region = new Region();

            Assert.IsNull(region.Name);
            Assert.IsTrue(new List<TouristPoint>().SequenceEqual(region.TouristPoints));
        }

        [TestMethod]
        public void CreateRegionWithData()
        {
            var region = new Region
            {
                Name = _name,
                TouristPoints = _touristPoints
            };

            Assert.AreEqual(_name, region.Name);
            Assert.AreEqual(_touristPoints, region.TouristPoints);
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
