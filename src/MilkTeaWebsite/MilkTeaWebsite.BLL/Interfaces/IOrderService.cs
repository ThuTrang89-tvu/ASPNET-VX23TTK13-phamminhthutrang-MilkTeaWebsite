using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int customerId, int cartId, string shippingAddress, string? note);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<Order?> GetOrderByOrderNumberAsync(string orderNumber);
        Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status);
        Task UpdateOrderStatusAsync(int orderId, string status, int? employeeId = null);
        Task CancelOrderAsync(int orderId);
    }
}
