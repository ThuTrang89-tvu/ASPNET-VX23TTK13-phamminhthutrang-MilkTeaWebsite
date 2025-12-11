using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MilkTeaWebsite.Pages.Staff.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IUserService userService, ILogger<EditModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public IEnumerable<SelectListItem> RoleOptions { get; private set; } = new List<SelectListItem>();

        public class InputModel
        {
            [HiddenInput]
            public int Id { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
            [StringLength(100, ErrorMessage = "Tên đăng nhập tối đa 100 ký tự")]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "Vui lòng nhập email")]
            [EmailAddress(ErrorMessage = "Email không hợp lệ")]
            public string Email { get; set; } = string.Empty;

            [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
            [Display(Name = "Số điện thoại")]
            public string? PhoneNumber { get; set; }

            [Required(ErrorMessage = "Vui lòng chọn vai trò")]
            [Display(Name = "Vai trò")]
            public int RoleId { get; set; }

            [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu mới phải có ít nhất 6 ký tự")]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu mới")]
            public string? NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu mới")]
            [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
            public string? ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy người dùng.";
                return RedirectToPage("/Staff/Users/Index");
            }

            Input = new InputModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId
            };

            await LoadRoleOptionsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            await LoadRoleOptionsAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = new User
                {
                    Id = Input.Id,
                    Username = Input.Username.Trim(),
                    Email = Input.Email.Trim(),
                    PhoneNumber = Input.PhoneNumber?.Trim() ?? string.Empty,
                    RoleId = Input.RoleId
                };

                var password = string.IsNullOrWhiteSpace(Input.NewPassword) ? null : Input.NewPassword;
                await _userService.UpdateUserAsync(user, password);
                TempData["SuccessMessage"] = "Cập nhật người dùng thành công!";
                return RedirectToPage("/Staff/Users/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user {UserId}", Input.Id);
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }

        private async Task LoadRoleOptionsAsync()
        {
            var roles = await _userService.GetAllRolesAsync();
            RoleOptions = roles
                .Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.RoleName
                })
                .ToList();
        }
    }
}
