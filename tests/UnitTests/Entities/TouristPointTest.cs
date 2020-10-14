
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class TouristPointTest
    {
        private string _name = "Punta Cana";
        private string _description = "PC is a nice place";
        private string _image = "aaaaabb223";
        private int _id = 1;
        private int _id2 = 2;

        [TestMethod]
        public void CreateEmptyTouristPoint()
        {
            var touristPoint = new TouristPoint();

            Assert.IsNull(touristPoint.Name);
            Assert.IsNull(touristPoint.Description);
            Assert.IsNull(touristPoint.Image);
            Assert.IsNull(touristPoint.Id);
        }

        [TestMethod]
        public void CreateTouristPointWithData()
        {
            var touristPoint = new TouristPoint
            {
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id
            };

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
                Name = _name,
                Description = _description,
                Image = _image,
                Id =_id
            };
            var touristPoint2 = new TouristPoint
            {
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
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id
            };
            var touristPoint2 = new TouristPoint
            {
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id2
            };

            Assert.AreEqual(touristPoint1, touristPoint2);
        }
    }
}
