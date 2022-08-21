using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Server.Models;
using FlocityClothingStore.Shared.Models.CartItem;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlocityClothingStore.Server.Services.CartItem
{
    public class CartItemService : ICartItemService
    {
        private ApplicationDbContext _context;
        public CartItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task<bool> ICartItemService.CreateCartItemAsync(CartItemCreate model)
        {
            if (model == null) return false;
            var cartItemEntity = new Models.CartItem
            {
                CartId = model.CartId,
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                Size = model.Size,

            };
            _context.CartItems.Add(cartItemEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<CartItemListItem>> GetAllCartItemsAsync()
        {
            var cartItems = _context.CartItems.Select(ct => new CartItemListItem
            {
                Id = ct.Id,
                CartId = ct.CartId,
                ProductId = ct.ProductId,
                Quantity = ct.Quantity,
                Size = ct.Size

            });
            return await cartItems.ToListAsync();

        }

        public async Task<CartItemDetail> GetCartItemByIdAsync(int cartId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartId);
            if (cartItem is null) return null;

            return new CartItemDetail
            {
                Id = cartItem.Id,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Size = cartItem.Size,
                ProductName = cartItem.Product.Name,
                ProductPrice = cartItem.Product.Price

            };
        }

        public async Task<bool> UpdateCartItemAsync(CartItemEdit model)
        {
            var cartItem = await _context.CartItems.FindAsync(model.Id);
            if (cartItem is null) return false;

            cartItem.CartId = model.CartId;
            cartItem.ProductId = model.ProductId;
            cartItem.Quantity = model.Quantity;
            cartItem.Size = model.Size;

            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

        public async Task<bool> DeleteCartItemAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);

            if (cartItem is null) return false;
            _context.CartItems.Remove(cartItem);
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;

        }
    }
}

