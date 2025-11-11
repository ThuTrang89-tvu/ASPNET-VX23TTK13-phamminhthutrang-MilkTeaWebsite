using System;
using System.Collections.Generic;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Cart : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime? ExpiresAt { get; set; } // Giỏ hàng có thể có thời gian hết hạn
        
        // Navigation properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
