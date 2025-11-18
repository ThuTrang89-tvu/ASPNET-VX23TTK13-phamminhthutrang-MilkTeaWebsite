using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(int customerId, int cartId, string shippingAddress, string? note)
        {
            var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(cartId);
            if (cart == null || cart.CustomerId != customerId)
                throw new Exception("Cart not found");

            if (!cart.CartItems.Any())
                throw new Exception("Cart is empty");

            // Calculate totals
            decimal totalAmount = cart.CartItems.Sum(ci => ci.TotalPrice);

            // Create order
            var order = new Order
            {
                OrderNumber = GenerateOrderNumber(),
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = "Pending",
                TotalAmount = totalAmount,
                DiscountAmount = 0,
                FinalAmount = totalAmount,
                ShippingAddress = shippingAddress,
                Note = note,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Create order details from cart items
            foreach (var cartItem in cart.CartItems)
            {
                var unitPrice = cartItem.BasePrice + cartItem.ToppingPrice;
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Size = cartItem.Size,
                    BasePrice = cartItem.BasePrice,
                    ToppingPrice = cartItem.ToppingPrice,
                    UnitPrice = unitPrice,
                    TotalPrice = cartItem.TotalPrice,
                    SelectedToppings = cartItem.SelectedToppings,
                    Note = cartItem.Note,
                    CreatedAt = DateTime.UtcNow
                };
                await _unitOfWork.OrderDetails.AddAsync(orderDetail);
            }

            // Clear cart
            foreach (var item in cart.CartItems)
            {
                item.IsDeleted = true;
                item.UpdatedAt = DateTime.UtcNow;
            }

            await _unitOfWork.SaveChangesAsync();

            return await _unitOfWork.Orders.GetOrderWithDetailsAsync(order.Id) ?? order;
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId);
        }

        public async Task<Order?> GetOrderByOrderNumberAsync(string orderNumber)
        {
            return await _unitOfWork.Orders.GetOrderByOrderNumberAsync(orderNumber);
        }

        public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId)
        {
            return await _unitOfWork.Orders.GetOrdersByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status)
        {
            return await _unitOfWork.Orders.GetOrdersByStatusAsync(status);
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status, int? employeeId = null)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.OrderStatus = status;
            if (employeeId.HasValue)
                order.EmployeeId = employeeId.Value;
            
            order.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            if (order.OrderStatus == "Completed" || order.OrderStatus == "Cancelled")
                throw new Exception("Cannot cancel this order");

            order.OrderStatus = "Cancelled";
            order.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();
        }

        private string GenerateOrderNumber()
        {
            return $"ORD{DateTime.UtcNow:yyyyMMddHHmmss}";
        }
    }
}
