using Microsoft.Extensions.FileProviders;
using Web_asp.net_core.Models;
using Web_asp.net_core.Data;

namespace Web_asp.net_core.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Thêm d?ch v? vào container.
            builder.Services.AddRazorPages();

            builder.Services.AddSession();

            var connectionString = builder.Configuration.GetConnectionString("MySqlConn");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            var app = builder.Build();

            // C?u hình pipeline HTTP request.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // Giá tr? m?c ??nh HSTS là 30 ngày. B?n có th? thay ??i nó cho các k?ch b?n production, xem thêm t?i https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "images")),
                RequestPath = "/images"
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}

