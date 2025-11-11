using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Customer?> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted);
        }

        public async Task<Customer?> GetCustomerWithOrdersAsync(int customerId)
        {
            return await _dbSet
                .Include(c => c.User)
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.Id == customerId && !c.IsDeleted);
        }
    }
}
