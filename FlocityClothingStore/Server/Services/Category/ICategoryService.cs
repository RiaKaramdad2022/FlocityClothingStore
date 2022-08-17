using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Category;

namespace FlocityClothingStore.Server.Services.Category
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryCreate model);
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<CategoryDetail> GetCategoryByIdAsync(int categoryId);
        Task<bool> UpdateCategoryAsync(CategoryEdit model);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
