using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer.Interfaces
{
    public interface IShopBasketService
    {
        Task<ShopBasket> UpdateShopBasket(int id, ShopBasket shopBasket);
        Task<IEnumerable<ShopBasket>> GetAll();
        Task<ShopBasket> Get(int id);
        Task<ShopBasket> Delete(int id);
        Task<ShopBasket> Add(ShopBasket shopBasket);
        Task<ShopBasket> Update(ShopBasket shopBasket);
    }
}
