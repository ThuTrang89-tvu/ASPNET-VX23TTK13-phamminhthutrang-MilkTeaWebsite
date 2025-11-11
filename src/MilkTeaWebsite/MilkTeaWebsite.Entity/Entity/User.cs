using System;

namespace MilkTeaWebsite.Entity.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public DateTime? LastLoginAt { get; set; }
        
        // Navigation properties
        public virtual Role Role { get; set; } = null!;
        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
