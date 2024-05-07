using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_asp.net_core.Models;

namespace Web_asp.net_core.Pages.Detail
{
    public class HoaDonDetailModel : PageModel
    {
        private readonly AppDbContext _context;

        public HoaDonDetailModel(AppDbContext context)
        {
            _context = context;
        }

        public HoaDon hoaDon { get; set; }
        public DaiLy daiLy { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            hoaDon = _context.HoaDons.Include(i => i.DaiLy).FirstOrDefault(m => m.SoHD == id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
