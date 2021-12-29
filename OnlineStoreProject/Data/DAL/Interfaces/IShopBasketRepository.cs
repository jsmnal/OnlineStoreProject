using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL.Interfaces
{
    public interface IShopBasketRepository : IRepository<ShopBasket>
    {
        Task<ShopBasket> UpdateShopBasket(int id, ShopBasket shopBasket);
    }
}
