using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(int orderId, string paymentMethod, decimal amount);
        Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
        Task UpdatePaymentStatusAsync(int paymentId, string status, string? transactionId = null);
    }
}
