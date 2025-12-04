namespace MilkTeaWebsite.Entity.Entity
{
    public class Topping : BaseEntity
    {
        public string ToppingName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal ToppingPrice { get; set; }
        public bool IsAvailable { get; set; } = true;
        
        // Navigation property
        public virtual ICollection<ProductTopping> ProductToppings { get; set; } = new List<ProductTopping>();
    }
}
