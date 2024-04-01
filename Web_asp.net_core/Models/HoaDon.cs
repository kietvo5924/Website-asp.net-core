using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_asp.net_core.Models
{
    public class HoaDon
    {
        [Key]
        public int SoHD { get; set; }

        [Required]
        [Display(Name = "Mã đại lý")]
        public int MaDaiLy { get; set; }

        [ForeignKey("MaDaiLy")]
        public DaiLy DaiLy { get; set; }

        [Required]
        [Display(Name = "Ngày lập hóa đơn")]
        public DateTime NgayLapHoaDon { get; set; }
    }
}
