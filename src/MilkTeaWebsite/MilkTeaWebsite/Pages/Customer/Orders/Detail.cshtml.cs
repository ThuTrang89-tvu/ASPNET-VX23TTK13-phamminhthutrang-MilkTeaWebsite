using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Customer.Orders
{
    public class DetailModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<DetailModel> _logger;

        public DetailModel(IOrderService orderService, ILogger<DetailModel> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public Order? Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                Order = await _orderService.GetOrderByIdAsync(id);

                if (Order == null)
                {
                    return NotFound();
                }

                // Verify order belongs to current user
                var customerIdClaim = User.FindFirst("CustomerId")?.Value;
                if (!string.IsNullOrEmpty(customerIdClaim))
                {
                    int customerId = int.Parse(customerIdClaim);
                    if (Order.CustomerId != customerId)
                    {
                        return Forbid();
                    }
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading order detail");
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostCancelAsync(int orderId)
        {
            try
            {
                await _orderService.CancelOrderAsync(orderId);
                TempData["Success"] = "Đã hủy đơn hàng thành công";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling order");
                TempData["Error"] = "Có lỗi xảy ra khi hủy đơn hàng";
            }

            return RedirectToPage(new { id = orderId });
        }
    }
}
