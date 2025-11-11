using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(username);
            
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            user.LastLoginAt = DateTime.UtcNow;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<User?> RegisterCustomerAsync(string username, string email, string password, string fullName, string phoneNumber)
        {
            // Check if username or email already exists
            if (await _unitOfWork.Users.GetByUsernameAsync(username) != null)
                throw new Exception("Username already exists");

            if (await _unitOfWork.Users.GetByEmailAsync(email) != null)
                throw new Exception("Email already exists");

            // Get Customer role
            var customerRole = await _unitOfWork.Roles.FirstOrDefaultAsync(r => r.RoleName == "Customer");
            if (customerRole == null)
                throw new Exception("Customer role not found");

            // Create user
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                PhoneNumber = phoneNumber,
                RoleId = customerRole.Id,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // Create customer profile
            var customer = new Customer
            {
                UserId = user.Id,
                FullName = fullName,
                Address = "",
                LoyaltyPoints = 0,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return await _unitOfWork.Users.GetUserWithRoleAsync(user.Id);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null || !VerifyPassword(oldPassword, user.PasswordHash))
                return false;

            user.PasswordHash = HashPassword(newPassword);
            user.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return HashPassword(password) == passwordHash;
        }
    }
}
