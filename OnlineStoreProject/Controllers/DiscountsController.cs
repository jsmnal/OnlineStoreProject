using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Data;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IRepository<Discount> _repository;

        public DiscountsController(IRepository<Discount> repository)
        {
            _repository = repository;
        }

        // GET: api/Discounts
        [HttpGet]
        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            return await _repository.GetAll();
        }

        // GET: api/Discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetDiscount(int id)
        {
            var discount = await _repository.Get(id);

            if (discount is null)
            {
                return NotFound();
            }

            return discount;
        }

        // PUT: api/Discounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscount(int id, Discount discount)
        {
            var existingDiscount = await _repository.Get(id);
            if (existingDiscount is null)
            {
                return NotFound();
            }

            await _repository.Update(discount);
            return NoContent();
        }

        // POST: api/Discounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discount>> PostDiscount(Discount discount)
        {
            await _repository.Add(discount);
            return CreatedAtAction("GetDiscount", new { id = discount.Id }, discount);
        }

        // DELETE: api/Discounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var existingDiscount = await _repository.Get(id);
            if (existingDiscount is null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }
    }
}
