using System;

namespace MilkTeaWebsite.Entity.Entity
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Card, MoMo, ZaloPay, etc.
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Completed, Failed, Refunded
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? TransactionId { get; set; } // ID giao dịch từ payment gateway
        public string? Note { get; set; }
        
        // Navigation properties
        public virtual Order Order { get; set; } = null!;
    }
}
