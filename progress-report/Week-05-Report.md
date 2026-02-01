# BÁO CÁO TUẦN 5

**Thời gian:** 02/12/2025 - 08/12/2025  
**Dự án:** Website bán trà sữa - ASP.NET Core  
**Sinh viên:** Phạm Minh Thu Trang

---

## MỤC TIÊU

- Cải thiện database schema (String → Relational model)
- Tạo bảng quan hệ ProductTopping, CartItemTopping, OrderDetailTopping
- Migrate seed data sang mô hình mới
- Code refactoring
- Bug fixes & optimization

---

## CÔNG VIỆC HOÀN THÀNH

### 1. Database Schema Redesign

**Vấn đề cũ:**

- Product-Topping: String `AvailableToppingIds`
- CartItem-Topping: String `SelectedToppings`
- OrderDetail-Topping: String `SelectedToppings`
- **Nhược điểm:** Không có referential integrity, khó query

**Giải pháp mới:**

**ProductTopping (Junction table):**

- ProductId, ToppingId (Composite PK)
- Foreign keys với CASCADE delete
- Many-to-Many relationship

**CartItemTopping (Snapshot):**

- Id (PK), CartItemId, ToppingId, ToppingPrice
- Preserve giá tại thời điểm add to cart
- Foreign keys với DELETE RESTRICT

**OrderDetailTopping (Historical snapshot):**

- Id (PK), OrderDetailId, ToppingId, ToppingName, ToppingPrice
- Lưu snapshot đầy đủ cho báo cáo
- Foreign keys với DELETE RESTRICT

### 2. Migration

**Migration File:**

- `20251204125701_AddToppingRelationshipTables`
- CREATE 3 tables mới
- CREATE indexes tự động
- Migrate seed data thành công

### 3. Entity Classes Update

**Product.cs:**

- Deprecate `AvailableToppingIds`
- Add `ProductToppings` navigation property

**CartItem.cs:**

- Deprecate `SelectedToppings`
- Add `CartItemToppings` collection
- Property `ToppingPrice` tính từ collection

**OrderDetail.cs:**

- Deprecate `SelectedToppings`
- Add `OrderDetailToppings` collection
- Preserve snapshot giá

### 4. Repository Layer

**New Repositories:**

- ProductToppingRepository: GetToppingsByProductId
- CartItemToppingRepository: CRUD operations
- OrderDetailToppingRepository: Historical queries

**Updated Repositories:**

- ProductRepository: Include ProductToppings
- CartRepository: Include CartItemToppings
- OrderRepository: Include OrderDetailToppings

### 5. Service Layer Refactoring

**CartService:**

```csharp
// Old: Parse string toppings
var toppingNames = topping.Split(',');

// New: Query relational table
var cartItemToppings = selectedToppings
    .Select(tid => new CartItemTopping {
        ToppingId = tid,
        ToppingPrice = topping.ToppingPrice
    });
```

**OrderService:**

```csharp
// New: Create snapshot
foreach (var cit in cartItem.CartItemToppings) {
    var odt = new OrderDetailTopping {
        ToppingId = cit.ToppingId,
        ToppingName = cit.Topping.ToppingName,
        ToppingPrice = cit.ToppingPrice
    };
}
```

### 6. Presentation Layer

**Products/Detail.cshtml:**

- Load toppings từ ProductToppings
- Display available toppings với giá

**Cart/Index.cshtml:**

- Hiển thị toppings từ CartItemToppings
- Show topping price breakdown

**Orders/Detail.cshtml:**

- Display từ OrderDetailToppings
- Historical snapshot với ToppingName

### 7. Bug Fixes

**Critical Bugs Fixed:**

- ✅ Cart total = 0đ (Fixed: Filter IsDeleted items)
- ✅ Update quantity không tính lại giá (Fixed: Recalculate TotalPrice)
- ✅ Delete button không hoạt động (Fixed: Add confirmation dialog)
- ✅ Topping price not synced (Fixed: Use relational data)

**Code in CartService.cs:**

```csharp
// Fixed: Recalculate total price on update
cartItem.Quantity = quantity;
cartItem.TotalPrice = (cartItem.BasePrice + cartItem.ToppingPrice) * quantity;
```

**Code in CartRepository.cs:**

```csharp
// Fixed: Filter deleted items
.Include(c => c.CartItems.Where(ci => !ci.IsDeleted))
```

### 8. Code Quality

**Refactoring:**

- Remove deprecated string-based code
- Clean up unused methods
- Add XML documentation
- Improve error handling

**Performance:**

- Add indexes cho junction tables
- Optimize EF Core queries với Include
- Reduce N+1 queries

---

## THỐNG KÊ

| Metric           | Số lượng   |
| ---------------- | ---------- |
| New Tables       | 3          |
| New Repositories | 3          |
| Migrations       | 1          |
| Bug Fixes        | 4 critical |
| Code Refactored  | 15 files   |

---

## KẾT QUẢ

**Hoàn thành:**

- ✅ Relational model thay string-based
- ✅ 3 bảng quan hệ mới
- ✅ Service layer refactored
- ✅ Critical bugs fixed
- ✅ Code quality improved

**Database:**

- Referential integrity: ✅
- Query performance: ✅ Improved
- Historical tracking: ✅ Complete

---

## KẾ HOẠCH TUẦN TIẾP THEO

- Final testing toàn diện
- Documentation hoàn thiện
- Deployment preparation
- Performance monitoring
- User acceptance testing

---

**Tỷ lệ hoàn thành:** 100% Core Features
