using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MilkTeaWebsite.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(IAuthService authService, ILogger<LoginModel> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; } = string.Empty;

        public string? ReturnUrl { get; set; }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _authService.LoginAsync(Username, Password);

                if (user == null)
                {
                    TempData["Error"] = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return Page();
                }

                // Create claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email ?? ""),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "Customer")
                };

                // Add Customer or Employee ID based on role
                if (user.Role?.RoleName == "Customer" && user.Customer != null)
                {
                    claims.Add(new Claim("CustomerId", user.Customer.Id.ToString()));
                    claims.Add(new Claim("FullName", user.Customer.FullName ?? ""));
                    claims.Add(new Claim("PhoneNumber", user.PhoneNumber ?? ""));
                }
                else if ((user.Role?.RoleName == "Admin" || user.Role?.RoleName == "Staff") && user.Employee != null)
                {
                    claims.Add(new Claim("EmployeeId", user.Employee.Id.ToString()));
                    claims.Add(new Claim("FullName", user.Employee.FullName ?? ""));
                    claims.Add(new Claim("PhoneNumber", user.PhoneNumber ?? ""));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                _logger.LogInformation("User {Username} logged in successfully", Username);

                // Redirect based on role
                if (user.Role?.RoleName == "Admin" || user.Role?.RoleName == "Staff")
                {
                    return RedirectToPage("/Staff/Dashboard/Index");
                }
                else
                {
                    return RedirectToPage(returnUrl ?? "/Customer/Products/Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                TempData["Error"] = "Có lỗi xảy ra trong quá trình đăng nhập";
                return Page();
            }
        }
    }
}
