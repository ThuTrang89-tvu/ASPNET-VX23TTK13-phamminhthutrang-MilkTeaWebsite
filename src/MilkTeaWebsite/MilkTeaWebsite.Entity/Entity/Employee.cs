using System.Collections.Generic;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Employee : BaseEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty; // Manager, Staff, etc.
        public decimal Salary { get; set; }
        public string? Department { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Order> ManagedOrders { get; set; } = new List<Order>();
    }
}
