-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 01, 2024 at 05:12 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `daily_ct_mayvt`
--

-- --------------------------------------------------------

--
-- Table structure for table `chitiethoadons`
--

CREATE TABLE `chitiethoadons` (
  `Id` int(11) NOT NULL,
  `SoHoaDon` int(11) NOT NULL,
  `MaSanPham` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chitiethoadons`
--

INSERT INTO `chitiethoadons` (`Id`, `SoHoaDon`, `MaSanPham`, `SoLuong`) VALUES
(1, 1, 1, 5),
(2, 3, 3, 10),
(3, 2, 5, 8),
(4, 4, 7, 7),
(5, 5, 9, 6),
(6, 7, 11, 3),
(7, 6, 13, 4),
(8, 8, 15, 2),
(9, 9, 17, 15),
(10, 10, 19, 1),
(11, 12, 2, 6),
(12, 14, 4, 5),
(13, 11, 6, 10),
(14, 13, 8, 8),
(15, 16, 10, 4),
(16, 15, 12, 12),
(17, 17, 14, 20),
(18, 18, 16, 6),
(19, 19, 18, 3),
(20, 20, 20, 2);

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `Id` int(11) NOT NULL,
  `UserName` longtext NOT NULL,
  `Password` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`Id`, `UserName`, `Password`) VALUES
(1, 'user4', '$2a$10$9XkK2D28PPK5CYVtiBkV0.U.WWBGZaceb2gTq3ywWnGah6xF3n26G');

-- --------------------------------------------------------

--
-- Table structure for table `dailies`
--

CREATE TABLE `dailies` (
  `MaDaiLy` int(11) NOT NULL,
  `TenChuDaiLy` longtext NOT NULL,
  `DiaChi` longtext NOT NULL,
  `SoDienThoai` longtext NOT NULL,
  `HinhThucThanhToan` longtext NOT NULL,
  `NoDauKy` decimal(18,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dailies`
--

INSERT INTO `dailies` (`MaDaiLy`, `TenChuDaiLy`, `DiaChi`, `SoDienThoai`, `HinhThucThanhToan`, `NoDauKy`) VALUES
(1, 'Cửa Hàng Kim Anh', '321 Đường Lê Lợi, Quận 1, Thành phố Hồ Chí Minh', '0123456789', 'Chuyển khoản', 50000000),
(2, 'Công ty Minh Khang', '456 Đường Nguyễn Văn Linh, Quận 7, Thành phố Hồ Chí Minh', '0987654321', 'Tiền mặt', 70000000),
(3, 'Nhà Phân Phối Hà Nội', '789 Đường Bà Triệu, Quận Hoàn Kiếm, Thành phố Hà Nội', '0369876543', 'Chuyển khoản', 60000000),
(4, 'Cửa Hàng Thời Trang Sài Gòn', '101 Đường Đề Thám, Quận 1, Thành phố Hồ Chí Minh', '0543219876', 'Tiền mặt', 45000000),
(5, 'Siêu Thị Thời Trang An Phát', '111 Đường Lê Thị Riêng, Quận 3, Thành phố Hồ Chí Minh', '0333333333', 'Chuyển khoản', 55000000),
(6, 'Cửa Hàng Thời Trang Huy Hoàng', '222 Đường Nguyễn Trãi, Quận 5, Thành phố Hồ Chí Minh', '0666666666', 'Tiền mặt', 48000000),
(7, 'Công ty Thời Trang Minh Anh', '333 Đường Trần Hưng Đạo, Quận 1, Thành phố Hồ Chí Minh', '0999999999', 'Chuyển khoản', 51000000),
(8, 'Cửa Hàng Áo Dài Phương Anh', '444 Đường Trần Phú, Quận Hoàng Mai, Thành phố Hà Nội', '0111111111', 'Tiền mặt', 69000000),
(9, 'Công ty Thời Trang Ánh Dương', '555 Đường Hoàng Văn Thụ, Quận Tân Bình, Thành phố Hồ Chí Minh', '0888888888', 'Chuyển khoản', 53000000),
(10, 'Cửa Hàng Quần Áo Gia Minh', '666 Đường Võ Văn Tần, Quận 3, Thành phố Hồ Chí Minh', '0777777777', 'Tiền mặt', 62000000),
(11, 'Siêu Thị Thời Trang Đại Phát', '777 Đường Đồng Khởi, Quận 1, Thành phố Hồ Chí Minh', '0555555555', 'Chuyển khoản', 57000000),
(12, 'Cửa Hàng Áo Khoác Sơn Anh', '888 Đường Hùng Vương, Quận 5, Thành phố Hồ Chí Minh', '0444444444', 'Tiền mặt', 51000000),
(13, 'Công ty Thời Trang Phong Phú', '999 Đường Cách Mạng Tháng Tám, Quận 3, Thành phố Hồ Chí Minh', '0333333333', 'Chuyển khoản', 59000000),
(14, 'Cửa Hàng Quần Áo Sơn Tùng', '1010 Đường Nguyễn Trãi, Quận Thanh Xuân, Thành phố Hà Nội', '0222222222', 'Tiền mặt', 53000000),
(15, 'Siêu Thị Thời Trang Minh Tuấn', '1111 Đường Hàng Bông, Quận Hoàn Kiếm, Thành phố Hà Nội', '0777777777', 'Chuyển khoản', 48000000),
(16, 'Cửa Hàng Áo Dài Minh Châu', '1212 Đường Lý Thường Kiệt, Quận 10, Thành phố Hồ Chí Minh', '0999999999', 'Tiền mặt', 62000000),
(17, 'Công ty Thời Trang Sơn Tây', '1313 Đường Lê Lai, Quận 1, Thành phố Hồ Chí Minh', '0888888888', 'Chuyển khoản', 54000000),
(18, 'Cửa Hàng Thời Trang Anh Thư', '1414 Đường Trần Phú, Quận Hoàng Mai, Thành phố Hà Nội', '0666666666', 'Tiền mặt', 57000000),
(19, 'Nhà Phân Phối Thời Trang Tín Nhi', '1515 Đường Trần Hưng Đạo, Quận 1, Thành phố Hồ Chí Minh', '0333333333', 'Chuyển khoản', 51000000),
(20, 'Cửa Hàng Thời Trang Trần Anh', '1616 Đường Trần Phú, Quận 5, Thành phố Hồ Chí Minh', '0222222222', 'Tiền mặt', 68000000),
(21, 'Siêu Thị Thời Trang Ánh Dương', '1717 Đường Võ Văn Tần, Quận 3, Thành phố Hồ Chí Minh', '0111111111', 'Chuyển khoản', 53000000),
(22, 'Cửa Hàng Áo Dài Sơn Ca', '1818 Đường Lý Thường Kiệt, Quận 10, Thành phố Hồ Chí Minh', '0999999999', 'Tiền mặt', 65000000);

-- --------------------------------------------------------

--
-- Table structure for table `hoadons`
--

CREATE TABLE `hoadons` (
  `SoHD` int(11) NOT NULL,
  `MaDaiLy` int(11) NOT NULL,
  `NgayLapHoaDon` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hoadons`
--

INSERT INTO `hoadons` (`SoHD`, `MaDaiLy`, `NgayLapHoaDon`) VALUES
(1, 7, '2024-03-19 00:00:00.000000'),
(2, 10, '2024-03-20 00:00:00.000000'),
(3, 5, '2024-03-21 00:00:00.000000'),
(4, 12, '2024-03-22 00:00:00.000000'),
(5, 3, '2024-03-23 00:00:00.000000'),
(6, 1, '2024-03-24 00:00:00.000000'),
(7, 9, '2024-03-25 00:00:00.000000'),
(8, 18, '2024-03-26 00:00:00.000000'),
(9, 13, '2024-03-27 00:00:00.000000'),
(10, 8, '2024-03-28 00:00:00.000000'),
(11, 11, '2024-03-29 00:00:00.000000'),
(12, 4, '2024-03-30 00:00:00.000000'),
(13, 15, '2024-03-31 00:00:00.000000'),
(14, 2, '2024-04-01 00:00:00.000000'),
(15, 6, '2024-04-02 00:00:00.000000'),
(16, 20, '2024-04-03 00:00:00.000000'),
(17, 14, '2024-04-04 00:00:00.000000'),
(18, 17, '2024-04-05 00:00:00.000000'),
(19, 19, '2024-04-06 00:00:00.000000'),
(20, 16, '2024-04-07 00:00:00.000000');

-- --------------------------------------------------------

--
-- Table structure for table `sanphams`
--

CREATE TABLE `sanphams` (
  `MaSanPham` int(11) NOT NULL,
  `TenSanPham` longtext NOT NULL,
  `Size` longtext NOT NULL,
  `DonGiaTraCham` decimal(18,0) NOT NULL,
  `DonGiaTraNgay` decimal(18,0) NOT NULL,
  `DonGiaTraGop` decimal(18,0) NOT NULL,
  `GhiChu` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sanphams`
--

INSERT INTO `sanphams` (`MaSanPham`, `TenSanPham`, `Size`, `DonGiaTraCham`, `DonGiaTraNgay`, `DonGiaTraGop`, `GhiChu`) VALUES
(1, 'Áo khoác nam', 'L', 280000, 300000, 320000, 'Áo khoác nam size L'),
(2, 'Áo thun nam', 'XL', 120000, 140000, 160000, 'Áo thun nam size XL'),
(3, 'Quần jean nam', 'M', 180000, 200000, 220000, 'Quần jean nam size M'),
(4, 'Áo sơ mi nam', 'M', 150000, 180000, 200000, 'Áo sơ mi nam size M'),
(5, 'Quần tây nam', 'L', 200000, 220000, 250000, 'Quần tây nam size L'),
(6, 'Áo khoác nữ', 'S', 250000, 280000, 300000, 'Áo khoác nữ size S'),
(7, 'Váy đầm nữ', 'M', 180000, 200000, 220000, 'Váy đầm nữ size M'),
(8, 'Giày thể thao nam', '42', 300000, 320000, 350000, 'Giày thể thao nam size 42'),
(9, 'Dép nữ', '38', 100000, 120000, 150000, 'Dép nữ size 38'),
(10, 'Túi xách nữ', '', 180000, 200000, 220000, 'Túi xách nữ'),
(11, 'Áo len nam', 'L', 220000, 240000, 260000, 'Áo len nam size L'),
(12, 'Quần jeans nữ', 'S', 180000, 200000, 220000, 'Quần jeans nữ size S'),
(13, 'Áo phông nam', 'XL', 120000, 140000, 160000, 'Áo phông nam size XL'),
(14, 'Quần legging nữ', 'M', 80000, 100000, 120000, 'Quần legging nữ size M'),
(15, 'Áo khoác nam', 'XL', 280000, 300000, 320000, 'Áo khoác nam size XL'),
(16, 'Áo thun nữ', 'L', 60000, 80000, 100000, 'Áo thun nữ size L'),
(17, 'Vớ nam', 'One size', 20000, 25000, 30000, 'Vớ nam'),
(18, 'Quần short nữ', 'M', 60000, 80000, 100000, 'Quần short nữ size M'),
(19, 'Áo khoác gió nam', 'L', 250000, 280000, 300000, 'Áo khoác gió nam size L'),
(20, 'Áo dài nữ', 'M', 350000, 380000, 400000, 'Áo dài nữ size M');

-- --------------------------------------------------------

--
-- Table structure for table `thanhtoans`
--

CREATE TABLE `thanhtoans` (
  `SoPhieuThu` int(11) NOT NULL,
  `NgayLapPhieu` datetime(6) NOT NULL,
  `MaDaiLy` int(11) NOT NULL,
  `SoTien` decimal(18,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `thanhtoans`
--

INSERT INTO `thanhtoans` (`SoPhieuThu`, `NgayLapPhieu`, `MaDaiLy`, `SoTien`) VALUES
(1, '2024-03-23 00:00:00.000000', 7, 5000000),
(2, '2024-03-24 00:00:00.000000', 10, 7000000),
(3, '2024-03-25 00:00:00.000000', 5, 6000000),
(4, '2024-03-26 00:00:00.000000', 12, 4500000),
(5, '2024-03-27 00:00:00.000000', 3, 5500000),
(6, '2024-03-28 00:00:00.000000', 1, 4800000),
(7, '2024-03-29 00:00:00.000000', 9, 5100000),
(8, '2024-03-30 00:00:00.000000', 18, 6900000),
(9, '2024-03-31 00:00:00.000000', 13, 5300000),
(10, '2024-04-01 00:00:00.000000', 8, 6200000),
(11, '2024-04-02 00:00:00.000000', 11, 5700000),
(12, '2024-04-03 00:00:00.000000', 4, 5100000),
(13, '2024-04-04 00:00:00.000000', 15, 5900000),
(14, '2024-04-05 00:00:00.000000', 2, 5300000),
(15, '2024-04-06 00:00:00.000000', 6, 4800000),
(16, '2024-04-07 00:00:00.000000', 20, 6200000),
(17, '2024-04-08 00:00:00.000000', 14, 5400000),
(18, '2024-04-09 00:00:00.000000', 17, 5700000),
(19, '2024-04-10 00:00:00.000000', 19, 5100000),
(20, '2024-04-11 00:00:00.000000', 16, 6800000);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20240324081502_TenMigration', '8.0.3');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `chitiethoadons`
--
ALTER TABLE `chitiethoadons`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ChiTietHoaDons_MaSanPham` (`MaSanPham`),
  ADD KEY `IX_ChiTietHoaDons_SoHoaDon` (`SoHoaDon`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `dailies`
--
ALTER TABLE `dailies`
  ADD PRIMARY KEY (`MaDaiLy`);

--
-- Indexes for table `hoadons`
--
ALTER TABLE `hoadons`
  ADD PRIMARY KEY (`SoHD`),
  ADD KEY `IX_HoaDons_MaDaiLy` (`MaDaiLy`);

--
-- Indexes for table `sanphams`
--
ALTER TABLE `sanphams`
  ADD PRIMARY KEY (`MaSanPham`);

--
-- Indexes for table `thanhtoans`
--
ALTER TABLE `thanhtoans`
  ADD PRIMARY KEY (`SoPhieuThu`),
  ADD KEY `IX_ThanhToans_MaDaiLy` (`MaDaiLy`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `chitiethoadons`
--
ALTER TABLE `chitiethoadons`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `dailies`
--
ALTER TABLE `dailies`
  MODIFY `MaDaiLy` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `hoadons`
--
ALTER TABLE `hoadons`
  MODIFY `SoHD` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `sanphams`
--
ALTER TABLE `sanphams`
  MODIFY `MaSanPham` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `thanhtoans`
--
ALTER TABLE `thanhtoans`
  MODIFY `SoPhieuThu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chitiethoadons`
--
ALTER TABLE `chitiethoadons`
  ADD CONSTRAINT `FK_ChiTietHoaDons_HoaDons_SoHoaDon` FOREIGN KEY (`SoHoaDon`) REFERENCES `hoadons` (`SoHD`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ChiTietHoaDons_SanPhams_MaSanPham` FOREIGN KEY (`MaSanPham`) REFERENCES `sanphams` (`MaSanPham`) ON DELETE CASCADE;

--
-- Constraints for table `hoadons`
--
ALTER TABLE `hoadons`
  ADD CONSTRAINT `FK_HoaDons_DaiLies_MaDaiLy` FOREIGN KEY (`MaDaiLy`) REFERENCES `dailies` (`MaDaiLy`) ON DELETE CASCADE;

--
-- Constraints for table `thanhtoans`
--
ALTER TABLE `thanhtoans`
  ADD CONSTRAINT `FK_ThanhToans_DaiLies_MaDaiLy` FOREIGN KEY (`MaDaiLy`) REFERENCES `dailies` (`MaDaiLy`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
