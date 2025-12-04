using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Products
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(IProductService productService, ICategoryService categoryService, ILogger<CreateModel> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public class InputModel
        {
            [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
            [StringLength(200, ErrorMessage = "Tên sản phẩm không được vượt quá 200 ký tự")]
            public string ProductName { get; set; } = string.Empty;

            [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự")]
            public string? Description { get; set; }

            [Required(ErrorMessage = "Giá size S là bắt buộc")]
            [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
            public decimal PriceS { get; set; }

            [Required(ErrorMessage = "Giá size M là bắt buộc")]
            [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
            public decimal PriceM { get; set; }

            [Required(ErrorMessage = "Giá size L là bắt buộc")]
            [Range(0, double.MaxValue, ErrorMessage = "Giá phải là số dương")]
            public decimal PriceL { get; set; }

            [Required(ErrorMessage = "Danh mục là bắt buộc")]
            public int CategoryId { get; set; }

            public string? ImageUrl { get; set; }

            [Required(ErrorMessage = "Số lượng tồn kho là bắt buộc")]
            [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải là số dương")]
            public int StockQuantity { get; set; } = 0;

            public bool IsAvailable { get; set; } = true;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            Categories = await _categoryService.GetAllCategoriesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = await _categoryService.GetAllCategoriesAsync();
                return Page();
            }

            try
            {
                var product = new Product
                {
                    ProductName = Input.ProductName,
                    Description = Input.Description,
                    PriceS = Input.PriceS,
                    PriceM = Input.PriceM,
                    PriceL = Input.PriceL,
                    CategoryId = Input.CategoryId,
                    ImageUrl = Input.ImageUrl,
                    StockQuantity = Input.StockQuantity,
                    IsAvailable = Input.IsAvailable
                };

                await _productService.CreateProductAsync(product);

                TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
                return RedirectToPage("/Staff/Products/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi thêm sản phẩm");
                Categories = await _categoryService.GetAllCategoriesAsync();
                return Page();
            }
        }
    }
}
