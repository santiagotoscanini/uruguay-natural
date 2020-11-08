using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers;
using Web.Models.AdministratorModel;
using Web.Models.AdministratorModels;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class AdministratorControllerTest
    {
        private const string Name = "test";
        private const string Email = "stm@imm.com";
        private const string Pass = "3lP@$$XD";

        [TestMethod]
        public void AddAdministratorTest()
        {
            var administratorModel = new AdministratorCreatingModel
            {
                Name = Name,
                Email = Email,
                Password = Pass,
            };

            var administratorService = new Mock<IAdministratorService>();
            administratorService.Setup(m => m.Add(administratorModel.ToEntity())).Returns(administratorModel.ToEntity());
            var controller = new AdministratorController(administratorService.Object);

            IActionResult result = controller.AddAdministrator(administratorModel);
            var status = result as ObjectResult;
            var content = status.Value as AdministratorBaseCreateModel;

            administratorService.VerifyAll();
            Assert.AreEqual(content, new AdministratorBaseCreateModel(administratorModel.ToEntity()));
        }
        
        [TestMethod]
        public void DeleteAdministratorTest()
        {
            var administratorService = new Mock<IAdministratorService>();
            administratorService.Setup(m => m.DeleteAdministrator(Email));
            var controller = new AdministratorController(administratorService.Object);

            IActionResult result = controller.DeleteAdministrator(Email);
            var status = result as NoContentResult;

            administratorService.VerifyAll();
            Assert.AreEqual(204, status.StatusCode);
        }
        
        [TestMethod]
        public void UpdateAdministratorTest()
        {
            var administrator = new Administrator
            {
                Name = "Admin",
                Email =  Email
            };
            var administratorModel = new AdministratorUpdatingModel{ Name = "Admin"};
            var administratorService = new Mock<IAdministratorService>();
            administratorService.Setup(m => m.UpdateAdministrator(administrator));
            var controller = new AdministratorController(administratorService.Object);

            IActionResult result = controller.UpdateAdministrator(Email, administratorModel);
            var status = result as NoContentResult;

            administratorService.VerifyAll();
            Assert.AreEqual(204, status.StatusCode);
        }
    }
}
