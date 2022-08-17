using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Customer;

namespace FlocityClothingStore.Server.Services.Cart
{
    public interface ICartService
    {
        Task<bool> CreateCart(CartCreate model);
        Task<IEnumerable<CartListItem>> GetAllCartItems();
        Task<CartDetail> GetCartItemById(int CartId);
        Task<bool> UpdateCart(CartEdit model);
        Task<bool> DeleteCart(int cartId);
    }
}
