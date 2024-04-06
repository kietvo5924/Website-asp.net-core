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
            // X�c th?c ??ng nh?p
            if (AuthenticateUser(UserName, Password))
            {
                // L?u th�ng tin ??ng nh?p v�o Session ho?c ViewData
                HttpContext.Session.SetString("UserName", UserName);

                // Chuy?n h??ng sau khi ??ng nh?p th�nh c�ng
                return RedirectToPage("/Index");
            }
            else
            {
                // X? l� khi ??ng nh?p th?t b?i, hi?n th? th�ng b�o l?i
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return RedirectToPage("/Register");
            }
        }

        public IActionResult OnPostLogout()
        {
            // X�a Session UserName ?? ??ng xu?t ng??i d�ng
            HttpContext.Session.Remove("UserName");

            // Tr? v? m� tr?ng th�i HTTP 200 OK
            return RedirectToPage("/Login");
        }

        private bool AuthenticateUser(string userName, string password)
        {
            // Truy v?n c? s? d? li?u ?? ki?m tra xem th�ng tin ??ng nh?p c� h?p l?
            var userFromDatabase = _context.Customers.SingleOrDefault(u => u.UserName == userName);

            // N?u kh�ng t�m th?y t�n ng??i d�ng
            if (userFromDatabase == null || string.IsNullOrEmpty(userFromDatabase.Password))
            {
                return false;
            }
            // Ki?m tra xem m?t kh?u c� kh?p v?i m?t kh?u trong c? s? d? li?u hay kh�ng

            return BCrypt.Net.BCrypt.Verify(password, userFromDatabase.Password);
        }
    }
}
