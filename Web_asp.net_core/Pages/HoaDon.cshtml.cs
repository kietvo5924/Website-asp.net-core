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

        public List<HoaDon> HoaDonList { get; set; }

        public async Task OnGetAsync()
        {
            HoaDonList = await _context.HoaDons.ToListAsync();
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
