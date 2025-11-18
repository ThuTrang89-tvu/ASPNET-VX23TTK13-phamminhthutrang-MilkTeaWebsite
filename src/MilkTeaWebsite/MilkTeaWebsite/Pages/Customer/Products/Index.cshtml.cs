using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Customer.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IProductService productService, ICategoryService categoryService, ILogger<IndexModel> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<string> AvailableToppings { get; set; } = new List<string>();
        public IList<int> SelectedCategoryIds { get; set; } = new List<int>();
        public IList<string> SelectedToppings { get; set; } = new List<string>();
        public string? SearchKeyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SortBy { get; set; }

        public async Task<IActionResult> OnGetAsync(
            [FromQuery(Name = "categories")] List<int>? categoryIds,
            int? categoryId,
            string? searchKeyword,
            decimal? minPrice,
            decimal? maxPrice,
            [FromQuery(Name = "toppings")] List<string>? toppings,
            string? sortBy)
        {
            try
            {
                var selectedCategoryIds = categoryIds ?? new List<int>();
                if (categoryId.HasValue && !selectedCategoryIds.Contains(categoryId.Value))
                {
                    selectedCategoryIds.Add(categoryId.Value);
                }

                SelectedCategoryIds = selectedCategoryIds
                    .Distinct()
                    .ToList();

                SearchKeyword = searchKeyword;
                MinPrice = minPrice;
                MaxPrice = maxPrice;
                SortBy = sortBy;

                if (toppings != null && toppings.Any())
                {
                    SelectedToppings = toppings
                        .Where(t => !string.IsNullOrWhiteSpace(t))
                        .Select(t => t.Trim())
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList();
                }
                else
                {
                    SelectedToppings = new List<string>();
                }

                var allProducts = (await _productService.GetAvailableProductsAsync()).ToList();

                Categories = (await _categoryService.GetAllCategoriesAsync())
                    .OrderBy(c => c.DisplayOrder)
                    .ThenBy(c => c.CategoryName)
                    .ToList();

                // Get all available topping IDs from products
                var toppingIds = allProducts
                    .Where(p => !string.IsNullOrWhiteSpace(p.AvailableToppingIds))
                    .SelectMany(p => p.AvailableToppingIds!
                        .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                    .Select(id => id.Trim())
                    .Distinct()
                    .OrderBy(id => id)
                    .ToList();
                
                AvailableToppings = toppingIds;

                IEnumerable<Product> filteredProducts = allProducts;

                if (SelectedCategoryIds.Any())
                {
                    var categorySet = new HashSet<int>(SelectedCategoryIds);
                    filteredProducts = filteredProducts.Where(p => categorySet.Contains(p.CategoryId));
                }

                // Apply search filter
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    filteredProducts = filteredProducts.Where(p =>
                        p.ProductName.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase) ||
                        (p.Description != null && p.Description.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                    );
                }

                // Apply price filter (using Medium size price as default)
                if (minPrice.HasValue)
                {
                    filteredProducts = filteredProducts.Where(p => p.PriceM >= minPrice.Value);
                }
                if (maxPrice.HasValue)
                {
                    filteredProducts = filteredProducts.Where(p => p.PriceM <= maxPrice.Value);
                }

                if (SelectedToppings.Any())
                {
                    var toppingSet = new HashSet<string>(SelectedToppings, StringComparer.OrdinalIgnoreCase);
                    filteredProducts = filteredProducts.Where(p =>
                    {
                        if (string.IsNullOrWhiteSpace(p.AvailableToppingIds))
                        {
                            return false;
                        }

                        var productToppingIds = p.AvailableToppingIds
                            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                            .Select(id => id.Trim())
                            .Where(id => !string.IsNullOrWhiteSpace(id));

                        return productToppingIds.Any(id => toppingSet.Contains(id));
                    });
                }

                // Apply sorting (using Medium price for price sorting)
                filteredProducts = sortBy switch
                {
                    "newest" => filteredProducts.OrderByDescending(p => p.CreatedAt),
                    "price-asc" => filteredProducts.OrderBy(p => p.PriceM),
                    "price-desc" => filteredProducts.OrderByDescending(p => p.PriceM),
                    "name-asc" => filteredProducts.OrderBy(p => p.ProductName),
                    "name-desc" => filteredProducts.OrderByDescending(p => p.ProductName),
                    _ => filteredProducts.OrderBy(p => p.Id)
                };

                Products = filteredProducts.ToList();

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
