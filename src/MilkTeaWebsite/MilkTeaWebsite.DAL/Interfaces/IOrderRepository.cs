using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderByOrderNumberAsync(string orderNumber);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<Order?> GetOrderWithDetailsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
    }
}
