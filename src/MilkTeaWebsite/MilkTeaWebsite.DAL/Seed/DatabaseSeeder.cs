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
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4qHQVMcxnHvYE5zEXI7tUpw_q-Oq5FMLZCg&s",
                    DisplayOrder = 1,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Trà Sữa Trái Cây",
                    Description = "Trà sữa kết hợp với các loại trái cây tươi ngon",
                    ImageUrl = "https://monngonmoingay.com/wp-content/uploads/2024/01/tra-sua.jpg",
                    DisplayOrder = 2,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Trà Trái Cây",
                    Description = "Trà thanh mát với trái cây tươi",
                    ImageUrl = "https://i.ytimg.com/vi/l6jiHzm5P5c/maxresdefault.jpg",
                    DisplayOrder = 3,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Coffee",
                    Description = "Các loại cà phê đặc biệt",
                    ImageUrl = "https://www.cubes-asia.com/storage/blogs/2024-12/ca-phe-nguyen-chat-la-gi-tac-dung-dac-diem.jpg",
                    DisplayOrder = 4,
                    CreatedAt = SeedDate
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Đồ Ăn Vặt",
                    Description = "Các món ăn vặt ngon miệng",
                    ImageUrl = "https://saigonchutla.vn/wp-content/uploads/2023/09/an-vat-kon-tum-3-800x445-1.jpg",
                    DisplayOrder = 5,
                    CreatedAt = SeedDate
                }
            );

            // Seed Toppings
            modelBuilder.Entity<Topping>().HasData(
                new Topping
                {
                    Id = 1,
                    ToppingName = "Trân châu đen",
                    Description = "Trân châu đen dai dai, ngọt ngọt",
                    ToppingPrice = 5000,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Topping
                {
                    Id = 2,
                    ToppingName = "Trân châu trắng",
                    Description = "Trân châu trắng mềm mịn",
                    ToppingPrice = 5000,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Topping
                {
                    Id = 3,
                    ToppingName = "Thạch rau câu",
                    Description = "Thạch rau câu nhiều màu sắc",
                    ToppingPrice = 4000,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Topping
                {
                    Id = 4,
                    ToppingName = "Pudding",
                    Description = "Pudding trứng mềm mịn",
                    ToppingPrice = 6000,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Topping
                {
                    Id = 5,
                    ToppingName = "Thạch dừa",
                    Description = "Thạch dừa thơm ngon",
                    ToppingPrice = 4000,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Topping
                {
                    Id = 6,
                    ToppingName = "Kem cheese",
                    Description = "Kem cheese béo ngậy",
                    ToppingPrice = 8000,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Topping
                {
                    Id = 7,
                    ToppingName = "Sốt socola",
                    Description = "Sốt socola đậm đà",
                    ToppingPrice = 7000,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Topping
                {
                    Id = 8,
                    ToppingName = "Trái cây tươi",
                    Description = "Trái cây tươi ngon theo mùa",
                    ToppingPrice = 10000,
                    IsAvailable = true,
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
                    PriceS = 30000,
                    PriceM = 35000,
                    PriceL = 40000,
                    CategoryId = 1,
                    ImageUrl = "https://www.bartender.edu.vn/wp-content/uploads/2015/11/tra-sua-truyen-thong.jpg",
                    StockQuantity = 100,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Trà Sữa Socola",
                    Description = "Trà sữa pha với socola nguyên chất, béo ngậy",
                    PriceS = 35000,
                    PriceM = 40000,
                    PriceL = 45000,
                    CategoryId = 1,
                    ImageUrl = "https://file.hstatic.net/200000868155/file/1926-post-cach-lam-tra-sua-socola-beo-thom-don-gian-tai-nha-1.jpg",
                    StockQuantity = 80,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Trà Sữa Matcha",
                    Description = "Trà sữa matcha Nhật Bản thơm ngon, đậm vị trà xanh",
                    PriceS = 40000,
                    PriceM = 45000,
                    PriceL = 50000,
                    CategoryId = 1,
                    ImageUrl = "https://product.hstatic.net/1000220639/product/tra-sua-luave-matcha-5_39ee13d0ab9b413186dbde4184d2dde9.jpg",
                    StockQuantity = 90,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                
                // Trà Sữa Trái Cây
                new Product
                {
                    Id = 4,
                    ProductName = "Trà Sữa Dâu Tây",
                    Description = "Trà sữa kết hợp với dâu tây tươi ngon",
                    PriceS = 38000,
                    PriceM = 42000,
                    PriceL = 47000,
                    CategoryId = 2,
                    ImageUrl = "https://cdn.nguyenkimmall.com/images/companies/_1/tin-tuc/kinh-nghiem-meo-hay/n%E1%BA%A5u%20%C4%83n/cach-lam-tra-sua-dau-5.jpg.jpg",
                    StockQuantity = 75,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Trà Sữa Xoài",
                    Description = "Trà sữa xoài thơm ngon, vị ngọt dịu",
                    PriceS = 36000,
                    PriceM = 40000,
                    PriceL = 45000,
                    CategoryId = 2,
                    ImageUrl = "https://lypham.vn/wp-content/uploads/2025/01/cach-lam-tra-sua-xoai.jpg",
                    StockQuantity = 85,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Trà Sữa Đào",
                    Description = "Trà sữa đào ngọt thanh, tươi mát",
                    PriceS = 38000,
                    PriceM = 42000,
                    PriceL = 47000,
                    CategoryId = 2,
                    ImageUrl = "https://cdn.tgdd.vn/Files/2021/08/07/1373678/huong-dan-cach-lam-tra-sua-dao-thom-ngon-mat-lanh-202201121043508846.jpg",
                    StockQuantity = 70,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },

                // Trà Trái Cây
                new Product
                {
                    Id = 7,
                    ProductName = "Trà Đào Cam Sả",
                    Description = "Trà đào cam sả thơm ngon, giải nhiệt",
                    PriceS = 33000,
                    PriceM = 38000,
                    PriceL = 43000,
                    CategoryId = 3,
                    ImageUrl = "https://lypham.vn/wp-content/uploads/2024/09/cach-lam-tra-dao-cam-sa.jpg",
                    StockQuantity = 95,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 8,
                    ProductName = "Trà Chanh Leo",
                    Description = "Trà chanh leo chua ngọt, thanh mát",
                    PriceS = 30000,
                    PriceM = 35000,
                    PriceL = 40000,
                    CategoryId = 3,
                    ImageUrl = "https://lypham.vn/wp-content/uploads/2024/10/chanh-day-mat-ong-truyen-thong.jpg",
                    StockQuantity = 100,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 9,
                    ProductName = "Trà Vải",
                    Description = "Trà vải thơm ngon, ngọt dịu",
                    PriceS = 31000,
                    PriceM = 36000,
                    PriceL = 41000,
                    CategoryId = 3,
                    ImageUrl = "https://raumamix.com.vn/wp-content/uploads/2025/02/Tra-Lai-Vai-Luc-Ngan.png",
                    StockQuantity = 88,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },

                // Coffee
                new Product
                {
                    Id = 10,
                    ProductName = "Cà Phê Sữa Đá",
                    Description = "Cà phê sữa đá truyền thống Việt Nam",
                    PriceS = 25000,
                    PriceM = 30000,
                    PriceL = 35000,
                    CategoryId = 4,
                    ImageUrl = "https://product.hstatic.net/200000914837/product/cafe_sua_da_ee2490f7d7dc47748ae88e323b31fa2b_eab075b7a57149fe80a152ade1b9cbc3_master.png",
                    StockQuantity = 120,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 11,
                    ProductName = "Bạc Xỉu",
                    Description = "Cà phê sữa nhẹ nhàng, ngọt dịu",
                    PriceS = 27000,
                    PriceM = 32000,
                    PriceL = 37000,
                    CategoryId = 4,
                    ImageUrl = "https://cdn.tgdd.vn/2021/03/CookProduct/Bac-xiu-la-gi-nguon-goc-va-cach-lam-bac-xiu-thom-ngon-don-gian-tai-nha-0-1200x676.jpg",
                    StockQuantity = 110,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 12,
                    ProductName = "Cappuccino",
                    Description = "Cà phê Cappuccino thơm ngon kiểu Ý",
                    PriceS = 40000,
                    PriceM = 45000,
                    PriceL = 50000,
                    CategoryId = 4,
                    ImageUrl = "https://www.nescafe.com/nz/sites/default/files/2023-09/NESCAF%C3%89%20Cappuccino.jpg",
                    StockQuantity = 65,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },

                // Đồ Ăn Vặt
                new Product
                {
                    Id = 13,
                    ProductName = "Bánh Flan",
                    Description = "Bánh flan mềm mịn, ngọt dịu",
                    PriceS = 15000,
                    PriceM = 15000,
                    PriceL = 15000,
                    CategoryId = 5,
                    ImageUrl = "https://superfoods.vn/wp-content/uploads/2023/08/banh-flan-1.jpg",
                    StockQuantity = 50,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 14,
                    ProductName = "Bánh Bông Lan Trứng Muối",
                    Description = "Bánh bông lan phô mai trứng muối thơm ngon",
                    PriceS = 25000,
                    PriceM = 25000,
                    PriceL = 25000,
                    CategoryId = 5,
                    ImageUrl = "https://anhquanbakery.com/uploads/product/full_azt857am-1320-bong-lan-trung-muoi-12.jpg",
                    StockQuantity = 40,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                },
                new Product
                {
                    Id = 15,
                    ProductName = "Khoai Lang Kén",
                    Description = "Khoai lang kén giòn tan, thơm ngon",
                    PriceS = 20000,
                    PriceM = 20000,
                    PriceL = 20000,
                    CategoryId = 5,
                    ImageUrl = "https://cdn.tgdd.vn/2021/10/CookRecipe/Avatar/khoai-lang-ken-voi-me-den-thumbnail.jpg",
                    StockQuantity = 60,
                    IsAvailable = true,
                    CreatedAt = SeedDate
                }
            );

            // Seed ProductToppings - Link products with available toppings
            modelBuilder.Entity<ProductTopping>().HasData(
                // Trà Sữa Truyền Thống (Product 1) - All toppings
                new ProductTopping { ProductId = 1, ToppingId = 1 },
                new ProductTopping { ProductId = 1, ToppingId = 2 },
                new ProductTopping { ProductId = 1, ToppingId = 3 },
                new ProductTopping { ProductId = 1, ToppingId = 4 },
                new ProductTopping { ProductId = 1, ToppingId = 5 },
                new ProductTopping { ProductId = 1, ToppingId = 6 },
                
                // Trà Sữa Socola (Product 2)
                new ProductTopping { ProductId = 2, ToppingId = 1 },
                new ProductTopping { ProductId = 2, ToppingId = 2 },
                new ProductTopping { ProductId = 2, ToppingId = 4 },
                new ProductTopping { ProductId = 2, ToppingId = 6 },
                new ProductTopping { ProductId = 2, ToppingId = 7 },
                
                // Trà Sữa Matcha (Product 3)
                new ProductTopping { ProductId = 3, ToppingId = 1 },
                new ProductTopping { ProductId = 3, ToppingId = 2 },
                new ProductTopping { ProductId = 3, ToppingId = 3 },
                new ProductTopping { ProductId = 3, ToppingId = 4 },
                new ProductTopping { ProductId = 3, ToppingId = 5 },
                
                // Trà Sữa Dâu Tây (Product 4)
                new ProductTopping { ProductId = 4, ToppingId = 1 },
                new ProductTopping { ProductId = 4, ToppingId = 2 },
                new ProductTopping { ProductId = 4, ToppingId = 3 },
                new ProductTopping { ProductId = 4, ToppingId = 8 },
                
                // Trà Sữa Xoài (Product 5)
                new ProductTopping { ProductId = 5, ToppingId = 1 },
                new ProductTopping { ProductId = 5, ToppingId = 2 },
                new ProductTopping { ProductId = 5, ToppingId = 5 },
                new ProductTopping { ProductId = 5, ToppingId = 8 },
                
                // Trà Sữa Đào (Product 6)
                new ProductTopping { ProductId = 6, ToppingId = 1 },
                new ProductTopping { ProductId = 6, ToppingId = 2 },
                new ProductTopping { ProductId = 6, ToppingId = 3 },
                new ProductTopping { ProductId = 6, ToppingId = 8 },
                
                // Trà Đào Cam Sả (Product 7)
                new ProductTopping { ProductId = 7, ToppingId = 1 },
                new ProductTopping { ProductId = 7, ToppingId = 3 },
                new ProductTopping { ProductId = 7, ToppingId = 5 },
                new ProductTopping { ProductId = 7, ToppingId = 8 },
                
                // Trà Chanh Leo (Product 8)
                new ProductTopping { ProductId = 8, ToppingId = 1 },
                new ProductTopping { ProductId = 8, ToppingId = 3 },
                new ProductTopping { ProductId = 8, ToppingId = 5 },
                
                // Trà Vải (Product 9)
                new ProductTopping { ProductId = 9, ToppingId = 1 },
                new ProductTopping { ProductId = 9, ToppingId = 2 },
                new ProductTopping { ProductId = 9, ToppingId = 3 },
                new ProductTopping { ProductId = 9, ToppingId = 8 },
                
                // Cà Phê Sữa Đá (Product 10)
                new ProductTopping { ProductId = 10, ToppingId = 6 },
                new ProductTopping { ProductId = 10, ToppingId = 7 },
                
                // Bạc Xỉu (Product 11)
                new ProductTopping { ProductId = 11, ToppingId = 6 },
                new ProductTopping { ProductId = 11, ToppingId = 7 },
                
                // Cappuccino (Product 12)
                new ProductTopping { ProductId = 12, ToppingId = 6 },
                new ProductTopping { ProductId = 12, ToppingId = 7 }
            );
        }
    }
}
