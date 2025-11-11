using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _dbSet
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .Where(od => od.OrderId == orderId && !od.IsDeleted)
                .ToListAsync();
        }
    }
}
