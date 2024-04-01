using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class ThemChiTietHoaDonModel : PageModel
    {
        private readonly ILogger<ThemChiTietHoaDonModel> _logger;
        private readonly AppDbContext _context;

        public ThemChiTietHoaDonModel(AppDbContext context, ILogger<ThemChiTietHoaDonModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet(int Id)
        {
            ListSanPham = _context.SanPhams.ToList();
            ListHoaDon = _context.HoaDons.ToList();

            return Page();
        }

        public List<SanPham> ListSanPham { get; set; }
        public List<HoaDon> ListHoaDon { get; set; }

        public IActionResult OnPostLuuThongTinChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.ChiTietHoaDons.Add(chiTietHoaDon);
                _context.SaveChanges();

                // Chuy?n h??ng ho?c th?c hi?n các thao tác khác sau khi l?u
                return RedirectToPage("SanPham");
            }

            var existingNhomHang = _context.ChiTietHoaDons.FirstOrDefault(n => n.Id == chiTietHoaDon.Id);

            if (existingNhomHang != null)
            {
                // X? lý khi ??i t??ng ?ã t?n t?i (trùng l?p)
                // Ví d?: Hi?n th? thông báo l?i, yêu c?u nh?p l?i, v.v.
                ModelState.AddModelError("Id", "Id ?ã t?n t?i. Vui lòng nh?p l?i.");
                return Page();
            }
            else
            {
                _context.ChiTietHoaDons.Add(chiTietHoaDon);
                _context.SaveChanges();

                // Chuy?n h??ng sau khi l?u thành công
                return RedirectToPage("SanPham");
            }
        }
    }
}
