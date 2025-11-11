using System.Collections.Generic;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public int? LoyaltyPoints { get; set; } = 0;
        
        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
