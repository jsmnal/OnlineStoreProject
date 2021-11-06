using System;
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
using OnlineStoreProject.Utils;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(IRepository<Product> repository, IWebHostEnvironment hostEnvironment)
        {
            _repository = repository;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repository.Get(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            var existingProduct = await _repository.Get(id);
            if (existingProduct is null)
            {
                return NotFound();
            }
            await _repository.Update(product);
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm]Product product)
        {
            ImageUpload imageUpload = new(_hostEnvironment);
            if (product.ImageFile is not null)
            {
                product.ImagePath = await imageUpload.Upload(product.ImageFile);
            };
            
            await _repository.Add(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _repository.Get(id);
            if (existingProduct is null)
            {
                return NotFound();
            }
            ImageUpload imageUpload = new(_hostEnvironment);
            imageUpload.Delete(existingProduct);

            await _repository.Delete(id);
            return NoContent();
        }
    }
}
