# 🧋 MilkTea Website - Hệ thống quản lý và bán hàng trà sữa trực tuyến

[![.NET Version](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-336791?style=flat-square&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-Compose-2496ED?style=flat-square&logo=docker&logoColor=white)](https://www.docker.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](LICENSE)

## 📋 Thông tin đồ án

**Đề tài:** Xây dựng website bán trà sữa trực tuyến với ASP.NET Core

**Môn học:** Lập trình Web ASP.NET

**Lớp:** VX23TTK13

**Sinh viên thực hiện:** Phạm Minh Thu Trang

**MSSV:** 470123172

**Giảng viên hướng dẫn:** TS. Đoàn Phước Miền

**Năm học:** 2024-2025

---

## 📖 Mô tả dự án

Hệ thống website bán trà sữa trực tuyến được xây dựng bằng ASP.NET Core, cho phép khách hàng đặt mua các loại trà sữa, topping và theo dõi đơn hàng. Hệ thống cũng cung cấp trang quản trị cho admin và nhân viên để quản lý sản phẩm, đơn hàng và khách hàng.

### 🎯 Mục tiêu

- Xây dựng website bán hàng trực tuyến cho cửa hàng trà sữa
- Áp dụng kiến trúc 3 lớp (3-Layer Architecture) trong ASP.NET Core
- Sử dụng Entity Framework Core với PostgreSQL
- Triển khai Repository Pattern và Unit of Work Pattern
- Tích hợp Docker để đơn giản hóa việc triển khai database

### 🌟 Tính năng chính (Dự kiến)

#### Dành cho khách hàng:
- ✅ Xem danh sách sản phẩm theo danh mục
- ✅ Tìm kiếm và lọc sản phẩm
- ✅ Thêm sản phẩm vào giỏ hàng
- ✅ Tùy chỉnh size, topping cho sản phẩm
- ✅ Đặt hàng và thanh toán
- ✅ Theo dõi lịch sử đơn hàng

#### Dành cho Admin/Nhân viên:
- ✅ Quản lý sản phẩm (CRUD)
- ✅ Quản lý danh mục sản phẩm
- ✅ Quản lý đơn hàng (cập nhật trạng thái)
- ✅ Quản lý khách hàng
- ✅ Báo cáo doanh thu

---

## 🏗️ Kiến trúc hệ thống

### Kiến trúc 3 lớp (3-Layer Architecture)

```
┌─────────────────────────────────────────────────────────┐
│                  Presentation Layer                      │
│              (MilkTeaWebsite - ASP.NET Core)            │
│              Razor Pages / MVC / API Controllers        │
└─────────────────────┬───────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────┐
│                Business Logic Layer (BLL)                │
│                  (MilkTeaWebsite.BLL)                   │
│           Services: Auth, Product, Cart, Order          │
└─────────────────────┬───────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────┐
│               Data Access Layer (DAL)                    │
│                  (MilkTeaWebsite.DAL)                   │
│        Repository Pattern + Unit of Work Pattern        │
│              Entity Framework Core + PostgreSQL         │
└─────────────────────┬───────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────┐
│                    Entity Layer                          │
│                (MilkTeaWebsite.Entity)                  │
│      Domain Models: User, Product, Order, Payment       │
└─────────────────────────────────────────────────────────┘
```

### Cấu trúc thư mục

```
ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite/
├── docker/
│   └── docker-compose.yml          # Docker Compose cho PostgreSQL
├── src/
│   └── MilkTeaWebsite/
│       ├── MilkTeaWebsite/         # Presentation Layer (Web App)
│       │   ├── Pages/              # Razor Pages
│       │   ├── wwwroot/            # Static files (CSS, JS, images)
│       │   ├── appsettings.json    # Configuration
│       │   ├── Program.cs          # Application entry point
│       │   └── MilkTeaWebsite.csproj
│       │
│       ├── MilkTeaWebsite.BLL/     # Business Logic Layer
│       │   ├── Interfaces/         # Service interfaces
│       │   ├── Implements/         # Service implementations
│       │   └── MilkTeaWebsite.BLL.csproj
│       │
│       ├── MilkTeaWebsite.DAL/     # Data Access Layer
│       │   ├── Context/            # DbContext
│       │   ├── Interfaces/         # Repository interfaces
│       │   ├── Implements/         # Repository implementations
│       │   ├── Migrations/         # EF Core migrations
│       │   └── MilkTeaWebsite.DAL.csproj
│       │
│       ├── MilkTeaWebsite.Entity/  # Entity Layer
│       │   ├── Entity/             # Domain models
│       │   └── MilkTeaWebsite.Entity.csproj
│       │
│       └── MilkTeaWebsite.sln      # Solution file
│
├── progress-report/                # Báo cáo tiến độ
├── thesis/                         # Tài liệu báo cáo
└── README.md                       # File này
```

---

## 🛠️ Công nghệ sử dụng

### Backend
- **Framework:** ASP.NET Core 9.0 (Razor Pages)
- **Language:** C# (.NET 9.0)
- **ORM:** Entity Framework Core 9.0
- **Database:** PostgreSQL 16 (Alpine)
- **Container:** Docker & Docker Compose

### Frontend (Dự kiến)
- **UI Framework:** Bootstrap 5
- **JavaScript:** jQuery (đã tích hợp sẵn)
- **Template Engine:** Razor Pages

### Design Patterns
- **Repository Pattern:** Tách biệt logic truy cập dữ liệu
- **Unit of Work Pattern:** Quản lý transaction
- **Dependency Injection:** ASP.NET Core built-in DI
- **3-Layer Architecture:** Phân tách rõ ràng các tầng

---

## 📦 Cài đặt và Cấu hình

### Yêu cầu hệ thống

- **.NET SDK:** 9.0 hoặc cao hơn
- **Docker Desktop:** Để chạy PostgreSQL
- **IDE:** Visual Studio 2022, JetBrains Rider, hoặc VS Code
- **Git:** Để clone repository

### Các bước cài đặt

#### 1. Clone repository

```bash
git clone https://github.com/ThuTrang89-tvu/ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite.git
cd ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite
```

#### 2. Khởi động PostgreSQL với Docker

```bash
cd docker
docker-compose up -d
```

Kiểm tra container đang chạy:
```bash
docker-compose ps
```

Kiểm tra kết nối database:
```bash
docker exec -it milktea_postgres psql -U milktea_user -d MilkTeaDb
```

#### 3. Restore NuGet packages

```bash
cd ../src/MilkTeaWebsite
dotnet restore
```

#### 4. Build solution

```bash
dotnet build
```

#### 5. Chạy ứng dụng (sau khi có migration)

```bash
cd MilkTeaWebsite
dotnet run
```

Ứng dụng sẽ chạy tại: `http://localhost:5000` hoặc `https://localhost:5001`

## 🔧 Cấu hình

### Connection String

File: `src/MilkTeaWebsite/MilkTeaWebsite/appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=MilkTeaDb;Username=milktea_user;Password=MilkTea@2025"
  }
}
```

### Docker Compose Configuration

File: `docker/docker-compose.yml`

```yaml
services:
  postgres:
    image: postgres:16-alpine
    container_name: milktea_postgres
    environment:
      POSTGRES_DB: MilkTeaDb
      POSTGRES_USER: milktea_user
      POSTGRES_PASSWORD: MilkTea@2025
    ports:
      - "5432:5432"
```

## 📈 Tiến độ thực hiện

### ✅ Đã hoàn thành (Setup Phase)

- [x] **Khởi tạo repository GitHub**
- [x] **Tạo cấu trúc solution với 4 projects**
  - [x] MilkTeaWebsite (Presentation Layer)
  - [x] MilkTeaWebsite.BLL (Business Logic Layer)
  - [x] MilkTeaWebsite.DAL (Data Access Layer)
  - [x] MilkTeaWebsite.Entity (Entity Layer)
- [x] **Cấu hình Project References**
  - [x] Web → BLL, DAL, Entity
  - [x] BLL → DAL, Entity
  - [x] DAL → Entity
- [x] **Cài đặt NuGet Packages**
  - [x] Entity Framework Core 9.0.10
  - [x] Npgsql.EntityFrameworkCore.PostgreSQL 9.0.4
  - [x] EF Core Design Tools
- [x] **Setup Docker Compose cho PostgreSQL**
  - [x] PostgreSQL 16 Alpine
  - [x] Configure database credentials
  - [x] Volume mapping cho data persistence
  - [x] Health check configuration
- [x] **Cấu hình Connection String**
- [x] **Setup Git (.gitignore, .gitattributes)**

### 🚧 Đang thực hiện (Development Phase)

- [ ] **Entity Layer - Domain Models**
  - [ ] User, Role entities
  - [ ] Customer, Employee entities
  - [ ] Category, Product entities
  - [ ] Cart, CartItem entities
  - [ ] Order, OrderDetail entities
  - [ ] Payment entity
- [ ] **Data Access Layer - Repository Pattern**
  - [ ] ApplicationDbContext
  - [ ] Generic Repository
  - [ ] Specialized Repositories
  - [ ] Unit of Work
- [ ] **Database Migration**
  - [ ] Initial Create Migration
  - [ ] Seed Data
- [ ] **Business Logic Layer - Services**
  - [ ] AuthService
  - [ ] ProductService
  - [ ] CartService
  - [ ] OrderService
  - [ ] PaymentService
- [ ] **Dependency Injection Configuration**
  - [ ] Register DbContext
  - [ ] Register Repositories
  - [ ] Register Services

### 📅 Kế hoạch tiếp theo (UI & Features Phase)

- [ ] **Authentication & Authorization**
  - [ ] Login/Register pages
  - [ ] Role-based authorization
  - [ ] Session management
- [ ] **Customer Features**
  - [ ] Product listing page
  - [ ] Product detail page
  - [ ] Shopping cart page
  - [ ] Checkout page
  - [ ] Order history page
- [ ] **Admin Features**
  - [ ] Admin dashboard
  - [ ] Product management (CRUD)
  - [ ] Order management
  - [ ] Customer management
  - [ ] Sales reports
- [ ] **Additional Features**
  - [ ] Search & filter products
  - [ ] Payment integration (VNPay/Momo)
  - [ ] Email notifications
  - [ ] Responsive design

---

## 🗂️ Tài liệu tham khảo

### Trong repository
- `src/MilkTeaWebsite/QUICKSTART.md` - Hướng dẫn nhanh khởi động dự án
- `src/MilkTeaWebsite/DOCKER_SETUP.md` - Chi tiết về Docker setup
- `src/MilkTeaWebsite/CODE_REVIEW_RECOMMENDATIONS.md` - Đề xuất cải tiến

### Links hữu ích
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Docker Documentation](https://docs.docker.com/)
- [Repository Pattern Guide](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)

---

## 📧 Liên hệ

**Sinh viên:** Phạm Minh Thư Trang

**Email:** [Email sinh viên]

**GitHub:** [@ThuTrang89-tvu](https://github.com/ThuTrang89-tvu)

---

## 📄 License

Dự án này được phát triển cho mục đích học tập tại Trường Đại học Trà Vinh.

---

## 🙏 Lời cảm ơn

- Thầy/Cô [] - Giảng viên hướng dẫn
- Trường Đại học Trà Vinh

---

**Cập nhật lần cuối:** Tháng 11, 2025

**Phiên bản:** 0.1.0 (Setup Phase)
