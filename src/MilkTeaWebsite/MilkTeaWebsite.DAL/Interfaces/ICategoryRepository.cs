using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
    }
}
