using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Orders
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
        public string? StatusFilter { get; set; }

        public async Task<IActionResult> OnGetAsync(string? status)
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                StatusFilter = status;

                if (!string.IsNullOrEmpty(status))
                {
                    Orders = await _orderService.GetOrdersByStatusAsync(status);
                }
                else
                {
                    // Get all orders (you might need to add this method to IOrderService)
                    var allStatuses = new[] { "Pending", "Confirmed", "Preparing", "Shipping", "Completed", "Cancelled" };
                    var allOrders = new List<Order>();
                    foreach (var s in allStatuses)
                    {
                        var orders = await _orderService.GetOrdersByStatusAsync(s);
                        allOrders.AddRange(orders);
                    }
                    Orders = allOrders.OrderByDescending(o => o.OrderDate);
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading orders");
                TempData["Error"] = "Có lỗi xảy ra khi tải đơn hàng";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int orderId, string newStatus)
        {
            try
            {
                var employeeIdClaim = User.FindFirst("EmployeeId")?.Value;
                int? employeeId = null;
                if (!string.IsNullOrEmpty(employeeIdClaim))
                {
                    employeeId = int.Parse(employeeIdClaim);
                }

                await _orderService.UpdateOrderStatusAsync(orderId, newStatus, employeeId);
                TempData["Success"] = "Đã cập nhật trạng thái đơn hàng";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order status");
                TempData["Error"] = "Có lỗi xảy ra khi cập nhật trạng thái";
            }

            return RedirectToPage();
        }
    }
}
