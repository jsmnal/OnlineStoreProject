using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using OnlineStoreProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> Add(Category category)
        {
            await _unitOfWork.Categorys.Add(category);
            await _unitOfWork.Save();
            return category;
        }

        public async Task<Category> Delete(int id)
        {
            var category = await _unitOfWork.Categorys.Get(id);
            if (category == null)
            {
                return category;
            }

            await _unitOfWork.Categorys.Delete(id);
            await _unitOfWork.Save();
            return category;
        }

        public async Task<Category> Get(int id)
        {
            var category = await _unitOfWork.Categorys.Get(id);
            return category;

        }

        public async Task<Category> Update(Category category)
        {
            await _unitOfWork.Categorys.Update(category);
            await _unitOfWork.Save();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categorys.GetAll();
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            await _unitOfWork.Categorys.UpdateCategory(id, category);
            await _unitOfWork.Save();
            return category;
        }

        public async Task<IEnumerable<Category>> GetWithName(string name)
        {
            return await _unitOfWork.Categorys.GetWithName(name);
        }
    }
}
