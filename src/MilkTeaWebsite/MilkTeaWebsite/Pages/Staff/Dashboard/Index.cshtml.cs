using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.Pages.Staff.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(
            IOrderService orderService,
            IProductService productService,
            ILogger<IndexModel> logger)
        {
            _orderService = orderService;
            _productService = productService;
            _logger = logger;
        }

        public int PendingOrdersCount { get; set; }
        public int ProcessingOrdersCount { get; set; }
        public int CompletedTodayCount { get; set; }
        public decimal TodayRevenue { get; set; }
        public IEnumerable<Order> RecentOrders { get; set; } = new List<Order>();
        public IEnumerable<Product> LowStockProducts { get; set; } = new List<Product>();

        public async Task<IActionResult> OnGetAsync()
        {
            // Check if user is staff (you should implement proper authorization)
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                // Load statistics
                var pendingOrders = await _orderService.GetOrdersByStatusAsync("Pending");
                PendingOrdersCount = pendingOrders.Count();

                var processingStatuses = new[] { "Confirmed", "Preparing", "Shipping" };
                ProcessingOrdersCount = 0;
                foreach (var status in processingStatuses)
                {
                    var orders = await _orderService.GetOrdersByStatusAsync(status);
                    ProcessingOrdersCount += orders.Count();
                }

                var completedOrders = await _orderService.GetOrdersByStatusAsync("Completed");
                var todayOrders = completedOrders.Where(o => o.OrderDate.Date == DateTime.Today);
                CompletedTodayCount = todayOrders.Count();
                TodayRevenue = todayOrders.Sum(o => o.TotalAmount);

                // Load recent orders (last 10)
                var allOrders = new List<Order>();
                foreach (var status in new[] { "Pending", "Confirmed", "Preparing" })
                {
                    var orders = await _orderService.GetOrdersByStatusAsync(status);
                    allOrders.AddRange(orders);
                }
                RecentOrders = allOrders.OrderByDescending(o => o.OrderDate).Take(10);

                // Load low stock products (stock < 10)
                var allProducts = await _productService.GetAllProductsAsync();
                LowStockProducts = allProducts.Where(p => p.StockQuantity < 10).Take(5);

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading dashboard");
                TempData["Error"] = "Có lỗi xảy ra khi tải dữ liệu";
                return Page();
            }
        }
    }
}
