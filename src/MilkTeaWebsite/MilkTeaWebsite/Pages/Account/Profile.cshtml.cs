using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProfileModel> _logger;

        public ProfileModel(ApplicationDbContext context, ILogger<ProfileModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public class InputModel
        {
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "Email là bắt buộc")]
            [EmailAddress(ErrorMessage = "Email không hợp lệ")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Họ và tên là bắt buộc")]
            public string FullName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
            [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
            public string Address { get; set; } = string.Empty;

            public string? Ward { get; set; }
            public string? District { get; set; }
            public string? City { get; set; }

            // Password change fields
            public string? CurrentPassword { get; set; }

            [MinLength(6, ErrorMessage = "Mật khẩu mới phải có ít nhất 6 ký tự")]
            public string? NewPassword { get; set; }

            [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
            public string? ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var user = await _context.Users
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            Input = new InputModel
            {
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FullName = user.Customer?.FullName ?? string.Empty,
                Address = user.Customer?.Address ?? string.Empty,
                Ward = user.Customer?.Ward,
                District = user.Customer?.District,
                City = user.Customer?.City
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var user = await _context.Users
                    .Include(u => u.Customer)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    ErrorMessage = "Không tìm thấy người dùng";
                    return Page();
                }

                // Update User info
                user.Email = Input.Email;
                user.PhoneNumber = Input.PhoneNumber;
                user.UpdatedAt = DateTime.UtcNow;

                // Update Customer info
                if (user.Customer != null)
                {
                    user.Customer.FullName = Input.FullName;
                    user.Customer.Address = Input.Address;
                    user.Customer.Ward = Input.Ward;
                    user.Customer.District = Input.District;
                    user.Customer.City = Input.City;
                    user.Customer.UpdatedAt = DateTime.UtcNow;
                }

                // Handle password change
                if (!string.IsNullOrEmpty(Input.CurrentPassword))
                {
                    if (string.IsNullOrEmpty(Input.NewPassword))
                    {
                        ModelState.AddModelError("Input.NewPassword", "Vui lòng nhập mật khẩu mới");
                        return Page();
                    }

                    // Verify current password
                    if (!BCrypt.Net.BCrypt.Verify(Input.CurrentPassword, user.PasswordHash))
                    {
                        ModelState.AddModelError("Input.CurrentPassword", "Mật khẩu hiện tại không đúng");
                        return Page();
                    }

                    // Update password
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Input.NewPassword);
                }

                await _context.SaveChangesAsync();

                SuccessMessage = "Cập nhật thông tin thành công!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating profile");
                ErrorMessage = "Có lỗi xảy ra khi cập nhật thông tin";
                return Page();
            }
        }
    }
}
