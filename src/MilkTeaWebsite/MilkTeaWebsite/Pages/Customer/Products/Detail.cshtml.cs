using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MilkTeaWebsite.Pages.Customer.Products
{
    public class DetailModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ILogger<DetailModel> _logger;

        public DetailModel(
            IProductService productService, 
            ICartService cartService,
            ILogger<DetailModel> logger)
        {
            _productService = productService;
            _cartService = cartService;
            _logger = logger;
        }

        public Product? Product { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int Quantity { get; set; } = 1;

        [BindProperty]
        public List<string> SelectedToppings { get; set; } = new();

        [BindProperty]
        public string? CustomTopping { get; set; }

        [BindProperty]
        public string? Note { get; set; }

        public IList<string> AvailableToppings { get; private set; } = new List<string>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Product = await _productService.GetProductByIdAsync(id);
                
                if (Product == null)
                {
                    return NotFound();
                }

                AvailableToppings = ParseToppingIds(Product.AvailableToppingIds);

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading product detail");
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login", new { returnUrl = $"/Customer/Products/Detail?id={ProductId}" });
            }

            try
            {
                // Get customer ID from claims
                var customerIdClaim = User.FindFirst("CustomerId")?.Value;
                if (string.IsNullOrEmpty(customerIdClaim))
                {
                    TempData["Error"] = "Không tìm thấy thông tin khách hàng";
                    return RedirectToPage("/Account/Login");
                }

                int customerId = int.Parse(customerIdClaim);

                Product = await _productService.GetProductByIdAsync(ProductId);

                if (Product == null)
                {
                    TempData["Error"] = "Không tìm thấy sản phẩm";
                    return RedirectToPage("/Customer/Products/Index");
                }

                if (!Product.IsAvailable || Product.StockQuantity <= 0)
                {
                    TempData["Error"] = "Sản phẩm hiện đang hết hàng";
                    return RedirectToPage(new { id = ProductId });
                }

                if (Quantity <= 0)
                {
                    Quantity = 1;
                }

                AvailableToppings = ParseToppingIds(Product.AvailableToppingIds);

                var selected = SelectedToppings
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .Select(t => t.Trim())
                    .ToList();

                if (!string.IsNullOrWhiteSpace(CustomTopping))
                {
                    selected.Add(CustomTopping.Trim());
                }

                var toppingPayload = selected
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                var toppingValue = toppingPayload.Any() ? string.Join(", ", toppingPayload) : null;

                await _cartService.AddToCartAsync(customerId, ProductId, Quantity, null, toppingValue, Note);
                
                TempData["Success"] = "Đã thêm sản phẩm vào giỏ hàng!";
                return RedirectToPage("/Customer/Cart/Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product to cart");
                TempData["Error"] = "Có lỗi xảy ra khi thêm vào giỏ hàng";
                return RedirectToPage(new { id = ProductId });
            }
        }

        private static List<string> ParseToppingIds(string? toppingIds)
        {
            if (string.IsNullOrWhiteSpace(toppingIds))
            {
                return new List<string>();
            }

            return toppingIds
                .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(id => id.Trim())
                .Where(id => !string.IsNullOrWhiteSpace(id))
                .Distinct()
                .OrderBy(id => id)
                .ToList();
        }
    }
}
