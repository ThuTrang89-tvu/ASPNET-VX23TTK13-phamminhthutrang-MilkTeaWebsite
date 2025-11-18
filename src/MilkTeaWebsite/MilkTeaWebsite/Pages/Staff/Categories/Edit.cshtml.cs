using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Categories
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(ICategoryService categoryService, ILogger<EditModel> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [BindProperty]
        public int CategoryId { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public Category? Category { get; set; }

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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            CategoryId = id;
            Category = await _categoryService.GetCategoryByIdAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                CategoryName = Category.CategoryName,
                Description = Category.Description,
                ImageUrl = Category.ImageUrl,
                DisplayOrder = Category.DisplayOrder
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Category = await _categoryService.GetCategoryByIdAsync(CategoryId);
                return Page();
            }

            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(CategoryId);
                
                if (category == null)
                {
                    return NotFound();
                }

                category.CategoryName = Input.CategoryName;
                category.Description = Input.Description;
                category.ImageUrl = Input.ImageUrl;
                category.DisplayOrder = Input.DisplayOrder;

                await _categoryService.UpdateCategoryAsync(category);

                TempData["SuccessMessage"] = "Cập nhật danh mục thành công!";
                return RedirectToPage("/Staff/Categories/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category");
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật danh mục");
                Category = await _categoryService.GetCategoryByIdAsync(CategoryId);
                return Page();
            }
        }
    }
}
