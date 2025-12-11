using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(u => u.Role)
                .Include(u => u.Customer)
                .Include(u => u.Employee)
                .Where(u => !u.IsDeleted)
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet
                .Include(u => u.Role)
                .Include(u => u.Customer)
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.Username == username && !u.IsDeleted);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .Include(u => u.Role)
                .Include(u => u.Customer)
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<User?> GetUserWithRoleAsync(int userId)
        {
            return await _dbSet
                .Include(u => u.Role)
                .Include(u => u.Customer)
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);
        }
    }
}
