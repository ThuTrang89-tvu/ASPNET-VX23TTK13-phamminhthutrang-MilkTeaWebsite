using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
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
        public string? Size { get; set; }

        [BindProperty]
        public string? Topping { get; set; }

        [BindProperty]
        public string? Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Product = await _productService.GetProductByIdAsync(id);
                
                if (Product == null)
                {
                    return NotFound();
                }

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

                await _cartService.AddToCartAsync(customerId, ProductId, Quantity, Size, Topping, Note);
                
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
    }
}
