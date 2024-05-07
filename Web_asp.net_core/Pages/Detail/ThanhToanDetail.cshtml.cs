using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_asp.net_core.Models;

namespace Web_asp.net_core.Pages.Detail
{
    public class ThanhToanDetailModel : PageModel
    {
        private readonly AppDbContext _context;

        public ThanhToanDetailModel(AppDbContext context)
        {
            _context = context;
        }

        public ThanhToan thanhToan { get; set; }
        public DaiLy daiLy { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            thanhToan = _context.ThanhToans.Include(i => i.DaiLy).FirstOrDefault(m => m.SoPhieuThu == id);

            if (thanhToan == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
