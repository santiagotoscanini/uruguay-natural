using ApplicationCore.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class CategoryServiceTest
    {
        private string _categoryName1 = "category_name_1";
        private string _categoryName2 = "category_name_2";


        [TestMethod]
        public void TestGetAllOk()
        {
            var categoriesToReturn = new List<Category>
            {
                new Category
                {
                    Name = _categoryName1,
                },
                new Category
                {
                    Name = _categoryName2,
                },
            };
            var mock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(categoriesToReturn);
            var categoryService = new CategoryService(mock.Object);

            IEnumerable<Category> categoriesSaved = categoryService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(categoriesSaved.SequenceEqual(categoriesToReturn));
        }
        
        [TestMethod]
        public void TestGetCategoryByNameOk()
        {
            var categoryToReturn = new Category
            {
                Name = _categoryName1,
            };
            var mock = new Mock<ICategoryRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetByName(_categoryName1)).Returns(categoryToReturn);
            var categoryService = new CategoryService(mock.Object);

            Category category = categoryService.GetCategoryByName(_categoryName1);

            mock.VerifyAll();
            Assert.AreEqual(categoryToReturn, category);
        }
    }
}
