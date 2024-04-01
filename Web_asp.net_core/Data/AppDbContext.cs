using Microsoft.EntityFrameworkCore;

namespace Web_asp.net_core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<DaiLy> DaiLies { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }

    }
}
