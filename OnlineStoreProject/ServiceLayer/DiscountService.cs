using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer
{
    public class DiscountService: IDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Discount> Add(Discount discount)
        {
            await _unitOfWork.Discounts.Add(discount);
            await _unitOfWork.Save();
            return discount;
        }

        public async Task<Discount> Delete(int id)
        {
            var discount = await _unitOfWork.Discounts.Get(id);
            if (discount == null)
            {
                return discount;
            }

            await _unitOfWork.Discounts.Delete(id);
            await _unitOfWork.Save();
            return discount;
        }

        public async Task<Discount> Get(int id)
        {
            var discount = await _unitOfWork.Discounts.Get(id);
            return discount;

        }

        public async Task<Discount> Update(Discount discount)
        {
            await _unitOfWork.Discounts.Update(discount);
            await _unitOfWork.Save();
            return discount;
        }

        public async Task<IEnumerable<Discount>> GetAll()
        {
            return await _unitOfWork.Discounts.GetAll();
        }

        public async Task<Discount> UpdateDiscount(int id, Discount discount)
        {
            await _unitOfWork.Discounts.UpdateDiscount(id, discount);
            await _unitOfWork.Save();
            return discount;
        }
    }
}
