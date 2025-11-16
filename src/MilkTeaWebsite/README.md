# Milk Tea Website - ASP.NET Core Razor Pages

Dự án website bán trà sữa với ASP.NET Core Razor Pages, Entity Framework Core và PostgreSQL.

## 📁 Cấu trúc dự án

```
MilkTeaWebsite/
├── MilkTeaWebsite.Entity/    # Entity models
├── MilkTeaWebsite.DAL/        # Data Access Layer (Repository Pattern)
├── MilkTeaWebsite.BLL/        # Business Logic Layer (Services)
└── MilkTeaWebsite/            # Razor Pages Web Application
    ├── Pages/
    │   ├── Account/           # Login, Register, Logout
    │   ├── Customer/          # Giao diện khách hàng
    │   │   ├── Products/      # Danh sách & chi tiết sản phẩm
    │   │   ├── Cart/          # Giỏ hàng
    │   │   └── Orders/        # Đơn hàng
    │   ├── Staff/             # Giao diện nhân viên
    │   │   ├── Dashboard/     # Thống kê
    │   │   ├── Orders/        # Quản lý đơn hàng
    │   │   └── Products/      # Quản lý sản phẩm
    │   └── Shared/
    │       ├── _CustomerLayout.cshtml  # Layout cho khách hàng
    │       └── _StaffLayout.cshtml     # Layout cho nhân viên
    └── wwwroot/
        ├── css/
        │   ├── customer.css   # CSS cho customer
        │   └── staff.css      # CSS cho staff
        └── js/
            └── staff.js       # JavaScript cho staff sidebar
```

## 🚀 Cài đặt và chạy

### 1. Yêu cầu
- .NET 9.0 SDK
- PostgreSQL
- IDE: Visual Studio / VS Code / Rider

### 2. Cấu hình database

Cập nhật connection string trong `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=milktea_db;Username=your_username;Password=your_password"
  }
}
```

### 3. Chạy migration

```bash
cd MilkTeaWebsite.DAL
dotnet ef database update
```

### 4. Chạy ứng dụng

```bash
cd MilkTeaWebsite
dotnet run
```

Truy cập: `https://localhost:5001` hoặc `http://localhost:5000`

## 👥 Tài khoản mặc định

### Admin/Staff (cần tạo trong database)
- Username: admin
- Password: (hash của password bạn muốn)

### Customer
- Đăng ký mới tại: `/Account/Register`

## ✨ Tính năng

### Khách hàng (Customer)
- ✅ Xem danh sách sản phẩm theo danh mục
- ✅ Xem chi tiết sản phẩm
- ✅ Chọn size, topping cho sản phẩm
- ✅ Thêm vào giỏ hàng
- ✅ Quản lý giỏ hàng (cập nhật số lượng, xóa)
- ✅ Thanh toán đơn hàng
- ✅ Xem lịch sử đơn hàng
- ✅ Xem chi tiết đơn hàng
- ✅ Hủy đơn hàng (nếu đang chờ xác nhận)

### Nhân viên (Staff/Admin)
- ✅ Dashboard với thống kê:
  - Đơn hàng mới
  - Đơn đang xử lý
  - Đơn hoàn thành hôm nay
  - Doanh thu hôm nay
  - Sản phẩm sắp hết hàng
- ✅ Quản lý đơn hàng:
  - Xem danh sách đơn hàng theo trạng thái
  - Xem chi tiết đơn hàng
  - Cập nhật trạng thái đơn hàng
  - Xác nhận đơn hàng
- ✅ Quản lý sản phẩm:
  - Xem danh sách sản phẩm
  - Xóa sản phẩm
  - (Create/Edit: cần implement thêm)

### Authentication & Authorization
- ✅ Đăng nhập với Cookie Authentication
- ✅ Đăng ký tài khoản khách hàng
- ✅ Phân quyền Customer/Staff/Admin
- ✅ Session management
- ✅ Claims-based authentication

## 🎨 Giao diện

### Customer Layout
- Navbar với menu điều hướng
- Cart badge hiển thị số lượng sản phẩm
- Footer với thông tin liên hệ
- Responsive design với Bootstrap 5
- Gradient màu đẹp mắt

### Staff Layout
- Sidebar menu cố định
- Toggle sidebar cho mobile
- Dashboard cards với thống kê
- Table views cho quản lý dữ liệu
- Professional dark theme

## 🛠️ Công nghệ sử dụng

- **Backend**: ASP.NET Core 9.0 Razor Pages
- **ORM**: Entity Framework Core 9.0
- **Database**: PostgreSQL
- **Authentication**: Cookie Authentication
- **Frontend**: 
  - Bootstrap 5
  - Font Awesome 6
  - jQuery
- **Architecture**: 
  - Repository Pattern
  - Unit of Work Pattern
  - Service Layer (BLL)

## 📝 TODO - Các tính năng cần bổ sung

### Customer
- [ ] Trang Profile/Account
- [ ] Đổi mật khẩu
- [ ] Quên mật khẩu
- [ ] Đánh giá sản phẩm
- [ ] Wishlist/Yêu thích

### Staff
- [ ] Create/Edit Product
- [ ] Quản lý danh mục
- [ ] Quản lý khách hàng
- [ ] Quản lý nhân viên
- [ ] Báo cáo chi tiết
- [ ] Export Excel
- [ ] Tích hợp thanh toán online

### Technical
- [ ] Validation chi tiết hơn
- [ ] Error handling tốt hơn
- [ ] Logging
- [ ] Unit tests
- [ ] Integration tests
- [ ] API documentation
- [ ] Caching
- [ ] Image upload

## 📞 Liên hệ

Nếu có vấn đề hoặc câu hỏi, vui lòng tạo issue trên GitHub.

## 📄 License

MIT License
