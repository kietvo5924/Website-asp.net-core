using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Pages
{
    public class EditThanhToanModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public EditThanhToanModel(AppDbContext context, ILogger<EditThanhToanModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public class EditThanhToanViewModel
        {
            public int SoPhieuThu { get; set; }

            [Required]
            [Display(Name = "Ngày l?p phi?u")]
            public DateTime NgayLapPhieu { get; set; }

            [Required]
            [Display(Name = "Mã ??i lý")]
            public int MaDaiLy { get; set; }

            [Required]
            [Display(Name = "S? ti?n")]
            [Column(TypeName = "decimal(18, 0)")]
            public decimal SoTien { get; set; }
        }

        [BindProperty]
        public EditThanhToanViewModel ThanhToanToUpdate { get; set; }
        public List<DaiLy> ListDaiLy { get; private set; }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            ListDaiLy = await _context.DaiLies.ToListAsync();

            ThanhToan thanhToan = _context.ThanhToans.Find(Id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            ThanhToanToUpdate = new EditThanhToanViewModel
            {
                SoPhieuThu = thanhToan.SoPhieuThu,
                NgayLapPhieu = thanhToan.NgayLapPhieu,
                MaDaiLy = thanhToan.MaDaiLy,
                SoTien = thanhToan.SoTien
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            ThanhToan thanhToan = _context.ThanhToans.Find(ThanhToanToUpdate.SoPhieuThu);
            if (thanhToan == null)
            {
                return NotFound();
            }

            thanhToan.SoPhieuThu = ThanhToanToUpdate.SoPhieuThu;
            thanhToan.NgayLapPhieu = ThanhToanToUpdate.NgayLapPhieu;
            thanhToan.MaDaiLy = ThanhToanToUpdate.MaDaiLy;
            thanhToan.SoTien = ThanhToanToUpdate.SoTien;

            try
            {
                _context.Update(thanhToan);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhToanExists(ThanhToanToUpdate.SoPhieuThu))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/ThanhToan");
        }

        private bool ThanhToanExists(int Id)
        {
            return _context.ThanhToans.Any(e => e.SoPhieuThu == Id);
        }
    }
}
