namespace MilkTeaWebsite.Entity.Entity
{
    public class CartItem : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Size { get; set; } // S, M, L
        public string? Topping { get; set; } // Các topping đã chọn
        public string? Note { get; set; }
        
        // Navigation properties
        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
