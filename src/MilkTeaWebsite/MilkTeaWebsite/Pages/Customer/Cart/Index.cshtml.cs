using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Customer.Cart
{
    public class IndexModel : PageModel
    {
        private readonly ICartService _cartService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ICartService cartService, ILogger<IndexModel> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        public Entity.Entity.Cart? Cart { get; set; }
        public decimal TotalAmount { get; set; }

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

                if (Cart?.Id != null)
                {
                    TotalAmount = await _cartService.GetCartTotalAsync(Cart.Id);
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading cart");
                TempData["Error"] = "Có lỗi xảy ra khi tải giỏ hàng";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostUpdateQuantityAsync(int cartItemId, int quantity)
        {
            try
            {
                await _cartService.UpdateCartItemAsync(cartItemId, quantity);
                TempData["Success"] = "Đã cập nhật số lượng";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cart item");
                TempData["Error"] = "Có lỗi xảy ra khi cập nhật";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveAsync(int cartItemId)
        {
            try
            {
                await _cartService.RemoveFromCartAsync(cartItemId);
                TempData["Success"] = "Đã xóa sản phẩm khỏi giỏ hàng";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing cart item");
                TempData["Error"] = "Có lỗi xảy ra khi xóa sản phẩm";
            }

            return RedirectToPage();
        }
    }
}
