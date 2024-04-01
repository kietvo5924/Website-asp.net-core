using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Pages
{
    public class EditSanPhamModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EditSanPhamModel> _logger;

        public EditSanPhamModel(AppDbContext context, ILogger<EditSanPhamModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public class EditSanPhamViewModel
        {
            public int MaSanPham { get; set; }

            [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
            public string TenSanPham { get; set; }

            public string Size { get; set; }
            public decimal DonGiaTraCham { get; set; }
            public decimal DonGiaTraNgay { get; set; }
            public decimal DonGiaTraGop { get; set; }
            public string GhiChu { get; set; }
        }

        [BindProperty]
        public EditSanPhamViewModel SanPhamToUpdate { get; set; }

        public IActionResult OnGet(int Id)
        {
            SanPham sanPham = _context.SanPhams.Find(Id);
            if (sanPham == null)
            {
                return NotFound();
            }

            SanPhamToUpdate = new EditSanPhamViewModel
            {
                MaSanPham = sanPham.MaSanPham,
                TenSanPham = sanPham.TenSanPham,
                Size = sanPham.Size,
                DonGiaTraCham = sanPham.DonGiaTraCham,
                DonGiaTraNgay = sanPham.DonGiaTraNgay,
                DonGiaTraGop = sanPham.DonGiaTraGop,
                GhiChu = sanPham.GhiChu
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SanPham sanPham = _context.SanPhams.Find(SanPhamToUpdate.MaSanPham);
            if (sanPham == null)
            {
                return NotFound();
            }

            sanPham.TenSanPham = SanPhamToUpdate.TenSanPham;
            sanPham.Size = SanPhamToUpdate.Size;
            sanPham.DonGiaTraCham = SanPhamToUpdate.DonGiaTraCham;
            sanPham.DonGiaTraNgay = SanPhamToUpdate.DonGiaTraNgay;
            sanPham.DonGiaTraGop = SanPhamToUpdate.DonGiaTraGop;
            sanPham.GhiChu = SanPhamToUpdate.GhiChu;

            try
            {
                _context.Update(sanPham);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(SanPhamToUpdate.MaSanPham))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/SanPham");
        }

        private bool SanPhamExists(int Id)
        {
            return _context.SanPhams.Any(e => e.MaSanPham == Id);
        }
    }
}
