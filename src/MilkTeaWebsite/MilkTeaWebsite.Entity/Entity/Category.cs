using System.Collections.Generic;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int DisplayOrder { get; set; } = 0;
        
        // Navigation properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
