using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer
{
    public class ProductService: IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Add(Product product)
        {
            await _unitOfWork.Products.Add(product);
            await _unitOfWork.Save();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var product = await _unitOfWork.Products.Get(id);
            if (product == null)
            {
                return product;
            }

            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save();
            return product;
        }

        public async Task<Product> Get(int id)
        {
            var product = await _unitOfWork.Products.Get(id);
            return product;

        }

        public async Task<Product> Update(Product product)
        {
            await _unitOfWork.Products.Update(product);
            await _unitOfWork.Save();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAll();
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            await _unitOfWork.Products.UpdateProduct(id, product);
            await _unitOfWork.Save();
            return product;
        }

        public async Task<IEnumerable<Product>> GetNewest(int limit)
        {
            return await _unitOfWork.Products.GetNewest(limit);
        }

        public async Task<IEnumerable<Product>> GetPopular(int limit)
        {
            return await _unitOfWork.Products.GetPopular(limit);
        }

        public async Task<IEnumerable<Product>> GetWithCategory(string name)
        {
            return await _unitOfWork.Products.GetWithCategory(name);
        }
    }
}
