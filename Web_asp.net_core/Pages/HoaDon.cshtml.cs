using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class HoaDonModel : PageModel
    {
        private readonly ILogger<HoaDonModel> _logger;
        private readonly AppDbContext _context;

        public HoaDonModel(AppDbContext context, ILogger<HoaDonModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public List<HoaDon> HoaDonList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                // N?u không, chuy?n h??ng ng??i dùng ??n trang ??ng nh?p
                return RedirectToPage("/Login");
            }

            HoaDonList = await _context.HoaDons.ToListAsync();
            foreach (var hoaDon in HoaDonList)
            {
                hoaDon.DaiLy = await _context.DaiLies.FindAsync(hoaDon.MaDaiLy);
            }   

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
