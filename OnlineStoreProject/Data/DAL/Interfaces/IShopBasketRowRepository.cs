using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL.Interfaces
{
    public interface IShopBasketRowRepository : IRepository<ShopBasketRow>
    {
        bool ProductExists(int product, int id);
        int ExistingRowId(int product, int id);
    }
}
