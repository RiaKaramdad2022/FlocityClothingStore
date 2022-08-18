using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.CartItem;

namespace FlocityClothingStore.Server.Services.CartItem
{
    public interface ICartItemService
    {
        Task<bool> CreateCartItemAsync(CartItemCreate model);
        Task<IEnumerable<CartItemListItem>> GetAllCartItemsAsync();
        Task<CartItemDetail> GetCartItemByIdAsync(int cartId);
        Task<bool> UpdateCartItemAsync(CartItemEdit model);
        Task<bool> DeleteCartItemAsync(int cartId);
    }
}
