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
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductAsync();
            return Ok(products);
        }

        public IActionResult Create()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult>Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(ModelState);
            }
            if (await _productService.CreateProductAsync(model))
                return RedirectToAction(nameof(Index));

            return Ok(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            var productEdit = new ProductEdit
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Size = product.Size,
                Quantity = product.Quantity
            };
            return Ok(productEdit);

        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProductEdit model)
        {
            if (id != model.Id || !ModelState.IsValid)
                return Ok(ModelState);

            bool wasUpdated = await _productService.UpdateProductAsync(model);
            
            if (wasUpdated) return RedirectToAction(nameof(Index));
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ProductDetail model)
        {
            if (await _productService.DeleteProductAsync(model.Id))
                return RedirectToAction(nameof(Index));
            else
                return BadRequest();
        }



    }
}
