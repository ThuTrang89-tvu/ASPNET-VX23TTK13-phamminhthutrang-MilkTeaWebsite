using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Customer.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IOrderService orderService, ILogger<IndexModel> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

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
                Orders = await _orderService.GetCustomerOrdersAsync(customerId);

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading orders");
                TempData["Error"] = "Có lỗi xảy ra khi tải đơn hàng";
                return Page();
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

            return RedirectToPage();
        }
    }
}
