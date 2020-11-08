using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class GuestTest
    {
        private string _name = "Adult";
        private int _percentage = 100;
        private int _minRankAge = 13;
        private int _maxRankAge = 120;

        [TestMethod]
        public void CreateEmptyGuest()
        {
            var guest = new Guest();
            
            Assert.IsNull(guest.Name);
            Assert.AreEqual(0, guest.Percentage);
            Assert.AreEqual(0, guest.MinRankAge);
            Assert.AreEqual(0, guest.MaxRankAge);
        }

        [TestMethod]
        public void CreateGuestWithData()
        {
            var guest = new Guest
            {
                Name = _name,
                Percentage = _percentage,
                MinRankAge = _minRankAge,
                MaxRankAge = _maxRankAge
            };
            
            Assert.AreEqual(_name, guest.Name);
            Assert.AreEqual(_percentage, guest.Percentage);
            Assert.AreEqual(_minRankAge, guest.MinRankAge);
            Assert.AreEqual(_maxRankAge, guest.MaxRankAge);
        }

        [TestMethod]
        public void EqualsOk()
        {
            var guest1 = new Guest
            {
                Name = _name,
                Percentage = _percentage,
                MinRankAge = _minRankAge,
                MaxRankAge = _maxRankAge
            };
            var guest2 = new Guest
            {
                Name = _name,
                Percentage = _percentage,
                MinRankAge = _minRankAge,
                MaxRankAge = _maxRankAge
            };
            
            Assert.AreEqual(guest1, guest2);
        }
        
        [TestMethod]
        public void EqualsFails()
        {
            var guest1 = new Guest
            {
                Name = _name,
                Percentage = _percentage,
                MinRankAge = _minRankAge,
                MaxRankAge = _maxRankAge
            };
            var guest2 = new Guest
            {
                Name = "Baby",
                Percentage = _percentage,
                MinRankAge = _minRankAge,
                MaxRankAge = _maxRankAge
            };
            
            Assert.AreNotEqual(guest1, guest2);
        }
    }
}
