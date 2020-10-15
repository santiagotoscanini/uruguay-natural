using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Models.CategoryModels;

namespace Web.Controllers
{
    [Route("api/v1/categories")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Se obtienen las categorias.
        /// </summary>
        /// <response code="200">Se obtuvo existosamente</response>
        /// <response code="500">Ocurrio un error en el servidor</response>
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAll().Select(r => new CategoryModel(r)));
        }
    }
}
