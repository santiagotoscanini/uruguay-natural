using System;
using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Web.Controllers;
using Web.Models.TouristPointModels;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class TouristPointControllerTest
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
        private byte[] _image = new byte[1];
        private int _id = 1;
        private int _id2 = 2;

        private string _base64image =
            "iVBORw0KGgoAAAANSUhEUgAAAJkAAAD2CAYAAADF/iU1AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiUAABYlAUlSJPAAAGFwSURBVHhe7X0FgFVV9/2d7k6YYuju7hZJaQSUkAYBgaFrhhmGBkGRUFQUAwVbbOxCRUQEFAmRbpiu9d/r3DnD4/Hw933/jxEY3tHFfXPvuXH2WWfvfdrIy8uDHXYUJuwks6PQYSeZHYUOO8nsKHTYSWZHocNOMjsKHXaS2VHosJPMjkKHnWR2FDrsJLOj0GEnmR2FDjvJ7Ch02ElmR6HDTrL/Ebm5uQq2rtlhwk6y/wEkV05OjoKdaDeGnWT/H8gFkC2kyszKQlp6ukKW/FZky7OTzRp2kv0XyBXkCIkys7ORkZWJi5cuYcubb+HV11/HufPn5HwWMnOyhYS2779bYSfZf4HcvBxk5Yj2ykjH5StX8NjapxAcUQJB4RFIXrwIJ0+dQppcT8/JVEQjKW09526DnWT/BWgKM7IylHl85rnnERAcBmdHVzg5u8HZ3QNx06fh5OnTSM1MQ3aeaDS76VSwk+y/QKaYyOzcHLzz4UcoHlMSboYDyof6olxEKNxcnODi5o4Zc2eL6TyvyJgjcW09526DnWT/ITIzM4U0udh/8CDqNWwEV8NAVS8DiztHYc2I5qgX5Q4fZwMePt5YvmoV0tLSFClZGbD1vLsJdpL9B6DZI8kuXb6CkWMnKIKVcTWQ1MgV5xKicGJhdTw7uDwaRLjBQzRaVEwJvP/he6pZIyMjw+Yz7ybYSfZ/gCFbaSNg06tvwC8wFMFCskFlnXFwZhSQ5Iors11xakl1rOhbHjEBrnCQ6y3btMFffx9DttREtTYTthbA+j1FGXaS/R8w276AE6fOokXLtuKHGWjsa+Dj4SFISw4B4g0gwUBagh9+S26MwU0i4Stm08XDE4uWr1QkYxsan6WD9TuKOuwk+wfQ3NFMZgvLlq18Ar5uLigpBFrc0g2p84shc7YDME9IRgjZTiVG4cMptdEoxtRmFWrUxgHx4RhItLu1V8BOsn9AlhCMxDh87Axq1W0ETyFO1wgDuybHIG++D3Ln5hNMNBmPF+e44/jS6pjbvRS8XB1guLhh+cqVimSZ4pvZSWbHNSAh0tPptANPPrMJrq7uiHUysOoeR6QtiUVevKMiV14+wYisuY5IWRCOT+c0Rp0YD6XNWrVthyspqcgRTaZJa+t9RRl2klnA7DaS3zRvmUKK7FxcvJyG+7r1hKMQpkOIgd2PeCJ3gQ9gqcU00cRk5iQ449iyBnikTTS8HA3VYPvxp18rbZaRlq6ezWDr/UUVdpLZAEOWaDGGT7/agYjwcPgIyWY3ckJqchCyhWBKgylyiV+W6Ii8eaZmI9EuLK2K50fURikvA4bhgPj5S9VzM5R/l6vIbP3Oogw7yWxAbBoyRetwtEXCgqVwpxPvYuCdh/yBZC/kzs7XXNcgn2Ty+7xUCr6Pb4iWJZyEZAbad+mDlBR5Xk5uQU3zboKdZDaQm5ODrIxMXErPRJsOneEtROklDv/BGRGmmSQSHUR7yTFJtJomWqJ5TEn0wV+LamBE4yDll5UoVRn79v2pNOPd2DhrJ5kNZIu2Ydi55w8Ui4pRja/x9Q1cmh8NUItRYwnJrodJtMx5Hji/pBIW9y4HNwcDrh7+eOPt99QzM9LS1NHWe4==";

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
            mock.Setup(m => m.GetAllFilteredByRegionAndCategory(null, null)).Returns(touristPointsToReturn);
            var controller = new TouristPointController(mock.Object);

            IActionResult result = controller.GetTouristPointFiltered(null, null);
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
                Image = _base64image,

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

            IActionResult result = controller.AddTouristPoint(touristPointModel);
            var status = result as ObjectResult;
            var content = status.Value as TouristPointModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new TouristPointModel(touristPointToReturn));
        }
    }
}
