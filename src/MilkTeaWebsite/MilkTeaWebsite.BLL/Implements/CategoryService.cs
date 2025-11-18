using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.Categories.FindAsync(c => !c.IsDeleted);
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetByIdAsync(categoryId);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            category.CreatedAt = DateTime.UtcNow;
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            category.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
