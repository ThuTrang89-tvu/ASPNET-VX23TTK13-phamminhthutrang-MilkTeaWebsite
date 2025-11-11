using System;
using System.Collections.Generic;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; } = string.Empty; // Mã đơn hàng
        public int CustomerId { get; set; }
        public int? EmployeeId { get; set; } // Nhân viên xử lý
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string OrderStatus { get; set; } = "Pending"; // Pending, Confirmed, Preparing, Delivering, Completed, Cancelled
        public decimal TotalAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string? Note { get; set; }
        
        // Navigation properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual Payment? Payment { get; set; }
    }
}
