using System.Collections.Generic;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public int StockQuantity { get; set; } = 0;
        public bool IsAvailable { get; set; } = true;
        public string? Size { get; set; } // S, M, L
        public string? Topping { get; set; } // Các loại topping có sẵn
        
        // Navigation properties
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
