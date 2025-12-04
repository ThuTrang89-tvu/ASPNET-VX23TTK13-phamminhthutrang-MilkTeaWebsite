using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.DAL.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DetailModel> _logger;

        public DetailModel(
            IProductService productService, 
            ICartService cartService,
            IUnitOfWork unitOfWork,
            ILogger<DetailModel> logger)
        {
            _productService = productService;
            _cartService = cartService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public Product? Product { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int Quantity { get; set; } = 1;

        [BindProperty]
        public string Size { get; set; } = "M";

        [BindProperty]
        public List<string> SelectedToppings { get; set; } = new();

        [BindProperty]
        public string? CustomTopping { get; set; }

        [BindProperty]
        public string? Note { get; set; }

        public IList<Topping> AvailableToppings { get; private set; } = new List<Topping>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Product = await _productService.GetProductByIdAsync(id);
                
                if (Product == null)
                {
                    return NotFound();
                }

                // Load available toppings from the ProductToppings navigation property
                await LoadAvailableToppingsAsync();

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

                await LoadAvailableToppingsAsync();

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

        private async Task LoadAvailableToppingsAsync()
        {
            if (Product == null || Product.ProductToppings == null || !Product.ProductToppings.Any())
            {
                AvailableToppings = new List<Topping>();
                return;
            }

            // Get toppings from the ProductToppings navigation property
            AvailableToppings = Product.ProductToppings
                .Where(pt => pt.Topping != null && pt.Topping.IsAvailable)
                .Select(pt => pt.Topping)
                .OrderBy(t => t.ToppingName)
                .ToList();
        }
    }
}

