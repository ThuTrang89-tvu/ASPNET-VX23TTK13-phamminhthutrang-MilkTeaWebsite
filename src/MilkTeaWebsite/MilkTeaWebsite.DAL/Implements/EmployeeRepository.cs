using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Employee?> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.UserId == userId && !e.IsDeleted);
        }
    }
}
