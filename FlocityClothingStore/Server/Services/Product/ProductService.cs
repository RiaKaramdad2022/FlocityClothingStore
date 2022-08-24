using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Server.Models;
using FlocityClothingStore.Shared.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace FlocityClothingStore.Server.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProductAsync(ProductCreate model)
        {
            if (model == null) return false;

            _context.Products.Add(new Models.Product
            {
                Name = model.Name,
                Price = model.Price,
                Description =model.Description,
                Size = model.Size,
                CategoryId = model.CategoryId,
             
            });
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
        {
            var products = await _context.Products.Select(product => new ProductListItem
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size,
                CategoryId = product.CategoryId,


            }).ToListAsync();
            return products;
        }
        public async Task<ProductDetail> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products.Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product is null) return null;

            return new ProductDetail
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,

            };

        }
        public async Task<bool> UpdateProductAsync(ProductEdit model)
        {
            var product = await _context.Products.FindAsync(model.Id);
            if (product is null) return false;

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Size = model.Size;
            product.CategoryId = model.CategoryId;


            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product is null) return false;

            _context.Products.Remove(product);
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

    }
}
