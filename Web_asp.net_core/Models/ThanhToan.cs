using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web_asp.net_core.Models
{
    public class ThanhToan
    {
        [Key]
        public int SoPhieuThu { get; set; }

        [Required]
        [Display(Name = "Ngày lập phiếu")]
        public DateTime NgayLapPhieu { get; set; }

        [Required]
        [Display(Name = "Mã đại lý")]
        public int MaDaiLy { get; set; }

        [ForeignKey("MaDaiLy")]
        public DaiLy DaiLy { get; set; }

        [Required]
        [Display(Name = "Số tiền")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal SoTien { get; set; }

        public ThanhToan()
        {
            NgayLapPhieu = DateTime.Now;
        }
    }
}
