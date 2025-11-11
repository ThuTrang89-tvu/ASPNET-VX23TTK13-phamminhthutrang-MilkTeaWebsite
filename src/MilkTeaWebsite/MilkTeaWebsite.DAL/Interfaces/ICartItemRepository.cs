using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
    }
}
