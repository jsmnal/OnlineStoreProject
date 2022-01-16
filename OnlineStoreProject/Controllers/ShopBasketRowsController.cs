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
    public class ShopBasketRowsController : ControllerBase
    {
        private readonly IShopBasketRowService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private ISession _currentSession => _httpContextAccessor.HttpContext.Session;

        public ShopBasketRowsController(IShopBasketRowService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;

            _httpContextAccessor = httpContextAccessor;

        }

        // GET: api/ShopBasketRows
        [HttpGet]
        public async Task<IEnumerable<ShopBasketRow>> GetShopBasketRows()
        {
            return await _service.GetAll();
        }

        // GET: api/ShopBasketRows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopBasketRow>> GetShopBasketRow(int id)
        {
            var shopBasketRow = await _service.Get(id);

            if (shopBasketRow is null) return NotFound();
            

            return shopBasketRow;
        }

        // PUT: api/ShopBasketRows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopBasketRow(int id, ShopBasketRow shopBasketRow)
        {
            await _service.UpdateShopBasketRow(id, shopBasketRow);
            return NoContent();
        }

        // POST: api/ShopBasketRows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopBasket>> PostShopBasketRow(ShopBasketRow shopBasketRow)
        {
            //shopBasketRow.ShopBasketId = int.Parse(Request.Cookies["Cookie"].ToString());
            if (!_currentSession.IsAvailable) await _currentSession.LoadAsync();
            shopBasketRow.ShopBasketId = int.Parse(_currentSession.GetString("Cart"));

            int productId = shopBasketRow.ProductId;
            int shopBasketId = shopBasketRow.ShopBasketId;
            if (_service.ProductExists(productId, shopBasketId) is true)
            {
                var shopBasketRowId = _service.GetSBRowId(productId, shopBasketId);
                var existingShopBasketRow = await _service.Get(shopBasketRowId);
                existingShopBasketRow.Quantity += shopBasketRow.Quantity;
                await _service.Update(existingShopBasketRow);
                return NoContent();

            }
            else
            {
                await _service.Add(shopBasketRow);
                return CreatedAtAction("GetShopBasketRow", new { id = shopBasketRow.Id }, shopBasketRow);
            }
        }

        [HttpPut("decreaseQuantity/{id}")]
        public async Task<IActionResult> DecreaseQuantity(int id, ShopBasketRow shopBasketRow)
        {
            var existingShopBasketRow = await _service.Get(id);
            if (existingShopBasketRow is null) return NotFound();
            existingShopBasketRow.Quantity -= shopBasketRow.Quantity;
            if(existingShopBasketRow.Quantity >= 0) { 
                await _service.Update(existingShopBasketRow);
                return NoContent();
            } else
            {
                return BadRequest();
            }
    }


        // DELETE: api/ShopBasketRows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopBasketRow(int id)
        {
            var existingShopBasketRow = await _service.Get(id);
            if (existingShopBasketRow is null) return NotFound();
            await _service.Delete(id);
            return NoContent();
        }

        [HttpGet("currentShopBasket")]
        public async Task<IEnumerable<ShopBasketRow>> GetWithShopBasketId()
        {
            if(!_currentSession.IsAvailable) await _currentSession.LoadAsync();
            int shopBasketId = int.Parse(_currentSession.GetString("Cart"));
            return await _service.GetWithShopBasketId(shopBasketId);
        }

        [HttpGet("currentShopBasket/total")]
        public async Task<decimal> GetTotal()
        {
            if (!_currentSession.IsAvailable) await _currentSession.LoadAsync();
            int shopBasketId = int.Parse(_currentSession.GetString("Cart"));
            return _service.GetShopBasketTotal(shopBasketId);
        }


    }
}
