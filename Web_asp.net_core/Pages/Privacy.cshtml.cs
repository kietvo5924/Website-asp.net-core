using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly AppDbContext _context;

        public PrivacyModel(AppDbContext context, ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostLogin()
        {
            // Xác thực đăng nhập
            if (AuthenticateUser(UserName, Password))
            {
                // Lưu thông tin đăng nhập vào Session hoặc ViewData
                HttpContext.Session.SetString("UserName", UserName);

                // Chuyển hướng sau khi đăng nhập thành công
                return RedirectToPage("/ThemSanPham");
            }
            else
            {
                // Xử lý khi đăng nhập thất bại, hiển thị thông báo lỗi
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return RedirectToPage("/Register");
            }
        }

        private bool AuthenticateUser(string userName, string password)
        {
            // Truy vấn cơ sở dữ liệu để kiểm tra xem thông tin đăng nhập có hợp lệ
            var userFromDatabase = _context.Customers.SingleOrDefault(u => u.UserName == userName);

            // Nếu không tìm thấy tên người dùng
            if (userFromDatabase == null || string.IsNullOrEmpty(userFromDatabase.Password))
            {
                return false;
            }
            // Kiểm tra xem mật khẩu có khớp với mật khẩu trong cơ sở dữ liệu hay không

            return BCrypt.Net.BCrypt.Verify(password, userFromDatabase.Password);
        }
    }
}

