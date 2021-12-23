using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL.Interfaces
{
    public interface IShopBasketRowRepository : IRepository<ShopBasketRow>
    {
        bool ProductExists(int productId, int shopBasketId);
        int GetSBRowId(int productId, int shopBasketId);
        Task<IEnumerable<ShopBasketRow>> GetWithShopBasketId(int shopBasketId);

    }
}
