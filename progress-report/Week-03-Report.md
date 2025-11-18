# Week 03 Progress Report - Milk Tea Website

**Project:** ASP.NET Core Milk Tea E-commerce Website  
**Student:** Phạm Minh Thư Trang  
**Date:** 18/11/2025  
**Week:** 03

---

## 📋 Summary

Tuần này tập trung vào việc **tái cấu trúc hệ thống định giá sản phẩm** để hỗ trợ nhiều kích thước (S/M/L) và topping có giá riêng biệt. Đây là một thay đổi lớn về database schema và business logic, yêu cầu cập nhật toàn bộ các layer từ Entity → Repository → Service → UI.

---

## ✅ Completed Tasks

### 1. Database Schema Redesign
- **Tạo mới Topping Entity**
  - Các thuộc tính: `ToppingName`, `Description`, `ToppingPrice`, `IsAvailable`
  - Seed 8 loại topping phổ biến với giá từ 4,000đ - 10,000đ
  - Ví dụ: Trân châu đen (5k), Pudding (6k), Kem cheese (8k), Trái cây tươi (10k)

- **Cập nhật Product Entity**
  - Thay đổi từ `Price` (decimal) → `PriceS`, `PriceM`, `PriceL` (3 decimals)
  - Xóa thuộc tính `Size` và `Topping` (string)
  - Thêm `AvailableToppingIds` (string) để liên kết với toppings
  - Seed 15 sản phẩm với giá 3 size, ví dụ: Trà Sữa Truyền Thống (30k/35k/40k)

- **Cập nhật CartItem và OrderDetail**
  - Thêm `BasePrice` (giá theo size)
  - Thêm `ToppingPrice` (tổng giá topping)
  - Thêm `TotalPrice` (= (BasePrice + ToppingPrice) × Quantity)
  - Thay `Topping` (string) → `SelectedToppings` (string)
  - OrderDetail có thêm `UnitPrice` = BasePrice + ToppingPrice

### 2. Data Access Layer (DAL)
- **Tạo ToppingRepository**
  - Interface: `IToppingRepository`
  - Implementation: `ToppingRepository` kế thừa `GenericRepository<Topping>`
  
- **Cập nhật Unit of Work**
  - Thêm property `IToppingRepository Toppings { get; }`
  - Khởi tạo trong constructor

- **Database Context Configuration**
  - Cấu hình fluent API cho Topping table
  - Cập nhật Product, CartItem, OrderDetail columns (decimal(18,2), nvarchar)
  - Seed data cho 8 toppings và 15 products

- **Migration**
  - Tạo migration: `AddToppingAndMultiSizePricing`
  - Apply thành công lên PostgreSQL database
  - Bao gồm: tạo bảng Toppings, alter bảng Products, CartItems, OrderDetails

### 3. Business Logic Layer (BLL)
- **CartService Enhancement**
  - `AddToCartAsync`: Tính `basePrice` theo size (S/M/L)
  - Query Topping table để tính `toppingPrice`
  - Lưu `BasePrice`, `ToppingPrice`, `TotalPrice` vào CartItem
  - `GetCartTotalAsync`: Sử dụng `TotalPrice` thay vì `UnitPrice * Quantity`

- **OrderService Enhancement**
  - `CreateOrderAsync`: Tạo OrderDetail với full pricing breakdown
  - Tính Order.TotalAmount từ CartItem.TotalPrice
  - Preserve pricing snapshot tại thời điểm đặt hàng

### 4. Presentation Layer (UI)
- **Customer Pages**
  - `Products/Index.cshtml`: Hiển thị PriceM, badge "S/M/L", số lượng topping
  - `Products/Detail.cshtml`: Hiển thị "Từ [PriceS]", form chọn size và topping
  - `Cart/Index.cshtml`: Hiển thị BasePrice + ToppingPrice, TotalPrice
  - `Orders/Detail.cshtml`: Hiển thị breakdown giá của từng item
  - `Orders/Checkout.cshtml`: Sử dụng TotalPrice cho tổng đơn hàng

- **Staff Pages**
  - `Products/Index.cshtml`: Hiển thị price range (PriceS - PriceL)
  - `Products/Create.cshtml`: Form nhập 3 giá (S/M/L) và AvailableToppingIds
  - `Products/Edit.cshtml`: Chỉnh sửa 3 giá và topping IDs
  - `Orders/Detail.cshtml`: Hiển thị chi tiết pricing cho staff xem

- **Page Models**
  - Cập nhật `Index.cshtml.cs`: Filter và sort theo PriceM
  - Cập nhật `Detail.cshtml.cs`: Parse AvailableToppingIds
  - Cập nhật `Create.cshtml.cs` và `Edit.cshtml.cs`: InputModel với PriceS/M/L

### 5. Code Quality
- **Build Status**: ✅ Success (0 errors, 1 warning về EF Core version)
- **Migration Status**: ✅ Applied successfully
- **Compilation**: Đã fix tất cả 18+ compilation errors sau breaking changes

---

## 🔧 Technical Implementation Details

### Pricing Calculation Logic
```csharp
// CartService.AddToCartAsync
decimal basePrice = size switch {
    "S" => product.PriceS,
    "M" => product.PriceM,
    "L" => product.PriceL,
    _ => product.PriceM
};

decimal toppingPrice = 0;
if (!string.IsNullOrEmpty(topping)) {
    var toppings = await _unitOfWork.Toppings.GetAllAsync();
    var selectedToppingNames = topping.Split(',')
        .Select(t => t.Trim());
    
    toppingPrice = toppings
        .Where(t => selectedToppingNames.Contains(
            t.ToppingName, 
            StringComparer.OrdinalIgnoreCase))
        .Sum(t => t.ToppingPrice);
}

decimal totalPrice = (basePrice + toppingPrice) * quantity;
```

### Database Seed Data Examples
- **Toppings**: Trân châu đen (5k), Trân châu trắng (5k), Thạch rau câu (4k), Pudding (6k), Thạch dừa (4k), Kem cheese (8k), Sốt socola (7k), Trái cây tươi (10k)
- **Products**: Trà Sữa Truyền Thống (30k/35k/40k), Trà Đào (32k/37k/42k), Trà Vải (30k/35k/40k), v.v.

---

## 📊 Statistics

- **Files Modified**: 25+ files
- **New Entities**: 1 (Topping)
- **Updated Entities**: 3 (Product, CartItem, OrderDetail)
- **New Repositories**: 1 (ToppingRepository)
- **Updated Services**: 2 (CartService, OrderService)
- **Updated Pages**: 10+ Razor pages/models
- **Migration**: 1 major migration
- **Seed Data**: 8 toppings + 15 products with 3-tier pricing

---

## 🚧 Challenges & Solutions

### Challenge 1: Breaking Changes
**Problem**: Thay đổi schema từ single `Price` sang `PriceS/M/L` gây ra 18+ compilation errors trong UI layer.

**Solution**: 
- Systematic approach: Entity → Repository → Service → UI
- Used grep search để tìm tất cả references
- Fix từng page một cách có tổ chức

### Challenge 2: Duplicate Seed Data
**Problem**: EF Core migration failed do seed Topping data bị duplicate (seeded 2 lần).

**Solution**: Removed duplicate `HasData()` calls trong DatabaseSeeder.cs

### Challenge 3: Dynamic Pricing Calculation
**Problem**: Cần tính giá real-time khi user chọn size và topping.

**Solution**: 
- Lưu pricing breakdown (BasePrice, ToppingPrice, TotalPrice) vào CartItem
- CartService query Topping table để lấy giá chính xác
- Business logic tập trung trong service layer, không phụ thuộc UI

---

## 🎯 Business Rules Implemented

1. **Menu Display**: Giá hiển thị = PriceM (size Medium) với 0 topping
2. **Size Selection**: User chọn S/M/L, giá thay đổi tương ứng
3. **Topping Selection**: Mỗi topping có giá riêng, tổng cộng vào đơn hàng
4. **Cart Calculation**: `TotalPrice = (BasePrice + ToppingPrice) × Quantity`
5. **Order Snapshot**: Lưu giá tại thời điểm đặt hàng (không thay đổi nếu sản phẩm đổi giá sau)

---

## 📈 Next Steps (Week 04)

### Planned Tasks
1. **UI Enhancement**
   - Thêm dynamic price update khi chọn size/topping (JavaScript)
   - Improve product detail page với price calculator
   - Add topping selector với checkbox và hiển thị giá

2. **Admin Features**
   - CRUD interface cho Topping management
   - Bulk update prices cho products
   - Pricing history/audit log

3. **Testing**
   - End-to-end testing: Add to cart → Checkout → Order
   - Test edge cases: Out of stock toppings, price changes
   - Performance testing với large product catalog

4. **Documentation**
   - API documentation cho pricing endpoints
   - User guide cho staff về quản lý giá
   - Database schema diagram update

---

## 💡 Lessons Learned

1. **Schema Design**: Breaking changes trong production cần migration strategy rõ ràng. Nên có backup và rollback plan.

2. **Separation of Concerns**: Pricing logic tập trung trong service layer giúp dễ maintain và test. UI chỉ hiển thị, không tính toán.

3. **Seed Data Management**: Cần careful review seed data trước khi migration để tránh duplicate key errors.

4. **Incremental Updates**: Với breaking changes lớn, nên update theo order: Data → Logic → UI để dễ debug.

5. **Code Organization**: Systematic file search (grep) và error tracking giúp đảm bảo không miss bất kỳ reference nào.

---

## 📝 Notes

- EF Core version conflict warning (9.0.1 vs 9.0.10) - không ảnh hưởng functionality nhưng nên update packages để consistency
- Migration file có note "operation may result in loss of data" - đây là expected do đổi column type, đã review và safe
- Existing cart items trước migration có thể có data inconsistency - cần clear carts hoặc data migration script nếu deploy production

---

## 🔗 Related Resources

- Migration file: `20251118031855_AddToppingAndMultiSizePricing.cs`
- Updated entities: `MilkTeaWebsite.Entity/Entity/`
- Service implementations: `MilkTeaWebsite.BLL/Implements/`
- Seed data: `MilkTeaWebsite.DAL/Seed/DatabaseSeeder.cs`

---

**Status**: ✅ All planned tasks for Week 03 completed successfully  
**Build**: ✅ Passing  
**Database**: ✅ Migration applied  
**Ready for**: Week 04 development and testing phase
