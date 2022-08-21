
using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace FlocityClothingStore.Server.Services.Cart
{
    public class CartService : ICartService
    {
        private ApplicationDbContext _context;
        public CartService(ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task<bool> CreateCartAsync(CartCreate model)
        {
            if (model == null) return false;
            var cartEntity = new Models.Cart
            {
                CustomerId = model.CustomerId,
  
            };
            _context.Carts.Add(cartEntity);
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<IEnumerable<CartListItem>> GetAllCartProductsAsync()
        {
            var carts = _context.Carts.Select(c => new CartListItem
            {
                Id = c.Id,
                CustomerId = c.CustomerId

            }) ;
            return await carts.ToListAsync();
        }
        public async Task<CartDetail> GetCartByIdAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart is null) return null;

            return new CartDetail
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                CustomerEmail = cart.Customer.Email,
                CustomerFullName = cart.Customer.FullName

            };
        }
        public async Task<bool> UpdateCartAsync(CartEdit model)
        {
            var cart = await _context.Carts.FindAsync(model.Id);
            if (cart is null) return false;

            cart.CustomerId = model.CustomerId;
    

            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

        public async Task<bool> DeleteCartAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);

            if (cart is null) return false;

            _context.Carts.Remove(cart);
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }
    }
}
