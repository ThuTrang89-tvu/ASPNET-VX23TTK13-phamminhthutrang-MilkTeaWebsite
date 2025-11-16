
Tên đề tài		Tên GV Hướng dẫn

**NHẬN XÉT CỦA GIẢNG VIÊN HƯỚNG DẪN**


















































































*…………, ngày ….. tháng …… năm ……*

`	`**Giáo viên hướng dẫn**

Tên đề tài: MilkTeaWebsite - Hệ thống quản lý và bán hàng cho cửa hàng trà sữa

Giáo viên hướng dẫn: (Điền tên giảng viên)

## NHẬN XÉT CỦA GIẢNG VIÊN HƯỚNG DẪN

Trà Vinh, ngày …… tháng …… năm ……

**Giáo viên hướng dẫn**

_(Ký tên và ghi rõ họ tên)_

--

## NHẬN XÉT CỦA THÀNH VIÊN HỘI ĐỒNG

Trà Vinh, ngày …… tháng …… năm ……

**Thành viên hội đồng**

_(Ký tên và ghi rõ họ tên)_

--

## LỜI CẢM ƠN

Khi hoàn thành đồ án "MilkTeaWebsite", em xin gửi lời cảm ơn chân thành tới thầy/cô hướng dẫn đã tận tình chỉ bảo, góp ý trong suốt quá trình nghiên cứu và thực hiện. Sự hỗ trợ về chuyên môn, định hướng thiết kế và góp ý về phần cài đặt đã giúp em hoàn thiện sản phẩm.

Em cũng xin cảm ơn các đồng nghiệp, bạn bè và những người đã tham gia test hệ thống, cung cấp phản hồi quý giá. Những góp ý đó đã giúp cải thiện trải nghiệm người dùng và sửa các lỗi logic trong quá trình phát triển.

Cuối cùng, em xin cảm ơn gia đình đã động viên, hỗ trợ về tinh thần trong suốt thời gian làm đồ án.

Em xin chân thành cảm ơn tất cả những ai đã giúp đỡ trong quá trình thực hiện đồ án. Những ý kiến đóng góp từ bạn bè và đồng nghiệp đã giúp phát hiện và khắc phục nhiều lỗi logic, đồng thời góp ý cải thiện trải nghiệm giao diện. Sự hỗ trợ về tài liệu tham khảo, thử nghiệm và hướng dẫn kỹ thuật khi chạy thử đã giúp đồ án hoàn thiện nhanh chóng hơn.

Quá trình thực hiện đồ án là một trải nghiệm học tập sâu sắc, giúp em củng cố kiến thức về phát triển web, kiến trúc phần mềm, và quản trị cơ sở dữ liệu. Em hy vọng sản phẩm này sẽ là nền tảng hữu ích để phát triển thêm các tính năng nâng cao trong tương lai và có thể tiếp tục được triển khai trên môi trường thực tế.

## MỤC LỤC

(Sinh viên tạo mục lục tự động khi xuất báo cáo sang PDF/Word)

## DANH MỤC HÌNH ẢNH

(Danh sách hình ảnh sẽ được cập nhật khi sinh viên chèn các ảnh chụp màn hình và sơ đồ)

## DANH MỤC BẢNG BIỂU

(Nếu có — liệt kê các bảng dữ liệu quan trọng)

## TÓM TẮT

Đồ án "MilkTeaWebsite" là một hệ thống web phục vụ cho bán hàng tại cửa hàng trà sữa, được triển khai trên nền tảng ASP.NET Core (Razor Pages). Hệ thống áp dụng mô hình phân lớp bao gồm Presentation (Razor Pages), Business Logic Layer (`MilkTeaWebsite.BLL`) và Data Access Layer (`MilkTeaWebsite.DAL`) cùng với Entity classes (`MilkTeaWebsite.Entity`).

Ứng dụng hỗ trợ các nghiệp vụ chính: quản lý danh mục và sản phẩm, vận hành giỏ hàng, tạo và quản lý đơn hàng, xử lý thanh toán (lưu thông tin giao dịch), và quản lý người dùng theo vai trò (Admin, Employee, Customer). Dữ liệu được quản lý bằng PostgreSQL thông qua Entity Framework Core; project có cấu hình retry và timeout cho Npgsql để tăng tính ổn định của kết nối cơ sở dữ liệu.

Họ và tên sinh viên thực hiện: (Điền tên sinh viên)

## MỞ ĐẦU

### Lý do chọn đề tài

Trong thời đại thương mại điện tử phát triển, các cửa hàng F&B như trà sữa ngày càng cần mở rộng kênh bán hàng trực tuyến để đáp ứng nhu cầu của khách hàng. Hệ thống quản lý bán hàng không chỉ hỗ trợ bán hàng mà còn giúp quản lý sản phẩm, đơn hàng và khách hàng một cách hiệu quả. Dựa trên thực tế đó, em chọn đề tài "MilkTeaWebsite" để áp dụng kiến thức về phát triển web, thiết kế cơ sở dữ liệu và kiến trúc phần mềm vào một sản phẩm cụ thể.

### Mục tiêu nghiên cứu

Mục tiêu chính của đồ án là thiết kế và triển khai một hệ thống web mẫu phục vụ bán hàng cho cửa hàng trà sữa, bao gồm các chức năng: quản lý sản phẩm và danh mục, chức năng giỏ hàng, tạo đơn hàng và lưu thông tin thanh toán. Bên cạnh đó, đồ án nhằm mục đích minh họa cách tổ chức mã theo kiến trúc phân lớp (Presentation - BLL - DAL) và sử dụng Entity Framework Core với PostgreSQL.

### Đối tượng và phạm vi nghiên cứu

Đối tượng nghiên cứu là hệ thống web bán hàng cỡ nhỏ cho cửa hàng trà sữa. Phạm vi thực hiện bao gồm phần backend (DAL và BLL), phần Presentation bằng Razor Pages, mô hình dữ liệu và một số giao diện cơ bản cho người dùng. Đồ án không bao gồm triển khai mobile app hay tích hợp cổng thanh toán thực tế (chỉ lưu mô phỏng Payment trong DB).

### Phương pháp nghiên cứu

Quá trình thực hiện đồ án kết hợp giữa nghiên cứu lý thuyết và thực nghiệm. Phương pháp bao gồm phân tích yêu cầu, thiết kế mô hình dữ liệu bằng Entity Framework Core, triển khai các service trong BLL, và phát triển giao diện Razor Pages. Việc kiểm thử được thực hiện thủ công bằng các kịch bản: đăng ký/đăng nhập, thao tác giỏ hàng, tạo đơn hàng và lưu thanh toán.

## CHƯƠNG 1: NGHIÊN CỨU LÝ THUYẾT

Trong chương này, đồ án trình bày các khái niệm nền tảng liên quan tới công nghệ sử dụng. Trước hết, ASP.NET Core Razor Pages là một framework xây dựng ứng dụng web theo mô hình page-centric, cho phép tách biệt logic xử lý và phần hiển thị. Entity Framework Core là một ORM giúp ánh xạ các entity C# vào bảng trong cơ sở dữ liệu và hỗ trợ migration để quản lý thay đổi cấu trúc DB.


Ngoài ra, kiến trúc phân lớp (layered architecture) được áp dụng để tách rời trách nhiệm: Presentation chịu trách nhiệm hiển thị, BLL xử lý nghiệp vụ, DAL tương tác trực tiếp với DB. Mô hình này giúp mã dễ bảo trì, kiểm thử và mở rộng.

Chương này cũng trình bày một số pattern và thực hành quan trọng được áp dụng trong đồ án. Cụ thể, pattern Repository và UnitOfWork được sử dụng để gom các thao tác dữ liệu lại với nhau, tạo thuận lợi cho việc quản lý transaction và rollback khi cần. Dependency Injection (DI) trong ASP.NET Core cho phép chuyển các phụ thuộc (ví dụ repository, service) vào lớp sử dụng, giúp tăng khả năng mock khi viết unit test. Bên cạnh đó, các phương pháp xử lý bất đồng bộ (async/await) được áp dụng cho các thao tác I/O để tránh block luồng và cải thiện khả năng đáp ứng của ứng dụng.

## CHƯƠNG 2: PHÂN TÍCH YÊU CẦU VÀ THIẾT KẾ

### Yêu cầu chức năng chính

Hệ thống cần hỗ trợ các chức năng cơ bản sau: quản lý danh mục và sản phẩm (CRUD), duyệt sản phẩm theo danh mục, giỏ hàng với các thuộc tính như kích thước (Size), topping và ghi chú, khả năng tạo đơn hàng từ giỏ hàng, tính toán tổng tiền và lưu chi tiết đơn hàng, cùng với lưu thông tin thanh toán. Hệ thống cũng cần quản lý người dùng theo vai trò (Admin, Employee, Customer) để phân quyền thao tác.

### Yêu cầu phi chức năng

Hệ thống được kỳ vọng hoạt động ổn định trong môi trường Development và Production; đảm bảo tính toàn vẹn dữ liệu, có khả năng xử lý nhiều truy vấn đồng thời, và cung cấp các cấu hình retry/timeout cho kết nối PostgreSQL để tăng độ bền khi mạng không ổn định. Mật khẩu người dùng được lưu dưới dạng băm (hash) trong trường `PasswordHash`.

### Lược đồ nghiệp vụ (Use-case)

Các tác nhân chính gồm Khách hàng và Nhân viên/Admin. Khách hàng thực hiện các hành vi: duyệt sản phẩm, thêm vào giỏ, đặt hàng và xem lịch sử. Nhân viên/Admin quản lý sản phẩm, duyệt và xử lý đơn hàng.

Trong thiết kế nghiệp vụ, các tiêu chí về tính toàn vẹn và hiệu năng được đặt lên hàng đầu. Ví dụ, chức năng tạo đơn hàng được triển khai để đảm bảo tính nguyên tử: khi lưu Order và các OrderDetail, hệ thống sử dụng transaction để đảm bảo toàn bộ các thao tác thành công hoặc rollback khi có lỗi. Đồng thời, logging được triển khai để lưu lại các ngoại lệ và hành vi bất thường nhằm phục vụ công tác debug và vận hành.

## CHƯƠNG 3: HIỆN THỰC HÓA NGHIÊN CỨU

### 3.1 Mô tả bài toán

Bài toán được mô tả là xây dựng một hệ thống hỗ trợ bán hàng trực tuyến cho một cửa hàng trà sữa, nhằm quản lý danh mục sản phẩm, cho phép khách hàng tạo giỏ hàng, thanh toán và quản trị viên quản lý đơn hàng, sản phẩm.

### 3.2 Thiết kế và triển khai

Hệ thống gồm các thành phần chính:

- Presentation: Razor Pages trong project `MilkTeaWebsite`. Đây là nơi xử lý các request từ người dùng và hiển thị dữ liệu.
- BLL: `MilkTeaWebsite.BLL` chứa các service như `AuthService`, `ProductService`, `CartService`, `OrderService` và `PaymentService` để xử lý nghiệp vụ.
- DAL: `MilkTeaWebsite.DAL` chứa `ApplicationDbContext` và các repository/UnitOfWork để thao tác với DB.

Trong `Program.cs`, ứng dụng cấu hình DbContext sử dụng PostgreSQL (Npgsql) với các thiết lập retry và command timeout; đồng thời đăng ký các service vào DI container.

Các service chính trong BLL được viết theo interface (ví dụ `IProductService`, `ICartService`) để tách rời triển khai và dễ dàng mock trong unit test. Phần lớn các phương thức truy vấn và cập nhật dữ liệu được triển khai bất đồng bộ sử dụng `async/await` nhằm tận dụng I/O không chặn. Những thao tác liên quan đến nhiều bảng được gom lại trong UnitOfWork để đảm bảo tính nhất quán dữ liệu.

### 3.3 Mô hình cơ sở dữ liệu

Mô hình dữ liệu được xây dựng bằng Entity Framework Core. `ApplicationDbContext` khai báo các DbSet chính như Users, Roles, Customers, Employees, Categories, Products, Carts, CartItems, Orders, OrderDetails và Payments. Một số ràng buộc được cấu hình trong `OnModelCreating`, bao gồm khóa chính, quan hệ một-nhiều, và các giới hạn độ dài cho trường văn bản.

(CHÈN HÌNH: sơ đồ ER của database — chụp màn hình `ApplicationDbContext` model hoặc Diagram từ công cụ thiết kế)

Chi tiết ràng buộc và tối ưu hóa chỉ mục được cấu hình trực tiếp trong `OnModelCreating`. Ví dụ, các trường `Username` và `Email` có chỉ mục duy nhất để ngăn trùng lặp và tăng tốc tìm kiếm; các trường số tiền được định nghĩa dưới dạng `decimal(18,2)` để đảm bảo chính xác khi tính toán tài chính. Việc seed dữ liệu cho một số bảng (như Category) được sử dụng để thuận tiện cho chạy demo.

### 3.4 Mô tả các bảng chính (tóm tắt)

- Role: lưu thông tin vai trò người dùng (Admin/Employee/Customer).
- User: gồm Username, Email, PasswordHash, RoleId và thông tin liên hệ.
- Customer/Employee: mở rộng thông tin cá nhân gắn với User.
- Category/Product: quản lý danh mục và sản phẩm, Product có các thuộc tính Price, ImageUrl, Size, Topping, IsDeleted.
- Cart/CartItem: lưu trạng thái giỏ hàng và các mục trong giỏ.
- Order/OrderDetail: lưu thông tin đơn hàng và chi tiết các sản phẩm trong đơn.
- Payment: lưu thông tin thanh toán liên kết 1:1 với Order.

Các bảng còn có một số trường metadata phổ biến như `CreatedAt`, `UpdatedAt` và `IsDeleted` để hỗ trợ việc theo dõi vòng đời bản ghi và xóa mềm. Thiết kế này giúp thuận tiện cho việc audit, phục hồi dữ liệu và cung cấp thông tin cho báo cáo sau này.

### 3.5 Kiến trúc hệ thống

Hệ thống áp dụng kiến trúc phân lớp rõ ràng: Presentation ↔ BLL ↔ DAL ↔ PostgreSQL. Việc tách biệt trách nhiệm giúp code dễ test và mở rộng. Các service trong BLL sử dụng UnitOfWork/Repository từ DAL để thao tác dữ liệu.

(CHÈN HÌNH: sơ đồ kiến trúc: lớp Presentation -> BLL -> DAL -> PostgreSQL)

## CHƯƠNG 4: KẾT QUẢ NGHIÊN CỨU

### 4.1 Giao diện và chức năng đã triển khai

Ứng dụng hiển thị các giao diện cơ bản: trang chủ, trang danh sách sản phẩm, trang chi tiết sản phẩm, trang giỏ hàng và trang thanh toán. Các chức năng chính vận hành đúng theo yêu cầu: CRUD sản phẩm/danh mục (với xóa mềm), thêm/sửa/xóa giỏ hàng, tạo đơn hàng và lưu thông tin thanh toán.

(CHÈN HÌNH: ảnh chụp màn hình trang chủ của web ứng dụng)

(CHÈN HÌNH: ảnh chụp màn hình chi tiết sản phẩm)

(CHÈN HÌNH: ảnh chụp màn hình giỏ hàng và trang thanh toán)

### 4.2 Kiểm thử và đánh giá

Việc kiểm thử được thực hiện thủ công theo kịch bản chính: đăng ký/đăng nhập người dùng, thêm sản phẩm vào giỏ, tạo đơn hàng và lưu payment. Ứng dụng chạy ổn định trong môi trường Development. Cấu hình Npgsql với EnableRetryOnFailure giúp giảm lỗi khi kết nối DB gặp sự cố tạm thời.

Bên cạnh kiểm thử thủ công, đồ án khuyến nghị triển khai thêm kiểm thử tự động. Unit tests cho BLL (mock DAL) giúp đảm bảo các logic nghiệp vụ hoạt động đúng; integration tests có thể dùng một instance PostgreSQL tạm thời (ví dụ chạy trong Docker) để kiểm tra migration và seed data; smoke tests tự động nên kiểm tra flow cơ bản (đăng nhập, thêm giỏ, đặt hàng) sau mỗi lần deploy.

### 4.3 Kết quả đạt được

- Hoàn thiện luồng nghiệp vụ: sản phẩm → giỏ hàng → đơn hàng → thanh toán.
- Xây dựng mô hình dữ liệu đầy đủ và seed một số danh mục mẫu để chạy thử.

## CHƯƠNG 5: KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN

### 5.1 Kết luận

Đồ án "MilkTeaWebsite" đã thực hiện thành công mục tiêu đề ra: xây dựng một hệ thống web mẫu phục vụ bán hàng cho cửa hàng trà sữa, thể hiện rõ các chức năng quản lý sản phẩm, giỏ hàng, đơn hàng và thanh toán. Việc áp dụng kiến trúc phân lớp và Entity Framework Core giúp mã nguồn rõ ràng và dễ bảo trì.

### 5.2 Hạn chế

Mặc dù hoàn thiện các chức năng cơ bản, đồ án vẫn còn một số hạn chế: chưa tích hợp cổng thanh toán thực tế, giao diện quản trị còn đơn giản và chưa có hệ thống logging/monitoring nâng cao; bảo mật có thể được cải thiện (ví dụ: mã hóa kết nối, token-based auth).

Ngoài ra, hệ thống hiện chưa tích hợp giải pháp logging tập trung và monitoring để giám sát hoạt động trong môi trường production. Việc bổ sung Serilog/Seq hoặc ELK stack sẽ giúp thu thập log theo ngữ cảnh và xử lý lỗi dễ dàng hơn. Đồng thời, việc triển khai các endpoint metrics và dashboard (Prometheus/Grafana) sẽ hỗ trợ theo dõi performance và phát hiện sớm các vấn đề.

### 5.3 Hướng phát triển

Trong tương lai có thể mở rộng: tích hợp cổng thanh toán (VNPAY/Stripe), phát triển API cho mobile app, cải thiện giao diện quản trị, thêm tính năng upload ảnh/thumbnail và caching để tối ưu hiệu năng.

## DANH MỤC TÀI LIỆU THAM KHẢO

- Microsoft Docs — ASP.NET Core
- Microsoft Docs — Entity Framework Core
- Npgsql — PostgreSQL .NET data provider

Họ và tên sinh viên thực hiện: (Điền tên sinh viên)

**MỞ ĐẦU**

1. Lý do chọn đề tài

Trong bối cảnh thương mại điện tử phát triển, các cửa hàng F&B (food & beverage) như trà sữa cần một hệ thống quản lý bán hàng trực tuyến để mở rộng kênh bán, quản lý đơn hàng và sản phẩm hiệu quả. Đề tài "MilkTeaWebsite" được chọn nhằm thực hành xây dựng hệ thống bán hàng mẫu, áp dụng kiến thức về phát triển web, kiến trúc ứng dụng và quản trị cơ sở dữ liệu.

2. Mục tiêu nghiên cứu

- Thiết kế và triển khai một ứng dụng web bán hàng cho cửa hàng trà sữa.
- Triển khai các chức năng quản lý sản phẩm, danh mục, giỏ hàng, đặt hàng và thanh toán.
- Sử dụng ASP.NET Core Razor Pages và Entity Framework Core với PostgreSQL.

3. Đối tượng và phạm vi nghiên cứu

Đối tượng: một hệ thống web bán hàng (MilkTeaWebsite) cho cửa hàng trà sữa.
Phạm vi: Thiết kế cơ sở dữ liệu, backend (DAL + BLL), một giao diện Razor Pages cơ bản cho khách hàng, và các API nội bộ cho quản trị.

4. Phương pháp nghiên cứu

- Phân tích yêu cầu và thiết kế hệ thống theo mô hình phân lớp.
- Sử dụng Entity Framework Core để thiết kế mô hình dữ liệu và migration.
- Phát triển tính năng theo test manual và kiểm tra bằng môi trường Development.

## CHƯƠNG 1: NGHIÊN CỨU LÝ THUYẾT

1. Cơ sở lý thuyết

- Lập trình web với ASP.NET Core Razor Pages: mô tả cách Razor Pages hoạt động, routing, page models và data binding.
- ORM với Entity Framework Core: DbContext, DbSet, migrations, LINQ to Entities.
- Kiến trúc phân lớp: tách biệt phần Data Access Layer (DAL), Business Logic Layer (BLL) và Presentation.

2. Công nghệ và thư viện sử dụng

- ASP.NET Core 7 (Razor Pages)
- Entity Framework Core (Npgsql provider for PostgreSQL)
- PostgreSQL
- C# 11

3. Thiết kế an toàn và xử lý lỗi

- Sử dụng migration và seeding dữ liệu ban đầu.
- Cấu hình retry và command timeout cho Npgsql (xem `Program.cs`).

## CHƯƠNG 2: PHÂN TÍCH YÊU CẦU VÀ THIẾT KẾ

1. Yêu cầu chức năng chính

- Quản lý sản phẩm: CRUD sản phẩm, phân loại theo danh mục, quản lý ảnh và thông tin mô tả.
- Quản lý danh mục: CRUD danh mục sản phẩm.
- Giỏ hàng: thêm/xóa/sửa sản phẩm trong giỏ hàng, lưu trạng thái theo khách hàng.
- Đặt hàng: tạo đơn hàng từ giỏ hàng, tính toán tổng tiền, giảm giá và tạo chi tiết đơn hàng.
- Thanh toán: lưu thông tin thanh toán và trạng thái giao dịch.
- Quản lý người dùng: vai trò Admin/Employee/Customer, đăng nhập/đăng ký (AuthService có triển khai trong BLL).

2. Yêu cầu phi chức năng

- Hiệu năng: xử lý truy vấn đồng bộ/không đồng bộ bằng EF Core, cấu hình retry cho kết nối DB.
- Bảo mật: phân quyền đơn giản qua Role; lưu password dạng hash trong `User.PasswordHash`.
- Môi trường: chạy trên ASP.NET Core với PostgreSQL; hỗ trợ chế độ Development và Production.

3. Lược đồ use-case (tóm tắt)

- Khách hàng: duyệt sản phẩm, thêm giỏ hàng, đặt hàng, xem lịch sử đơn hàng.
- Nhân viên/Admin: quản lý sản phẩm/danh mục, xử lý đơn hàng, xem báo cáo.

## CHƯƠNG 3: HIỆN THỰC HÓA NGHIÊN CỨU

3.1 Mô tả bài toán

Xây dựng một hệ thống web cho cửa hàng trà sữa cho phép quản lý sản phẩm, giỏ hàng, đặt hàng và thanh toán. Hệ thống cần cung cấp giao diện cho khách hàng và trang quản trị cho nhân viên/admin.

3.2 Yêu cầu chức năng (chi tiết)

- Sản phẩm: tạo, sửa, xóa (ẩn mềm bằng `IsDeleted`), lấy sản phẩm theo danh mục và trạng thái sẵn có.
- Giỏ hàng: lưu Cart và CartItem, hỗ trợ các thuộc tính như Size, Topping, Note.
- Đơn hàng: lưu Order và OrderDetail, theo dõi trạng thái đơn, nhân viên xử lý và địa chỉ giao hàng.
- Thanh toán: lưu Payment liên kết 1-1 với Order.

3.3 Mô hình cơ sở dữ liệu

- Cơ sở dữ liệu thiết kế bằng Entity Framework Core, `ApplicationDbContext` khai báo các DbSet chính: Users, Roles, Customers, Employees, Categories, Products, Carts, CartItems, Orders, OrderDetails, Payments.

- (CHÈN HÌNH: sơ đồ ER của database — chụp màn hình `ApplicationDbContext` model hoặc Diagram từ công cụ thiết kế)

Mô tả các bảng chính (tóm tắt):

- Role: Id, RoleName, Description, CreatedAt
- User: Id, Username, Email, PasswordHash, RoleId, PhoneNumber
- Customer: thông tin liên quan đến User (FullName, Address, City,...)
- Category: CategoryName, Description, ImageUrl
- Product: ProductName, Description, Price, ImageUrl, Size, Topping, CategoryId, IsDeleted
- Cart / CartItem: Cart chứa nhiều CartItem; CartItem lưu thông tin UnitPrice, Size, Topping, Note
- Order / OrderDetail: Order lưu thông tin tổng, trạng thái, địa chỉ; OrderDetail lưu từng sản phẩm trong đơn
- Payment: PaymentMethod, PaymentStatus, Amount, TransactionId

3.4 Lược đồ Use case / DFD

- (CHÈN HÌNH: Use case diagram: các tác nhân Customer, Employee/Admin và các hành vi chính)

3.5 Kiến trúc hệ thống

Hệ thống sử dụng kiến trúc phân lớp:

- Presentation: ASP.NET Core Razor Pages (`MilkTeaWebsite` project)
- Business Logic Layer: `MilkTeaWebsite.BLL` — chứa các service như `AuthService`, `ProductService`, `CartService`, `OrderService`, `PaymentService`.
- Data Access Layer: `MilkTeaWebsite.DAL` — `ApplicationDbContext`, repositories và UnitOfWork (đăng ký `IUnitOfWork, UnitOfWork` trong DI).

- Cơ sở dữ liệu: PostgreSQL (config connection string trong `appsettings.json`).

- (CHÈN HÌNH: sơ đồ kiến trúc: lớp Presentation -> BLL -> DAL -> PostgreSQL)

## CHƯƠNG 4: KẾT QUẢ NGHIÊN CỨU

4.1 Giao diện và chức năng

- Giao diện chính: Razor Pages cho trang chủ, trang sản phẩm, trang chi tiết sản phẩm, giỏ hàng và trang thanh toán.
- Trang quản trị: (Nếu có) giao diện quản lý sản phẩm/danh mục/đơn hàng.

- (CHÈN HÌNH: ảnh chụp màn hình trang chủ của web ứng dụng)
- (CHÈN HÌNH: ảnh chụp màn hình chi tiết sản phẩm)
- (CHÈN HÌNH: ảnh chụp màn hình giỏ hàng và trang thanh toán)

4.2 Kiểm thử và đánh giá

- Kiểm thử thủ công: đăng ký/đăng nhập, thêm sản phẩm vào giỏ, tạo đơn hàng, thực hiện thanh toán (mô phỏng lưu Payment).
- Hiệu năng: ứng dụng sử dụng EF Core với các query không đồng bộ; Npgsql được cấu hình retry để tăng độ bền khi kết nối tới DB.

4.3 Các kết quả chính

- Đã triển khai thành công toàn bộ flow: sản phẩm -> giỏ hàng -> đặt hàng -> thanh toán.
- Mô hình dữ liệu hoàn chỉnh với seed data cho một số danh mục cơ bản.

## CHƯƠNG 5: KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN

5.1 Kết luận

Đồ án "MilkTeaWebsite" đã xây dựng một hệ thống mẫu phục vụ bán hàng cho cửa hàng trà sữa, minh họa được các chức năng quản lý sản phẩm, giỏ hàng, đơn hàng và thanh toán. Hệ thống áp dụng tốt kiến trúc phân lớp, sử dụng ASP.NET Core và EF Core với PostgreSQL.

5.2 Hướng phát triển

- Thêm hệ thống xác thực bằng JWT và API cho mobile.
- Tích hợp cổng thanh toán thực tế (PayPal/Stripe/VNPAY).
- Thêm hệ thống xử lý ảnh (upload/resize) và CDN.
- Tối ưu hiệu năng: caching, tối ưu query, pagination.

## DANH MỤC TÀI LIỆU THAM KHẢO

- Microsoft Docs - ASP.NET Core
- Microsoft Docs - Entity Framework Core
- Npgsql - PostgreSQL .NET data provider

Họ và tên SV thực hiện: (Điền tên SV)
