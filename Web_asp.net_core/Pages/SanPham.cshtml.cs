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

            // Kh?i t?o NhomHangList ?? tr�nh c?nh b�o CS8618
            SanPhamList = new List<SanPham>();
        }

        public List<SanPham> SanPhamList { get; set; }

        public async Task OnGetAsync()
        {
            SanPhamList = await _context.SanPhams.ToListAsync();
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
