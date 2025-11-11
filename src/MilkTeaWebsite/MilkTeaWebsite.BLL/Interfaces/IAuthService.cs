using MilkTeaWebsite.Entity.Entity;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string username, string password);
        Task<User?> RegisterCustomerAsync(string username, string email, string password, string fullName, string phoneNumber);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
