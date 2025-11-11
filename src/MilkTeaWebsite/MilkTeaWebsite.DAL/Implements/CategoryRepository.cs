using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            return await _dbSet
                .Include(c => c.Products)
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.DisplayOrder)
                .ToListAsync();
        }
    }
}
