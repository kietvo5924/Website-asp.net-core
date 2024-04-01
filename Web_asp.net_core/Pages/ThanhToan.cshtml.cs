using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class ThanhToanModel : PageModel
    {
        private readonly ILogger<ThanhToanModel> _logger;
        private readonly AppDbContext _context;

        public ThanhToanModel(AppDbContext context, ILogger<ThanhToanModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public List<ThanhToan> ThanhToanList { get; set; }

        public async Task OnGetAsync()
        {
            ThanhToanList = await _context.ThanhToans.ToListAsync();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var thanhToan = await _context.ThanhToans.FindAsync(id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            _context.ThanhToans.Remove(thanhToan);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
