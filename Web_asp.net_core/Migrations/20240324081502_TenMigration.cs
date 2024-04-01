using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_asp.net_core.Migrations
{
    /// <inheritdoc />
    public partial class TenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DaiLies",
                columns: table => new
                {
                    MaDaiLy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenChuDaiLy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiaChi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoDienThoai = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HinhThucThanhToan = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoDauKy = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaiLies", x => x.MaDaiLy);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenSanPham = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DonGiaTraCham = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    DonGiaTraNgay = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    DonGiaTraGop = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    GhiChu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.MaSanPham);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    SoHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaDaiLy = table.Column<int>(type: "int", nullable: false),
                    NgayLapHoaDon = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.SoHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_DaiLies_MaDaiLy",
                        column: x => x.MaDaiLy,
                        principalTable: "DaiLies",
                        principalColumn: "MaDaiLy",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    SoPhieuThu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NgayLapPhieu = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MaDaiLy = table.Column<int>(type: "int", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.SoPhieuThu);
                    table.ForeignKey(
                        name: "FK_ThanhToans_DaiLies_MaDaiLy",
                        column: x => x.MaDaiLy,
                        principalTable: "DaiLies",
                        principalColumn: "MaDaiLy",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SoHoaDon = table.Column<int>(type: "int", nullable: false),
                    MaSanPham = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_SoHoaDon",
                        column: x => x.SoHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "SoHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_MaSanPham",
                        column: x => x.MaSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_MaSanPham",
                table: "ChiTietHoaDons",
                column: "MaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_SoHoaDon",
                table: "ChiTietHoaDons",
                column: "SoHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaDaiLy",
                table: "HoaDons",
                column: "MaDaiLy");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaDaiLy",
                table: "ThanhToans",
                column: "MaDaiLy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "DaiLies");
        }
    }
}
