# **Student Portal MVC (Hệ thống Quản lý Đào tạo Đại học)**

## **1. CÁCH THỨC HOẠT ĐỘNG & QUY TRÌNH NGHIỆP VỤ CỐT LÕI**
Hệ thống được thiết kế theo mô hình Phân quyền đa tầng (Role-Based & Resource-Based). Tùy thuộc vào việc ai đang đăng nhập, giao diện và các luồng thao tác sẽ thay đổi hoàn toàn để khớp với nghiệp vụ của người đó.

### **1.1. Luồng thao tác của Sinh viên (Student)**
Sinh viên sử dụng hệ thống để theo dõi tiến độ học tập và đăng ký môn học.
* **Đăng ký môn học (Nghiệp vụ phức tạp nhất):** Khi sinh viên bấm "Đăng ký" một lớp học, hệ thống không lưu ngay mà sẽ đưa vào một chuỗi kiểm duyệt khắt khe (Database Transaction). 
  1. **Kiểm tra thời gian:** Học kỳ hiện tại có đang mở cửa đăng ký không?
  2. **Kiểm tra sức chứa (Capacity):** Lớp học còn slot trống không? (Hệ thống có cơ chế chặn đụng độ nếu 2 sinh viên cùng giành nhau 1 slot cuối cùng).
  3. **Kiểm tra trùng lịch:** Thứ và Tiết học của lớp này có bị trùng lấp với bất kỳ lớp nào sinh viên đã đăng ký trước đó không?
  4. **Kiểm tra Môn tiên quyết:** Sinh viên đã học và đạt điểm qua môn (> 5.0) đối với các môn học yêu cầu của môn này chưa?
  *Nếu vượt qua toàn bộ 4 vòng kiểm tra, hệ thống mới ghi nhận đăng ký và trừ đi 1 slot của lớp học.*
* **Hủy đăng ký (Unenroll):** Trả lại slot cho lớp học. Nút hủy sẽ bị vô hiệu hóa nếu Giảng viên đã bắt đầu nhập điểm cho sinh viên đó.
* **Theo dõi Bảng điểm & GPA:** Hệ thống không lưu cứng điểm GPA. Mỗi khi sinh viên mở bảng điểm, hệ thống sẽ tự động tổng hợp các môn đã có điểm, nhân hệ số tín chỉ và tính toán GPA (On-the-fly) theo thời gian thực.

### **1.2. Luồng thao tác của Giảng viên & Trưởng Khoa/Ngành (Professor / HeadMaster)**
Hệ thống phân tách rạch ròi giữa quyền của "Giảng viên thông thường" và "Trưởng khoa / Trưởng ngành".
* **Giảng viên thông thường:**
  * Truy cập danh sách các Lớp học đang mở của Khoa mình. Nếu lịch trống, có thể bấm nút **"Nhận dạy lớp"**. Hệ thống sẽ kiểm tra xem lớp đó có bị trùng lịch với các lớp thầy/cô đang dạy hay không.
  * Truy cập danh sách sinh viên của lớp mình đang dạy để **Nhập điểm**. Áp dụng cơ chế an toàn: nếu 2 giảng viên cùng dạy 1 lớp và cùng lúc sửa điểm của 1 sinh viên, người lưu sau sẽ bị chặn lại để tránh ghi đè dữ liệu.
* **Trưởng Khoa / Trưởng Ngành (Resource-Based Policy):**
  * Được trao quyền đặc biệt để **Tạo/Sửa/Xóa Môn học** và **Mở Lớp học mới**.
  * **Cách ly dữ liệu (Data Isolation):** Trưởng khoa của Khoa Công nghệ Thông tin CHỈ nhìn thấy và chỉ được phép thao tác trên các Môn học/Lớp học thuộc Khoa CNTT. Không thể can thiệp vào dữ liệu của Khoa khác.

### **1.3. Luồng thao tác của Quản trị viên (Admin)**
Admin là người vận hành cốt lõi, không trực tiếp giảng dạy nhưng thiết lập "sân chơi" cho toàn trường.
* **Quản lý Tài khoản Động:** Khi Admin tạo User mới, Form sẽ tự động biến đổi giao diện (Dùng JS). Chọn Role Sinh viên thì bắt buộc chọn Ngành/Khoa; chọn Role Worker thì bắt buộc nhập Phòng ban.
* **Quản lý Cấu trúc Đào tạo (Master-Detail):** Admin tạo Khoa mới và điền luôn danh sách các Ngành thuộc Khoa đó trên cùng 1 biểu mẫu. 
* **Điều phối Học kỳ:** Admin quyết định thêm Học kỳ mới và là người cầm "Công tắc" (Toggle) để Bật/Tắt đợt đăng ký môn học của toàn trường.
* **Hệ thống Thông báo (Notification Hub):** Admin có thể "phát loa" thông báo. Hệ thống cho phép lọc cực kỳ chi tiết: Gửi chung toàn trường, gửi riêng cho 1 Role (VD: Toàn bộ Giảng viên), gửi riêng cho 1 Khoa, 1 Ngành, hoặc đích danh 1 cá nhân.
* **Tài chính & Lương thưởng:** Cấp phát học bổng cho sinh viên hoặc lương cho nhân viên.

### **1.4. Luồng thao tác của Nhân sự / Giáo vụ (Worker)**
* Chủ yếu xem thông báo từ Admin, cập nhật thông tin hồ sơ (Phòng ban, Chức vụ).
* Quản lý thu nhập: Truy cập để xem lịch sử nhận Lương/Thưởng của chính bản thân (Dữ liệu bị ẩn hoàn toàn với các Worker khác).

---

## **2. CÁC CƠ CHẾ ĐẢM BẢO AN TOÀN VẬN HÀNH**
Để các luồng nghiệp vụ trên không bị hỏng hóc trong quá trình chạy thực tế, hệ thống áp dụng các cơ chế ngầm:
* **Chống đụng độ (RowVersion Concurrency):** Mọi hành động nhạy cảm (Sửa điểm, Đăng ký môn lấy slot) đều được gắn một mã phiên bản. Tránh triệt để lỗi "Last Save Wins" khi có thao tác đồng thời.
* **Xóa an toàn (Soft Delete):** Mọi thao tác "Xóa" trên giao diện (Xóa User, Hủy lớp, Bỏ môn học) thực chất chỉ là đổi cờ `IsDeleted`. Dữ liệu vẫn được giữ lại nguyên vẹn trong DB để không làm hỏng lịch sử tài chính hay bảng điểm.
* **Audit Logs (Lưu vết hệ thống):** Bất kỳ ai thực hiện hành động Thêm/Sửa/Xóa, hệ thống tự động ghi lại IP, Thời gian, Tên người dùng và Kết quả (Thành công/Thất bại) để Admin truy vết.

---

## **3. TỔNG QUAN KIẾN TRÚC**
Hệ thống được thiết kế tinh gọn để dễ bảo trì và dễ mở rộng tính năng sau này:
* **N-Tier Architecture (Kiến trúc 3 lớp):** Tuân thủ tuyệt đối luồng dữ liệu: `Controller` (Nhận Request) $\rightarrow$ `Service` (Xử lý toàn bộ logic nghiệp vụ, tính toán) $\rightarrow$ `Repository` (Thực thi truy vấn LINQ/SQL) $\rightarrow$ `Database`. 
* **Database & ORM:** Dùng SQLite và Entity Framework Core.
* **Authentication:** Dùng ASP.NET Core Identity.
* **Observability (Giám sát):** Có hệ thống ghi log ra file bằng `Serilog`, có endpoint kiểm tra sức khỏe Database (`HealthChecks`) và API trả lỗi chuẩn hóa (`ProblemDetails`).
