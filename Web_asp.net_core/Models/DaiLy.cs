using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_asp.net_core.Models
{
    public class DaiLy
    {
        [Key]
        public int MaDaiLy { get; set; }

        [Required]
        [Display(Name = "Tên chủ đại lý")]
        public string TenChuDaiLy { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [Required]
        [Display(Name = "Hình thức thanh toán")]
        public string HinhThucThanhToan { get; set; }

        [Display(Name = "Nợ đầu kỳ")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal NoDauKy { get; set; }
    }
}
