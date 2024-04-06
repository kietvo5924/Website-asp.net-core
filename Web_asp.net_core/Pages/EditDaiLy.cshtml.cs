using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Pages
{
    public class EditDaiLyModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EditDaiLyModel> _logger;

        public EditDaiLyModel(AppDbContext context, ILogger<EditDaiLyModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public class EditDaiLyViewModel
        {
            public int MaDaiLy { get; set; }

            [Required]
            [Display(Name = "Tên ch? ??i lý")]
            public string TenChuDaiLy { get; set; }

            [Required]
            [Display(Name = "??a ch?")]
            public string DiaChi { get; set; }

            [Required]
            [Display(Name = "S? ?i?n tho?i")]
            public string SoDienThoai { get; set; }

            [Required]
            [Display(Name = "Hình th?c thanh toán")]
            public string HinhThucThanhToan { get; set; }

            [Display(Name = "N? ??u k?")]
            [Column(TypeName = "decimal(18, 0)")]
            public decimal NoDauKy { get; set; }
        }

        [BindProperty]
        public EditDaiLyViewModel DaiLyToUpDate { get; set; }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            DaiLy daiLy = _context.DaiLies.Find(Id);
            if (daiLy == null)
            {
                return NotFound();
            }

            DaiLyToUpDate = new EditDaiLyViewModel
            {
                MaDaiLy = daiLy.MaDaiLy,
                TenChuDaiLy = daiLy.TenChuDaiLy,
                DiaChi = daiLy.DiaChi,
                SoDienThoai = daiLy.SoDienThoai,
                HinhThucThanhToan = daiLy.HinhThucThanhToan,
                NoDauKy = daiLy.NoDauKy
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DaiLy daiLy = _context.DaiLies.Find(DaiLyToUpDate.MaDaiLy);
            if (daiLy == null)
            {
                return NotFound();
            }

            daiLy.TenChuDaiLy = DaiLyToUpDate.TenChuDaiLy;
            daiLy.DiaChi = DaiLyToUpDate.DiaChi;
            daiLy.SoDienThoai = DaiLyToUpDate.SoDienThoai;
            daiLy.HinhThucThanhToan = DaiLyToUpDate.HinhThucThanhToan;
            daiLy.NoDauKy = DaiLyToUpDate.NoDauKy;

            try
            {
                _context.Update(daiLy);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaiLyExists(DaiLyToUpDate.MaDaiLy)) {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/DaiLy");
        }

        private bool DaiLyExists(int Id)
        {
            return _context.DaiLies.Any(e => e.MaDaiLy == Id);
        }
    }
}
