using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Products
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IProductService productService, ICategoryService categoryService, ILogger<EditModel> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public Product? Product { get; set; }
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            ProductId = id;
            Product = await _productService.GetProductByIdAsync(id);
            Categories = await _categoryService.GetAllCategoriesAsync();

            if (Product == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                ProductName = Product.ProductName,
                Description = Product.Description,
                PriceS = Product.PriceS,
                PriceM = Product.PriceM,
                PriceL = Product.PriceL,
                CategoryId = Product.CategoryId,
                ImageUrl = Product.ImageUrl,
                StockQuantity = Product.StockQuantity,
                IsAvailable = Product.IsAvailable
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Product = await _productService.GetProductByIdAsync(ProductId);
                Categories = await _categoryService.GetAllCategoriesAsync();
                return Page();
            }

            try
            {
                var product = await _productService.GetProductByIdAsync(ProductId);
                
                if (product == null)
                {
                    return NotFound();
                }

                product.ProductName = Input.ProductName;
                product.Description = Input.Description;
                product.PriceS = Input.PriceS;
                product.PriceM = Input.PriceM;
                product.PriceL = Input.PriceL;
                product.CategoryId = Input.CategoryId;
                product.ImageUrl = Input.ImageUrl;
                product.StockQuantity = Input.StockQuantity;
                product.IsAvailable = Input.IsAvailable;

                await _productService.UpdateProductAsync(product);

                TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công!";
                return RedirectToPage("/Staff/Products/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật sản phẩm");
                Product = await _productService.GetProductByIdAsync(ProductId);
                Categories = await _categoryService.GetAllCategoriesAsync();
                return Page();
            }
        }
    }
}
