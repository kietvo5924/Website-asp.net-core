using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class SanPhamModel : PageModel
    {
        private readonly ILogger<SanPhamModel> _logger;
        private readonly AppDbContext _context;

        public SanPhamModel(AppDbContext context, ILogger<SanPhamModel> logger)
        {
            _logger = logger;
            _context = context;

            // Kh?i t?o NhomHangList ?? tránh c?nh báo CS8618
            SanPhamList = new List<SanPham>();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public List<SanPham> SanPhamList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                // N?u không, chuy?n h??ng ng??i dùng ??n trang ??ng nh?p
                return RedirectToPage("/Login");
            }

            SanPhamList = await _context.SanPhams.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);

            if (sanPham == null)
            {
                return NotFound();
            }

            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();

            return RedirectToPage("SanPham");
        }
    }
}
