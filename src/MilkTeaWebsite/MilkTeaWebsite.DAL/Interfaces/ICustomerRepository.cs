using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer?> GetByUserIdAsync(int userId);
        Task<Customer?> GetCustomerWithOrdersAsync(int customerId);
    }
}
