# BÁO CÁO TUẦN 3

**Thời gian:** 18/11/2025 - 25/11/2025  
**Dự án:** Website bán trà sữa - ASP.NET Core  
**Sinh viên:** Phạm Minh Thu Trang

---

## MỤC TIÊU

- Tái cấu trúc hệ thống định giá (Multi-size pricing)
- Tạo Topping Entity và relationships
- Cập nhật CartService và OrderService
- Migrate database schema
- Update UI cho size và topping selection

---

## CÔNG VIỆC HOÀN THÀNH

### 1. Database Schema Redesign

**Topping Entity (Mới):**

- ToppingName, Description, ToppingPrice, IsAvailable
- Seed 8 loại topping: Trân châu đen (5k), Pudding (6k), Kem cheese (8k), Trái cây (10k)

**Product Entity (Cập nhật):**

- Từ `Price` → `PriceS`, `PriceM`, `PriceL`
- Xóa `Size`, `Topping` (string)
- Thêm `AvailableToppingIds` (string)
- Seed 15 sản phẩm với 3 mức giá

**CartItem và OrderDetail (Cập nhật):**

- Thêm `BasePrice` (giá theo size)
- Thêm `ToppingPrice` (tổng giá topping)
- Thêm `TotalPrice` = (BasePrice + ToppingPrice) × Quantity
- `SelectedToppings` thay `Topping`

**Migration:**

- `AddToppingAndMultiSizePricing`
- Apply thành công lên PostgreSQL

### 2. Data Access Layer

**ToppingRepository:**

- IToppingRepository interface
- ToppingRepository implementation
- Update UnitOfWork với Toppings property

**Database Context:**

- Fluent API cho Topping table
- Update column types: decimal(18,2), nvarchar
- Seed data cho toppings và products

### 3. Business Logic Layer

**CartService Enhancement:**

- `AddToCartAsync`: Tính basePrice theo size (S/M/L)
- Query Topping table để tính toppingPrice
- Lưu BasePrice, ToppingPrice, TotalPrice
- `GetCartTotalAsync`: Sử dụng TotalPrice

**OrderService Enhancement:**

- `CreateOrderAsync`: Tạo OrderDetail với pricing breakdown
- Tính TotalAmount từ CartItem.TotalPrice
- Preserve pricing snapshot

### 4. Presentation Layer

**Customer Pages:**

- Products/Index: Hiển thị PriceM, badge "S/M/L"
- Products/Detail: Form chọn size và topping
- Cart/Index: Hiển thị BasePrice + ToppingPrice
- Orders/Detail: Breakdown giá từng item
- Checkout: Tổng tiền với TotalPrice

**Staff Pages:**

- Products/Index: Price range (PriceS - PriceL)
- Products/Create: Form nhập 3 giá + toppings
- Products/Edit: Chỉnh sửa giá và toppings
- Orders/Detail: Chi tiết pricing

**Page Models:**

- Update filter/sort theo PriceM
- Parse AvailableToppingIds
- InputModel với PriceS/M/L

### 5. Pricing Logic

**Calculation Flow:**

```
basePrice = size switch {
    "S" => product.PriceS,
    "M" => product.PriceM,
    "L" => product.PriceL,
    _ => product.PriceM
};

toppingPrice = toppings
    .Where(t => selectedToppingNames.Contains(t.ToppingName))
    .Sum(t => t.ToppingPrice);

totalPrice = (basePrice + toppingPrice) * quantity;
```

---

## THỐNG KÊ

| Metric         | Số lượng                              |
| -------------- | ------------------------------------- |
| New Tables     | 1 (Toppings)                          |
| Updated Tables | 3 (Products, CartItems, OrderDetails) |
| Migrations     | 1                                     |
| Seed Data      | 8 toppings, 15 products               |
| Updated Pages  | 10                                    |

---

## KẾT QUẢ

**Hoàn thành:**

- ✅ Multi-size pricing (S/M/L)
- ✅ Topping management
- ✅ Pricing calculation logic
- ✅ Database migration thành công
- ✅ UI update cho size/topping selection

**Bug Fixes:**

- Fixed 18+ compilation errors
- Build status: ✅ Success

---

## KẾ HOẠCH TUẦN 4

- Payment gateway integration
- Order status workflow
- Email notifications
- Staff dashboard với charts
- Performance optimization

---

**Tỷ lệ hoàn thành:** 100% Multi-size & Topping System
