using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context, ILogger<LoginModel> logger)
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
            // Xác th?c ??ng nh?p
            if (AuthenticateUser(UserName, Password))
            {
                // L?u thông tin ??ng nh?p vào Session ho?c ViewData
                HttpContext.Session.SetString("UserName", UserName);

                // Chuy?n h??ng sau khi ??ng nh?p thành công
                return RedirectToPage("/Index");
            }
            else
            {
                // X? lý khi ??ng nh?p th?t b?i, hi?n th? thông báo l?i
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return RedirectToPage("/Register");
            }
        }

        public IActionResult OnPostLogout()
        {
            // Xóa Session UserName ?? ??ng xu?t ng??i dùng
            HttpContext.Session.Remove("UserName");

            // Tr? v? mã tr?ng thái HTTP 200 OK
            return RedirectToPage("/Login");
        }

        private bool AuthenticateUser(string userName, string password)
        {
            // Truy v?n c? s? d? li?u ?? ki?m tra xem thông tin ??ng nh?p có h?p l?
            var userFromDatabase = _context.Customers.SingleOrDefault(u => u.UserName == userName);

            // N?u không tìm th?y tên ng??i dùng
            if (userFromDatabase == null || string.IsNullOrEmpty(userFromDatabase.Password))
            {
                return false;
            }
            // Ki?m tra xem m?t kh?u có kh?p v?i m?t kh?u trong c? s? d? li?u hay không

            return BCrypt.Net.BCrypt.Verify(password, userFromDatabase.Password);
        }
    }
}
