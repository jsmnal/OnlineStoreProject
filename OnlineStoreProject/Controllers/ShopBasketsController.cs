using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopBasketsController : ControllerBase
    {
        private readonly IShopBasketService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _currentSession => _httpContextAccessor.HttpContext.Session;

        public ShopBasketsController(IShopBasketService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;

    }


        // GET: api/ShopBaskets
        [HttpGet]
        public async Task<IEnumerable<ShopBasket>> GetShopBaskets()
        {
            return await _service.GetAll();
        }

        // GET: api/ShopBaskets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopBasket>> GetShopBasket(int id)
        {
            var shopBasket = await _service.Get(id);

            if (shopBasket == null) return NotFound();
            

            return shopBasket;
        }

        // PUT: api/ShopBaskets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopBasket(int id, ShopBasket shopBasket)
        {
            shopBasket.Updated = DateTime.Now;
            if(shopBasket.SentOrder is true)
            {
                _currentSession.Clear();
                
            }
            await _service.UpdateShopBasket(id, shopBasket); 
            return NoContent();
        }

        // POST: api/ShopBaskets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopBasket>> PostShopBasket(ShopBasket shopBasket)
        {
            if (!_currentSession.IsAvailable) await _currentSession.LoadAsync();

            shopBasket.SentOrder = false;
            shopBasket.Created = DateTime.Now;
            
            if (_currentSession.GetString("Cart") is null)
            {
                await _service.Add(shopBasket);
                //Response.Cookies.Append("Cookie", shopBasket.Id.ToString());
                _currentSession.SetString("Cart", shopBasket.Id.ToString());
                return CreatedAtAction("GetShopBasket", new { id = shopBasket.Id }, shopBasket);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/ShopBaskets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopBasket(int id)
        {
            var existingShopBasket = await _service.Get(id);
            if (existingShopBasket is null) return NotFound();
      
            await _service.Delete(id);
            return NoContent();
        }
    }
}
