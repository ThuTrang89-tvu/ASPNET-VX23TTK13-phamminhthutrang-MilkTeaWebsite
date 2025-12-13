# BÁO CÁO TUẦN 2

**Thời gian:** 11/11/2025 - 18/11/2025  
**Dự án:** Website bán trà sữa - ASP.NET Core  
**Sinh viên:** Phạm Minh Thu Trang

---

## MỤC TIÊU

- Triển khai Presentation Layer với Razor Pages
- Xây dựng Authentication & Authorization
- Implement Shopping Cart UI
- Tạo trang Customer (Products listing, Details)
- Responsive Design với Bootstrap 5

---

## CÔNG VIỆC HOÀN THÀNH

### 1. Shared Components

- \_Layout.cshtml: Navbar, Footer
- \_LoginPartial.cshtml: User menu dropdown
- CartBadge ViewComponent: Real-time cart count
- CategoryMenu ViewComponent: Category navigation

### 2. Public Pages (Customer)

**Trang đã hoàn thành:**

- Index (`/`): Trang chủ, featured products
- Products/Index: Danh sách sản phẩm, filter, search, pagination
- Products/Details: Chi tiết sản phẩm, add to cart
- Cart/Index: Giỏ hàng, update quantity, remove item
- Cart/Checkout: Thanh toán, địa chỉ giao hàng
- Account/Login: Đăng nhập
- Account/Register: Đăng ký
- Account/Profile: Thông tin cá nhân, đổi mật khẩu

### 3. Admin/Staff Pages

- Admin/Dashboard: Thống kê tổng quan
- Admin/Products: CRUD sản phẩm
- Admin/Categories: CRUD danh mục
- Admin/Orders: Quản lý đơn hàng
- Staff/Orders: Xử lý đơn hàng

### 4. Authentication & Authorization

**Cookie Authentication:**

- LoginPath: `/Account/Login`
- AccessDeniedPath: `/Account/AccessDenied`
- ExpireTimeSpan: 7 days
- SlidingExpiration: true

**Security:**

- Password hashing: BCrypt.Net
- Role-based authorization: Admin, Employee, Customer
- Remember Me functionality
- Anti-CSRF tokens
- Logout with cookie cleanup

**Authorization Policies:**

- AdminOnly: Chỉ Admin
- EmployeeOrAdmin: Employee hoặc Admin

### 5. Shopping Cart

**Features:**

- Add to cart với size (S/M/L) và topping
- Update quantity (AJAX)
- Remove item với confirmation
- Calculate total price real-time
- Session cart cho guest users
- Persistent cart cho logged-in users

### 6. Product Management

**Customer Side:**

- Grid/List view toggle
- Filter by category
- Search by name
- Sort by price/name
- Pagination (12 items/page)

**Admin Side:**

- Create product với validation
- Edit product với image preview
- Soft delete (IsDeleted flag)
- Category assignment
- Stock management

### 7. UI/UX Improvements

- Bootstrap 5 responsive design
- Mobile-friendly navigation
- Toast notifications (success/error)
- Loading spinners
- Form validation client-side
- Breadcrumb navigation

---

## THỐNG KÊ

| Metric          | Số lượng |
| --------------- | -------- |
| Razor Pages     | 18       |
| View Components | 2        |
| CSS Files       | 3        |
| JS Files        | 5        |
| Layouts         | 3        |

---

## KẾT QUẢ

**Hoàn thành:**

- ✅ Full authentication flow (Login/Register/Logout)
- ✅ Shopping cart functionality
- ✅ Product listing với filter/search
- ✅ Responsive UI với Bootstrap 5
- ✅ Role-based authorization

**Chưa hoàn thành:**

- Order tracking cho customer
- Email notifications
- Payment gateway integration

---

## KẾ HOẠCH TUẦN 3

- Cải thiện hệ thống định giá (Multi-size pricing)
- Topping management
- Order status workflow
- Email service
- Performance optimization

---

**Tỷ lệ hoàn thành:** 100% Presentation Layer & Auth
