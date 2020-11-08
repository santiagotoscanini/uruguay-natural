using System.Collections.Generic;
using ApplicationCore.Services;
using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class PriceCalculatorServiceTest
    {
        [TestMethod]
        public void CalculatePrice()
        {
            NumberOfGuests numberOfGuests = new NumberOfGuests
             {
                 NumberOfAdults = 2,
                 NumberOfChildren = 1,
                 NumberOfBabies = 0
             };
             double price = 20.0;
             IEnumerable<Guest> guests = new List<Guest>
             {
                 new Guest
                 {
                     Name = "Adult",
                     Percentage = 100,
                 },
                 new Guest
                 {
                     Name = "Child",
                     Percentage = 50,
                 },
                 new Guest()
                 {
                     Name = "Baby",
                     Percentage = 25
                 }
             };
             double totalPrice = 50.0;
            
            var mockGuestService = new Mock<IGuestService>();
            mockGuestService.Setup(g => g.GetAll()).Returns(guests);
            var priceCalculatorService = new PriceCalculatorService(mockGuestService.Object);

            double calculatedPrice = priceCalculatorService.CalculatePrice(numberOfGuests, price);
            
            Assert.AreEqual(totalPrice, calculatedPrice);
        }
    }
}