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
        public void CalculatePriceWithEvenRetired()
        {
            var numberOfGuests = new NumberOfGuests
            {
                NumberOfAdults = 2,
                NumberOfChildren = 1,
                NumberOfBabies = 0,
                NumberOfRetired = 10 
            };
            const double price = 20.0;

            const double totalPrice = 220.0;

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
                new Guest
                {
                    Name = "Baby",
                    Percentage = 25
                },
                new Guest
                {
                    Name = "Retired",
                    Percentage = 70
                }
            };
            var mockGuestService = new Mock<IGuestService>();
            mockGuestService.Setup(g => g.GetAll()).Returns(guests);
            var priceCalculatorService = new PriceCalculatorService(mockGuestService.Object);

            
            double calculatedPrice = priceCalculatorService.CalculatePrice(numberOfGuests, price);

            
            Assert.AreEqual(totalPrice, calculatedPrice);
        }
        
        [TestMethod]
        public void CalculatePriceWithOddRetired()
        {
            var numberOfGuests = new NumberOfGuests
            {
                NumberOfAdults = 2,
                NumberOfChildren = 1,
                NumberOfBabies = 0,
                NumberOfRetired = 9, 
            };
            const double price = 20.0;

            const double totalPrice = 206.0;

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
                new Guest
                {
                    Name = "Baby",
                    Percentage = 25
                },
                new Guest
                {
                    Name = "Retired",
                    Percentage = 70
                }
            };
            var mockGuestService = new Mock<IGuestService>();
            mockGuestService.Setup(g => g.GetAll()).Returns(guests);
            var priceCalculatorService = new PriceCalculatorService(mockGuestService.Object);

            
            double calculatedPrice = priceCalculatorService.CalculatePrice(numberOfGuests, price);

            
            Assert.AreEqual(totalPrice, calculatedPrice);
        }
    }
}