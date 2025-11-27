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

## 📖 Tổng quan dự án

### Mô tả

Hệ thống website bán trà sữa trực tuyến được xây dựng bằng ASP.NET Core, cung cấp nền tảng thương mại điện tử hoàn chỉnh cho cửa hàng trà sữa. Hệ thống cho phép khách hàng đặt mua sản phẩm trực tuyến, tùy chỉnh đơn hàng và theo dõi trạng thái giao hàng. Đồng thời, cung cấp các công cụ quản trị mạnh mẽ cho admin và nhân viên để vận hành cửa hàng hiệu quả.

### Công nghệ sử dụng

- **Framework:** ASP.NET Core 9.0 (Razor Pages)
- **Ngôn ngữ:** C# (.NET 9.0)
- **ORM:** Entity Framework Core 9.0
- **Database:** PostgreSQL 16
- **Container:** Docker & Docker Compose
- **Frontend:** Bootstrap 5, jQuery, Razor Pages

### Kiến trúc hệ thống

Dự án áp dụng kiến trúc 3 lớp (3-Layer Architecture) kết hợp với các Design Patterns:

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

**Giải thích các tầng:**

1. **Presentation Layer (MilkTeaWebsite):** 
   - Giao diện người dùng sử dụng Razor Pages
   - Xử lý HTTP requests/responses
   - Hiển thị dữ liệu cho người dùng

2. **Business Logic Layer (MilkTeaWebsite.BLL):**
   - Chứa các service xử lý logic nghiệp vụ
   - Validate dữ liệu trước khi lưu
   - Xử lý các quy tắc kinh doanh

3. **Data Access Layer (MilkTeaWebsite.DAL):**
   - Repository Pattern để tương tác với database
   - Unit of Work để quản lý transaction
   - Entity Framework Core làm ORM

4. **Entity Layer (MilkTeaWebsite.Entity):**
   - Định nghĩa các domain models
   - POCOs (Plain Old CLR Objects)
   - Mapping với database tables

---

## 👥 Chức năng theo Actor

### 🛍️ Khách hàng (Customer)

#### Quản lý tài khoản
- Đăng ký tài khoản mới
- Đăng nhập/Đăng xuất
- Xem và cập nhật thông tin cá nhân
- Đổi mật khẩu

#### Duyệt và tìm kiếm sản phẩm
- Xem danh sách sản phẩm theo danh mục (trà sữa, trà trái cây, topping...)
- Tìm kiếm sản phẩm theo tên
- Lọc sản phẩm theo giá, danh mục
- Xem chi tiết sản phẩm (mô tả, giá, hình ảnh)

#### Giỏ hàng và đặt hàng
- Thêm sản phẩm vào giỏ hàng
- Tùy chỉnh size (S, M, L)
- Thêm/bớt topping (trân châu, thạch, pudding...)
- Điều chỉnh số lượng sản phẩm trong giỏ
- Xóa sản phẩm khỏi giỏ hàng
- Đặt hàng và nhập thông tin giao hàng
- Chọn phương thức thanh toán

#### Quản lý đơn hàng
- Xem lịch sử đơn hàng
- Theo dõi trạng thái đơn hàng
- Xem chi tiết đơn hàng
- Hủy đơn hàng (nếu chưa xác nhận)

### 👨‍💼 Nhân viên (Staff)

#### Quản lý đơn hàng
- Xem danh sách đơn hàng mới
- Cập nhật trạng thái đơn hàng:
  - Chờ xác nhận → Đang chuẩn bị
  - Đang chuẩn bị → Đang giao
  - Đang giao → Đã giao
  - Hủy đơn hàng (với lý do)
- Xem chi tiết đơn hàng
- In hóa đơn

#### Quản lý sản phẩm
- Xem danh sách sản phẩm
- Cập nhật trạng thái sản phẩm (còn hàng/hết hàng)
- Cập nhật giá sản phẩm

#### Quản lý khách hàng
- Xem danh sách khách hàng
- Xem lịch sử mua hàng của khách hàng
- Hỗ trợ khách hàng

### 👨‍💻 Quản trị viên (Admin)

#### Quản lý sản phẩm (CRUD đầy đủ)
- Thêm sản phẩm mới
- Chỉnh sửa thông tin sản phẩm
- Xóa sản phẩm
- Upload/thay đổi hình ảnh sản phẩm
- Quản lý giá theo size

#### Quản lý danh mục
- Thêm/sửa/xóa danh mục sản phẩm
- Sắp xếp thứ tự hiển thị danh mục

#### Quản lý người dùng
- Xem danh sách tất cả người dùng
- Tạo tài khoản nhân viên
- Phân quyền người dùng (Admin/Staff/Customer)
- Khóa/mở khóa tài khoản
- Reset mật khẩu người dùng

#### Quản lý đơn hàng
- Xem tất cả đơn hàng
- Lọc đơn hàng theo trạng thái, ngày
- Cập nhật trạng thái đơn hàng
- Xử lý đơn hàng có vấn đề

#### Báo cáo và thống kê
- Dashboard tổng quan:
  - Doanh thu theo ngày/tháng/năm
  - Số lượng đơn hàng
  - Sản phẩm bán chạy
  - Khách hàng mới
- Báo cáo doanh thu chi tiết
- Thống kê sản phẩm bán chạy nhất
- Thống kê khách hàng thân thiết
- Xuất báo cáo (PDF/Excel)

---

## � Hướng dẫn cài đặt và chạy ứng dụng

### Yêu cầu hệ thống

Hướng dẫn này dành cho máy tính **chưa cài đặt gì**, sẽ hướng dẫn chi tiết từng bước.

**Hệ điều hành hỗ trợ:**
- Windows 10/11
- macOS (Intel hoặc Apple Silicon)
- Linux (Ubuntu, Debian, Fedora...)

### Bước 1: Cài đặt Git

#### Windows:
1. Tải Git từ: https://git-scm.com/download/win
2. Chạy file cài đặt, chọn "Next" cho tất cả các bước
3. Sau khi cài, mở **Command Prompt** hoặc **PowerShell** và kiểm tra:
```bash
git --version
```

#### macOS:
```bash
# Cài Homebrew (nếu chưa có)
/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"

# Cài Git
brew install git

# Kiểm tra
git --version
```

#### Linux (Ubuntu/Debian):
```bash
sudo apt update
sudo apt install git -y
git --version
```

### Bước 2: Cài đặt Docker và Docker Compose

Docker sẽ chạy PostgreSQL database cho ứng dụng.

#### Windows:

1. **Bật WSL 2** (Windows Subsystem for Linux):
   - Mở PowerShell với quyền Administrator
   ```powershell
   wsl --install
   ```
   - Khởi động lại máy tính

2. **Tải và cài Docker Desktop:**
   - Tải từ: https://www.docker.com/products/docker-desktop/
   - Chạy file cài đặt
   - Khởi động Docker Desktop
   - Đợi Docker khởi động hoàn tất (biểu tượng Docker ở system tray chuyển sang màu xanh)

3. **Kiểm tra:**
```bash
docker --version
docker-compose --version
```

#### macOS:

1. **Tải Docker Desktop cho Mac:**
   - Intel: https://desktop.docker.com/mac/main/amd64/Docker.dmg
   - Apple Silicon (M1/M2/M3): https://desktop.docker.com/mac/main/arm64/Docker.dmg

2. **Cài đặt:**
   - Mở file .dmg đã tải
   - Kéo Docker vào thư mục Applications
   - Mở Docker từ Applications
   - Cho phép các quyền cần thiết

3. **Kiểm tra:**
```bash
docker --version
docker compose version
```

#### Linux (Ubuntu/Debian):

```bash
# Cài đặt các gói cần thiết
sudo apt update
sudo apt install apt-transport-https ca-certificates curl software-properties-common -y

# Thêm GPG key của Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Thêm Docker repository
echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Cài Docker
sudo apt update
sudo apt install docker-ce docker-ce-cli containerd.io docker-compose-plugin -y

# Cho phép user hiện tại sử dụng Docker không cần sudo
sudo usermod -aG docker $USER

# Đăng xuất và đăng nhập lại, sau đó kiểm tra
docker --version
docker compose version
```

### Bước 3: Cài đặt .NET SDK 9.0

#### Windows:

1. Tải .NET 9.0 SDK từ: https://dotnet.microsoft.com/download/dotnet/9.0
2. Chọn phiên bản **SDK** (không phải Runtime)
3. Chạy file cài đặt
4. Sau khi cài, mở Command Prompt mới và kiểm tra:
```bash
dotnet --version
```

#### macOS:

```bash
# Sử dụng Homebrew
brew install dotnet-sdk

# Hoặc tải trực tiếp:
# - Intel: https://dotnet.microsoft.com/download/dotnet/9.0
# - Apple Silicon: Chọn ARM64

# Kiểm tra
dotnet --version
```

#### Linux (Ubuntu/Debian):

```bash
# Thêm Microsoft package repository
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Cài .NET SDK
sudo apt update
sudo apt install dotnet-sdk-9.0 -y

# Kiểm tra
dotnet --version
```

### Bước 4: Clone repository

```bash
# Clone dự án từ GitHub
git clone https://github.com/ThuTrang89-tvu/ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite.git

# Di chuyển vào thư mục dự án
cd ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite
```

### Bước 5: Khởi động PostgreSQL Database

```bash
# Di chuyển vào thư mục docker
cd docker

# Khởi động PostgreSQL container
docker compose up -d

# Kiểm tra container đang chạy
docker compose ps

# Xem logs (nếu cần)
docker compose logs
```

**Thông tin kết nối Database:**
- Host: `localhost`
- Port: `5432`
- Database: `MilkTeaDb`
- Username: `milktea_user`
- Password: `MilkTea@2025`

### Bước 6: Khôi phục NuGet Packages

```bash
# Quay về thư mục gốc
cd ..

# Di chuyển vào thư mục solution
cd src/MilkTeaWebsite

# Restore tất cả NuGet packages
dotnet restore

# Kiểm tra có lỗi gì không
dotnet build
```

### Bước 7: Chạy Database Migrations (Nếu có)

```bash
# Di chuyển vào project Web
cd MilkTeaWebsite

# Chạy migrations để tạo database schema
dotnet ef database update

# Nếu gặp lỗi "ef command not found", cài đặt EF Core tools:
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

### Bước 8: Chạy ứng dụng

```bash
# Đảm bảo đang ở thư mục MilkTeaWebsite
# (src/MilkTeaWebsite/MilkTeaWebsite)

# Chạy ứng dụng
dotnet run
```

**Kết quả mong đợi:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

### Bước 9: Truy cập ứng dụng

Mở trình duyệt web và truy cập:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001

**Lưu ý:** Lần đầu truy cập HTTPS có thể báo cảnh báo certificate không an toàn, chọn "Advanced" → "Proceed" (do sử dụng self-signed certificate).

### Bước 10: Dừng ứng dụng

- **Dừng web app:** Nhấn `Ctrl + C` trong terminal đang chạy `dotnet run`
- **Dừng PostgreSQL:**
```bash
cd docker
docker compose down
```

---

## 🔧 Các lệnh hữu ích

### Quản lý Database

```bash
# Xem logs của PostgreSQL
cd docker
docker compose logs postgres

# Truy cập PostgreSQL CLI
docker exec -it milktea_postgres psql -U milktea_user -d MilkTeaDb

# Backup database
docker exec milktea_postgres pg_dump -U milktea_user MilkTeaDb > backup.sql

# Restore database
docker exec -i milktea_postgres psql -U milktea_user -d MilkTeaDb < backup.sql
```

### Quản lý Migrations

```bash
# Tạo migration mới
dotnet ef migrations add <TenMigration>

# Xem danh sách migrations
dotnet ef migrations list

# Cập nhật database
dotnet ef database update

# Rollback về migration trước
dotnet ef database update <TenMigration>

# Xóa migration cuối cùng (chưa apply)
dotnet ef migrations remove
```

### Build và Clean

```bash
# Build solution
dotnet build

# Build ở chế độ Release
dotnet build --configuration Release

# Clean build artifacts
dotnet clean

# Restore + Build
dotnet build --no-restore
```

---

## 🐛 Xử lý sự cố thường gặp

### 1. "Port 5432 already in use"
**Nguyên nhân:** Đã có PostgreSQL khác đang chạy trên port 5432

**Giải pháp:**
```bash
# Windows: Tìm và kill process
netstat -ano | findstr :5432
taskkill /PID <PID> /F

# macOS/Linux
lsof -i :5432
kill -9 <PID>

# Hoặc thay đổi port trong docker-compose.yml
ports:
  - "5433:5432"  # Dùng port 5433 thay vì 5432
```

### 2. "Docker daemon is not running"
**Giải pháp:** Khởi động Docker Desktop hoặc Docker service
```bash
# Linux
sudo systemctl start docker

# macOS/Windows: Mở Docker Desktop application
```

### 3. "Unable to resolve service for type DbContext"
**Nguyên nhân:** Chưa đăng ký DbContext trong Dependency Injection

**Giải pháp:** Kiểm tra file `Program.cs` có dòng:
```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### 4. "Connection string not found"
**Giải pháp:** Kiểm tra `appsettings.json` có connection string đúng:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=MilkTeaDb;Username=milktea_user;Password=MilkTea@2025"
  }
}
```

### 5. Lỗi SSL khi chạy migrations
**Giải pháp:** Thêm `SSL Mode=Prefer` vào connection string:
```json
"DefaultConnection": "Host=localhost;Port=5432;Database=MilkTeaDb;Username=milktea_user;Password=MilkTea@2025;SSL Mode=Prefer"
```

---

## 📚 Tài liệu tham khảo

- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Docker Documentation](https://docs.docker.com/)
- [Razor Pages Tutorial](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/)

---

## 📧 Liên hệ

**Sinh viên:** Phạm Minh Thu Trang

**MSSV:** 470123172

**GitHub:** [@ThuTrang89-tvu](https://github.com/ThuTrang89-tvu)

---

## 📄 License

Dự án này được phát triển cho mục đích học tập tại Trường Đại học Trà Vinh.

---

**Cập nhật lần cuối:** Tháng 11, 2025
