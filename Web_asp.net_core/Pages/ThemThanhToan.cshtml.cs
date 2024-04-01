using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_asp.net_core.Models;

namespace Web_asp.net_core.Pages
{
    public class ThemThanhToanModel : PageModel
    {
        private readonly ILogger<ThemThanhToanModel> _logger;
        private readonly AppDbContext _context;

        public ThemThanhToanModel(AppDbContext context, ILogger<ThemThanhToanModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet(int Id)
        {
            ListDaiLy = _context.DaiLies.ToList();

            return Page();
        }

        public DateTime NgayLapPhieu { get; set; }
        public List<DaiLy> ListDaiLy { get; set; }

        public IActionResult OnPostLuuThongTinThanhToan(ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                thanhToan.NgayLapPhieu = DateTime.Now;

                _context.ThanhToans.Add(thanhToan);
                _context.SaveChanges();

                // Chuy?n h??ng ho?c th?c hi?n các thao tác khác sau khi l?u
                return RedirectToPage("SanPham");
            }

            var existingNhomHang = _context.ThanhToans.FirstOrDefault(n => n.SoPhieuThu == thanhToan.SoPhieuThu);

            if (existingNhomHang != null)
            {
                // X? lý khi ??i t??ng ?ã t?n t?i (trùng l?p)
                // Ví d?: Hi?n th? thông báo l?i, yêu c?u nh?p l?i, v.v.
                ModelState.AddModelError("Id", "Id ?ã t?n t?i. Vui lòng nh?p l?i.");
                return Page();
            }
            else
            {
                _context.ThanhToans.Add(thanhToan);
                _context.SaveChanges();

                // Chuy?n h??ng sau khi l?u thành công
                return RedirectToPage("SanPham");
            }
        }
    }
}
