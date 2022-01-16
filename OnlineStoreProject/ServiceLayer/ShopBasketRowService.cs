using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer
{
    public class ShopBasketRowService: IShopBasketRowService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopBasketRowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShopBasketRow> Add(ShopBasketRow shopBasketRow)
        {
            await _unitOfWork.ShopBasketRows.Add(shopBasketRow);
            await _unitOfWork.Save();
            return shopBasketRow;
        }

        public async Task<ShopBasket> AddShopBasket(ShopBasket shopBasket)
        {
            await _unitOfWork.ShopBaskets.Add(shopBasket);
            await _unitOfWork.Save();
            return shopBasket;
        }

        public async Task<ShopBasketRow> Delete(int id)
        {
            var shopBasketRow = await _unitOfWork.ShopBasketRows.Get(id);
            if (shopBasketRow == null)
            {
                return shopBasketRow;
            }

            await _unitOfWork.ShopBasketRows.Delete(id);
            await _unitOfWork.Save();
            return shopBasketRow;
        }

        public async Task<ShopBasketRow> Get(int id)
        {
            var shopBasketRow = await _unitOfWork.ShopBasketRows.Get(id);
            return shopBasketRow;

        }

        public async Task<ShopBasketRow> Update(ShopBasketRow shopBasketRow)
        {
            await _unitOfWork.ShopBasketRows.Update(shopBasketRow);
            await _unitOfWork.Save();
            return shopBasketRow;
        }

        public async Task<IEnumerable<ShopBasketRow>> GetAll()
        {
            return await _unitOfWork.ShopBasketRows.GetAll();
        }

        public async Task<ShopBasketRow> UpdateShopBasketRow(int id, ShopBasketRow shopBasketRow)
        {
            await _unitOfWork.ShopBasketRows.UpdateShopBasketRow(id, shopBasketRow);
            await _unitOfWork.Save();
            return shopBasketRow;
        }

        public bool ProductExists(int productId, int shopBasketId)
        {
            return _unitOfWork.ShopBasketRows.ProductExists(productId, shopBasketId);
        }

        public int GetSBRowId(int productId, int shopBasketId)
        {

            return _unitOfWork.ShopBasketRows.GetSBRowId(productId, shopBasketId);
        }

        public async Task<IEnumerable<ShopBasketRow>> GetWithShopBasketId(int shopBasketId)
        {
            return await _unitOfWork.ShopBasketRows.GetWithShopBasketId(shopBasketId);
        }

        public decimal GetShopBasketTotal(int shopBasketId)
        {
            return _unitOfWork.ShopBasketRows.GetShopBasketTotal(shopBasketId);
        }
    }
}
