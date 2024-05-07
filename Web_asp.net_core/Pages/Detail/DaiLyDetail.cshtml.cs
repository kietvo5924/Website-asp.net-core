using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_asp.net_core.Models;

namespace Web_asp.net_core.Pages.Detail
{
    public class DaiLyDetailModel : PageModel
    {
        private readonly AppDbContext _context;

        public DaiLyDetailModel(AppDbContext context)
        {
            _context = context;
        }

        public DaiLy daiLy { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            daiLy = _context.DaiLies.FirstOrDefault(m => m.MaDaiLy == id);

            if (daiLy == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
