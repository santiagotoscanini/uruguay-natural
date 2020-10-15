using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class LodgingTest
    {
        [TestMethod]
        public void CreateEmptyLodging()
        {
            var emptyLodging = new Lodging();

            Assert.IsNull(emptyLodging.Name);
            Assert.AreEqual(0, emptyLodging.NumberOfStars);
            Assert.IsNull(emptyLodging.TouristPoint);
            Assert.IsNull(emptyLodging.Address);
            Assert.AreEqual(0, emptyLodging.Images.Size());
            Assert.AreEqual(0, emptyLodging.CostPerNight);
            Assert.IsNull(emptyLodging.Description);
            Assert.IsNull(emptyLodging.ContactNumber);
            Assert.IsNull(emptyLodging.DescriptionForBookings);
            Assert.AreEqual(0, emptyLodging.Id);
            Assert.AreEqual(0, emptyLodging.MaximumSize);
            Assert.AreEqual(0, emptyLodging.ActualSize);
        }
    }
}