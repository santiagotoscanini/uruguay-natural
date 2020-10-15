
using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Web.Controllers
{
    [TestsClass]
    public class LodgingControllerTest
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
        private ICollection<string> _images = new List<string> { "1234jnj" };
        private double _costPerNight = 200.0;
        private string _description = "Good place";
        private string _contactNumber = "23346789";
        private string _descriptionForBookings = "Call this number";
        private int _id = 1;
        private int _id2 = 2;
        private int _maximumSize = 300;
        private int _currentlyOccupiedPlaces = 0;

        [TestMethod]
        public void TestGetAllLodgingsOk()
        {
            var lodgingsToReturn = new List<Lodging>
            {
                new Lodging
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
                },
                new Lodging
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
                    Id = _id2,
                    MaximumSize = _maximumSize,
                    CurrentlyOccupiedPlaces = _currentlyOccupiedPlaces
                },
            };
            var mock = new Mock<ILodgingService>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(lodgingsToReturn);
            var controller = new LodgingController(mock.Object);

            IActionResult result = controller.GetAllLodgings();
            var okResult = result as OkObjectResult;
            var lodgings = okResult.Value as IEnumerable<LodgingModel>;

            mock.VerifyAll();
            Assert.IsTrue(lodgingsToReturn.Select(b => new LodgingModel(b)).SequenceEqual(lodgings));
        }

        [TestMethod]
        public void TestPostLodgingOk()
        {
            var lodgingModel = new LodgingCreatingModel
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
                MaximumSize = _maximumSize,
                CurrentlyOccupiedPlaces = _currentlyOccupiedPlaces
            };
            var lodgingToReturn = new Lodging
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
                Id = _id2,
                MaximumSize = _maximumSize,
                CurrentlyOccupiedPlaces = _currentlyOccupiedPlaces
            };

            var mock = new Mock<ILodgingService>();
            mock.Setup(m => m.Add(It.IsAny<Lodging>())).Returns(lodgingToReturn);
            var controller = new LodgingController(mock.Object);

            IActionResult result = controller.AddLodging(lodgingModel);
            var status = result as CreatedAtRouteResult;
            var content = status.Value as LodgingBaseCreateModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new LodgingBaseCreateModel(lodgingToReturn));
        }

        [TestMethod]
        public void TestGetLodgingOk()
        {
            var lodgingToReturn = new Lodging
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
                Id = _id2,
                MaximumSize = _maximumSize,
                CurrentlyOccupiedPlaces = _currentlyOccupiedPlaces
            };

            var mock = new Mock<ILodgingService>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(_id)).Returns(lodgingToReturn);
            var controller = new LodgingController(mock.Object);

            IActionResult result = controller.GetLodgingById(_id);
            var okResult = result as OkObjectResult;
            var lodging = okResult.Value as LodgingStateInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(new LodgingStateInfoModel(lodgingToReturn), lodging);
        }

        [TestMethod]
        public void TestPutLodgingOk()
        {
            var lodgingToReturn = new Lodging
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
                Id = _id2,
                MaximumSize = _maximumSize,
                CurrentlyOccupiedPlaces = _currentlyOccupiedPlaces
            };
            var updateInfoLodging = new LodgingUpdateInfoModel
            {
                Id = _id2,
                CurrentlyOccupiedPlaces = _maximumSize
            
            };
            var stateInfoLodging = new Lodging
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
                Id = _id2,
                MaximumSize = _maximumSize,
                CurrentlyOccupiedPlaces = _maximumSize
            };

            var mock = new Mock<ILodgingService>(MockBehavior.Strict);
            mock.Setup(m => m.Update(updateInfoLodging)).Returns(stateInfoLodging);
            var controller = new LodgingController(mock.Object);

            IActionResult result = controller.UpdateLodging(lodgingToReturn);
            var okResult = result as OkObjectResult;
            var lodging = okResult.Value as LodgingModel;

            mock.VerifyAll();
            Assert.AreEqual(lodging.CurrentlyOccupiedPlaces, _maximumSize);
        }

        public void TestDeleteLodgingOk()
        {
            var lodgingModel = new LodgingCreatingModel
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
                MaximumSize = _maximumSize,
                CurrentlyOccupiedPlaces = _currentlyOccupiedPlaces
            };
            var lodgingToReturn = new Lodging
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
            var mock = new Mock<ILodgingService>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(_id)); 
            mock.Setup(m => m.Add(It.IsAny<Lodging>())).Returns(lodgingToReturn);
            mock.Setup(m => m.GetAll()).Returns(new List<Lodging>());
            var controller = new LodgingController(mock.Object);

            controller.AddLoging(lodgingModel);
            controller.DeleteLodging(_id);
            IActionResult result = controller.getAll();
            var okResult = result as OkObjectResult;
            var lodgings = okResult.Value as IEnumerable<LodgingModel>;

            mock.VerifyAll();
            Assert.IsTrue(new List<LodgingModel>().SequenceEqual(lodgings));
        }
    }
}
