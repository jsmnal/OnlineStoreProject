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
    public class ShopBasketRowsController : ControllerBase
    {
        private readonly IRepository<ShopBasketRow> _repository;

        public ShopBasketRowsController(IRepository<ShopBasketRow> repository)
        {
            _repository = repository;
        }

        // GET: api/ShopBasketRows
        [HttpGet]
        public async Task<IEnumerable<ShopBasketRow>> GetShopBasketRows()
        {
            return await _repository.GetAll();
        }

        // GET: api/ShopBasketRows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopBasketRow>> GetShopBasketRow(int id)
        {
            var shopBasketRow = await _repository.Get(id);

            if (shopBasketRow is null)
            {
                return NotFound();
            }

            return shopBasketRow;
        }

        // PUT: api/ShopBasketRows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopBasketRow(int id, ShopBasketRow shopBasketRow)
        {
            var existingShopBasketRow = await _repository.Get(id);
            if (existingShopBasketRow is null)
            {
                return NotFound();
            }

            await _repository.Update(shopBasketRow);
            return NoContent();
        }

        // POST: api/ShopBasketRows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopBasketRow>> PostShopBasketRow(ShopBasketRow shopBasketRow)
        {
            await _repository.Add(shopBasketRow);
            return CreatedAtAction("GetShopBasketRow", new { id = shopBasketRow.Id }, shopBasketRow);
        }

        // DELETE: api/ShopBasketRows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopBasketRow(int id)
        {
            var existingShopBasketRow = await _repository.Get(id);
            if (existingShopBasketRow is null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }

    }
}
