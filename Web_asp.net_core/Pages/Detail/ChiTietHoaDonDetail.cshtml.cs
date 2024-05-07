using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_asp.net_core.Models;

namespace Web_asp.net_core.Pages.Detail
{
    public class ChiTietHoaDonDetailModel : PageModel
    {
        private readonly AppDbContext _context;

        public ChiTietHoaDonDetailModel(AppDbContext context)
        {
            _context = context;
        }

        public ChiTietHoaDon chiTietHoaDon { get; set; }
        public SanPham sanPham { get; set; }
        public HoaDon hoaDon { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            chiTietHoaDon = _context.ChiTietHoaDons.Include(i => i.SanPham).FirstOrDefault(m => m.Id == id);

            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
