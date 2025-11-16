using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MilkTeaWebsite.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IAuthService _authService;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(IAuthService authService, ILogger<RegisterModel> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3-50 ký tự")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-100 ký tự")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _authService.RegisterCustomerAsync(
                    Username,
                    Email,
                    Password,
                    FullName,
                    PhoneNumber
                );

                if (user == null)
                {
                    TempData["Error"] = "Tên đăng nhập hoặc email đã tồn tại";
                    return Page();
                }

                _logger.LogInformation("New user registered: {Username}", Username);
                TempData["Success"] = "Đăng ký thành công! Vui lòng đăng nhập.";
                return RedirectToPage("/Account/Login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration");
                TempData["Error"] = "Có lỗi xảy ra trong quá trình đăng ký. Vui lòng thử lại!";
                return Page();
            }
        }
    }
}
