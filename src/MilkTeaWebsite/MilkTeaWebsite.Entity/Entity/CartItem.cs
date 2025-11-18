namespace MilkTeaWebsite.Entity.Entity
{
    public class CartItem : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        // Pricing breakdown
        public string? Size { get; set; } // S, M, L
        public decimal BasePrice { get; set; } // Price for selected size
        public string? SelectedToppings { get; set; } // Comma-separated topping names
        public decimal ToppingPrice { get; set; } // Total topping price
        public decimal TotalPrice { get; set; } // (BasePrice + ToppingPrice) * Quantity
        
        public string? Note { get; set; }
        
        // Navigation properties
        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
