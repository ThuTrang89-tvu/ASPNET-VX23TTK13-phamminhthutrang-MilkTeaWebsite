using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }
        public ICartRepository Carts { get; private set; }
        public ICartItemRepository CartItems { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderDetailRepository OrderDetails { get; private set; }
        public IPaymentRepository Payments { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            Customers = new CustomerRepository(_context);
            Employees = new EmployeeRepository(_context);
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
            Carts = new CartRepository(_context);
            CartItems = new CartItemRepository(_context);
            Orders = new OrderRepository(_context);
            OrderDetails = new OrderDetailRepository(_context);
            Payments = new PaymentRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
