# BÁO CÁO TUẦN 1

**Thời gian:** 07/11/2025 - 11/11/2025 

**Dự án:** Website bán trà sữa - ASP.NET Core

**Sinh viên:** Phạm Minh Thu Trang

---

## MỤC TIÊU

- Khởi tạo repository và cấu trúc 3 lớp- Khởi tạo repository và cấu trúc 3 lớp

- Thiết kế Entity models và Database- Thiết kế Entity models và Database

- Triển khai Repository Pattern- Triển khai Repository Pattern

- Setup PostgreSQL với Docker- Setup PostgreSQL với Docker

- Cấu hình Dependency Injection- Cấu hình Dependency Injection

---

## CÔNG VIỆC HOÀN THÀNH## ✅ Công việc đã hoàn thành

### 1. Cấu trúc Solution (4 Projects)### 1. Khởi tạo và cấu trúc dự án

- MilkTeaWebsite (Web Layer)

- MilkTeaWebsite.BLL (Business Logic)#### 1.1. Cấu trúc Solution (4 Projects)

- MilkTeaWebsite.DAL (Data Access)```

- MilkTeaWebsite.Entity (Domain Models)MilkTeaWebsite.sln

├── MilkTeaWebsite (Web - Presentation Layer)

### 2. Công nghệ├── MilkTeaWebsite.BLL (Business Logic Layer)

- .NET SDK 9.0├── MilkTeaWebsite.DAL (Data Access Layer)

- Entity Framework Core 9.0.10└── MilkTeaWebsite.Entity (Domain Models)

- PostgreSQL 16 + Docker```

- Npgsql 9.0.4

#### 1.2. Project References

### 3. Entity Models (12 entities)```

- BaseEntity: Id, CreatedAt, UpdatedAt, IsDeletedMilkTeaWebsite

- User: Username, Email, PasswordHash, RoleId ├─→ MilkTeaWebsite.BLL

- Role: RoleName, Description ├─→ MilkTeaWebsite.DAL

- Customer: UserId, FullName, PhoneNumber, Address └─→ MilkTeaWebsite.Entity

- Employee: UserId, FullName, Position

- Category: CategoryName, DisplayOrderMilkTeaWebsite.BLL

- Product: ProductName, CategoryId, Price ├─→ MilkTeaWebsite.DAL

- Cart: CustomerId, ExpiresAt └─→ MilkTeaWebsite.Entity

- CartItem: CartId, ProductId, Quantity, Size, Topping

- Order: OrderNumber, CustomerId, OrderStatus, TotalAmountMilkTeaWebsite.DAL

- OrderDetail: OrderId, ProductId, Quantity, UnitPrice └─→ MilkTeaWebsite.Entity

- Payment: OrderId, PaymentMethod, PaymentStatus```

### 4. Repository Pattern (13 Repositories)### 2. Công nghệ sử dụng

- IGenericRepository<T> + GenericRepository<T>

- UserRepository: GetByUsername, GetByEmail- **.NET SDK**: 9.0

- ProductRepository: GetAvailableProducts, GetProductsByCategory- **Entity Framework Core**: 9.0.10

- CartRepository: GetActiveCartByCustomerId, GetCartWithItems- **Database**: PostgreSQL 16 (Npgsql 9.0.4)

- OrderRepository: GetOrdersByCustomerId, GetOrderWithDetails- **Container**: Docker Compose

- PaymentRepository: GetPaymentByOrderId

- IUnitOfWork: Quản lý transaction### 3. Entity Layer - Domain Models

### 5. Business Logic Layer (5 Services)#### 3.1. Các Entity đã implement (12 entities)

- AuthService: Login, Register, Password hashing

- ProductService: CRUD, Filter, Soft delete| STT | Entity | Mô tả | Thuộc tính chính |

- CartService: Add/Remove items, Calculate total|-----|--------|-------|------------------|

- OrderService: Create, Update status, Cancel| 1 | **BaseEntity** | Base class cho tất cả entities | Id, CreatedAt, UpdatedAt, IsDeleted |

- PaymentService: Create, Update status| 2 | **User** | Tài khoản người dùng | Username, Email, PasswordHash, RoleId |

| 3 | **Role** | Vai trò (Admin, Employee, Customer) | RoleName, Description |

### 6. Database| 4 | **Customer** | Thông tin khách hàng | UserId, FullName, PhoneNumber, Address |

- Migration InitialCreate: 12 tables| 5 | **Employee** | Thông tin nhân viên | UserId, FullName, PhoneNumber, Position |

- Seed data: 3 Roles (Admin, Employee, Customer), 4 Categories| 6 | **Category** | Danh mục sản phẩm | CategoryName, Description, DisplayOrder |

- Docker Compose: PostgreSQL 16 Alpine| 7 | **Product** | Sản phẩm | ProductName, CategoryId, Price, Description |

- Dependency Injection setup| 8 | **Cart** | Giỏ hàng | CustomerId, ExpiresAt |

| 9 | **CartItem** | Chi tiết giỏ hàng | CartId, ProductId, Quantity, Size, Topping |

### 7. Documentation| 10 | **Order** | Đơn hàng | OrderNumber, CustomerId, OrderStatus, TotalAmount |

- README.md, QUICKSTART.md| 11 | **OrderDetail** | Chi tiết đơn hàng | OrderId, ProductId, Quantity, UnitPrice |

- Architecture documentation| 12 | **Payment** | Thanh toán | OrderId, PaymentMethod, PaymentStatus, Amount |

- Setup guide

### 4. Data Access Layer (DAL)

---

#### 4.1. Repository Pattern (13 Repositories)

## THỐNG KÊ

**Interfaces:**

| Metric | Số lượng |```

|--------|----------|IGenericRepository<T> - Base repository interface

| Projects | 4 |IUserRepository

| C# Files | 69 |IRoleRepository

| Entities | 12 |ICustomerRepository

| Repositories | 13 |IEmployeeRepository

| Services | 5 |ICategoryRepository

| Tables | 12 |IProductRepository

| Migrations | 1 |ICartRepository

ICartItemRepository

---IOrderRepository

IOrderDetailRepository

## KẾT QUẢIPaymentRepository

IUnitOfWork - Unit of Work pattern

**Hoàn thành:**```

- ✅ 3-Layer Architecture với Repository & Unit of Work Pattern

- ✅ 12 Entity models với relationships**Implementations:**

- ✅ PostgreSQL + Docker setup```

- ✅ Clean code, maintainableGenericRepository<T> - Base repository với CRUD cơ bản

UserRepository - Specialized queries: GetByUsername, GetByEmail

**Chưa hoàn thành:**RoleRepository

- Frontend UI (Razor Pages)CustomerRepository - GetByUserId

- Authentication UIEmployeeRepository - GetByUserId

- Error handling middlewareCategoryRepository

ProductRepository - GetAvailableProducts, GetProductsByCategory

---CartRepository - GetActiveCartByCustomerId, GetCartWithItems

CartItemRepository

## KẾ HOẠCH TUẦN 2OrderRepository - GetOrdersByCustomerId, GetOrderWithDetails

OrderDetailRepository - GetOrderDetailsByOrderId

- Presentation Layer: Home, Products listing, DetailsPaymentRepository - GetPaymentByOrderId

- Authentication: Login/Register với Cookie AuthUnitOfWork - Quản lý transaction và repositories

- Shopping Cart UI```

- Product search & filter

- Bootstrap 5 responsive design#### 4.2. Unit of Work Pattern

```csharp

---public interface IUnitOfWork : IDisposable

{

**Tỷ lệ hoàn thành:** 100% Backend Infrastructure    IUserRepository Users { get; }

    IRoleRepository Roles { get; }
    ICustomerRepository Customers { get; }
    IEmployeeRepository Employees { get; }
    ICategoryRepository Categories { get; }
    IProductRepository Products { get; }
    ICartRepository Carts { get; }
    ICartItemRepository CartItems { get; }
    IOrderRepository Orders { get; }
    IOrderDetailRepository OrderDetails { get; }
    IPaymentRepository Payments { get; }

    Task<int> SaveChangesAsync();
}
```

### 5. Business Logic Layer (BLL)

#### 5.1. Services đã implement (5 Services)

- **AuthService**: Login, Register, Password hashing/verification
- **ProductService**: CRUD, Filter by category, Soft delete
- **CartService**: Add/Remove items, Calculate total, Support size/topping
- **OrderService**: Create order, Update status, Cancel order
- **PaymentService**: Create payment, Update payment status

### 6. Database & Infrastructure

- ✅ Migration: InitialCreate với 12 tables
- ✅ Seed data: 3 Roles, 4 Categories
- ✅ Docker Compose: PostgreSQL 16 Alpine với health check
- ✅ Dependency Injection: DbContext, Repositories, Services

### 7. Tài liệu dự án

- README.md, .gitignore, QUICKSTART.md
- Kiến trúc 3 lớp với sơ đồ
- Hướng dẫn cài đặt và database schema

---

## 📊 Thống kê Code

| **Metric**                     | **Số lượng**  |
| ------------------------------ | ------------- |
| **Total Projects**             | 4 projects    |
| **Total C# Files**             | 69 files      |
| **Entity Models**              | 12 entities   |
| **Repository Interfaces**      | 13 interfaces |
| **Repository Implementations** | 13 classes    |
| **Service Interfaces**         | 5 interfaces  |
| **Service Implementations**    | 5 classes     |
| **Database Tables**            | 12 tables     |
| **Migrations**                 | 1 migration   |
| **NuGet Packages**             | 5 packages    |
| **Git Commits**                | 8 commits     |

---

## 🎯 Kết quả đạt được

1. ✅ **Kiến trúc vững chắc**: 3-Layer Architecture với Repository & Unit of Work Pattern
2. ✅ **Clean Code**: Code tổ chức tốt, dễ maintain
3. ✅ **Database Design**: 12 tables với relationships rõ ràng
4. ✅ **Docker Ready**: PostgreSQL setup nhanh với Docker Compose
5. ✅ **Documentation**: Tài liệu đầy đủ, dễ setup

---

## 🚀 Kế hoạch tuần 2

1. **Presentation Layer**

   - [ ] Layout chung, trang Home, Products listing
   - [ ] Product details page
   - [ ] Responsive design với Bootstrap

2. **Authentication & Authorization**

   - [ ] Login/Register pages
   - [ ] Cookie Authentication
   - [ ] Role-based authorization

3. **Customer Features**
   - [ ] Shopping Cart UI
   - [ ] Add to cart functionality
   - [ ] Product search & filter

---

## 📝 Ghi chú

**Điểm mạnh:**

- ✅ Backend infrastructure hoàn chỉnh với clean architecture
- ✅ Repository Pattern và Unit of Work được triển khai đúng
- ✅ Code quality tốt, follow best practices

**Cần hoàn thiện:**

- ⚠️ Frontend UI (Razor Pages)
- ⚠️ Authentication UI và Cookie Auth
- ⚠️ Error Handling middleware
- ⚠️ Input validation và Unit Tests

---

**Ngày báo cáo:** 11/11/2025  
**Tỷ lệ hoàn thành:** 100% (Backend Infrastructure)
