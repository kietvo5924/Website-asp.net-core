using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_asp.net_core.Models
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }

        [Required]
        [Display(Name = "Tên sản phẩm")]
        public string TenSanPham { get; set; }

        [Display(Name = "Kích thước")]
        public string Size { get; set; }

        [Display(Name = "Đơn giá trả chậm")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGiaTraCham { get; set; }

        [Display(Name = "Đơn giá trả ngay")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGiaTraNgay { get; set; }

        [Display(Name = "Đơn giá trả góp")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal DonGiaTraGop { get; set; }

        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}
