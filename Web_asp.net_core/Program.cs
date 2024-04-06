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

            // Th�m d?ch v? v�o container.
            builder.Services.AddRazorPages();

            builder.Services.AddSession();

            var connectionString = builder.Configuration.GetConnectionString("MySqlConn");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            var app = builder.Build();

            // C?u h�nh pipeline HTTP request.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // Gi� tr? m?c ??nh HSTS l� 30 ng�y. B?n c� th? thay ??i n� cho c�c k?ch b?n production, xem th�m t?i https://aka.ms/aspnetcore-hsts.
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

