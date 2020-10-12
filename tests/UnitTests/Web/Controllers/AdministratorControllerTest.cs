using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers;
using Web.Models.AdministratorModels;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    class AdministratorControllerTest
    {
        private string _name = "test";
        private string _email = "stm@imm.com";
        private string _pass = "3lP@$$XD";

        [TestMethod]
        public void AddAdministratorTest()
        {
            var administratorModel = new AdministratorCreatingModel
            {
                Name = _name,
                Email = _email,
                Password = _pass,
            };

            var mock = new Mock<IAdministratorService>();
            mock.Setup(m => m.Add(It.IsAny<Administrator>())).Returns(administratorModel.ToEntity());
            var controller = new AdministratorController(mock.Object);

            IActionResult result = controller.CreateAdministrator(administratorModel);
            var status = result as CreatedAtRouteResult;
            var content = status.Value as AdministratorBaseCreateModel;

            mock.VerifyAll();
            Assert.AreEqual(content, new AdministratorBaseCreateModel(administratorModel.ToEntity()));
        }
    }
}
