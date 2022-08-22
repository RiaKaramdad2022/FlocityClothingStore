using FlocityClothingStore.Server.Services.Category;
using FlocityClothingStore.Server.Services.Customer;
using FlocityClothingStore.Shared.Models.Category;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Category(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (model == null) return BadRequest();

            bool wasSuccessful = await _categoryService.CreateCategoryAsync(model);

            if (wasSuccessful) return Ok();
            else return UnprocessableEntity();
        }

        //The Edit method will be similar to the Create method, but with a CategoryEdit parameter an int id parameter. This will also be a PUT method, and 
        // will require a Category Id in the URL

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CategoryEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();

            bool wasSucessful = await _categoryService.UpdateCategoryAsync(model);

            if (wasSucessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            bool wasSucessful = await _categoryService.DeleteCategoryAsync(id);

            if (!wasSucessful) return BadRequest();
            return Ok();

        }

       
    



    }
}
