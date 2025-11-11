using System.Collections.Generic;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; } = string.Empty; // Admin, Employee, Customer
        public string? Description { get; set; }
        
        // Navigation properties
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
