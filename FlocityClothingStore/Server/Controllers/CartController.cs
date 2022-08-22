using FlocityClothingStore.Server.Services.Cart;
using FlocityClothingStore.Shared.Models.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlocityClothingStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService )
        {
            _cartService = cartService;
        }

        public async Task<List<CartListItem>> Index()
        {
            var cartProducts = await _cartService.GetAllCartProductsAsync();
            return cartProducts.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Cart(int id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartCreate model)
        {
            if (model == null) return BadRequest();

            bool wasSucessful = await _cartService.CreateCartAsync(model);

            if (wasSucessful) return Ok();
            else return UnprocessableEntity(); 
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CartEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();

            bool wasSucessful = await _cartService.UpdateCartAsync(model);

            if (wasSucessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);
            if (cart == null) return NotFound();

            bool wasSucessful = await _cartService.DeleteCartAsync(id);
            if (!wasSucessful) return BadRequest();
            return Ok();

        }
    }
}
