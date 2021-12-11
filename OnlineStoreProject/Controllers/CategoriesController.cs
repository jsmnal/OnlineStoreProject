using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Data;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Models;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
        private readonly CategoryRepository _categoryRepository;
        public CategoriesController(IRepository<Category> repository, CategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _repository.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, Category category)
        {
            var existingCategory = await _repository.Get(id);

            if (existingCategory is null)
            {
                return NotFound();
            }

            await _repository.Update(category);
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _repository.Add(category);
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var existingCategory = await _repository.Get(id);

            if (existingCategory is null)
            {
                return NotFound();
            }

            await _repository.Delete(id);

            return NoContent();
        }

        [HttpGet]
        public  async Task<IEnumerable<Category>> GetCategories()
        {
            return await _repository.GetAll();
        }

        [HttpGet("name={name}")]
        public async Task<IEnumerable<Category>> GetWithCategoryName(string name)
        {
            return await _categoryRepository.GetWithName(name);
        }

    }
}
