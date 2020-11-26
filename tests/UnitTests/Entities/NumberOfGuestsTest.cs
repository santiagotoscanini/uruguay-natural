using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    public class NumberOfGuestsTest
    {
        private int _numberOfAdults = 10;
        private int _numberOfChildren = 3;
        private int _numberOfBabies = 3;
        private int _numberOfRetired = 123;
        
        [TestMethod]
        public void CreateEmptyNumberOfGuests()
        {
            var numberOfGuests = new NumberOfGuests();
            
            Assert.AreEqual(0, numberOfGuests.NumberOfAdults);
            Assert.AreEqual(0, numberOfGuests.NumberOfChildren);
            Assert.AreEqual(0, numberOfGuests.NumberOfBabies);
            Assert.AreEqual(0, numberOfGuests.NumberOfRetired);
        }

        [TestMethod]
        public void CreateNumberOfGuestsWithData()
        {
            var numberOfGuests = new NumberOfGuests
            {
                NumberOfAdults = _numberOfAdults,
                NumberOfChildren = _numberOfChildren,
                NumberOfBabies = _numberOfBabies,
                NumberOfRetired = _numberOfRetired
            };
            
            Assert.AreEqual(_numberOfAdults, numberOfGuests.NumberOfAdults);
            Assert.AreEqual(_numberOfChildren, numberOfGuests.NumberOfChildren);
            Assert.AreEqual(_numberOfBabies, numberOfGuests.NumberOfBabies);
            Assert.AreEqual(_numberOfRetired, numberOfGuests.NumberOfRetired);
        }
    }
}
