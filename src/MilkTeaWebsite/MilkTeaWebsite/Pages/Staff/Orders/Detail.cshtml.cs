using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Orders
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

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading order detail");
                return NotFound();
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

            return RedirectToPage(new { id = orderId });
        }
    }
}
