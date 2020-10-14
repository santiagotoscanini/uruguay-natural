using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Web.Controllers;
using Web.Models.RegionModels;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class RegionControllerTest
    {
        private string _name = "nameDummy";
        private string _name2 = "nameDummy2";

        [TestMethod]
        public void TestGetAllRegionsOk()
        {
            var regionsToReturn = new List<Region>
            {
                new Region
                {
                    Name = _name
                },
                new Region
                {
                    Name = _name2
                }
            };
            var mock = new Mock<IRegionService>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(regionsToReturn);
            var controller = new RegionController(mock.Object);

            IActionResult result = controller.GetAllRegions();
            var okResult = result as OkObjectResult;
            var regions = okResult.Value as IEnumerable<RegionModel>;

            mock.VerifyAll();
            Assert.IsTrue(regionsToReturn.Select(r => new RegionModel(r)).SequenceEqual(regions));
        }
    }
}
