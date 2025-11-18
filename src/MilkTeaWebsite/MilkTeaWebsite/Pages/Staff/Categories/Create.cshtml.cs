using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Categories
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ICategoryService categoryService, ILogger<CreateModel> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
            [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
            public string CategoryName { get; set; } = string.Empty;

            [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
            public string? Description { get; set; }

            public string? ImageUrl { get; set; }

            [Range(0, int.MaxValue, ErrorMessage = "Thứ tự hiển thị phải là số dương")]
            public int DisplayOrder { get; set; } = 0;
        }

        public IActionResult OnGet()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

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
                var category = new Category
                {
                    CategoryName = Input.CategoryName,
                    Description = Input.Description,
                    ImageUrl = Input.ImageUrl,
                    DisplayOrder = Input.DisplayOrder
                };

                await _categoryService.CreateCategoryAsync(category);

                TempData["SuccessMessage"] = "Thêm danh mục thành công!";
                return RedirectToPage("/Staff/Categories/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category");
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi thêm danh mục");
                return Page();
            }
        }
    }
}
