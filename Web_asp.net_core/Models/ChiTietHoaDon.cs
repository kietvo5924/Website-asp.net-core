using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Số hóa đơn")]
        public int SoHoaDon { get; set; }

        [ForeignKey("SoHoaDon")]
        public HoaDon HoaDon { get; set; }

        [Required]
        [Display(Name = "Mã sản phẩm")]
        public int MaSanPham { get; set; }

        [ForeignKey("MaSanPham")]
        public SanPham SanPham { get; set; }

        [Required]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
    }
}
