using MilkTeaWebsite.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace MilkTeaWebsite.DAL.Seed
{
    public static class DatabaseSeeder
    {
        // Use a fixed date for seed data to avoid migration issues
        private static readonly DateTime SeedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        
        // Pre-generated password hashes (to avoid dynamic BCrypt calls)
    // Password: Admin@123
    private static readonly string AdminPasswordHash = "$2a$11$33KxIZkVa3ixVHvGUwluSOwDg73KWZwKebIemMP7NvXy2Pnzg92Yi";
    // Password: Staff@123
    private static readonly string StaffPasswordHash = "$2a$11$3pJRfnggMMl4F5lBO6hPXOgSNcSxAqtbx51q7npi2dWnY5RLs1wma";

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", Description = "Administrator", CreatedAt = SeedDate },
                new Role { Id = 2, RoleName = "Staff", Description = "Staff member", CreatedAt = SeedDate },
                new Role { Id = 3, RoleName = "Customer", Description = "Customer", CreatedAt = SeedDate }
            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@milktea.com",
                    PasswordHash = AdminPasswordHash,
                    PhoneNumber = "0123456789",
                    RoleId = 1,
                    CreatedAt = SeedDate
                },
                new User
                {
                    Id = 2,
                    Username = "staff01",
                    Email = "staff01@milktea.com",
                    PasswordHash = StaffPasswordHash,
                    PhoneNumber = "0987654321",
                    RoleId = 2,
                    CreatedAt = SeedDate
                }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    UserId = 1,
                    FullName = "Nguyễn Văn Admin",
                    Position = "Manager",
                    Department = "Management",
                    Salary = 20000000,
                    CreatedAt = SeedDate
                },
                new Employee
                {
                    Id = 2,
                    UserId = 2,
                    FullName = "Trần Thị Staff",
                    Position = "Staff",
                    Department = "Sales",
                    Salary = 12000000,
                    CreatedAt = SeedDate
                }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    CategoryName = "Trà Sữa Truyền Thống",
                    Description = "Trà sữa được pha chế theo công thức truyền thống",
                    ImageUrl = "/images/categories/tra-sua-truyen-thong.jpg",
                    DisplayOrder = 1,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Trà Sữa Trái Cây",
                    Description = "Trà sữa kết hợp với các loại trái cây tươi ngon",
                    ImageUrl = "/images/categories/tra-sua-trai-cay.jpg",
                    DisplayOrder = 2,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Trà Trái Cây",
                    Description = "Trà thanh mát với trái cây tươi",
                    ImageUrl = "/images/categories/tra-trai-cay.jpg",
                    DisplayOrder = 3,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Coffee",
                    Description = "Các loại cà phê đặc biệt",
                    ImageUrl = "/images/categories/coffee.jpg",
                    DisplayOrder = 4,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Đồ Ăn Vặt",
                    Description = "Các món ăn vặt ngon miệng",
                    ImageUrl = "/images/categories/do-an-vat.jpg",
                    DisplayOrder = 5,
                    CreatedAt = SeedDate
                }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                // Trà Sữa Truyền Thống
                new Product
                {
                    Id = 1,
                    ProductName = "Trà Sữa Truyền Thống",
                    Description = "Trà sữa được pha chế theo công thức truyền thống, hương vị đậm đà",
                    Price = 35000,
                    CategoryId = 1,
                    ImageUrl = "/images/products/tra-sua-truyen-thong.jpg",
                    StockQuantity = 100,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Trân châu, Thạch, Pudding",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Trà Sữa Socola",
                    Description = "Trà sữa pha với socola nguyên chất, béo ngậy",
                    Price = 40000,
                    CategoryId = 1,
                    ImageUrl = "/images/products/tra-sua-socola.jpg",
                    StockQuantity = 80,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Trân châu, Thạch, Pudding",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Trà Sữa Matcha",
                    Description = "Trà sữa matcha Nhật Bản thơm ngon, đậm vị trà xanh",
                    Price = 45000,
                    CategoryId = 1,
                    ImageUrl = "/images/products/tra-sua-matcha.jpg",
                    StockQuantity = 90,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Trân châu, Thạch, Pudding",
                    CreatedAt = SeedDate
                },
                
                // Trà Sữa Trái Cây
                new Product
                {
                    Id = 4,
                    ProductName = "Trà Sữa Dâu Tây",
                    Description = "Trà sữa kết hợp với dâu tây tươi ngon",
                    Price = 42000,
                    CategoryId = 2,
                    ImageUrl = "/images/products/tra-sua-dau-tay.jpg",
                    StockQuantity = 75,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Trân châu, Thạch dâu, Pudding",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Trà Sữa Xoài",
                    Description = "Trà sữa xoài thơm ngon, vị ngọt dịu",
                    Price = 40000,
                    CategoryId = 2,
                    ImageUrl = "/images/products/tra-sua-xoai.jpg",
                    StockQuantity = 85,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Trân châu, Thạch xoài, Pudding",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Trà Sữa Đào",
                    Description = "Trà sữa đào ngọt thanh, tươi mát",
                    Price = 42000,
                    CategoryId = 2,
                    ImageUrl = "/images/products/tra-sua-dao.jpg",
                    StockQuantity = 70,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Trân châu, Thạch đào, Pudding",
                    CreatedAt = SeedDate
                },

                // Trà Trái Cây
                new Product
                {
                    Id = 7,
                    ProductName = "Trà Đào Cam Sả",
                    Description = "Trà đào cam sả thơm ngon, giải nhiệt",
                    Price = 38000,
                    CategoryId = 3,
                    ImageUrl = "/images/products/tra-dao-cam-sa.jpg",
                    StockQuantity = 95,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Thạch, Trái cây",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 8,
                    ProductName = "Trà Chanh Leo",
                    Description = "Trà chanh leo chua ngọt, thanh mát",
                    Price = 35000,
                    CategoryId = 3,
                    ImageUrl = "/images/products/tra-chanh-leo.jpg",
                    StockQuantity = 100,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Thạch, Trái cây",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 9,
                    ProductName = "Trà Vải",
                    Description = "Trà vải thơm ngon, ngọt dịu",
                    Price = 36000,
                    CategoryId = 3,
                    ImageUrl = "/images/products/tra-vai.jpg",
                    StockQuantity = 88,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Thạch vải, Trái cây",
                    CreatedAt = SeedDate
                },

                // Coffee
                new Product
                {
                    Id = 10,
                    ProductName = "Cà Phê Sữa Đá",
                    Description = "Cà phê sữa đá truyền thống Việt Nam",
                    Price = 30000,
                    CategoryId = 4,
                    ImageUrl = "/images/products/ca-phe-sua-da.jpg",
                    StockQuantity = 120,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Shot thêm",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 11,
                    ProductName = "Bạc Xỉu",
                    Description = "Cà phê sữa nhẹ nhàng, ngọt dịu",
                    Price = 32000,
                    CategoryId = 4,
                    ImageUrl = "/images/products/bac-xiu.jpg",
                    StockQuantity = 110,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Shot thêm",
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 12,
                    ProductName = "Cappuccino",
                    Description = "Cà phê Cappuccino thơm ngon kiểu Ý",
                    Price = 45000,
                    CategoryId = 4,
                    ImageUrl = "/images/products/cappuccino.jpg",
                    StockQuantity = 65,
                    IsAvailable = true,
                    Size = "M, L",
                    Topping = "Shot thêm",
                    CreatedAt = SeedDate
                },

                // Đồ Ăn Vặt
                new Product
                {
                    Id = 13,
                    ProductName = "Bánh Flan",
                    Description = "Bánh flan mềm mịn, ngọt dịu",
                    Price = 15000,
                    CategoryId = 5,
                    ImageUrl = "/images/products/banh-flan.jpg",
                    StockQuantity = 50,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 14,
                    ProductName = "Bánh Bông Lan Trứng Muối",
                    Description = "Bánh bông lan phô mai trứng muối thơm ngon",
                    Price = 25000,
                    CategoryId = 5,
                    ImageUrl = "/images/products/banh-bong-lan.jpg",
                    StockQuantity = 40,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 15,
                    ProductName = "Khoai Lang Kén",
                    Description = "Khoai lang kén giòn tan, thơm ngon",
                    Price = 20000,
                    CategoryId = 5,
                    ImageUrl = "/images/products/khoai-lang-ken.jpg",
                    StockQuantity = 60,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                }
            );
        }
    }
}
