using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class ToruistPointControllerTest
    {
        private ICollection<TouristPointCategory> _touristPointCategories = new List<TouristPointCategory>
        {
            new TouristPointCategory
            {
                Id = 1,
                Category = new Category { Name = "Playa"},
                TouristPoint = new TouristPoint { Id = 1}
            }          
        };
        private ICollection<TouristPointCategory> _touristPointCategories2 = new List<TouristPointCategory>
        {
            new TouristPointCategory
            {
                Id = 2,
                Category = new Category { Name = "Playa" },
                TouristPoint = new TouristPoint { Id = 2 }
            }
        };
        private ICollection<string> _categoriesNames = new List<string> { "Playa" };
        private Region _region = new Region { Name = "Este" };
        private string _name = "Maldonado";
        private string _description = "Dummy description";
        private string _image = "image";
        private int? _id = 1;
        private int? _id2 = 2;

        [TestMethod]
        public void TestGetAllTouristPointOk()
        {

            var touristPointsToReturn = new List<TouristPoint>
            {
                new TouristPoint
                {
                    TouristPointCategories = _touristPointCategories,
                    Region = _region,
                    Name = _name,
                    Description = _description,
                    Image = _image,
                    Id = _id,
                },
                new TouristPoint
                {
                    TouristPointCategories = _touristPointCategories2,
                    Region = _region,
                    Name = _name,
                    Description = _description,
                    Image = _image,
                    Id = _id2,
                }
            };
            var mock = new Mock<ITouristPointService>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(touristPointsToReturn);
            var controller = new TouristPointController(mock.Object);

            IActionResult result = controller.GetAllTouristPoints();
            var okResult = result as OkObjectResult;
            var touristPoints = okResult.Value as IEnumerable<TouristPointModel>;

            mock.VerifyAll();
            Assert.IsTrue(touristPointsToReturn.Select(b => new TouristPointModel(b)).SequenceEqual(touristPoints));
        }

        [TestMethod]
        public void TestPostTouristPointOk()
        {
            var touristPointModel = new TouristPointCreatingModel
            {
                Categories = _categoriesNames,
                RegionName = "Este",
                Name = "Maldonado",
                Description = "Dummy description",
                Image = "image",

            };
            var touristPointToReturn = new TouristPoint
            {
                TouristPointCategories = _touristPointCategories2,
                Region = _region,
                Name = _name,
                Description = _description,
                Image = _image,
                Id = _id2,
            };
            var mock = new Mock<ITouristPointService>();
            mock.Setup(m => m.Add(It.IsAny<TouristPoint>(), _categoriesNames)).Returns(touristPointToReturn);
            var controller = new TouristPointController(mock.Object);

            IActionResult result = controller.CreateTouristPoint(touristPointModel);
            var status = result as CreatedAtRouteResult;
            var content = status.Value as TouristPointCreatingModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new TouristPointCreatingModel(touristPointToReturn));
        }
    }
}
