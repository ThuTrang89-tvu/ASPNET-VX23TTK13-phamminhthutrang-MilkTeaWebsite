using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System.ComponentModel.DataAnnotations;

namespace MilkTeaWebsite.Pages.Customer.Orders
{
    public class CheckoutModel : PageModel
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly ILogger<CheckoutModel> _logger;

        public CheckoutModel(
            ICartService cartService,
            IOrderService orderService,
            ILogger<CheckoutModel> logger)
        {
            _cartService = cartService;
            _orderService = orderService;
            _logger = logger;
        }

        public Entity.Entity.Cart? Cart { get; set; }
        public decimal TotalAmount { get; set; }

        [BindProperty]
        public string CustomerName { get; set; } = string.Empty;

        [BindProperty]
        public string PhoneNumber { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ giao hàng")]
        public string ShippingAddress { get; set; } = string.Empty;

        [BindProperty]
        public string? Note { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                var customerIdClaim = User.FindFirst("CustomerId")?.Value;
                if (string.IsNullOrEmpty(customerIdClaim))
                {
                    return RedirectToPage("/Account/Login");
                }

                int customerId = int.Parse(customerIdClaim);
                Cart = await _cartService.GetActiveCartAsync(customerId);

                if (Cart?.Id == null || !Cart.CartItems.Any())
                {
                    TempData["Error"] = "Giỏ hàng của bạn đang trống";
                    return RedirectToPage("/Customer/Cart/Index");
                }

                TotalAmount = await _cartService.GetCartTotalAsync(Cart.Id);

                // Load customer info
                CustomerName = User.Identity?.Name ?? "";
                PhoneNumber = User.FindFirst("PhoneNumber")?.Value ?? "";

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading checkout page");
                TempData["Error"] = "Có lỗi xảy ra";
                return RedirectToPage("/Customer/Cart/Index");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var customerIdClaim = User.FindFirst("CustomerId")?.Value;
                if (string.IsNullOrEmpty(customerIdClaim))
                {
                    return RedirectToPage("/Account/Login");
                }

                int customerId = int.Parse(customerIdClaim);
                Cart = await _cartService.GetActiveCartAsync(customerId);

                if (Cart?.Id == null)
                {
                    TempData["Error"] = "Không tìm thấy giỏ hàng";
                    return RedirectToPage("/Customer/Cart/Index");
                }

                var order = await _orderService.CreateOrderAsync(
                    customerId, 
                    Cart.Id, 
                    ShippingAddress, 
                    Note
                );

                TempData["Success"] = "Đặt hàng thành công! Mã đơn hàng: " + order.OrderNumber;
                return RedirectToPage("/Customer/Orders/Detail", new { id = order.Id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                TempData["Error"] = "Có lỗi xảy ra khi đặt hàng. Vui lòng thử lại!";
                return Page();
            }
        }
    }
}
