# 🧋 MilkTea Website - Website Bán Trà Sữa Trực Tuyến

## 📋 Giới thiệu

Website bán trà sữa trực tuyến được xây dựng bằng **ASP.NET Core 9.0**, cho phép khách hàng đặt hàng online và quản trị viên quản lý sản phẩm, đơn hàng hiệu quả.

**Công nghệ:** ASP.NET Core 9.0 • PostgreSQL 16 • Docker • Entity Framework Core

**Thông tin đồ án:**

- **Sinh viên:** Phạm Minh Thu Trang (MSSV: 470123172)
- **Lớp:** VX23TTK13 - Lập trình Web ASP.NET
- **Năm học:** 2024-2025

---

## 🚀 Hướng Dẫn Cài Đặt và Chạy

### Bước 1️⃣: Cài Đặt Các Công Cụ Cần Thiết

#### 1.1. Cài đặt .NET SDK 9.0

**Windows:**

- Truy cập: https://dotnet.microsoft.com/download/dotnet/9.0
- Tải **SDK 9.0** (không phải Runtime)
- Chạy file cài đặt và làm theo hướng dẫn
- Mở Command Prompt/PowerShell mới và kiểm tra:

```bash
dotnet --version
```

**macOS:**

```bash
# Cài bằng Homebrew
brew install dotnet-sdk

# Kiểm tra
dotnet --version
```

#### 1.2. Cài đặt Docker Desktop

Docker sẽ chạy PostgreSQL database.

**Windows:**

1. Bật WSL 2 (mở PowerShell với quyền Admin):
   ```powershell
   wsl --install
   ```
2. Khởi động lại máy
3. Tải Docker Desktop: https://www.docker.com/products/docker-desktop/
4. Cài đặt và khởi động Docker Desktop
5. Đợi biểu tượng Docker ở system tray chuyển màu xanh

**macOS:**

1. Tải Docker Desktop:
   - Intel Mac: https://desktop.docker.com/mac/main/amd64/Docker.dmg
   - Apple Silicon (M1/M2/M3): https://desktop.docker.com/mac/main/arm64/Docker.dmg
2. Kéo Docker.app vào thư mục Applications
3. Mở Docker từ Applications

**Kiểm tra:**

```bash
docker --version
docker compose version
```

#### 1.3. Cài đặt Git

**Windows:**

- Tải từ: https://git-scm.com/download/win
- Cài đặt với các tùy chọn mặc định

**macOS:**

```bash
brew install git
```

**Kiểm tra:**

```bash
git --version
```

---

### Bước 2️⃣: Clone Dự Án Về Máy

Mở Terminal (macOS/Linux) hoặc Command Prompt/PowerShell (Windows):

```bash
# Clone dự án từ GitHub
git clone https://github.com/ThuTrang89-tvu/ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite.git

# Vào thư mục dự án
cd ASPNET-VX23TTK13-phamminhthutrang-MilkTeaWebsite
```

---

### Bước 3️⃣: Khởi Động PostgreSQL Database

```bash
# Vào thư mục docker
cd docker

# Khởi động PostgreSQL bằng Docker Compose
docker compose up -d

# Kiểm tra container đã chạy chưa
docker compose ps
```

**Kết quả mong đợi:**

```
NAME                 IMAGE               STATUS
milktea_postgres     postgres:16-alpine  Up
```

**Thông tin database:**

- Host: `localhost:5432`
- Database: `MilkTeaDb`
- Username: `milktea_user`
- Password: `MilkTea@2025`

---

### Bước 4️⃣: Cài Đặt Dependencies và Tạo Database

```bash
# Quay về thư mục gốc
cd ..

# Vào thư mục solution
cd src/MilkTeaWebsite

# Restore các NuGet packages
dotnet restore

# Vào thư mục project chính
cd MilkTeaWebsite

# Cài đặt EF Core Tools (nếu chưa có)
dotnet tool install --global dotnet-ef

# Tạo database và chạy migrations
cd ../MilkTeaWebsite.DAL
dotnet ef database update --startup-project ../MilkTeaWebsite
```

**Giải thích:**

- `dotnet restore`: Tải các thư viện cần thiết
- `dotnet-ef`: Công cụ để làm việc với database
- `database update`: Tạo bảng và cấu trúc database

---

### Bước 5️⃣: Chạy Ứng Dụng Với HTTPS

```bash
# Quay về thư mục project web
cd ../MilkTeaWebsite

# Tin cậy HTTPS certificate cho development (chỉ chạy 1 lần)
dotnet dev-certs https --trust

# Chạy ứng dụng với HTTPS
dotnet run --launch-profile https
```

**Kết quả:**

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7284
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5006
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

---

### Bước 6️⃣: Truy Cập Website

Mở trình duyệt và truy cập:

🔐 **HTTPS (Khuyến nghị):** https://localhost:7284

🌐 **HTTP:** http://localhost:5006

**Lưu ý:** Nếu trình duyệt báo cảnh báo certificate, chọn "Advanced" → "Proceed to localhost" (an toàn vì đây là development).

---

### Bước 7️⃣: Dừng Ứng Dụng

**Dừng web app:**

- Nhấn `Ctrl + C` trong terminal đang chạy

**Dừng PostgreSQL:**

```bash
cd docker
docker compose down
```

**Khởi động lại PostgreSQL (khi cần):**

```bash
cd docker
docker compose up -d
```

---

## 🎯 Tóm Tắt Các Lệnh Quan Trọng

### Chạy ứng dụng hàng ngày:

```bash
# 1. Khởi động PostgreSQL (nếu chưa chạy)
cd docker
docker compose up -d

# 2. Chạy web app với HTTPS
cd ../src/MilkTeaWebsite/MilkTeaWebsite
dotnet run --launch-profile https
```

### Làm sạch và chạy lại từ đầu:

```bash
# 1. Dừng và xóa PostgreSQL container + data
cd docker
docker compose down -v

# 2. Khởi động lại PostgreSQL
docker compose up -d

# 3. Clean project
cd ../src/MilkTeaWebsite
dotnet clean

# 4. Xóa migrations cũ (nếu có lỗi)
cd MilkTeaWebsite.DAL
rm -rf Migrations/*

# 5. Tạo migration mới
dotnet ef migrations add InitialCreate --startup-project ../MilkTeaWebsite

# 6. Update database
dotnet ef database update --startup-project ../MilkTeaWebsite

# 7. Chạy app
cd ../MilkTeaWebsite
dotnet run --launch-profile https
```

---

## 🐛 Xử Lý Lỗi Thường Gặp

### ❌ Lỗi: "Port 5432 already in use"

**Nguyên nhân:** PostgreSQL đang chạy trên máy

**Giải pháp:**

```bash
# macOS/Linux: Giải phóng port
lsof -i :5432
kill -9 <PID>

# Windows: Tìm và dừng process
netstat -ano | findstr :5432
taskkill /PID <PID> /F
```

### ❌ Lỗi: "Docker daemon is not running"

**Giải pháp:** Mở Docker Desktop và đợi khởi động hoàn tất

### ❌ Lỗi: "Unable to connect to database"

**Giải pháp:**

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
