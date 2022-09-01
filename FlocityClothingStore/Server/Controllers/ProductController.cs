using FlocityClothingStore.Server.Services.Product;
using FlocityClothingStore.Shared.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlocityClothingStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productServcie)
        {
            _productService = productServcie;
        }

        [HttpGet]
        public async Task<List<ProductListItem>> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return products.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Product(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        //The Create endpoint is a POST method that will return an IActionResult. It will take in a ProductCreate model from the request body.
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreate model)
        {
            //if model is null we will return BadRequst.
            if (model == null) return BadRequest();
            //however, if the result is successful, we will return Ok, but it fails we will return UnprocessableEntity.
            bool wasSuccessful = await _productService.CreateProductAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProductEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
          
            bool wasSucessful = await _productService.UpdateProductAsync(model);

            if (wasSucessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            bool wasSucessful = await _productService.DeleteProductAsync(id);
            if (!wasSucessful) return BadRequest();
            return Ok();
        }

    }
}
