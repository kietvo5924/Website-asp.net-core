using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_asp.net_core.Pages
{
    public class DaiLyModel : PageModel
    {
        private readonly ILogger<DaiLyModel> _logger;
        private readonly AppDbContext _context;

        public DaiLyModel(AppDbContext context, ILogger<DaiLyModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public List<DaiLy> DaiLyList { get; set; }
        
        public async Task OnGetAsync()
        {
            DaiLyList = await _context.DaiLies.ToListAsync();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var daiLy = await _context.DaiLies.FindAsync(id);   
            if (daiLy == null)
            {
                return NotFound();
            }

            _context.DaiLies.Remove(daiLy);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
