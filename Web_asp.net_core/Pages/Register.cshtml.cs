using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace Web_asp.net_core.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context, ILogger<RegisterModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnPostRegister()
        {
            if (string.IsNullOrEmpty(Customer.Password))
            {
                ModelState.AddModelError(string.Empty, "Password is required.");
                return Page();
            }
            if (!IsValidPassword(Customer.Password))
            {
                ModelState.AddModelError(string.Empty, "Password must be at least 8 characters long and contain at least one special character.");
                return Page();
            }

            if (ModelState.IsValid)
            {

                // B?m m?t kh?u tr??c khi l?u vào c? s? d? li?u
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Customer.Password);

                // Thêm thông tin ng??i dùng vào c? s? d? li?u
                Customer.Password = hashedPassword;

                // Thêm thông tin ng??i dùng vào c? s? d? li?u
                _context.Customers.Add(Customer);
                _context.SaveChanges();

                // Chuy?n h??ng sau khi ??ng ký thành công
                return RedirectToPage("/Login", new { UserName = Customer.UserName });
            }

            // X? lý khi ModelState không h?p l?
            return Page();
        }
        private bool IsValidPassword(string password)
        {
            // Ki?m tra xem m?t kh?u có ít nh?t 8 ký t? và có ít nh?t m?t ký t? ??c bi?t
            return Regex.IsMatch(password, @"(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?/~`])\S{8,}");
        }
    }
}
