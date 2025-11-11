using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Payment?> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _dbSet
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.OrderId == orderId && !p.IsDeleted);
        }

        public async Task<Payment?> GetPaymentByTransactionIdAsync(string transactionId)
        {
            return await _dbSet
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.TransactionId == transactionId && !p.IsDeleted);
        }
    }
}
