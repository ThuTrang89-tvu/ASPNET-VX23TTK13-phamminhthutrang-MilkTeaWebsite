using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ICategoryService categoryService, ILogger<IndexModel> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        [TempData]
        public string? SuccessMessage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                Categories = await _categoryService.GetAllCategoriesAsync();
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading categories");
                TempData["Error"] = "Có lỗi xảy ra khi tải danh mục";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int categoryId)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(categoryId);
                SuccessMessage = "Xóa danh mục thành công!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting category");
                TempData["Error"] = "Có lỗi xảy ra khi xóa danh mục";
                return RedirectToPage();
            }
        }
    }
}
