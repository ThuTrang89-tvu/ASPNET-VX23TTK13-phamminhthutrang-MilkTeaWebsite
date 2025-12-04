namespace MilkTeaWebsite.Entity.Entity
{
    public class ProductTopping
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        
        public int ToppingId { get; set; }
        public virtual Topping Topping { get; set; } = null!;
    }
}
