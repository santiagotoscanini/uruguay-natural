using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace UnitTests.Entities
{
    [TestClass]
    public class TouristPointTest
    {
        private ICollection<Category> _categories = new List<Category>
        {
            new Category
            {
                Name = "Beach"
            },
            new Category
            {
                Name = "History"
            }
        };

        private Region _region = new Region
        {
            Name = "North"
        };

        private string _name = "Punta Cana";
        private string _description = "PC is a nice place";
        private string _image = "aaaaabb223";
        private int _id = 1;
        private int _id2 = 2;

        [TestMethod]
        public void CreateEmptyTouristPoint()
        {
            var touristPoint = new TouristPoint();

            Assert.IsNull(touristPoint.Categories);
            Assert.IsNull(touristPoint.Region);
            Assert.IsNull(touristPoint.Name);
            Assert.IsNull(touristPoint.Description);
            Assert.IsNull(touristPoint.Image);
            Assert.AreEqual(0, touristPoint.Id);
        }

        [TestMethod]
        public void CreateTouristPointWithData()
        {
            var touristPoint = new TouristPoint
            {
                Categories = _categories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id
            };

            Assert.AreEqual(touristPoint.Categories, _categories);
            Assert.AreEqual(touristPoint.Region, _region);
            Assert.AreEqual(touristPoint.Name, _name);
            Assert.AreEqual(touristPoint.Description, _description);
            Assert.AreEqual(touristPoint.Image, _image);
            Assert.AreEqual(touristPoint.Id, _id);
        }

        [TestMethod]
        public void EqualsOk()
        {
            var touristPoint1 = new TouristPoint
            {
                Categories = _categories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id =_id
            };
            var touristPoint2 = new TouristPoint
            {
                Categories = _categories,
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
                Categories = _categories,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id
            };
            var touristPoint2 = new TouristPoint
            {
                Categories = _categories,
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
