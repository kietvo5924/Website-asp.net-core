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

            // Ki?m tra xem Session UserName ?� t?n t?i hay kh�ng
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                // N?u kh�ng, chuy?n h??ng ng??i d�ng ??n trang ??ng nh?p
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

                // Chuy?n h??ng ho?c th?c hi?n c�c thao t�c kh�c sau khi l?u
                return RedirectToPage("SanPham");
            }

            var existingNhomHang = _context.HoaDons.FirstOrDefault(n => n.SoHD == hoaDon.SoHD);

            if (existingNhomHang != null)
            {
                // X? l� khi ??i t??ng ?� t?n t?i (tr�ng l?p)
                // V� d?: Hi?n th? th�ng b�o l?i, y�u c?u nh?p l?i, v.v.
                ModelState.AddModelError("Id", "Id ?� t?n t?i. Vui l�ng nh?p l?i.");
                return Page();
            }
            else
            {
                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chuy?n h??ng sau khi l?u th�nh c�ng
                return RedirectToPage("SanPham");
            }
        }
    }
}
