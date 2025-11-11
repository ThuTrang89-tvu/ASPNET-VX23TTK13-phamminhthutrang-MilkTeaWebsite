using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.Entity.Entity;

namespace MilkTeaWebsite.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoleName).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.RoleName).IsUnique();
            });

            // Configure User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
                
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                
                entity.HasOne(e => e.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Address).HasMaxLength(500);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.District).HasMaxLength(100);
                entity.Property(e => e.Ward).HasMaxLength(100);
                
                entity.HasOne(e => e.User)
                    .WithOne(u => u.Customer)
                    .HasForeignKey<Customer>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Position).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Department).HasMaxLength(100);
                
                entity.HasOne(e => e.User)
                    .WithOne(u => u.Employee)
                    .HasForeignKey<Employee>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
            });

            // Configure Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.Size).HasMaxLength(10);
                entity.Property(e => e.Topping).HasMaxLength(500);
                
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Cart
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Carts)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure CartItem
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Size).HasMaxLength(10);
                entity.Property(e => e.Topping).HasMaxLength(500);
                entity.Property(e => e.Note).HasMaxLength(500);
                
                entity.HasOne(e => e.Cart)
                    .WithMany(c => c.CartItems)
                    .HasForeignKey(e => e.CartId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
                entity.Property(e => e.OrderStatus).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.FinalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ShippingAddress).HasMaxLength(500);
                entity.Property(e => e.Note).HasMaxLength(1000);
                
                entity.HasIndex(e => e.OrderNumber).IsUnique();
                
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
                    
                entity.HasOne(e => e.Employee)
                    .WithMany(emp => emp.ManagedOrders)
                    .HasForeignKey(e => e.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure OrderDetail
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Size).HasMaxLength(10);
                entity.Property(e => e.Topping).HasMaxLength(500);
                entity.Property(e => e.Note).HasMaxLength(500);
                
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Payment
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PaymentMethod).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PaymentStatus).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TransactionId).HasMaxLength(255);
                entity.Property(e => e.Note).HasMaxLength(500);
                
                entity.HasOne(e => e.Order)
                    .WithOne(o => o.Payment)
                    .HasForeignKey<Payment>(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", Description = "Administrator", CreatedAt = seedDate },
                new Role { Id = 2, RoleName = "Employee", Description = "Employee", CreatedAt = seedDate },
                new Role { Id = 3, RoleName = "Customer", Description = "Customer", CreatedAt = seedDate }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Trà Sữa Truyền Thống", Description = "Các loại trà sữa truyền thống", DisplayOrder = 1, CreatedAt = seedDate },
                new Category { Id = 2, CategoryName = "Trà Trái Cây", Description = "Trà kết hợp trái cây tươi", DisplayOrder = 2, CreatedAt = seedDate },
                new Category { Id = 3, CategoryName = "Trà Sữa Đặc Biệt", Description = "Các món trà sữa đặc biệt", DisplayOrder = 3, CreatedAt = seedDate },
                new Category { Id = 4, CategoryName = "Topping", Description = "Các loại topping", DisplayOrder = 4, CreatedAt = seedDate }
            );
        }
    }
}
