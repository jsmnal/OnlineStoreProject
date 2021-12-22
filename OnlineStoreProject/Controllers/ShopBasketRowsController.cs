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
        private readonly IShopBasketRowRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private ISession _currentSession => _httpContextAccessor.HttpContext.Session;

        public ShopBasketRowsController(IShopBasketRowRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;

            _httpContextAccessor = httpContextAccessor;

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
            //shopBasketRow.ShopBasketId = int.Parse(Request.Cookies["Cookie"].ToString());
            await _currentSession.LoadAsync();
            shopBasketRow.ShopBasketId = int.Parse(_currentSession.GetString("Cart"));
            if (_repository.ProductExists(shopBasketRow.ProductId, shopBasketRow.ShopBasketId) == true)
            {
                var existingShopBasketRow = await _repository.Get(_repository.ExistingRowId(shopBasketRow.ProductId, shopBasketRow.ShopBasketId));
                existingShopBasketRow.Quantity += 1;
                await _repository.Update(existingShopBasketRow);
                return NoContent();

            }
            else
            {
                shopBasketRow.Quantity = 1;
                await _repository.Add(shopBasketRow);
                return CreatedAtAction("GetShopBasketRow", new { id = shopBasketRow.Id }, shopBasketRow);
            }
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
