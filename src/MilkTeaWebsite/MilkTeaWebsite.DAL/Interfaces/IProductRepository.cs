using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetAvailableProductsAsync();
        Task<Product?> GetProductWithCategoryAsync(int productId);
    }
}
