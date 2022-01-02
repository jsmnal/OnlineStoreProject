using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;

namespace OnlineStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopBasketRowsController : ControllerBase
    {
        private readonly IShopBasketRowRepository _sbRowRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private ISession _currentSession => _httpContextAccessor.HttpContext.Session;

        public ShopBasketRowsController(IShopBasketRowRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _sbRowRepository = repository;

            _httpContextAccessor = httpContextAccessor;

        }

        // GET: api/ShopBasketRows
        [HttpGet]
        public async Task<IEnumerable<ShopBasketRow>> GetShopBasketRows()
        {
            return await _sbRowRepository.GetAll();
        }

        // GET: api/ShopBasketRows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopBasketRow>> GetShopBasketRow(int id)
        {
            var shopBasketRow = await _sbRowRepository.Get(id);

            if (shopBasketRow is null) return NotFound();
            

            return shopBasketRow;
        }

        // PUT: api/ShopBasketRows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopBasketRow(int id, ShopBasketRow shopBasketRow)
        {
            await _sbRowRepository.UpdateShopBasketRow(id, shopBasketRow);
            return NoContent();
        }

        // POST: api/ShopBasketRows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopBasketRow>> PostShopBasketRow(ShopBasketRow shopBasketRow)
        {
            //shopBasketRow.ShopBasketId = int.Parse(Request.Cookies["Cookie"].ToString());
            if (!_currentSession.IsAvailable) await _currentSession.LoadAsync();
            shopBasketRow.ShopBasketId = int.Parse(_currentSession.GetString("Cart"));

            int productId = shopBasketRow.ProductId;
            int shopBasketId = shopBasketRow.ShopBasketId;
            if (_sbRowRepository.ProductExists(productId, shopBasketId) is true)
            {
                var shopBasketRowId = _sbRowRepository.GetSBRowId(productId, shopBasketId);
                var existingShopBasketRow = await _sbRowRepository.Get(shopBasketRowId);
                existingShopBasketRow.Quantity += shopBasketRow.Quantity;
                await _sbRowRepository.Update(existingShopBasketRow);
                return NoContent();

            }
            else
            {
                await _sbRowRepository.Add(shopBasketRow);
                return CreatedAtAction("GetShopBasketRow", new { id = shopBasketRow.Id }, shopBasketRow);
            }
        }

        [HttpPut("decreaseQuantity/{id}")]
        public async Task<IActionResult> DecreaseQuantity(int id, ShopBasketRow shopBasketRow)
        {
            var existingShopBasketRow = await _sbRowRepository.Get(id);
            if (existingShopBasketRow is null) return NotFound();

            existingShopBasketRow.Quantity -= shopBasketRow.Quantity;
            await _sbRowRepository.Update(existingShopBasketRow);
            return NoContent();
        }


        // DELETE: api/ShopBasketRows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopBasketRow(int id)
        {
            var existingShopBasketRow = await _sbRowRepository.Get(id);
            if (existingShopBasketRow is null) return NotFound();
            await _sbRowRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("currentShopBasket")]
        public async Task<IEnumerable<ShopBasketRow>> GetWithShopBasketId()
        {
            if(!_currentSession.IsAvailable) await _currentSession.LoadAsync();
            int shopBasketId = int.Parse(_currentSession.GetString("Cart"));
            return await _sbRowRepository.GetWithShopBasketId(shopBasketId);
        }

        [HttpGet("currentShopBasket/total")]
        public async Task<decimal> GetTotal()
        {
            if (!_currentSession.IsAvailable) await _currentSession.LoadAsync();
            int shopBasketId = int.Parse(_currentSession.GetString("Cart"));
            return _sbRowRepository.GetShopBasketTotal(shopBasketId);
        }


    }
}
