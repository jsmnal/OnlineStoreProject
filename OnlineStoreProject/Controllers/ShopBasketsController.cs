﻿using System;
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
    public class ShopBasketsController : ControllerBase
    {
        private readonly IRepository<ShopBasket> _repository;

        public ShopBasketsController(IRepository<ShopBasket> repository)
        {
            _repository = repository;
        }

        // GET: api/ShopBaskets
        [HttpGet]
        public async Task<IEnumerable<ShopBasket>> GetShopBaskets()
        {
            return await _repository.GetAll();
        }

        // GET: api/ShopBaskets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopBasket>> GetShopBasket(int id)
        {
            var shopBasket = await _repository.Get(id);

            if (shopBasket == null)
            {
                return NotFound();
            }

            return shopBasket;
        }

        // PUT: api/ShopBaskets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopBasket(int id, ShopBasket shopBasket)
        {
            var existingShopBasket = await _repository.Get(id);
            if (existingShopBasket is null)
            {
                return NotFound();
            }

            await _repository.Update(shopBasket);
            return NoContent();
        }

        // POST: api/ShopBaskets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopBasket>> PostShopBasket(ShopBasket shopBasket)
        {
            await _repository.Add(shopBasket);
            return CreatedAtAction("GetShopBasket", new { id = shopBasket.Id }, shopBasket);
        }

        // DELETE: api/ShopBaskets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopBasket(int id)
        {
            var existingShopBasket = await _repository.Get(id);
            if (existingShopBasket is null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }
    }
}