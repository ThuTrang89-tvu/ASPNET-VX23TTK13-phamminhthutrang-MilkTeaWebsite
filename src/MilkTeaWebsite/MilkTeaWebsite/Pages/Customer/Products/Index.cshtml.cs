using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Customer.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IProductService productService, ILogger<IndexModel> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int? SelectedCategoryId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? categoryId)
        {
            try
            {
                SelectedCategoryId = categoryId;

                if (categoryId.HasValue)
                {
                    Products = await _productService.GetProductsByCategoryAsync(categoryId.Value);
                }
                else
                {
                    Products = await _productService.GetAvailableProductsAsync();
                }

                // Get all categories for filter (you'll need to add this to IProductService)
                // For now, we'll extract unique categories from products
                Categories = Products.Select(p => p.Category).Distinct().ToList();

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading products");
                TempData["Error"] = "Có lỗi xảy ra khi tải sản phẩm";
                return Page();
            }
        }
    }
}
