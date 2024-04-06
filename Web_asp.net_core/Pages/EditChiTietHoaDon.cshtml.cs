using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Pages
{
    public class EditChiTietHoaDonModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public EditChiTietHoaDonModel(AppDbContext context, ILogger<EditChiTietHoaDonModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public class EditChiTietHoaDonViewModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "S? hóa ??n là b?t bu?c")]
            [Display(Name = "S? hóa ??n")]
            public int SoHoaDon { get; set; }

            [Required(ErrorMessage = "Mã s?n ph?m là b?t bu?c")]
            [Display(Name = "Mã s?n ph?m")]
            public int MaSanPham { get; set; }

            [Required(ErrorMessage = "S? l??ng là b?t bu?c")]
            [Display(Name = "S? l??ng")]
            public int SoLuong { get; set; }
        }

        [BindProperty]
        public EditChiTietHoaDonViewModel ChiTietHoaDonToUpdate { get; set; }
        public List<HoaDon> ListHoaDon { get; private set; }
        public List<SanPham> ListSanPham { get; private set; }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("UserName");

            return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            ListHoaDon = await _context.HoaDons.ToListAsync();
            ListSanPham = await _context.SanPhams.ToListAsync();

            ChiTietHoaDon chiTietHoaDon = _context.ChiTietHoaDons.Find(Id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            ChiTietHoaDonToUpdate = new EditChiTietHoaDonViewModel
            {
                Id = chiTietHoaDon.Id,
                SoHoaDon = chiTietHoaDon.SoHoaDon,
                MaSanPham = chiTietHoaDon.MaSanPham,
                SoLuong = chiTietHoaDon.SoLuong
            };

            return Page();
        } 

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            ChiTietHoaDon chiTietHoaDon = _context.ChiTietHoaDons.Find(ChiTietHoaDonToUpdate.Id);
            if(chiTietHoaDon == null)
            {
                return NotFound();
            }

            chiTietHoaDon.SoHoaDon = ChiTietHoaDonToUpdate.SoHoaDon;
            chiTietHoaDon.MaSanPham = ChiTietHoaDonToUpdate.MaSanPham;
            chiTietHoaDon.SoLuong = ChiTietHoaDonToUpdate.SoLuong;

            try
            {
                _context.Update(chiTietHoaDon);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHoaDonExists(ChiTietHoaDonToUpdate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/ChiTietHoaDon");
        }

        private bool ChiTietHoaDonExists(int Id)
        {
            return _context.ChiTietHoaDons.Any(e => e.Id == Id);
        }
    }
}
