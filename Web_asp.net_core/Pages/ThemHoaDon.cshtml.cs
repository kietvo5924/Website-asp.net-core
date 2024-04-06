using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class ThemHoaDonModel : PageModel
    {
        private readonly ILogger<ThemHoaDonModel> _logger;
        private readonly AppDbContext _context;

        public ThemHoaDonModel(AppDbContext context, ILogger<ThemHoaDonModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public IActionResult OnGet(int Id)
        {
            ListDaiLy = _context.DaiLies.ToList();

            // Ki?m tra xem Session UserName ?ã t?n t?i hay không
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                // N?u không, chuy?n h??ng ng??i dùng ??n trang ??ng nh?p
                return RedirectToPage("/Login");
            }

            return Page();
        }

        public List<DaiLy> ListDaiLy { get; set; }

        public IActionResult OnPostLuuThongTinHoaDon(HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chuy?n h??ng ho?c th?c hi?n các thao tác khác sau khi l?u
                return RedirectToPage("SanPham");
            }

            var existingNhomHang = _context.HoaDons.FirstOrDefault(n => n.SoHD == hoaDon.SoHD);

            if (existingNhomHang != null)
            {
                // X? lý khi ??i t??ng ?ã t?n t?i (trùng l?p)
                // Ví d?: Hi?n th? thông báo l?i, yêu c?u nh?p l?i, v.v.
                ModelState.AddModelError("Id", "Id ?ã t?n t?i. Vui lòng nh?p l?i.");
                return Page();
            }
            else
            {
                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chuy?n h??ng sau khi l?u thành công
                return RedirectToPage("SanPham");
            }
        }
    }
}
