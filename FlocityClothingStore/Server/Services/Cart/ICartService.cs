using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Customer;

namespace FlocityClothingStore.Server.Services.Cart
{
    public interface ICartService
    {
        Task<bool> CreateCartAsync(CartCreate model);
        Task<IEnumerable<CartListItem>> GetAllCartItemsAsync();
        Task<CartDetail> GetCartItemByIdAsync(int cartId);
        Task<bool> UpdateCartAsync(CartEdit model);
        Task<bool> DeleteCartAsync(int cartId);
    }
}
