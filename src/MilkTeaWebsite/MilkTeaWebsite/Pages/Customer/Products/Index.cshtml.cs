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
        public string? SearchKeyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<string>? SelectedSizes { get; set; }
        public string? SortBy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? categoryId, string? searchKeyword, 
            decimal? minPrice, decimal? maxPrice, List<string>? sizes, string? sortBy)
        {
            try
            {
                SelectedCategoryId = categoryId;
                SearchKeyword = searchKeyword;
                MinPrice = minPrice;
                MaxPrice = maxPrice;
                SelectedSizes = sizes;
                SortBy = sortBy;

                // Get all available products
                IEnumerable<Product> products;
                if (categoryId.HasValue)
                {
                    products = await _productService.GetProductsByCategoryAsync(categoryId.Value);
                }
                else
                {
                    products = await _productService.GetAvailableProductsAsync();
                }

                // Apply search filter
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    products = products.Where(p => 
                        p.ProductName.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase) ||
                        (p.Description != null && p.Description.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                    );
                }

                // Apply price filter
                if (minPrice.HasValue)
                {
                    products = products.Where(p => p.Price >= minPrice.Value);
                }
                if (maxPrice.HasValue)
                {
                    products = products.Where(p => p.Price <= maxPrice.Value);
                }

                // Apply size filter
                if (sizes != null && sizes.Any())
                {
                    products = products.Where(p => 
                        !string.IsNullOrEmpty(p.Size) && 
                        sizes.Any(s => p.Size.Contains(s, StringComparison.OrdinalIgnoreCase))
                    );
                }

                // Apply sorting
                products = sortBy switch
                {
                    "newest" => products.OrderByDescending(p => p.CreatedAt),
                    "price-asc" => products.OrderBy(p => p.Price),
                    "price-desc" => products.OrderByDescending(p => p.Price),
                    "name-asc" => products.OrderBy(p => p.ProductName),
                    "name-desc" => products.OrderByDescending(p => p.ProductName),
                    _ => products.OrderBy(p => p.Id)
                };

                Products = products.ToList();

                // Get all categories for filter
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
