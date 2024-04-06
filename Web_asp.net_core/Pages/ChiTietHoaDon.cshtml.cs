using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class ChiTietHoaDonModel : PageModel
    {
        private readonly ILogger<ChiTietHoaDonModel> _logger;
        private readonly AppDbContext _context;

        public ChiTietHoaDonModel(AppDbContext context, ILogger<ChiTietHoaDonModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public List<ChiTietHoaDon> ChiTietHoaDonList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                // N?u không, chuy?n h??ng ng??i dùng ??n trang ??ng nh?p
                return RedirectToPage("/Login");
            }

            ChiTietHoaDonList = await _context.ChiTietHoaDons.ToListAsync();
            foreach (var chiTietHoaDon in ChiTietHoaDonList)
            {
                chiTietHoaDon.SanPham = await _context.SanPhams.FindAsync(chiTietHoaDon.MaSanPham);
            }

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var chiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);

            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            _context.ChiTietHoaDons.Remove(chiTietHoaDon);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

    }
}
