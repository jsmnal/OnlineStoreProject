using OnlineStoreProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreProject.Data.DAL
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly OnlineStoreContext _context;
        public ProductRepository(OnlineStoreContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<Product> Get(int id)
        {
            return await _context.Products.Include(c => c.Category).Include(d => d.Discount).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async override Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.Include(c => c.Category).Include(d => d.Discount).ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetNewest(int limit)
        {
            return await _context.Products.OrderByDescending(d => d.CreatedDate).Take(limit).ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetPopular(int limit)
        {
            return await _context.Products.OrderByDescending(d => d.Views).Take(limit).ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetWithCategory(string name)
        {
           return await _context.Products.Include(c => c.Category).Where(p => p.Category.Name.Contains(name)).ToArrayAsync();
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct is not null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.StockQuantity = product.StockQuantity;
                existingProduct.Price = product.Price;
                existingProduct.ImageFile = product.ImageFile;
                existingProduct.ImagePath = product.ImagePath;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.DiscountId = product.DiscountId;
            }
            _context.Entry(existingProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingProduct;
        }

    }
}
