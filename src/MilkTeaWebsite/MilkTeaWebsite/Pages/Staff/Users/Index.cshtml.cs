using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IUserService userService, ILogger<IndexModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public IEnumerable<User> Users { get; private set; } = new List<User>();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                Users = await _userService.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading users");
                ErrorMessage = "Không thể tải danh sách người dùng";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int userId)
        {
            var currentUserId = int.TryParse(User.FindFirst("UserId")?.Value, out var parsedId)
                ? parsedId
                : (int?)null;

            if (currentUserId.HasValue && currentUserId.Value == userId)
            {
                ErrorMessage = "Bạn không thể xóa tài khoản của chính mình.";
                return RedirectToPage();
            }

            try
            {
                var deleted = await _userService.DeleteUserAsync(userId);
                if (deleted)
                {
                    SuccessMessage = "Xóa người dùng thành công!";
                }
                else
                {
                    ErrorMessage = "Không tìm thấy người dùng để xóa.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", userId);
                ErrorMessage = "Có lỗi xảy ra khi xóa người dùng.";
            }

            return RedirectToPage();
        }
    }
}
