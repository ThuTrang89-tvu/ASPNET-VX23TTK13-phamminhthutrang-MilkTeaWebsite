using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Products
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

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                Products = await _productService.GetAllProductsAsync();
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading products");
                TempData["Error"] = "Có lỗi xảy ra khi tải sản phẩm";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int productId)
        {
            try
            {
                await _productService.DeleteProductAsync(productId);
                TempData["Success"] = "Đã xóa sản phẩm thành công";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product");
                TempData["Error"] = "Có lỗi xảy ra khi xóa sản phẩm";
            }

            return RedirectToPage();
        }
    }
}
