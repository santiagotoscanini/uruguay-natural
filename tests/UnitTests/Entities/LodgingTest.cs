using Castle.Core.Internal;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.Entities
{
    [TestClass]
    public class LodgingTest
    {
        private string _name = "Moon";
        private int _numberOfStars = 3;
        private TouristPoint _touristPoint = new TouristPoint
        {
            TouristPointCategories = new List<TouristPointCategory>(),
            Region = new Region
            {
                Name = "Norte",
            },
            Name = "Rocha",
            Description = "Good place",
            Image = "sfafg222",
            Id = 2,
         };
        private string _address = "Av. Rio 123";
        private IEnumerable<string> _images = new List<string>{"1234jnj"};
        private double _costPerNight = 200.0;
        private string _description = "Good place";
        private string _contactNumber = "23346789";
        private string _descriptionForBookings = "Call this number";
        private int _id = 1;
        private int _maximumSize = 300;
        private int _currentlyOccupiedPlaces = 0;


        [TestMethod]
        public void CreateEmptyLodging()
        {
            var emptyLodging = new Lodging();

            Assert.IsNull(emptyLodging.Name);
            Assert.AreEqual(0, emptyLodging.NumberOfStars);
            Assert.IsNull(emptyLodging.TouristPoint);
            Assert.IsNull(emptyLodging.Address);
            Assert.IsTrue(emptyLodging.Images.IsNullOrEmpty());
            Assert.AreEqual(0, emptyLodging.CostPerNight);
            Assert.IsNull(emptyLodging.Description);
            Assert.IsNull(emptyLodging.ContactNumber);
            Assert.IsNull(emptyLodging.DescriptionForBookings);
            Assert.AreEqual(0, emptyLodging.Id);
            Assert.AreEqual(0, emptyLodging.MaximumSize);
            Assert.AreEqual(0, emptyLodging.CurrentlyOccupiedPlaces);
        }

        [TestMethod]
        public void CreateLodging()
        {
            var lodging = new Lodging
            { 
                Name = _name,
                NumberOfStars = _numberOfStars,
                TouristPoint = _touristPoint,
                Address = _address,
                Images = _images,
                CostPerNight = _costPerNight,
                ContactNumber = _contactNumber,
                Description = _description,
                DescriptionForBookings = _descriptionForBookings,
                Id = _id,
                MaximumSize = _maximumSize,
                CurrentlyOccupiedPlaces = _currentlyOccupiedPlaces
            };

            Assert.AreEqual(_name, lodging.Name);
            Assert.AreEqual(_numberOfStars, lodging.NumberOfStars);
            Assert.AreEqual(_touristPoint, lodging.TouristPoint);
            Assert.AreEqual(_address, lodging.Address);
            Assert.AreEqual(_images, lodging.Images);
            Assert.AreEqual(_costPerNight, lodging.CostPerNight);
            Assert.AreEqual(_contactNumber, lodging.ContactNumber);
            Assert.AreEqual(_description, lodging.Description);
            Assert.AreEqual(_descriptionForBookings, lodging.DescriptionForBookings);
            Assert.AreEqual(_id, lodging.Id);
            Assert.AreEqual(_maximumSize, lodging.MaximumSize);
            Assert.AreEqual(_currentlyOccupiedPlaces, lodging.CurrentlyOccupiedPlaces);
        }
    }
}