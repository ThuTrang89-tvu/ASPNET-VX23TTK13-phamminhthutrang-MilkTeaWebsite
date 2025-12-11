using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int userId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<User> CreateUserAsync(User user, string password);
        Task<User> UpdateUserAsync(User user, string? newPassword = null);
        Task<bool> DeleteUserAsync(int userId);
    }
}
