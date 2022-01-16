using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly OnlineStoreContext _context;
        private readonly ShopBasketRepository _shopBasketRepository;
        private readonly ShopBasketRowRepository _sbRowRepository;
        private readonly ProductRepository _productRepository;
        private readonly DiscountRepository _discountRepository;
        private readonly CategoryRepository _categoryRepository;

        public UnitOfWork(OnlineStoreContext context)
        {
            _context = context;
        }

        public IShopBasketRepository ShopBaskets => _shopBasketRepository ?? new ShopBasketRepository(_context);
        public IShopBasketRowRepository ShopBasketRows => _sbRowRepository ?? new ShopBasketRowRepository(_context);
        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);
        public IDiscountRepository Discounts => _discountRepository ?? new DiscountRepository(_context);
        public ICategoryRepository Categorys => _categoryRepository ?? new CategoryRepository(_context);

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }

}
