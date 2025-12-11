# 🧋 MilkTea Website - Website Bán Trà Sữa Trực Tuyến

## 📋 Mô Tả Dự Án

Website bán trà sữa trực tuyến đầy đủ tính năng, cho phép:

- **Khách hàng**: Xem sản phẩm, thêm vào giỏ hàng, tùy chỉnh topping, đặt hàng và thanh toán
- **Nhân viên**: Quản lý đơn hàng, cập nhật trạng thái giao hàng
- **Quản trị viên**: Quản lý sản phẩm, danh mục, người dùng, thống kê doanh thu

**Công nghệ sử dụng:**

- **Backend**: ASP.NET Core 9.0 với Razor Pages
- **Database**: PostgreSQL 16 (Docker)
- **ORM**: Entity Framework Core 9.0
- **Authentication**: Cookie-based Authentication với BCrypt
- **Architecture**: Repository Pattern + Unit of Work
- **UI Framework**: Bootstrap 5

**Thông tin đồ án:**

- **Sinh viên**: Phạm Minh Thu Trang (MSSV: 470123172)
- **Lớp**: VX23TTK13 - Lập trình Web ASP.NET
- **Năm học**: 2024-2025

---

## � Yêu Cầu Hệ Thống

Trước khi bắt đầu, cần cài đặt các công cụ sau:

### ✅ Git

- **Windows**: Tải từ [git-scm.com](https://git-scm.com/download/win)
- **macOS**: `brew install git` hoặc tải từ [git-scm.com](https://git-scm.com/download/mac)
- **Linux**: `sudo apt install git` hoặc `sudo yum install git`

### ✅ .NET SDK 9.0+

- **Tải từ**: [dotnet.microsoft.com/download/dotnet/9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- **macOS với Homebrew**: `brew install dotnet-sdk`
- **Kiểm tra**: `dotnet --version` (phải >= 9.0)

### ✅ Docker Desktop

- **Windows**: Tải từ [docker.com/products/docker-desktop](https://www.docker.com/products/docker-desktop)
  - Yêu cầu WSL 2: `wsl --install` trong PowerShell (Admin)
- **macOS**: Tải từ [docker.com/products/docker-desktop](https://www.docker.com/products/docker-desktop)
- **Linux**: `sudo apt install docker.io docker-compose`
- **Kiểm tra**: `docker --version` và `docker-compose --version`

### ✅ .NET EF Core Tools (để chạy migrations)

```bash
dotnet tool install --global dotnet-ef
```

Kiểm tra: `dotnet ef --version`

---

## 🚀 Hướng Dẫn Cài Đặt và Chạy (Từ Đầu)

### Bước 1: Clone Repository

```bash
git clone https://github.com/ThuTrang89-tvu/ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite.git
cd ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite
```

### Bước 2: Khởi Động PostgreSQL Database

```bash
cd docker
docker-compose up -d
```

Đợi 5-10 giây để PostgreSQL khởi động hoàn tất. Kiểm tra:

```bash
docker ps
```

Bạn sẽ thấy container `milktea_postgres` đang chạy.

### Bước 3: Apply Migrations (Tạo Database Schema & Seed Data)

```bash
cd ../src/MilkTeaWebsite/MilkTeaWebsite.DAL
dotnet ef database update --startup-project ../MilkTeaWebsite
```

Migration sẽ tự động:

- Tạo tất cả các bảng (Users, Products, Categories, Orders, Cart, Toppings, v.v.)
- Seed dữ liệu mẫu (5 categories, 15 products, 6 toppings, 1 admin user)

### Bước 4: Trust HTTPS Certificate (Chỉ chạy 1 lần)

```bash
dotnet dev-certs https --trust
```

Nhấn **Yes** khi hệ thống hỏi.

### Bước 5: Chạy Ứng Dụng

```bash
cd ../MilkTeaWebsite
dotnet run --launch-profile https
```

Mở trình duyệt và truy cập:

- **HTTPS**: https://localhost:7284
- **HTTP**: http://localhost:5006

### Bước 6: Đăng Nhập

**Tài khoản Admin mặc định:**

- **Email**: admin@milktea.com
- **Password**: Admin@123

**Tài khoản khác** (tạo trong seed data nếu có) hoặc đăng ký mới từ trang web.

---

## 🛠️ Các Lệnh Hữu Ích

### Dừng và Khởi Động Lại Database

```bash
# Dừng
cd docker
docker-compose down

# Khởi động lại
docker-compose up -d
```

### Reset Database (Xóa Toàn Bộ Data)

```bash
cd docker
docker-compose down -v  # Xóa cả volumes
docker-compose up -d    # Tạo lại container

# Apply migrations lại
cd ../src/MilkTeaWebsite/MilkTeaWebsite.DAL
```

### Tạo Migration Mới

```bash
cd src/MilkTeaWebsite/MilkTeaWebsite.DAL
dotnet ef migrations add TenMigration --startup-project ../MilkTeaWebsite
dotnet ef database update --startup-project ../MilkTeaWebsite
```

### Xem Dữ Liệu Trong Database

```bash
docker exec -it milktea_postgres psql -U milktea_user -d MilkTeaDb

# Trong psql:
\dt              # Xem danh sách bảng
SELECT * FROM "Products";
\q               # Thoát
```

---

## 📂 Cấu Trúc Dự Án

```
ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite/
├── docker/
│   └── docker-compose.yml          # Cấu hình PostgreSQL
├── src/
│   └── MilkTeaWebsite/
│       ├── MilkTeaWebsite/         # Web Application (Razor Pages)
│       │   ├── Pages/              # Razor Pages UI
│       │   │   ├── Customer/       # Trang khách hàng
│       │   │   ├── Staff/          # Trang nhân viên
│       │   │   └── Account/        # Đăng nhập/Đăng ký
│       │   ├── wwwroot/            # Static files (CSS, JS, images)
│       │   └── Program.cs          # Entry point
│       ├── MilkTeaWebsite.BLL/     # Business Logic Layer
│       │   ├── Interfaces/         # Service interfaces
│       │   └── Implements/         # Service implementations
│       ├── MilkTeaWebsite.DAL/     # Data Access Layer
│       │   ├── Context/            # DbContext
│       │   ├── Interfaces/         # Repository interfaces
│       │   ├── Implements/         # Repository implementations
│       │   ├── Migrations/         # EF Core Migrations
│       │   └── Seed/               # Seed data
│       └── MilkTeaWebsite.Entity/  # Entity Models
│           └── Entity/             # Domain entities
├── progress-report/                # Báo cáo tiến độ hàng tuần
└── README.md
```

---

## � Tính Năng Chính

### Khách Hàng

- ✅ Xem danh sách sản phẩm theo danh mục
- ✅ Tìm kiếm sản phẩm
- ✅ Xem chi tiết sản phẩm với topping
- ✅ Thêm vào giỏ hàng (chọn size, số lượng, topping)
- ✅ Quản lý giỏ hàng (cập nhật số lượng, xóa)
- ✅ Thanh toán và đặt hàng
- ✅ Xem lịch sử đơn hàng

### Nhân Viên

- ✅ Xem danh sách đơn hàng
- ✅ Cập nhật trạng thái đơn hàng (Đang xử lý → Đang giao → Hoàn thành)
- ✅ Xem chi tiết đơn hàng

### Quản Trị Viên

- ✅ Quản lý sản phẩm (CRUD)
- ✅ Quản lý danh mục (CRUD)
- ✅ Quản lý người dùng
- ✅ Thống kê doanh thu

---

## 🔐 Tài Khoản Mặc Định

Sau khi seed data, bạn có thể đăng nhập bằng:

**Admin:**

- Email: `admin@milktea.com`
- Password: `Admin@123`
- Quyền: Full access (quản lý sản phẩm, đơn hàng, người dùng)

---

## 🐛 Xử Lý Lỗi Thường Gặp

### ❌ Lỗi: "Port 5432 already in use"

**Nguyên nhân:** PostgreSQL đã chạy trên máy hoặc Docker container cũ còn tồn tại

**Giải pháp:**

```bash
# Kiểm tra và dừng container cũ
docker ps -a
docker stop milktea_postgres
docker rm milktea_postgres

# Hoặc dừng PostgreSQL service trên máy
# macOS:
brew services stop postgresql

# Windows: Mở Services và stop PostgreSQL
```

### ❌ Lỗi: "Docker daemon is not running"

**Giải pháp:** Mở **Docker Desktop** và đợi biểu tượng chuyển màu xanh (Ready)

### ❌ Lỗi: "Unable to connect to database"

**Giải pháp:**

```bash
# 1. Kiểm tra container đang chạy
docker ps

# 2. Kiểm tra logs
docker logs milktea_postgres

# 3. Restart container
cd docker
docker-compose restart

# 4. Đợi 5 giây rồi test connection
docker exec milktea_postgres pg_isready -U milktea_user -d MilkTeaDb
```

### ❌ Lỗi: "Port 7284 already in use"

**Nguyên nhân:** Có process khác đang dùng port hoặc app đang chạy

**Giải pháp:**

```bash
# macOS/Linux: Tìm và kill process
lsof -i :7284
kill -9 <PID>

# Windows:
netstat -ano | findstr :7284
taskkill /PID <PID> /F
```

### ❌ Lỗi: "Migration already applied"

**Giải pháp:** Không cần làm gì, database đã được cập nhật rồi

### ❌ Lỗi: "HTTPS certificate not trusted"

**Giải pháp:**

```bash
# Trust lại certificate
dotnet dev-certs https --clean
dotnet dev-certs https --trust

# Restart browser sau khi trust
```

---

## 🧪 Test Ứng Dụng

### 1. Test Đăng Nhập

- Truy cập: https://localhost:7284/Account/Login
- Đăng nhập với `admin@milktea.com` / `Admin@123`
- Xác nhận redirect về trang chủ và hiển thị tên user

### 2. Test Giỏ Hàng

- Xem sản phẩm → Chọn size, topping → Thêm vào giỏ
- Vào giỏ hàng → Thay đổi số lượng → Verify giá cập nhật
- Xóa sản phẩm → Verify confirm dialog

### 3. Test Đặt Hàng

- Thêm sản phẩm vào giỏ → Thanh toán
- Điền thông tin giao hàng → Đặt hàng
- Kiểm tra order trong database:

```bash
docker exec -it milktea_postgres psql -U milktea_user -d MilkTeaDb -c "SELECT * FROM \"Orders\" ORDER BY \"Id\" DESC LIMIT 5;"
```

---

## 📚 Tài Liệu Tham Khảo

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Docker Documentation](https://docs.docker.com/)
- [Bootstrap 5](https://getbootstrap.com/docs/5.0/)

---

## 📝 Ghi Chú Quan Trọng

⚠️ **Development Mode**: Ứng dụng đang chạy ở chế độ Development với:

- Sensitive data logging enabled
- HTTPS self-signed certificate
- Không nên deploy production với config này

🔒 **Security**:

- Đổi password mặc định trong production
- Cập nhật connection string trong `appsettings.json`
- Enable HTTPS trong production

💾 **Data Persistence**:

- Dữ liệu lưu trong Docker volume `docker_postgres_data`
- Chạy `docker-compose down -v` sẽ XÓA TOÀN BỘ dữ liệu
- Backup định kỳ bằng `pg_dump` nếu cần

---

## 👥 Liên Hệ

**Sinh viên thực hiện:** Phạm Minh Thu Trang  
**MSSV:** 470123172  
**Lớp:** VX23TTK13 - Lập trình Web ASP.NET  
**Trường:** Trường Đại học Trà Vinh

---

## 📜 License

Dự án này được phát triển cho mục đích học tập và nghiên cứu.

---

**🎉 Chúc bạn code vui vẻ!**

```bash
# Kiểm tra PostgreSQL đang chạy
docker compose ps

# Xem logs để debug
docker compose logs postgres

# Khởi động lại nếu cần
docker compose restart
```

### ❌ Lỗi: "dotnet-ef command not found"

**Giải pháp:**

```bash
# Cài đặt EF Core Tools
dotnet tool install --global dotnet-ef

# Hoặc update nếu đã cài
dotnet tool update --global dotnet-ef
```

### ❌ Lỗi migration hoặc seed data

**Giải pháp:** Xóa database và tạo lại từ đầu (xem phần "Làm sạch và chạy lại từ đầu" ở trên)

---

## 📚 Chức Năng Chính

### 🛍️ Khách Hàng

- Xem và tìm kiếm sản phẩm trà sữa
- Thêm sản phẩm vào giỏ hàng, chọn size (S/M/L) và topping
- Đặt hàng và theo dõi trạng thái đơn hàng
- Quản lý tài khoản cá nhân

### 👨‍💼 Nhân Viên

- Xem và xử lý đơn hàng mới
- Cập nhật trạng thái đơn hàng (Đang chuẩn bị → Đang giao → Hoàn thành)
- Quản lý sản phẩm và tồn kho

### 👨‍💻 Quản Trị Viên

- Quản lý sản phẩm (thêm/sửa/xóa)
- Quản lý danh mục và topping
- Quản lý người dùng và phân quyền
- Xem báo cáo doanh thu và thống kê

---

## 📁 Cấu Trúc Dự Án

```
├── docker/                          # Docker Compose cho PostgreSQL
│   └── docker-compose.yml
├── src/
│   └── MilkTeaWebsite/
│       ├── MilkTeaWebsite/          # Web Application (Razor Pages)
│       ├── MilkTeaWebsite.BLL/      # Business Logic Layer
│       ├── MilkTeaWebsite.DAL/      # Data Access Layer
│       └── MilkTeaWebsite.Entity/   # Domain Models
└── README.md
```

**Kiến trúc 3 lớp:**

- **Presentation Layer** (MilkTeaWebsite): Giao diện người dùng
- **Business Logic Layer** (BLL): Xử lý logic nghiệp vụ
- **Data Access Layer** (DAL): Tương tác với database

---

## 📞 Liên Hệ

**Sinh viên:** Phạm Minh Thu Trang  
**MSSV:** 470123172  
**GitHub:** [@ThuTrang89-tvu](https://github.com/ThuTrang89-tvu)

---

## 📄 License

Dự án phát triển cho mục đích học tập tại Trường Đại học Trà Vinh.

**Cập nhật:** Tháng 12, 2025
