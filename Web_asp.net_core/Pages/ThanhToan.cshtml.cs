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

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public List<ThanhToan> ThanhToanList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Ki?m tra xem Session UserName ?ã t?n t?i hay không
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
            {
                // N?u không, chuy?n h??ng ng??i dùng ??n trang ??ng nh?p
                return RedirectToPage("/Login");
            }

            ThanhToanList = await _context.ThanhToans.ToListAsync();
            foreach (var thanhToan in ThanhToanList)
            {
                thanhToan.DaiLy = await _context.DaiLies.FindAsync(thanhToan.MaDaiLy);
            }

            return Page();
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
