using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IShopBasketRepository ShopBaskets { get; }
        IShopBasketRowRepository ShopBasketRows { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categorys { get; }
        IDiscountRepository Discounts { get; }
        Task<int> Save();
    }
}
