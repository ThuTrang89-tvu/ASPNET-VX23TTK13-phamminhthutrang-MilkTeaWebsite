using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Order?> GetOrderByOrderNumberAsync(string orderNumber)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderNumber == orderNumber && !o.IsDeleted);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _dbSet
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Payment)
                .Where(o => o.CustomerId == customerId && !o.IsDeleted)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
        {
            return await _dbSet
                .Include(o => o.Customer)
                    .ThenInclude(c => c.User)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Category)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == orderId && !o.IsDeleted);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .Where(o => o.OrderStatus == status && !o.IsDeleted)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
    }
}
