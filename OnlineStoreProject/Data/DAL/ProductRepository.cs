﻿using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreProject.Data.DAL
{
    public class ProductRepository : BaseRepository<Product>
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
    }
}
