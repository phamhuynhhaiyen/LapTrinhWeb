USE [master]
GO
/****** Object:  Database [WebRaoVat]    Script Date: 6/27/2021 9:42:34 PM ******/
CREATE DATABASE [WebRaoVat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebRaoVat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WebRaoVat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebRaoVat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\WebRaoVat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WebRaoVat] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebRaoVat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebRaoVat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebRaoVat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebRaoVat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebRaoVat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebRaoVat] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebRaoVat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebRaoVat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebRaoVat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebRaoVat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebRaoVat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebRaoVat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebRaoVat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebRaoVat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebRaoVat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebRaoVat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebRaoVat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebRaoVat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebRaoVat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebRaoVat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebRaoVat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebRaoVat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebRaoVat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebRaoVat] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebRaoVat] SET  MULTI_USER 
GO
ALTER DATABASE [WebRaoVat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebRaoVat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebRaoVat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebRaoVat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebRaoVat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebRaoVat] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [WebRaoVat] SET QUERY_STORE = OFF
GO
USE [WebRaoVat]
GO
/****** Object:  Table [dbo].[BaiDang]    Script Date: 6/27/2021 9:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiDang](
	[MaBaiDang] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](200) NULL,
	[MaLoaiSP] [int] NULL,
	[TieuDe] [ntext] NULL,
	[Gia] [bigint] NULL,
	[TinhTrang] [bit] NULL,
	[MoTa] [ntext] NULL,
	[HinhAnh] [text] NULL,
	[TrangThai] [int] NULL,
	[NgayDang] [date] NULL,
	[HinhAnh1] [text] NULL,
	[HinhAnh2] [text] NULL,
	[HinhAnh3] [text] NULL,
	[HinhAnh4] [text] NULL,
 CONSTRAINT [PK_BaiDang] PRIMARY KEY CLUSTERED 
(
	[MaBaiDang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 6/27/2021 9:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](50) NULL,
	[Hinh] [text] NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 6/27/2021 9:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](50) NULL,
	[MaDanhMuc] [int] NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/27/2021 9:42:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Username] [varchar](200) NOT NULL,
	[Password] [varchar](200) NULL,
	[NgayThamGia] [date] NULL,
	[DiaChi] [ntext] NULL,
	[SDT] [char](10) NULL,
	[Hinh] [text] NULL,
	[Quyen] [int] NULL,
	[TenNguoiDung] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaiDang] ON 

INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4]) VALUES (3, N'yen', 2, N'Cần bán điện thoại SamSung', 3000000, 0, N'Hello', N'/Images/anvat.jpg', 0, NULL, N'/Images/1-1_1523988105.jpg', N'/Images/anvat.jpg', N'/Images/1-1_1523988105.jpg', N'/Images/1-1_1523988105.jpg')
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4]) VALUES (4, N'yen', 5, N'Đồ ăn vặt Hàn Quốc', 35000, 1, N'Đồ ăn thơm ngon. ', N'/Images/anvat.jpg', 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4]) VALUES (5, N'yen', 1, N'Cần bán điện thoại SamSung', 1200000, 1, N'1', N'/Images/1-1_1523988105.jpg', 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4]) VALUES (7, N'yen', 1, N'Đồ ăn Hàn Quốc', 3500, 0, N'4', N'/Images/1-1_1523988105.jpg', 0, NULL, N'/Images/anvat.jpg', N'/Images/ung-dung-cua-mvc-trong-lap-trinh.jpg', NULL, NULL)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4]) VALUES (8, N'yen', 1, N'ttt', 230, 1, N'45', N'/Images/1-1_1523988105.jpg', 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4]) VALUES (9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BaiDang] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (1, N'Điện thoại', N'https://static.chotot.com/storage/c2cCategories/5010.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (2, N'Máy tính', N'https://static.chotot.com/storage/c2cCategories/5030.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (3, N'Xe', N'https://static.chotot.com/storage/new-logos/VEH/2020.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (4, N'Ăn uống', N'https://static.chotot.com/storage/c2cCategories/14020.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (5, N'Đồ gia dụng', N'https://static.chotot.com/storage/c2cCategories/14030.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (6, N'Sách', N'https://static.chotot.com/storage/c2cCategories/4070.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (7, N'Thời trang ', N'https://static.chotot.com/storage/c2cCategories/3030.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (8, N'Thú cưng', N'https://static.chotot.com/storage/c2cCategories/12050.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (9, N'Giải trí', N'https://static.chotot.com/storage/c2cCategories/4040.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (10, N'Mẹ và bé', N'https://static.chotot.com/storage/c2cCategories/12050.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (11, N'Văn phòng phẩm', N'https://static.chotot.com/storage/c2cCategories/8010.svg')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc]) VALUES (1, N'Iphone', 1)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc]) VALUES (2, N'Điện thoại Android', 1)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc]) VALUES (3, N'Máy tính để bàn', 2)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc]) VALUES (4, N'Máy tính xách tay', 2)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc]) VALUES (5, N'Đồ ăn vặt', 4)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
INSERT [dbo].[TaiKhoan] ([Username], [Password], [NgayThamGia], [DiaChi], [SDT], [Hinh], [Quyen], [TenNguoiDung]) VALUES (N'yen', N'123', CAST(N'2021-06-25' AS Date), NULL, NULL, NULL, NULL, N'Phạm Huỳnh Hải Yến')
GO
ALTER TABLE [dbo].[BaiDang]  WITH CHECK ADD  CONSTRAINT [FK_BaiDang_LoaiSanPham] FOREIGN KEY([MaLoaiSP])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSP])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaiDang] CHECK CONSTRAINT [FK_BaiDang_LoaiSanPham]
GO
ALTER TABLE [dbo].[BaiDang]  WITH CHECK ADD  CONSTRAINT [FK_BaiDang_TaiKhoan] FOREIGN KEY([Username])
REFERENCES [dbo].[TaiKhoan] ([Username])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaiDang] CHECK CONSTRAINT [FK_BaiDang_TaiKhoan]
GO
ALTER TABLE [dbo].[LoaiSanPham]  WITH CHECK ADD  CONSTRAINT [FK_LoaiSanPham_DanhMuc] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMuc] ([MaDanhMuc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoaiSanPham] CHECK CONSTRAINT [FK_LoaiSanPham_DanhMuc]
GO
USE [master]
GO
ALTER DATABASE [WebRaoVat] SET  READ_WRITE 
GO
