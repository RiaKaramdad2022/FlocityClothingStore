﻿using FlocityClothingStore.Server.Services.Product;
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
            var products = await _productService.GetAllProductAsync();
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

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreate model)
        {
            if (model == null) return BadRequest();

            bool wasSuccessful = await _productService.CreateProductAsync(model);

            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ProductEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
          
            bool wasUpdated = await _productService.UpdateProductAsync(model);

            if (wasUpdated) return Ok();
            return BadRequest();
        }

        [HttpGet("{id}")]
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
