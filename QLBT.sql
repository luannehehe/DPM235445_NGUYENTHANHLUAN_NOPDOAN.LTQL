-- 1. TẠO CƠ SỞ DỮ LIỆU
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'UngDungBanThuoc')
BEGIN
    CREATE DATABASE UngDungBanThuoc;
END
GO

USE UngDungBanThuoc;
GO

-- 2. XÓA BẢNG CŨ (Theo thứ tự: Bảng con trước, bảng cha sau)
IF OBJECT_ID('NguoiDung', 'U') IS NOT NULL DROP TABLE NguoiDung;
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('Thuoc', 'U') IS NOT NULL DROP TABLE Thuoc;
IF OBJECT_ID('NhaCungCap', 'U') IS NOT NULL DROP TABLE NhaCungCap;
IF OBJECT_ID('NhomThuoc', 'U') IS NOT NULL DROP TABLE NhomThuoc;
IF OBJECT_ID('KhachHang', 'U') IS NOT NULL DROP TABLE KhachHang;
IF OBJECT_ID('NhanVien', 'U') IS NOT NULL DROP TABLE NhanVien;
GO

-- 3. TẠO CÁC BẢNG DỮ LIỆU
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    TenNV NVARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(10),
    SoDienThoai VARCHAR(15),
    ChucVu NVARCHAR(50)
);

CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(50) NOT NULL,
    SoDienThoai VARCHAR(15),
    DiaChi NVARCHAR(100)
);

CREATE TABLE NhomThuoc (
    MaNhom VARCHAR(10) PRIMARY KEY,
    TenNhom NVARCHAR(50) NOT NULL
);

CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(10) PRIMARY KEY,
    TenNCC NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    DiaChi NVARCHAR(100)
);

CREATE TABLE Thuoc (
    MaThuoc VARCHAR(10) PRIMARY KEY,
    TenThuoc NVARCHAR(100) NOT NULL,
    MaNhom VARCHAR(10) FOREIGN KEY REFERENCES NhomThuoc(MaNhom),
    MaNCC VARCHAR(10) FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    DonGia DECIMAL(18, 0) NOT NULL,
    SoLuongTon INT NOT NULL,
    DonViTinh NVARCHAR(20)
);

CREATE TABLE HoaDon (
    MaHD VARCHAR(10) PRIMARY KEY,
    MaNV VARCHAR(10) FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaKH VARCHAR(10) FOREIGN KEY REFERENCES KhachHang(MaKH),
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18, 0) DEFAULT 0
);

CREATE TABLE ChiTietHoaDon (
    MaHD VARCHAR(10) FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaThuoc VARCHAR(10) FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18, 0) NOT NULL,
    ThanhTien DECIMAL(18, 0) NOT NULL,
    PRIMARY KEY (MaHD, MaThuoc)
);

CREATE TABLE NguoiDung (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    TenHienThi NVARCHAR(100), -- Cột bị thiếu
    MatKhau VARCHAR(50) NOT NULL,
    LoaiTaiKhoan INT -- Cột bị thiếu (1: Quản lý, 0: Nhân viên)
);
GO


INSERT INTO NguoiDung (TenDangNhap, TenHienThi, MatKhau, LoaiTaiKhoan) VALUES 
('admin', N'Nguyễn Đức Huy', '123', 1), 
('nhanvien1', N'Nhân viên bán thuốc', '123', 0);
GO

INSERT INTO NhanVien VALUES
('NV001', N'Nguyễn Văn An', N'Nam', '0987654321', N'Quản lý'),
('NV002', N'Trần Thị Bích', N'Nữ', '0912345678', N'Dược sĩ'),
('NV003', N'Lê Hoàng Nam', N'Nam', '0933445566', N'Dược sĩ');

INSERT INTO KhachHang VALUES
('KH001', N'Anh Cường', '0123456789', N'Không có'),
('KH002', N'Phạm Văn Cường', '0977112233', N'Quận 1, TP.HCM'),
('KH003', N'Ngô Thị Dung', '0988998877', N'Quận 3, TP.HCM');

INSERT INTO NhomThuoc VALUES
('NT001', N'Thuốc kháng sinh'),
('NT002', N'Thuốc giảm đau'),
('NT003', N'Vitamin'),
('NT004', N'Thuốc tiêu hóa');

INSERT INTO NhaCungCap VALUES
('NCC001', N'Dược Hậu Giang', '0292389143', N'Cần Thơ'),
('NCC002', N'Traphaco', '18006612', N'Hà Nội'),
('NCC003', N'Sanofi Việt Nam', '0283829852', N'TP.HCM');

INSERT INTO Thuoc VALUES
('TH001', N'Paracetamol 500mg', 'NT002', 'NCC001', 35000, 500, N'Hộp'),
('TH002', N'Amoxicillin 500mg', 'NT001', 'NCC001', 45000, 200, N'Hộp'),
('TH003', N'Vitamin C 1000mg', 'NT003', 'NCC002', 80000, 150, N'Hộp'),
('TH004', N'Smecta', 'NT004', 'NCC003', 120000, 100, N'Hộp'),
('TH005', N'Panadol Extra', 'NT002', 'NCC003', 60000, 300, N'Hộp');

INSERT INTO HoaDon (MaHD, MaNV, MaKH, NgayLap, TongTien) VALUES
('HD001', 'NV002', 'KH001', '2026-04-20', 105000),
('HD002', 'NV003', 'KH002', '2026-04-20', 200000);

INSERT INTO ChiTietHoaDon VALUES
('HD001', 'TH001', 1, 35000, 35000),
('HD001', 'TH005', 1, 60000, 60000),
('HD002', 'TH003', 2, 80000, 160000),
('HD002', 'TH002', 1, 45000, 45000);

-- Cập nhật lại tổng tiền hóa đơn
UPDATE HoaDon
SET TongTien = (SELECT SUM(ThanhTien) FROM ChiTietHoaDon WHERE ChiTietHoaDon.MaHD = HoaDon.MaHD);
GO

PRINT N'Khởi tạo và chuẩn hóa dữ liệu THÀNH CÔNG!';

