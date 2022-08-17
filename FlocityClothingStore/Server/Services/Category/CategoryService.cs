using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Category;
using FlocityClothingStore.Shared.Models.Customer;
using Microsoft.EntityFrameworkCore; 

namespace FlocityClothingStore.Server.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            var categoryEntity = new Category
            {
                CategoryName = model.CategoryName,
                ProductId = model.ProductId
            };
            _context.Categories.Add(categoryEntity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.Select(c =>
                    new CategoryListItem
                    {
                        Id = c.Id,
                        ProductId = c.ProductId,
                        CategoryName = c.CategoryName
                    }).ToListAsync();
            return categories;
        }
        public async Task<CategoryDetail> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category is null)
                return null;

            return new CategoryDetail
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                ProductId = category.ProductId,
            };
        }
        public async Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            var category = await _context.Categories.FindAsync(model.Id);
            if (category is null) return false;

            category.ProductId = model.ProductId;
            category.CategoryName = model.CategoryName;

            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category is null) return false;

            _context.Categories.Remove(category);
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }
    }

    
}
