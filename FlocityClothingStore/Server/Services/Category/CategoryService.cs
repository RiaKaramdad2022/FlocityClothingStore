using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Server.Models;
using FlocityClothingStore.Shared.Models.Cart;
using FlocityClothingStore.Shared.Models.Category;
using FlocityClothingStore.Shared.Models.Customer;
using FlocityClothingStore.Shared.Models.Product;
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
            if (model == null) return false;
            var categoryEntity = new Models.Category
            {
                CategoryName = model.CategoryName,

            };
            _context.Categories.Add(categoryEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<Shared.Models.Category.CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = _context.Categories.Select(c => new Shared.Models.Category.CategoryListItem
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            });
            return await categories.ToListAsync();
        }
        public async Task<CategoryDetail> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category is null) return null;

            return new CategoryDetail
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Products = category.Products
                .Where(p => p.CategoryId == categoryId)
                .Select(c => 
                new ProductListItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price,
                    Size = c.Size

                }).ToList()
            };
        }

        public async Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            var category = await _context.Categories.FindAsync(model.Id);
            if (category is null) return false;

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
