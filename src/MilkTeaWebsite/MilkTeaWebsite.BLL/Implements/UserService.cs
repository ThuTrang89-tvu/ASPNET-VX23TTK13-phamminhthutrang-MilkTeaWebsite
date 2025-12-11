using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Implements
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllWithDetailsAsync();
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _unitOfWork.Users.GetUserWithRoleAsync(userId);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.Roles.FindAsync(r => !r.IsDeleted);
            return roles.OrderBy(r => r.RoleName);
        }

        public async Task<User> CreateUserAsync(User user, string password)
        {
            await EnsureUsernameUniqueAsync(user.Username);
            await EnsureEmailUniqueAsync(user.Email);

            user.PasswordHash = HashPassword(password);
            user.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var createdUser = await _unitOfWork.Users.GetUserWithRoleAsync(user.Id);
            return createdUser ?? user;
        }

        public async Task<User> UpdateUserAsync(User user, string? newPassword = null)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(user.Id)
                ?? throw new Exception("User not found");

            if (!string.Equals(existingUser.Username, user.Username, StringComparison.OrdinalIgnoreCase))
            {
                await EnsureUsernameUniqueAsync(user.Username);
            }

            if (!string.Equals(existingUser.Email ?? string.Empty, user.Email ?? string.Empty, StringComparison.OrdinalIgnoreCase))
            {
                await EnsureEmailUniqueAsync(user.Email);
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.RoleId = user.RoleId;
            existingUser.UpdatedAt = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                existingUser.PasswordHash = HashPassword(newPassword);
            }

            _unitOfWork.Users.Update(existingUser);
            await _unitOfWork.SaveChangesAsync();

            var updatedUser = await _unitOfWork.Users.GetUserWithRoleAsync(existingUser.Id);
            return updatedUser ?? existingUser;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.IsDeleted = true;
            user.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private async Task EnsureUsernameUniqueAsync(string username)
        {
            if (await _unitOfWork.Users.GetByUsernameAsync(username) != null)
            {
                throw new Exception("Tên đăng nhập đã tồn tại");
            }
        }

        private async Task EnsureEmailUniqueAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }

            if (await _unitOfWork.Users.GetByEmailAsync(email) != null)
            {
                throw new Exception("Email đã tồn tại");
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
