using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer.Interfaces
{
    public interface IShopBasketRowService
    {
        bool ProductExists(int productId, int shopBasketId);
        int GetSBRowId(int productId, int shopBasketId);
        Task<IEnumerable<ShopBasketRow>> GetWithShopBasketId(int shopBasketId);
        Task<ShopBasketRow> UpdateShopBasketRow(int id, ShopBasketRow shopBasketRow);
        decimal GetShopBasketTotal(int id);
        Task<IEnumerable<ShopBasketRow>> GetAll();
        Task<ShopBasketRow> Get(int id);
        Task<ShopBasketRow> Delete(int id);
        Task<ShopBasketRow> Add(ShopBasketRow shopBasketRow);
        Task<ShopBasket> AddShopBasket(ShopBasket shopBasket);
        Task<ShopBasketRow> Update(ShopBasketRow shopBasketRow);
    }
}
