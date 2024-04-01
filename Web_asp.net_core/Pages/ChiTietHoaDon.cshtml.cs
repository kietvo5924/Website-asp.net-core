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

        public List<ChiTietHoaDon> ChiTietHoaDonList { get; set; }

        public async Task OnGetAsync()
        {
            ChiTietHoaDonList = await _context.ChiTietHoaDons.ToListAsync();
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
