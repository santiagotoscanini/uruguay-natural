using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Entities
{
    [TestClass]
    public class TouristPointTest
    {
        private ICollection<TouristPointCategory> _touristPointCategories = new List<TouristPointCategory>
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

        private Region _region = new Region
        {
            Name = "North"
        };

        private string _name = "Punta Cana";
        private string _description = "PC is a nice place";
        private byte[] _image = new byte[1];
        private int _id = 1;
        private int _id2 = 2;

        [TestMethod]
        public void CreateEmptyTouristPoint()
        {
            var touristPoint = new TouristPoint();

            Assert.IsTrue(touristPoint.TouristPointCategories.SequenceEqual(new List<TouristPointCategory>()));
            Assert.IsNull(touristPoint.Region);
            Assert.IsNull(touristPoint.Name);
            Assert.IsNull(touristPoint.Description);
            Assert.IsNull(touristPoint.Image);
            Assert.AreEqual(0, touristPoint.Id);
            Assert.IsTrue(new List<Lodging>().SequenceEqual(touristPoint.Lodgings));
        }

        [TestMethod]
        public void CreateTouristPointWithData()
        {
            var touristPoint = new TouristPoint
            {
                TouristPointCategories = _touristPointCategories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id,
                Lodgings = new List<Lodging>(),
            };

            Assert.AreEqual(touristPoint.TouristPointCategories, _touristPointCategories);
            Assert.AreEqual(touristPoint.Region, _region);
            Assert.AreEqual(touristPoint.Name, _name);
            Assert.AreEqual(touristPoint.Description, _description);
            Assert.AreEqual(touristPoint.Image, _image);
            Assert.AreEqual(touristPoint.Id, _id);
            Assert.IsTrue(new List<Lodging>().SequenceEqual(touristPoint.Lodgings));
        }

        [TestMethod]
        public void EqualsOk()
        {
            var touristPoint1 = new TouristPoint
            {
                TouristPointCategories = _touristPointCategories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id =_id
            };
            var touristPoint2 = new TouristPoint
            {
                TouristPointCategories = _touristPointCategories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id =_id
            };

            Assert.AreEqual(touristPoint1, touristPoint2);
        }

        [TestMethod]
        public void EqualsFails()
        {
            var touristPoint1 = new TouristPoint
            {
                TouristPointCategories = _touristPointCategories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id
            };
            var touristPoint2 = new TouristPoint
            {
                TouristPointCategories = _touristPointCategories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id2
            };

            Assert.AreNotEqual(touristPoint1, touristPoint2);
        }
    }
}
