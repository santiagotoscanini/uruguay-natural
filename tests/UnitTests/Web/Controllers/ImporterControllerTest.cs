using System.Collections.Generic;
using System.Linq;
using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers;
using Web.Models.ImporterModel;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class ImporterControllerTest
    {
        private string _importerName = "Name1";

        [TestMethod]
        public void GetImportersTest()
        {
            var importersNames = new List<string>{_importerName};
            var mock = new Mock<IImporterService>(MockBehavior.Strict);
            mock.Setup(m => m.GetNames()).Returns(importersNames);
            
            var importerController = new ImporterController(mock.Object);
            
            IActionResult result = importerController.GetImporters();
            var okResult = result as OkObjectResult;
            var names = okResult.Value as IEnumerable<string>;
            
            mock.VerifyAll();
            Assert.IsTrue(importersNames.SequenceEqual(names));
        }
        
        [TestMethod]
        public void ImportLodgingsTest()
        {
            var model = new ImporterBaseModel
            {
                Name = _importerName,
                FilePath = "Path",
            };
            var mock = new Mock<IImporterService>(MockBehavior.Strict);
            mock.Setup(m => m.Import(model.Name, model.FilePath));
            
            var importerController = new ImporterController(mock.Object);
            
            IActionResult result = importerController.ImportLodgings(model);
            var okResult = result as StatusCodeResult;
            
            mock.VerifyAll();
            Assert.AreEqual(201, okResult.StatusCode);
        }
    }
}