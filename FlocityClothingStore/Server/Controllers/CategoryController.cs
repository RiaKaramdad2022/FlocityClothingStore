using FlocityClothingStore.Server.Services.Category;
using FlocityClothingStore.Server.Services.Customer;
using FlocityClothingStore.Shared.Models.Category;
using FlocityClothingStore.Shared.Models.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlocityClothingStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<CategoryListItem>> Index()
        {
            var catgories = await _categoryService.GetAllCategoriesAsync();
            return catgories.ToList();
        }
    }
}
