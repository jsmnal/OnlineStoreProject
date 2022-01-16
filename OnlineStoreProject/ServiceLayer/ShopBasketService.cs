using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer
{
    public class ShopBasketService: IShopBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopBasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShopBasket> Add(ShopBasket shopBasket)
        {
            await _unitOfWork.ShopBaskets.Add(shopBasket);
            await _unitOfWork.Save();
            return shopBasket;
        }

        public async Task<ShopBasket> Delete(int id)
        {
            var shopBasket = await _unitOfWork.ShopBaskets.Get(id);
            if (shopBasket == null)
            {
                return shopBasket;
            }

            await _unitOfWork.ShopBaskets.Delete(id);
            await _unitOfWork.Save();
            return shopBasket;
        }

        public async Task<ShopBasket> Get(int id)
        {
            var shopBasket = await _unitOfWork.ShopBaskets.Get(id);
            return shopBasket;

        }

        public async Task<ShopBasket> Update(ShopBasket shopBasket)
        {
            await _unitOfWork.ShopBaskets.Update(shopBasket);
            await _unitOfWork.Save();
            return shopBasket;
        }

        public async Task<IEnumerable<ShopBasket>> GetAll()
        {
            return await _unitOfWork.ShopBaskets.GetAll();
        }

        public async Task<ShopBasket> UpdateShopBasket(int id, ShopBasket shopBasket)
        {
            await _unitOfWork.ShopBaskets.UpdateShopBasket(id, shopBasket);
            await _unitOfWork.Save();
            return shopBasket;
        }
    }
}
