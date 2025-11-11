using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Implements
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Payment> CreatePaymentAsync(int orderId, string paymentMethod, decimal amount)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            var payment = new Payment
            {
                OrderId = orderId,
                PaymentMethod = paymentMethod,
                PaymentStatus = "Pending",
                Amount = amount,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.SaveChangesAsync();

            return payment;
        }

        public async Task<Payment?> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _unitOfWork.Payments.GetPaymentByOrderIdAsync(orderId);
        }

        public async Task UpdatePaymentStatusAsync(int paymentId, string status, string? transactionId = null)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(paymentId);
            if (payment == null)
                throw new Exception("Payment not found");

            payment.PaymentStatus = status;
            if (status == "Completed")
                payment.PaymentDate = DateTime.UtcNow;
            
            if (!string.IsNullOrEmpty(transactionId))
                payment.TransactionId = transactionId;

            payment.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Payments.Update(payment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
