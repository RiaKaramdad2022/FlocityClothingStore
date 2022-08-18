
using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Shared.Models.Cart;

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
            var cartEntity = new Cart
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Size = model.Size
            };
            _context.Carts.Add(cartEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<CartListItem>> GetAllCartItemsAsync()
        {
            var results = await (from products in _context.ProductDetail
                                 join cart in _context.CartDetail
                                 on products.ProductId equals cart.ProductId
                                 select new CartListItem
                                 {
                                     Id = cart.CartId,
                                     ProductId = cart.ProductId,
                                     ProductName = Cart.Product.Name,
                                     Size = cart.Size,
                                     Quantity = cart.Quantity,
                                     DateOfTransaction = DateTime.Now
                                 }).ToListAsync();
            return results;
        }
        public async Task<CartDetail> GetCartItemByIdAsync(int cartId)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart is null) return null;

            return new CartDetail
            {
                Id = cart.Id,
                ProductId = cart.ProductId,
                ProductName = cart.Product.Name,
                Size = cart.Size,
                Quantity = cart.Quantity,
                DateOfTransaction = DateTime.Now

            };
        }

        public async Task<bool> UpdateCartAsync(CartEdit model)
        {
            var cart = await _context.Carts.FindAsync(model.Id);
            if (cart is null) return false;

            cart.ProductName = model.ProductName;
            cart.ProductId = model.ProductId;
            cart.Size = model.Size;
            cart.Quantity = model.Quantity;
            cart.DateOfTransaction = model.DateTime.Now;

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
