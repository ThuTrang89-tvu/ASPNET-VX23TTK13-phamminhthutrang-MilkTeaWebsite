using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithDetailsAsync();
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetUserWithRoleAsync(int userId);
    }
}
