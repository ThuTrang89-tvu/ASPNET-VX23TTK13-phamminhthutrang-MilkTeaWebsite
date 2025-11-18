namespace MilkTeaWebsite.Entity.Entity
{
    public class Topping : BaseEntity
    {
        public string ToppingName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal ToppingPrice { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
