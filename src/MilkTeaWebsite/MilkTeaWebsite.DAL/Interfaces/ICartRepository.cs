using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetActiveCartByCustomerIdAsync(int customerId);
        Task<Cart?> GetCartWithItemsAsync(int cartId);
    }
}
