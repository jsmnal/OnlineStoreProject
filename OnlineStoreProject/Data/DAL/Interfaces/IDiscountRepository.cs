using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL.Interfaces
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        Task<Discount> UpdateDiscount(int id, Discount discount);
    }
}
