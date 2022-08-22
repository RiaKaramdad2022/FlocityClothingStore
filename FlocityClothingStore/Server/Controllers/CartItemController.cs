using FlocityClothingStore.Server.Services.CartItem;
using FlocityClothingStore.Shared.Models.CartItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlocityClothingStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public async Task<List<CartItemListItem>> Index()
        {
            var cartItem = await _cartItemService.GetAllCartItemsAsync();
            return cartItem.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CartItem(int id)
        {
            var cartItem = await _cartItemService.GetCartItemByIdAsync(id);
            if (cartItem == null) return NotFound();
            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartItemCreate model)
        {
            if (model == null) return BadRequest();

            bool wasScuccessful = await _cartItemService.CreateCartItemAsync(model);

            if (wasScuccessful) return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CartItemEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();

            bool wasSucessful = await _cartItemService.UpdateCartItemAsync(model);
            if (wasSucessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cartItem = await _cartItemService.GetCartItemByIdAsync(id);
            if (cartItem == null) return NotFound();

            bool wasSucessful = await _cartItemService.DeleteCartItemAsync(id);
            if (!wasSucessful) return BadRequest();
            return Ok();


        }
    }
}
