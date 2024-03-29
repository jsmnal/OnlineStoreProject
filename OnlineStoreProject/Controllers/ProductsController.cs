﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Data;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;
using OnlineStoreProject.Utils;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IProductService _service;

        public ProductsController(IProductService service, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _service.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _service.Get(id);

            if (product is null) return NotFound();

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            await _service.UpdateProduct(id, product);
            return NoContent();
        }

        [HttpPut("increaseView/{id}")]
        public async Task<IActionResult> IncreaseProductsViews(int id)
        {
            var existingProduct = await _service.Get(id);
            if (existingProduct is null) return NotFound();

            existingProduct.Views += 1;
            await _service.Update(existingProduct);
            return NoContent();
        }

        [HttpPut("decreaseStockQuantity/{id}")]
        public async Task<IActionResult> DecreaseStockQuantity(int id, Product product)
        {
            var existingProduct = await _service.Get(id);
            if (existingProduct is null) return NotFound();

            existingProduct.StockQuantity -= product.StockQuantity;
            if (existingProduct.StockQuantity >= 0)
            {
                await _service.Update(existingProduct);
                return NoContent();
            } else
            {
                return BadRequest();
            }
        }

        [HttpPut("increaseStockQuantity/{id}")]
        public async Task<IActionResult> IncreaseStockQuantity(int id, Product product)
        {
            var existingProduct = await _service.Get(id);
            if (existingProduct is null) return NotFound();

            existingProduct.StockQuantity += product.StockQuantity;
            await _service.Update(existingProduct);
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm]Product product)
        {
            ImageUpload imageUpload = new(_hostEnvironment);
            if (product.ImageFile is not null) product.ImagePath = await imageUpload.Upload(product.ImageFile);
            product.CreatedDate = DateTime.Now;
            await _service.Add(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _service.Get(id);
            if (existingProduct is null) return NotFound();
            
            ImageUpload imageUpload = new(_hostEnvironment);
            imageUpload.Delete(existingProduct);

            await _service.Delete(id);
            return NoContent();
        }

        [HttpGet("limit={limit}")]
        public async Task<IEnumerable<Product>> GetNewest(int limit)
        {
            return await _service.GetNewest(limit);
        }

        [HttpGet("category={categoryName}")]
        public async Task<IEnumerable<Product>> GetWithCategoryName(string categoryName)
        {
            return await _service.GetWithCategory(categoryName);
        }

        [HttpGet("popular={limit}")]
        public async Task<IEnumerable<Product>> GetPopular(int limit)
        {
            return await _service.GetPopular(limit);
        }
    }
}
