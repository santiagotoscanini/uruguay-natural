using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Web.Controllers;
using Web.Models.CategoryModels;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        private string _name = "nameDummy";
        private string _name2 = "nameDummy2";

        [TestMethod]
        public void TestGetAllCategoriesOk()
        {
            var categoriesToReturn = new List<Category>
            {
                new Category
                {
                    Name = _name
                },
                new Category
                {
                    Name = _name2
                }
            };
            var mock = new Mock<ICategoryService>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoriesToReturn);
            var controller = new CategoryController(mock.Object);

            IActionResult result = controller.GetAllCategories();
            var okResult = result as OkObjectResult;
            var categories = okResult.Value as IEnumerable<CategoryModel>;

            mock.VerifyAll();
            Assert.IsTrue(categoriesToReturn.Select(r => new CategoryModel(r)).SequenceEqual(categories));
        }
    }
}
