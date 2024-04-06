using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Pages
{
    public class EditHoaDonModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EditHoaDonModel> _logger;

        public EditHoaDonModel(AppDbContext context, ILogger<EditHoaDonModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public class EditHoaDonViewModel
        {
            public int SoHD { get; set; }

            [Required]
            [Display(Name = "Mã ??i lý")]
            public int MaDaiLy { get; set; }

            [Required]
            [Display(Name = "Ngày l?p hóa ??n")]
            public DateTime NgayLapHoaDon { get; set; }
        }

        [BindProperty]
        public EditHoaDonViewModel HoaDonToUpdate { get; set; }
        public List<DaiLy> ListDaiLy { get; private set; }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            // L?y danh sách các ??a ch? t? c? s? d? li?u
            ListDaiLy = await _context.DaiLies.ToListAsync();

            HoaDon hoaDon = _context.HoaDons.Find(Id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            HoaDonToUpdate = new EditHoaDonViewModel
            {
                SoHD = hoaDon.SoHD,
                MaDaiLy = hoaDon.MaDaiLy,
                NgayLapHoaDon = hoaDon.NgayLapHoaDon
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HoaDon hoaDon = _context.HoaDons.Find(HoaDonToUpdate.SoHD);
            if (hoaDon == null)
            {
                return NotFound();
            }

            hoaDon.SoHD = HoaDonToUpdate.SoHD;
            hoaDon.MaDaiLy = HoaDonToUpdate.MaDaiLy;
            hoaDon.NgayLapHoaDon = HoaDonToUpdate.NgayLapHoaDon;

            try
            {
                _context.Update(hoaDon);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonExists(HoaDonToUpdate.SoHD))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/HoaDon");
        }

        private bool HoaDonExists(int Id)
        {
            return _context.HoaDons.Any(e => e.SoHD == Id);
        }
    }
}
