using FlocityClothingStore.Shared.Models.Product;

namespace FlocityClothingStore.Server.Services.Product
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(ProductCreate model);
        Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
        Task<ProductDetail> GetProductByIdAsync(int productId);
        Task<bool> UpdateProductAsync(ProductEdit model);

        Task<bool> DeleteProductAsync(int productId);
    }
}
