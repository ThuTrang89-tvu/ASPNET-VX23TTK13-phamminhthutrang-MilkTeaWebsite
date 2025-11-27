# Week 04 Planning - Milk Tea Website

**Project:** ASP.NET Core Milk Tea E-commerce Website  
**Student:** Phạm Minh Thư Trang  
**Start Date:** 23/11/2025  
**Week:** 04 (Tuần cuối cùng)  
**Status:** Planning

---

## 🎯 Mục tiêu tuần 04

Tuần cuối cùng tập trung vào **hoàn thiện hệ thống, kiểm thử toàn diện và viết báo cáo đồ án** theo cấu trúc mẫu. Đây là giai đoạn tổng kết, đảm bảo tất cả tính năng hoạt động ổn định và chuẩn bị tài liệu đầy đủ để nộp.

---

## 📅 Kế hoạch chi tiết

### **Ngày 1-2 (23-24/11): Payment Integration & Order Processing**

#### A. Payment Service Enhancement
- [ ] Tích hợp VNPay/Momo payment gateway (mock version)
- [ ] Tạo PaymentController với endpoints:
  - `POST /api/payment/create` - Tạo link thanh toán
  - `GET /api/payment/callback` - Xử lý callback từ gateway
  - `GET /api/payment/status/{orderId}` - Kiểm tra trạng thái
- [ ] Cập nhật PaymentService:
  - `GeneratePaymentUrl()` - Tạo URL thanh toán
  - `VerifyPaymentCallback()` - Xác thực callback
  - `UpdatePaymentStatus()` - Cập nhật trạng thái giao dịch

#### B. Order Status Management
- [ ] Tạo enum `OrderStatus`: Pending, Confirmed, Processing, Delivering, Completed, Cancelled
- [ ] Cập nhật OrderService với các phương thức:
  - `ConfirmOrderAsync()` - Nhân viên xác nhận đơn
  - `UpdateOrderStatusAsync()` - Cập nhật trạng thái
  - `CancelOrderAsync()` - Hủy đơn hàng
  - `GetOrdersByStatusAsync()` - Lọc theo trạng thái
- [ ] Thêm logic gửi email thông báo khi đơn hàng thay đổi trạng thái

#### C. Testing Payment Flow
- [ ] Test flow: Tạo đơn → Thanh toán → Callback → Cập nhật trạng thái
- [ ] Test case: Thanh toán thành công, thất bại, timeout
- [ ] Kiểm tra transaction rollback khi thanh toán thất bại

---

### **Ngày 3 (25/11): Staff & Admin Features**

#### A. Staff Dashboard
- [ ] Tạo trang Staff/Dashboard với các widgets:
  - Tổng số đơn hàng hôm nay
  - Doanh thu hôm nay
  - Đơn hàng đang chờ xử lý
  - Top 5 sản phẩm bán chạy
- [ ] Biểu đồ doanh thu theo ngày/tuần/tháng (Chart.js)

#### B. Order Management for Staff
- [ ] Trang Staff/Orders/Index:
  - Danh sách đơn hàng với filter theo Status
  - Tìm kiếm theo OrderId, Customer Name, Phone
  - Pagination với 20 đơn/trang
- [ ] Trang Staff/Orders/Details/{id}:
  - Xem chi tiết đơn hàng
  - Cập nhật trạng thái (dropdown với confirm modal)
  - In hóa đơn (PDF generation)
  - Ghi chú nội bộ

#### C. Product Management for Admin
- [ ] Trang Admin/Products/Create - Tạo sản phẩm mới
- [ ] Trang Admin/Products/Edit/{id} - Sửa sản phẩm
- [ ] Trang Admin/Products/Delete/{id} - Xóa mềm (IsDeleted = true)
- [ ] Upload ảnh sản phẩm với preview và resize
- [ ] Quản lý toppings available cho từng sản phẩm

---

### **Ngày 4 (26/11): Testing & Bug Fixes**

#### A. Functional Testing
- [ ] **Customer Flow Testing**:
  - Đăng ký → Đăng nhập → Duyệt sản phẩm → Thêm giỏ hàng → Thanh toán → Xem đơn hàng
  - Test với nhiều kịch bản: Size khác nhau, nhiều topping, ghi chú đặc biệt
  - Test cập nhật số lượng và xóa sản phẩm khỏi giỏ

- [ ] **Staff Flow Testing**:
  - Đăng nhập Staff → Xem dashboard → Xử lý đơn hàng → Cập nhật trạng thái → In hóa đơn
  - Test filter và search orders
  - Test phân quyền (Staff không được truy cập Admin pages)

- [ ] **Admin Flow Testing**:
  - Đăng nhập Admin → Quản lý sản phẩm → Thêm/sửa/xóa → Upload ảnh
  - Quản lý danh mục → Quản lý toppings
  - Xem báo cáo doanh thu

#### B. Performance Testing
- [ ] Test với 100 concurrent users (JMeter/Postman)
- [ ] Đo response time cho các API endpoints
- [ ] Kiểm tra memory leaks và connection pooling
- [ ] Test database query performance với EXPLAIN ANALYZE

#### C. Security Testing
- [ ] Test SQL injection trên form inputs
- [ ] Test XSS vulnerabilities
- [ ] Test CSRF protection
- [ ] Kiểm tra password hashing (BCrypt)
- [ ] Test authorization (role-based access control)

#### D. Bug Fixes & Optimization
- [ ] Fix tất cả bugs phát hiện trong testing
- [ ] Optimize slow queries (add indexes nếu cần)
- [ ] Add error handling và logging
- [ ] Improve validation messages

---

### **Ngày 5-6 (27-28/11): Documentation - Viết Báo Cáo Đồ Án**

#### A. Chuẩn bị tài liệu kỹ thuật

##### 1. Database Documentation
- [ ] Tạo ER Diagram (sử dụng dbdiagram.io hoặc draw.io)
- [ ] Mô tả chi tiết từng bảng: tên, cột, kiểu dữ liệu, ràng buộc
- [ ] Liệt kê các relationships (1-1, 1-n, n-n)
- [ ] Giải thích các indexes và performance considerations

##### 2. API Documentation
- [ ] Document tất cả endpoints (nếu có API)
- [ ] Request/Response examples
- [ ] Authentication requirements
- [ ] Error codes và messages

##### 3. Architecture Documentation
- [ ] Vẽ sơ đồ kiến trúc hệ thống (Presentation → BLL → DAL → Database)
- [ ] Giải thích từng layer và responsibilities
- [ ] Dependency injection flow diagram
- [ ] Deployment architecture (nếu có deploy)

##### 4. Screenshots
- [ ] Chụp màn hình tất cả các trang chính:
  - Trang chủ
  - Danh sách sản phẩm (grid view)
  - Chi tiết sản phẩm (với size/topping selector)
  - Giỏ hàng (cart summary)
  - Checkout form
  - Trang đơn hàng (order history)
  - Staff dashboard
  - Staff order management
  - Admin product management
  - Login/Register pages

#### B. Viết Báo Cáo Đồ Án (theo cấu trúc 220064_MauBaoCao.md)

##### **Phần Mở Đầu**
- [ ] **Lời cảm ơn**: Cảm ơn giảng viên hướng dẫn, bạn bè, gia đình
- [ ] **Mục lục**: Tạo mục lục tự động (Word) hoặc thủ công (Markdown)
- [ ] **Danh mục hình ảnh**: Liệt kê tất cả hình/ảnh chụp màn hình
- [ ] **Danh mục bảng biểu**: Liệt kê các bảng (nếu có)
- [ ] **Tóm tắt**: 
  - Giới thiệu tổng quan về đề tài (200-300 từ)
  - Công nghệ sử dụng: ASP.NET Core Razor Pages, EF Core, PostgreSQL
  - Kiến trúc: 3-layer (Presentation, BLL, DAL)
  - Chức năng chính đã hoàn thành
  - Kết quả đạt được

##### **Phần Mở Đầu**
- [ ] **1. Lý do chọn đề tài**:
  - Xu hướng thương mại điện tử F&B
  - Nhu cầu quản lý bán hàng trực tuyến cho cửa hàng trà sữa
  - Áp dụng kiến thức web development và kiến trúc phần mềm
  
- [ ] **2. Mục tiêu nghiên cứu**:
  - Xây dựng hệ thống web bán hàng hoàn chỉnh
  - Triển khai quản lý sản phẩm, giỏ hàng, đơn hàng, thanh toán
  - Áp dụng kiến trúc phân lớp và Entity Framework Core
  
- [ ] **3. Đối tượng và phạm vi nghiên cứu**:
  - Đối tượng: Hệ thống web bán trà sữa
  - Phạm vi: Backend (DAL + BLL), Frontend (Razor Pages), Database (PostgreSQL)
  - Không bao gồm: Mobile app, payment gateway thực tế
  
- [ ] **4. Phương pháp nghiên cứu**:
  - Phân tích yêu cầu → Thiết kế database → Triển khai code → Testing
  - Sử dụng Agile methodology (weekly sprints)

##### **Chương 1: Nghiên Cứu Lý Thuyết**
- [ ] **1.1 Cơ sở lý thuyết**:
  - ASP.NET Core Razor Pages: Page models, routing, data binding
  - Entity Framework Core: DbContext, Migrations, LINQ
  - Kiến trúc phân lớp (Layered Architecture)
  
- [ ] **1.2 Công nghệ sử dụng**:
  - ASP.NET Core 9.0 với Razor Pages
  - Entity Framework Core 9.0.10
  - PostgreSQL 16
  - C# 12, Bootstrap 5, JavaScript ES6
  
- [ ] **1.3 Patterns áp dụng**:
  - Repository Pattern
  - Unit of Work Pattern
  - Dependency Injection
  - Async/Await programming

##### **Chương 2: Phân Tích Yêu Cầu và Thiết Kế**
- [ ] **2.1 Yêu cầu chức năng**:
  - Quản lý sản phẩm: CRUD, phân loại, hình ảnh
  - Quản lý danh mục: CRUD categories
  - Giỏ hàng: Add/Update/Remove items, Size/Topping selection
  - Đặt hàng: Create order, calculate total, order details
  - Thanh toán: Payment info, transaction logging
  - Quản lý người dùng: Roles (Admin/Staff/Customer), Authentication
  
- [ ] **2.2 Yêu cầu phi chức năng**:
  - Hiệu năng: Response time < 2s, support 100+ concurrent users
  - Bảo mật: Password hashing (BCrypt), Role-based authorization
  - Khả năng mở rộng: Modular architecture, scalable database
  - Tính khả dụng: 99% uptime, error handling & logging
  
- [ ] **2.3 Use Case Diagram**:
  - Vẽ diagram với actors: Customer, Staff, Admin
  - Use cases: Browse products, Add to cart, Checkout, Manage orders, Manage products
  
- [ ] **2.4 Database Design**:
  - ER Diagram với tất cả entities
  - Mô tả chi tiết từng bảng (columns, types, constraints)
  - Relationships và foreign keys

##### **Chương 3: Hiện Thực Hóa Nghiên Cứu**
- [ ] **3.1 Mô tả bài toán**:
  - Xây dựng hệ thống web bán trà sữa
  - Hỗ trợ multi-size pricing và toppings
  - Quản lý đơn hàng và thanh toán
  
- [ ] **3.2 Thiết kế và triển khai**:
  - **Presentation Layer**: Razor Pages structure, routing, page models
  - **Business Logic Layer**: Services (AuthService, ProductService, CartService, OrderService, PaymentService)
  - **Data Access Layer**: DbContext, Repositories, UnitOfWork
  - Giải thích code snippets quan trọng
  
- [ ] **3.3 Mô hình cơ sở dữ liệu**:
  - Chi tiết các bảng: Users, Roles, Customers, Employees, Categories, Products, Toppings, Carts, CartItems, Orders, OrderDetails, Payments
  - Seed data strategy
  - Indexes và performance optimization
  
- [ ] **3.4 Kiến trúc hệ thống**:
  - Sơ đồ kiến trúc 3-layer
  - Data flow: User Request → Razor Page → Service → Repository → Database
  - Dependency injection configuration (Program.cs)

##### **Chương 4: Kết Quả Nghiên Cứu**
- [ ] **4.1 Giao diện và chức năng**:
  - Mô tả từng trang với screenshots
  - Trang Customer: Home, Products, Detail, Cart, Checkout, Orders
  - Trang Staff: Dashboard, Order Management
  - Trang Admin: Product Management, Category Management
  
- [ ] **4.2 Kiểm thử và đánh giá**:
  - Kịch bản kiểm thử: Register → Login → Browse → Add to cart → Checkout → Payment
  - Kết quả testing: Số test cases passed/failed
  - Performance metrics: Response time, concurrent users
  - Security testing results
  
- [ ] **4.3 Kết quả đạt được**:
  - Hoàn thành 100% chức năng core
  - Hệ thống ổn định, responsive
  - Database schema tối ưu với indexes
  - Code quality: Clean code, comments, documentation

##### **Chương 5: Kết Luận và Hướng Phát Triển**
- [ ] **5.1 Kết luận**:
  - Tóm tắt những gì đã làm được
  - Đánh giá mức độ hoàn thành mục tiêu
  - Kinh nghiệm học được
  
- [ ] **5.2 Hạn chế**:
  - Chưa tích hợp payment gateway thực tế
  - Giao diện admin còn đơn giản
  - Chưa có hệ thống logging/monitoring nâng cao
  - Chưa deploy lên production
  
- [ ] **5.3 Hướng phát triển**:
  - Tích hợp VNPay/Momo thực tế
  - Phát triển API cho mobile app
  - Thêm real-time notifications (SignalR)
  - Cải thiện admin dashboard với analytics
  - Deploy lên Azure/AWS
  - Thêm caching (Redis) cho performance
  - Implement CI/CD pipeline

##### **Phần Kết**
- [ ] **Danh mục tài liệu tham khảo**:
  - Microsoft Docs - ASP.NET Core
  - Microsoft Docs - Entity Framework Core
  - Npgsql Documentation
  - Bootstrap Documentation
  - Stack Overflow threads (nếu có tham khảo)
  - GitHub repositories (nếu có tham khảo)

##### **Phụ lục**
- [ ] **Phụ lục A**: Source code structure (cây thư mục)
- [ ] **Phụ lục B**: Database scripts (CREATE TABLE statements)
- [ ] **Phụ lục C**: Configuration files (appsettings.json sample)
- [ ] **Phụ lục D**: Screenshots đầy đủ tất cả các màn hình
- [ ] **Phụ lục E**: Test cases table (TC ID, Description, Input, Expected, Actual, Status)

---

### **Ngày 7 (29/11): Final Review & Submission**

#### A. Code Review & Cleanup
- [ ] Review toàn bộ code, remove commented code và debug logs
- [ ] Đảm bảo code formatting consistent (sử dụng .editorconfig)
- [ ] Add XML documentation comments cho public methods
- [ ] Update README.md với installation guide
- [ ] Tạo CHANGELOG.md liệt kê tất cả changes theo tuần

#### B. Database Finalization
- [ ] Backup database với seed data
- [ ] Tạo SQL script để restore database
- [ ] Document database connection string format
- [ ] Hướng dẫn chạy migrations

#### C. Submission Preparation
- [ ] **Nộp báo cáo PDF**:
  - Export markdown sang Word/PDF
  - Đảm bảo formatting đẹp (fonts, spacing, margins)
  - Kiểm tra tất cả hình ảnh hiển thị đúng
  - Đánh số trang, add header/footer
  
- [ ] **Nộp source code**:
  - Tạo tag `v1.0.0` trên GitHub
  - Export ZIP file (exclude bin, obj, node_modules)
  - Include README.md với setup instructions
  - Đính kèm database backup file
  
- [ ] **Video demo** (nếu yêu cầu):
  - Quay video demo 10-15 phút
  - Show case tất cả features
  - Giải thích architecture overview
  - Upload lên YouTube/Google Drive

#### D. Presentation Preparation (nếu cần thuyết trình)
- [ ] Tạo slide PowerPoint (15-20 slides):
  - Slide 1: Title, student info
  - Slide 2-3: Giới thiệu đề tài, mục tiêu
  - Slide 4-6: Công nghệ và kiến trúc
  - Slide 7-10: Database design và features
  - Slide 11-15: Screenshots và demo
  - Slide 16-18: Testing và kết quả
  - Slide 19: Hạn chế và hướng phát triển
  - Slide 20: Q&A
  
- [ ] Luyện thuyết trình 3-4 lần
- [ ] Chuẩn bị trả lời câu hỏi kỹ thuật

---

## 📊 Checklist Tổng Hợp

### ✅ Technical Implementation
- [ ] Payment integration hoàn tất
- [ ] Staff dashboard đầy đủ widgets
- [ ] Admin product management CRUD
- [ ] Order status workflow đầy đủ
- [ ] Email notifications (mock)
- [ ] PDF invoice generation (bonus)

### ✅ Testing
- [ ] Functional testing: Customer flow
- [ ] Functional testing: Staff flow
- [ ] Functional testing: Admin flow
- [ ] Performance testing với 100 users
- [ ] Security testing (SQL injection, XSS, CSRF)
- [ ] Bug fixes và optimization

### ✅ Documentation
- [ ] Database ER Diagram
- [ ] Architecture diagram
- [ ] API documentation (nếu có)
- [ ] Screenshots đầy đủ tất cả pages
- [ ] README.md với setup guide

### ✅ Báo Cáo Đồ Án
- [ ] Lời cảm ơn, Mục lục, Danh mục hình
- [ ] Tóm tắt và Mở đầu
- [ ] Chương 1: Nghiên cứu lý thuyết
- [ ] Chương 2: Phân tích yêu cầu và thiết kế
- [ ] Chương 3: Hiện thực hóa nghiên cứu
- [ ] Chương 4: Kết quả nghiên cứu
- [ ] Chương 5: Kết luận và hướng phát triển
- [ ] Danh mục tài liệu tham khảo
- [ ] Phụ lục (code structure, database scripts, screenshots)

### ✅ Submission
- [ ] Export báo cáo sang PDF (formatting đẹp)
- [ ] Tạo GitHub release tag v1.0.0
- [ ] Export source code ZIP
- [ ] Database backup file
- [ ] Video demo (optional)
- [ ] PowerPoint slides (nếu thuyết trình)
- [ ] Nộp đúng deadline

---

## 🎯 Expected Deliverables

1. **Báo cáo đồ án PDF** (50-80 trang):
   - Đầy đủ 5 chương theo cấu trúc mẫu
   - Screenshots minh họa rõ ràng
   - ER Diagram và Architecture diagram
   - Formatted đẹp, professional

2. **Source Code**:
   - Repository GitHub với lịch sử commits đầy đủ
   - Tag version v1.0.0
   - README.md chi tiết
   - Clean code, well-documented

3. **Database**:
   - PostgreSQL backup file (.sql)
   - ER Diagram
   - Migration scripts

4. **Demo Materials** (optional):
   - Video demo 10-15 phút
   - PowerPoint presentation
   - Test accounts (Admin/Staff/Customer)

---

## 💡 Tips Quan Trọng

### Viết Báo Cáo
- **Đừng copy-paste**: Viết bằng lời của bạn, thể hiện hiểu biết
- **Screenshots chất lượng cao**: Dùng full page screenshot, crop gọn gàng
- **Giải thích code**: Đừng chỉ paste code, hãy giải thích logic
- **Số liệu cụ thể**: "Hệ thống xử lý 100 concurrent users với response time < 2s"
- **Professional tone**: Tránh ngôn ngữ quá casual

### Testing
- **Test như người dùng thật**: Thử các edge cases, invalid inputs
- **Document bugs**: Lưu lại bug với steps to reproduce
- **Performance benchmark**: Đo actual numbers, không ước tính

### Code Quality
- **Clean code**: Remove debug logs, commented code
- **Consistent formatting**: Dùng .editorconfig
- **Meaningful names**: Variables, methods, classes
- **Comments**: Giải thích "why", không phải "what"

---

## 📞 Support & Questions

Nếu gặp khó khăn trong tuần này, hãy:
1. Check documentation (Microsoft Docs, Stack Overflow)
2. Debug systematically với breakpoints
3. Ask for help với context đầy đủ
4. Track issues trong GitHub Issues

---

**Good luck với tuần cuối cùng! 🚀**

Hãy focus vào việc hoàn thiện và viết báo cáo chất lượng. Đây là tuần quyết định thành công của đồ án!
