# **NHẬN XÉT CỦA GIÁO VIÊN HƯỚNG DẪN**

_Trà Vinh, ngày …… tháng …… năm ……_

**Giáo viên hướng dẫn**

_(Ký tên và ghi rõ họ tên)_

# **NHẬN XÉT CỦA THÀNH VIÊN HỘI ĐỒNG**

_Trà Vinh, ngày …… tháng …… năm ……_

**Thành viên hội đồng**

_(Ký tên và ghi rõ họ tên)_

# **LỜI CẢM ƠN**

Kính thưa thầy ThS. Ngô Thanh Huy, tôi xin bày tỏ lòng cảm ơn chân thành đến thầy vì sự hướng dẫn và hỗ trợ quý báu trong suốt quá trình thực hiện đề tài Phát triển ứng dụng minichat bằng Java. Thầy đã dành nhiều thời gian và công sức để giúp tôi nắm bắt các khái niệm phức tạp và áp dụng chúng vào thực tiễn một cách hiệu quả.

Qua các buổi học online, thầy đã chia sẻ những kiến thức quý giá và cung cấp cho tôi những công cụ cần thiết để hoàn thành bài báo cáo môn Ứng dụng phát triển hướng dịch vụ. Tôi rất biết ơn sự nhiệt tình và kiên nhẫn của thầy trong việc giải đáp mọi thắc mắc và khó khăn mà tôi gặp phải.

Sự chỉ dẫn tận tình của thầy đã giúp tôi tự tin hơn trong việc phát triển ứng dụng, và những phản hồi của thầy đã góp phần quan trọng trong việc hoàn thiện sản phẩm cuối cùng. Tôi rất trân trọng những kiến thức và kinh nghiệm mà thầy đã truyền đạt, và chúng sẽ là hành trang quý báu cho tôi trong tương lai.

Một lần nữa, tôi xin chân thành cảm ơn thầy và mong rằng sẽ tiếp tục nhận được sự hướng dẫn từ thầy trong các môn học tiếp theo. Trân trọng cảm ơn!

# **MỤC LỤC**

[**NHẬN XÉT CỦA GIÁO VIÊN HƯỚNG DẪN** 1](#_Toc211671775)

[**NHẬN XÉT CỦA THÀNH VIÊN HỘI ĐỒNG** 2](#_Toc211671776)

[**LỜI CẢM ƠN** 3](#_Toc211671777)

[**MỤC LỤC** 4](#_Toc211671778)

[**DANH MỤC HÌNH ẢNH** 6](#_Toc211671779)

[**TÓM TẮT** 7](#_Toc211671780)

[**MỞ ĐẦU** 9](#_Toc211671781)

[**CHƯƠNG 1: TỔNG QUAN** 11](#_Toc211671782)

[**1.1 Mô hình Client-Server trong ứng dụng MiniChat** 11](#_Toc211671783)

[**1.2 Giao thức Socket và truyền tải dữ liệu trong MiniChat** 11](#_Toc211671784)

[**1.3 Bảo mật trong việc truyền tải dữ liệu** 11](#_Toc211671785)

[**1.4 Java và các tính năng hỗ trợ trong phát triển hệ thống** 12](#_Toc211671786)

[**1.5 Phát triển và cải tiến hệ thống** 12](#_Toc211671787)

[**CHƯƠNG 2: NGHIÊN CỨU LÝ THUYẾT** 13](#_Toc211671788)

[**2.1. Giới thiệu về mô hình Client-Server** 13](#_Toc211671789)

[**2.1.1. Khái niệm và nguyên lý hoạt động** 13](#_Toc211671790)

[**2.1.2. Vai trò của Client và Server trong hệ thống** 14](#_Toc211671791)

[**2.1.3. Ưu điểm và hạn chế của mô hình Client-Server** 15](#_Toc211671792)

[**2.2. Socket và các loại Socket** 17](#_Toc211671793)

[**2.2.1. Khái niệm về Socket trong lập trình mạng** 17](#_Toc211671794)

[**2.2.2. Phân loại Socket: Stream Socket và Datagram Socket** 18](#_Toc211671795)

[**2.3. Lập trình Java với Socket** 19](#_Toc211671796)

[**2.3.1. Thư viện và lớp hỗ trợ trong Java** 19](#_Toc211671797)

[**2.3.2. Quy trình thiết lập kết nối Client-Server bằng Java Socket** 20](#_Toc211671798)

[**2.3.3. Các ví dụ minh họa cơ bản** 22](#_Toc211671799)

[**2.4. Tính ổn định và quản lý kết nối** 23](#_Toc211671800)

[**2.4.1. Cơ chế quản lý nhiều kết nối đồng thời** 23](#_Toc211671801)

[**2.4.2. Xử lý lỗi và duy trì ổn định hệ thống** 24](#_Toc211671802)

[**CHƯƠNG 3: NỘI DUNG THỰC HIỆN** 27](#_Toc211671803)

[**3.1. Giải pháp** 27](#_Toc211671804)

[**3.2. Thực nghiệm** 28](#_Toc211671805)

[**3.3. Chạy chương trình _(Phụ lục)_** 36](#_Toc211671806)

[**CHƯƠNG 4: ĐÁNH GIÁ KẾT QUẢ** 37](#_Toc211671807)

[**4.1. Kết quả đạt được** 37](#_Toc211671808)

[**4.2. Hạn chế** 37](#_Toc211671809)

[**4.3. Hướng phát triển** 38](#_Toc211671810)

[**CHƯƠNG 5: KẾT LUẬN** 39](#_Toc211671811)

[**5.1. Kết quả đạt được** 39](#_Toc211671812)

[**5.2. Đóng góp mới** 39](#_Toc211671813)

[**5.3. Đề xuất phát triển** 40](#_Toc211671814)

[**5.4. Kết luận** 40](#_Toc211671815)

[**DANH MỤC TÀI LIỆU THAM KHẢO** 41](#_Toc211671816)

[**PHỤ LỤC** 42](#_Toc211671817)

# **DANH MỤC HÌNH ẢNH**

[Hình ảnh 1 Kiến trúc Client-Server 14](#_Toc211671818)

[Hình ảnh 2 Ưu và nhược điểm của Mô hình Máy chủ - Khách hàng 16](#_Toc211671819)

[Hình ảnh 3 Ổ cắm trong Mạng Máy Tính 17](#_Toc211671820)

[Hình ảnh 4 Kiến trúc máy khách máy chủ mô hình java 21](#_Toc211671821)

[Hình ảnh 5 Luồng, socket và giao tiếp 23](#_Toc211671822)

[Hình ảnh 6 Xử lý nhiều Máy chủ Quản lý 25](#_Toc211671823)

[Hình ảnh 7 Giao diện đăng nhập 42](#_Toc211671824)

[Hình ảnh 8 Giao diện các client kết nối và khung chát 42](#_Toc211671825)

[Hình ảnh 9 Chát chung 43](#_Toc211671826)

[Hình ảnh 10 Chát riêng 43](#_Toc211671827)

[Hình ảnh 11 Tạo nhóm 44](#_Toc211671828)

[Hình ảnh 12 Chát nhóm 44](#_Toc211671829)

# **TÓM TẮT**

Báo cáo này trình bày việc phát triển một ứng dụng minichat sử dụng Java, tập trung vào việc tạo ra một công cụ giao tiếp tức thời cho các nhóm người dùng trong cùng một mạng nội bộ. Mục tiêu chính là xây dựng một ứng dụng nhẹ nhàng, đơn giản nhưng đáp ứng đầy đủ các nhu cầu giao tiếp cơ bản, đồng thời đảm bảo tính bảo mật và ổn định trong quá trình hoạt động.

Vấn đề chính cần giải quyết là làm thế nào để duy trì kết nối liên tục giữa các người dùng, xử lý đồng thời nhiều yêu cầu giao tiếp và bảo vệ dữ liệu cá nhân khỏi những nguy cơ tiềm ẩn. Những vấn đề này đòi hỏi một hệ thống có khả năng mở rộng linh hoạt và được thiết kế theo các chuẩn bảo mật hiện đại.

Phương pháp tiếp cận sử dụng mô hình client-server, trong đó server đóng vai trò là trung tâm kết nối, nhận và phân phối tin nhắn giữa các client. Điều này không chỉ giúp quản lý dễ dàng các kết nối mà còn cho phép ứng dụng mở rộng quy mô mà không ảnh hưởng đến hiệu suất. Java Networking đã được sử dụng để quản lý các kết nối mạng, kết hợp với Java Multithreading để xử lý đồng thời nhiều kết nối.

Cách giải quyết vấn đề bao gồm các bước từ thiết kế giao diện người dùng, lập trình hệ thống server, xử lý kết nối socket đến việc tối ưu hóa truyền tải dữ liệu và bảo mật thông tin. Mỗi bước đều được thực hiện với mục tiêu đảm bảo ứng dụng hoạt động mượt mà, ổn định và an toàn.

Kết quả là một ứng dụng minichat hoàn chỉnh với giao diện đơn giản nhưng hiệu quả, có khả năng truyền tải tin nhắn nhanh chóng giữa các người dùng trong mạng nội bộ. Bên cạnh đó, hệ thống bảo mật bằng AES đã được tích hợp, đảm bảo rằng các tin nhắn được mã hóa an toàn trong quá trình truyền tải.

Kết luận báo cáo không chỉ chứng minh tính khả thi của việc phát triển một ứng dụng minichat bằng Java mà còn mở ra nhiều cơ hội để phát triển thêm các tính năng nâng cao trong tương lai.

# **MỞ ĐẦU**

**Lý do chọn đề tài**

Trong bối cảnh toàn cầu hóa và kết nối mạng không ngừng mở rộng, các ứng dụng chat trở thành công cụ không thể thiếu trong cuộc sống hiện đại. Việc phát triển một ứng dụng chat an toàn, hiệu quả và thân thiện với người dùng là nhu cầu cấp thiết. Đề tài Phát triển ứng dụng MiniChat sử dụng Java và công nghệ socket được chọn nhằm đáp ứng nhu cầu này.

**Mục đích nghiên cứu**

Mục đích của đề tài là phát triển một ứng dụng chat sử dụng kiến trúc Client-Server và công nghệ socket trong Java. Các mục tiêu cụ thể bao gồm:

- Hiểu và áp dụng kiến trúc Client-Server.
- Sử dụng công nghệ socket để tạo kết nối ổn định giữa client và server.
- Thiết kế giao diện người dùng thân thiện.
- Đảm bảo bảo mật và ổn định của hệ thống.
- Tích hợp và kiểm thử ứng dụng.

**Đối tượng nghiên cứu**

Đối tượng nghiên cứu bao gồm các thành phần kỹ thuật và thực tiễn liên quan đến phát triển ứng dụng chat:

- Kiến trúc Client-Server: Cách thức hoạt động và triển khai.
- Công nghệ socket trong Java: Sử dụng API socket để quản lý kết nối.
- Giao diện người dùng: Thiết kế và triển khai giao diện thân thiện.
- Bảo mật và ổn định: Đảm bảo an toàn và hiệu quả của hệ thống.

**Phạm vi nghiên cứu**

- Nghiên cứu lý thuyết:
- Kiến trúc Client-Server và công nghệ socket.
- Các kỹ thuật bảo mật thông tin.
- Phát triển ứng dụng:
- Thiết kế hệ thống và giao diện người dùng.
- Triển khai các chức năng trên server.
- Tích hợp và kiểm thử hệ thống.
- Đánh giá và hoàn thiện:
- Đánh giá hiệu quả hoạt động.
- Cải tiến và nâng cao chất lượng hệ thống.

**Ý nghĩa của đề tài**

Nghiên cứu và phát triển ứng dụng MiniChat mang lại nhiều giá trị, từ hiểu biết về công nghệ đến cung cấp công cụ giao tiếp hữu ích. Đề tài còn giúp nâng cao kỹ năng lập trình, giải quyết vấn đề và làm việc nhóm. Kết quả của nghiên cứu này có thể được ứng dụng trong nhiều lĩnh vực khác nhau, góp phần nâng cao hiệu quả công việc và học tập.

# **CHƯƠNG 1: TỔNG QUAN**

## **1.1 Mô hình Client-Server trong ứng dụng MiniChat**

Mô hình Client-Server là một kiến trúc quen thuộc trong phát triển các ứng dụng mạng. Với mô hình này, các client gửi yêu cầu tới server, và server xử lý yêu cầu đó trước khi gửi phản hồi lại cho client. Mô hình này giúp phân tách rõ ràng giữa các tác vụ và giúp tối ưu hóa việc quản lý các kết nối và dữ liệu. Đặc biệt trong các ứng dụng trò chuyện như MiniChat, mô hình Client-Server rất hữu ích trong việc phân phối và đồng bộ hóa tin nhắn giữa các người dùng.

MiniChat sẽ sử dụng mô hình này để cho phép các người dùng (client) kết nối đến một server duy nhất, từ đó gửi và nhận tin nhắn, tham gia vào các nhóm chat và quản lý các kết nối. Server sẽ có nhiệm vụ xử lý các yêu cầu từ client và phân phối tin nhắn tới các client phù hợp.

## **1.2 Giao thức Socket và truyền tải dữ liệu trong MiniChat**

Giao thức Socket là một công nghệ quan trọng trong việc thiết lập kết nối giữa các máy tính và giúp truyền tải dữ liệu qua mạng. Socket giúp việc giao tiếp giữa client và server trở nên nhanh chóng và hiệu quả, đặc biệt khi truyền tải các tin nhắn trong thời gian thực.

Trong MiniChat, giao thức Socket sẽ giúp đảm bảo rằng các tin nhắn được truyền tải giữa các client và server một cách mượt mà. Socket cũng cho phép hệ thống hỗ trợ các kết nối đồng thời giữa nhiều client mà không gặp phải vấn đề về hiệu suất.

## **1.3 Bảo mật trong việc truyền tải dữ liệu**

MiniChat sẽ sử dụng các biện pháp bảo mật như mã hóa SSL/TLS để bảo vệ thông tin của người dùng trong quá trình truyền tải dữ liệu qua mạng. Việc mã hóa này sẽ giúp ngăn ngừa các cuộc tấn công từ bên ngoài và đảm bảo rằng tin nhắn của người dùng không bị xâm nhập khi chúng di chuyển qua mạng.

Bảo mật là yếu tố quan trọng trong việc phát triển các ứng dụng trò chuyện, đặc biệt khi người dùng trao đổi thông tin cá nhân hoặc thông tin nhạy cảm. MiniChat sẽ áp dụng các phương pháp bảo mật mạnh mẽ để bảo vệ quyền riêng tư của người dùng.

## **1.4 Java và các tính năng hỗ trợ trong phát triển hệ thống**

Java là ngôn ngữ lập trình lý tưởng cho việc phát triển các ứng dụng mạng nhờ vào khả năng đa nền tảng và hiệu suất ổn định. Việc sử dụng Java trong MiniChat sẽ giúp tối ưu hóa việc phát triển và bảo trì hệ thống, đồng thời giúp đảm bảo tính linh hoạt và khả năng mở rộng trong tương lai.

Java cung cấp các thư viện mạnh mẽ cho phép dễ dàng quản lý các kết nối và truyền tải dữ liệu. Điều này giúp MiniChat có thể xử lý nhiều kết nối đồng thời mà không ảnh hưởng đến hiệu suất của hệ thống.

## **1.5 Phát triển và cải tiến hệ thống**

MiniChat có thể tiếp tục phát triển trong tương lai với các tính năng như gửi file, gọi video, hoặc tích hợp với các nền tảng khác để nâng cao trải nghiệm người dùng. Hệ thống có thể mở rộng để phục vụ cho các nhóm lớn hoặc các tổ chức, doanh nghiệp.

# **CHƯƠNG 2: NGHIÊN CỨU LÝ THUYẾT**

## **2.1. Giới thiệu về mô hình Client-Server**

### **2.1.1. Khái niệm và nguyên lý hoạt động**

Mô hình Client-Server là một trong những kiến trúc cơ bản và phổ biến nhất trong lĩnh vực mạng máy tính và lập trình ứng dụng phân tán. Khi nghiên cứu, tôi nhận thấy đây là phương thức tổ chức giao tiếp giữa hai thực thể chính: Client (máy khách) và Server (máy chủ). Trong đó, Client đóng vai trò là bên gửi yêu cầu dịch vụ, còn Server là bên tiếp nhận, xử lý và trả về kết quả cho Client. Nguyên lý hoạt động của mô hình này được ví như mối quan hệ "hỏi - đáp": Client luôn là nơi khởi tạo yêu cầu, còn Server chịu trách nhiệm phản hồi dựa trên khả năng và tài nguyên mà nó quản lý.

Một đặc điểm quan trọng tôi tìm hiểu được là quá trình giao tiếp trong mô hình Client-Server diễn ra theo quy tắc chặt chẽ, thông qua các giao thức mạng tiêu chuẩn như TCP/IP hoặc UDP. Ví dụ, khi một ứng dụng chat nhỏ được xây dựng bằng Java, Client sẽ gửi yêu cầu kết nối đến địa chỉ IP và cổng của Server. Sau đó, Server lắng nghe yêu cầu, chấp nhận kết nối, rồi trao đổi dữ liệu hai chiều. Nhờ vậy, tôi có thể dễ dàng hình dung được cơ chế truyền tin được kiểm soát, có điểm đầu và điểm cuối rõ ràng.


## **3.3. Chạy chương trình _(Phụ lục)_**

# **CHƯƠNG 4: ĐÁNH GIÁ KẾT QUẢ**

## **4.1. Kết quả đạt được**

Trong quá trình triển khai hệ thống dự án đã hoàn thành tốt các mục tiêu đề ra. Một trong những điểm đáng chú ý là khả năng quản lý tốt nhiều kết nối từ các client. Người dùng có thể gửi và nhận tin nhắn theo thời gian thực mà không gặp bất kỳ sự cố nào về hiệu suất. Hệ thống cũng đã hỗ trợ tính năng gửi tin nhắn riêng tư giữa các người dùng, mang lại sự linh hoạt và hiệu quả trong giao tiếp cá nhân.

Việc cập nhật danh sách người dùng trực tuyến theo thời gian thực là một tính năng nổi bật khác, giúp người dùng dễ dàng biết được những ai đang tham gia trong phòng chat và từ đó dễ dàng chọn người để gửi tin nhắn. Về mặt kỹ thuật, hệ thống sử dụng các thread độc lập để quản lý kết nối của từng client, giúp server duy trì được tính ổn định ngay cả khi có nhiều người dùng tham gia cùng lúc.

Nhìn chung, hệ thống đã hoàn thành tốt các yêu cầu về khả năng giao tiếp đồng thời và đáp ứng nhu cầu sử dụng của người dùng một cách hiệu quả.

## **4.2. Hạn chế**

Mặc dù đạt được nhiều kết quả tích cực, nhưng hệ thống vẫn còn một số hạn chế nhất định. Đầu tiên là về bảo mật. Hiện tại, dữ liệu giữa server và client không được mã hóa, dẫn đến rủi ro bảo mật. Điều này có thể tạo ra nguy cơ rò rỉ thông tin nếu có sự can thiệp từ các bên thứ ba. Việc bảo vệ dữ liệu người dùng trong quá trình truyền tải là vô cùng quan trọng, và đây là một điểm yếu cần khắc phục.

Hơn nữa, hệ thống chưa hỗ trợ lưu trữ lịch sử tin nhắn, khiến người dùng không thể xem lại các cuộc trò chuyện trước đó khi thoát khỏi phòng chat. Điều này gây ra sự bất tiện, đặc biệt đối với những người cần theo dõi nội dung của các cuộc trò chuyện dài hạn hoặc liên tục.

Ngoài ra, giao diện của hệ thống cũng còn khá đơn giản và thiếu các tính năng hiện đại như thông báo khi có tin nhắn mới hoặc hiển thị trạng thái người dùng (trực tuyến, đang gõ). Điều này có thể làm giảm trải nghiệm của người dùng và cần được cải thiện để tăng tính tiện ích và thu hút hơn.

## **4.3. Hướng phát triển**

Trong tương lai, hệ thống cần được phát triển thêm về bảo mật và trải nghiệm người dùng. Trước tiên, việc áp dụng các giao thức mã hóa như SSL/TLS sẽ giúp bảo vệ dữ liệu người dùng trong quá trình truyền tải, đảm bảo rằng các cuộc trò chuyện được an toàn và không bị đánh cắp thông tin. Mã hóa end-to-end cũng nên được xem xét để tăng cường bảo mật cho các tin nhắn cá nhân.

Việc phát triển tính năng lưu trữ lịch sử tin nhắn cũng là một hướng đi quan trọng, giúp người dùng có thể xem lại các tin nhắn đã gửi và nhận trước đó. Điều này không chỉ cải thiện trải nghiệm người dùng mà còn giúp họ quản lý thông tin một cách hiệu quả hơn. Cuối cùng, nâng cấp giao diện người dùng với các tính năng hiện đại như thông báo tin nhắn mới, trạng thái hoạt động của người dùng sẽ giúp hệ thống trở nên hấp dẫn hơn và thân thiện hơn với người sử dụng.

# **CHƯƠNG 5: KẾT LUẬN**

## **5.1. Kết quả đạt được**

Hệ thống đã đạt được nhiều kết quả tích cực trong quá trình phát triển và triển khai. Server có khả năng xử lý đa kết nối từ nhiều người dùng một cách đồng thời, giúp đảm bảo rằng các cuộc trò chuyện diễn ra một cách mượt mà và không bị gián đoạn. Điều này đã cải thiện trải nghiệm giao tiếp thời gian thực, khi mà sự ổn định và tốc độ phản hồi nhanh chóng đóng vai trò quyết định trong hiệu quả sử dụng.

Tính năng gửi tin nhắn riêng tư đã hoạt động ổn định, giúp người dùng có thể lựa chọn giữa việc gửi tin nhắn công khai hoặc riêng tư một cách linh hoạt. Khả năng này đã giúp tăng cường tính linh hoạt trong việc giao tiếp và đảm bảo rằng các cuộc trò chuyện riêng tư được bảo mật. Ngoài ra, hệ thống còn tích hợp chức năng cập nhật danh sách người dùng trực tuyến theo thời gian thực, giúp người dùng nhanh chóng nhận diện được những người đang tham gia phòng chat và tương tác dễ dàng.

Giao diện người dùng của hệ thống tuy đơn giản nhưng đã thể hiện được tính hiệu quả, giúp người dùng dễ dàng làm quen và sử dụng các tính năng chính mà không gặp khó khăn. Điều này đã giúp nâng cao trải nghiệm người dùng, đặc biệt là với những người mới sử dụng.

## **5.2. Đóng góp mới**

Dự án đã mang lại những đóng góp quan trọng trong việc phát triển hệ thống chat client-server. Một trong những đóng góp đáng chú ý nhất là việc sử dụng kiến trúc thread-based để xử lý nhiều kết nối đồng thời một cách ổn định và hiệu quả. Điều này giúp hệ thống có thể mở rộng quy mô trong tương lai mà không gặp phải những vấn đề về hiệu suất.

Ngoài ra, tính năng gửi tin nhắn riêng tư giữa người dùng đã mang lại sự linh hoạt và tiện dụng, giúp người dùng có thể giao tiếp một cách bảo mật khi cần thiết. Tính năng cập nhật danh sách người dùng theo thời gian thực là một đóng góp khác, giúp người dùng dễ dàng theo dõi và tương tác với các thành viên trong phòng chat, cải thiện khả năng tương tác và kết nối giữa các thành viên.

## **5.3. Đề xuất phát triển**

Để hệ thống tiếp tục phát triển và đáp ứng tốt hơn nhu cầu của người dùng, một số cải tiến cần được xem xét. Đầu tiên, tính bảo mật cần được nâng cao bằng cách tích hợp các giao thức bảo mật như SSL/TLS để mã hóa dữ liệu truyền tải giữa server và client. Điều này sẽ giúp bảo vệ thông tin người dùng khỏi các cuộc tấn công mạng và đảm bảo rằng dữ liệu được bảo mật.

Ngoài ra, tính năng lưu trữ lịch sử tin nhắn cần được phát triển thêm để người dùng có thể xem lại các cuộc trò chuyện trước đó. Đây là một tính năng quan trọng trong các hệ thống chat hiện đại, giúp người dùng dễ dàng theo dõi lại thông tin cần thiết mà không gặp khó khăn.

Cuối cùng, giao diện người dùng có thể được nâng cấp để hỗ trợ các tính năng như thông báo tin nhắn mới và trạng thái người dùng (trực tuyến, đang gõ tin nhắn), giúp tăng cường tính tương tác và cải thiện trải nghiệm người dùng.

## **5.4. Kết luận**

Tổng kết lại, hệ thống đã hoàn thành xuất sắc các chức năng cơ bản của một ứng dụng chat client-server. Các tính năng như gửi tin nhắn công khai, riêng tư, cập nhật danh sách người dùng theo thời gian thực và quản lý nhiều kết nối đồng thời đã hoạt động tốt, mang lại trải nghiệm giao tiếp hiệu quả cho người dùng. Với các đề xuất cải tiến về bảo mật, lưu trữ tin nhắn và giao diện người dùng, hệ thống sẽ trở nên mạnh mẽ và hoàn thiện hơn, đáp ứng tốt hơn các nhu cầu của người dùng trong tương lai.

# **DANH MỤC TÀI LIỆU THAM KHẢO**

- **Lập trình Python và giao tiếp mạng**. Hà Nội: NXB Khoa học và Kỹ thuật.
- **Lập trình Java và mạng cơ bản**. <https://laptrinhonline.vn/python>.
- **Học lập trình Python cho người mới bắt đầu**. <https://mindx.edu.vn/python>.
- **Lập trình Python và giao tiếp mạng**. Hà Nội: NXB Khoa học và Kỹ thuật.
- **Cộng đồng lập trình Python Việt Nam**. <https://vietpython.com/>.

# **PHỤ LỤC**

Hình ảnh 7 Giao diện đăng nhập
