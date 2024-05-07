using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_asp.net_core.Models;

namespace Web_asp.net_core.Pages.Detail
{
    public class SanPhamDetailModel : PageModel
    {
        private readonly AppDbContext _context;

        public SanPhamDetailModel(AppDbContext context)
        {
            _context = context;
        }

        public SanPham SanPham { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SanPham = _context.SanPhams.FirstOrDefault(m => m.MaSanPham == id);

            if (SanPham == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
