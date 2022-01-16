using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer.Interfaces
{
    public interface IDiscountService
    {
        Task<Discount> Get(int id);
        Task<Discount> Delete(int id);
        Task<Discount> Add(Discount discount);
        Task<Discount> Update(Discount discount);
        Task<IEnumerable<Discount>> GetAll();
        Task<Discount> UpdateDiscount(int id, Discount discount);
    }
}
