using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
        Task<Payment?> GetPaymentByTransactionIdAsync(string transactionId);
    }
}
