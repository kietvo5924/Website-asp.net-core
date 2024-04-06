using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class ThemDaiLyModel : PageModel
    {
        private readonly ILogger<ThemDaiLyModel> _logger;
        private readonly AppDbContext _context;

        public ThemDaiLyModel(AppDbContext context, ILogger<ThemDaiLyModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public IActionResult OnGet()
        {
            // Ki?m tra xem Session UserName ?ã t?n t?i hay không
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                // N?u không, chuy?n h??ng ng??i dùng ??n trang ??ng nh?p
                return RedirectToPage("/Login");
            }

            return Page();
        }

        public IActionResult OnPostLuuThongTinDaiLy(DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                _context.DaiLies.Add(daiLy);
                _context.SaveChanges();

                // Chuy?n h??ng ho?c th?c hi?n các thao tác khác sau khi l?u
                return RedirectToPage("SanPham");
            }

            var existingNhomHang = _context.DaiLies.FirstOrDefault(n => n.MaDaiLy == daiLy.MaDaiLy);

            if (existingNhomHang != null)
            {
                // X? lý khi ??i t??ng ?ã t?n t?i (trùng l?p)
                // Ví d?: Hi?n th? thông báo l?i, yêu c?u nh?p l?i, v.v.
                ModelState.AddModelError("Id", "Id ?ã t?n t?i. Vui lòng nh?p l?i.");
                return Page();
            }
            else
            {
                _context.DaiLies.Add(daiLy);
                _context.SaveChanges();

                // Chuy?n h??ng sau khi l?u thành công
                return RedirectToPage("SanPham");
            }
        }
    }
}
