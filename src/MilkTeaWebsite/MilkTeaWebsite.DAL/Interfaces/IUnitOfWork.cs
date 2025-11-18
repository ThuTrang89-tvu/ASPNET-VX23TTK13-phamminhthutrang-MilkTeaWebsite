using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        ICustomerRepository Customers { get; }
        IEmployeeRepository Employees { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IToppingRepository Toppings { get; }
        ICartRepository Carts { get; }
        ICartItemRepository CartItems { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        IPaymentRepository Payments { get; }
        
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}
