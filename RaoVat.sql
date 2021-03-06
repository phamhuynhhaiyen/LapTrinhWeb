USE [master]
GO
/****** Object:  Database [WebRaoVat]    Script Date: 7/15/2021 2:13:46 PM ******/
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
/****** Object:  User [sa1]    Script Date: 7/15/2021 2:13:46 PM ******/
CREATE USER [sa1] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[sa1]
GO
/****** Object:  User [ruong]    Script Date: 7/15/2021 2:13:46 PM ******/
CREATE USER [ruong] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [sa1]    Script Date: 7/15/2021 2:13:46 PM ******/
CREATE SCHEMA [sa1]
GO
/****** Object:  Table [dbo].[BaiDang]    Script Date: 7/15/2021 2:13:46 PM ******/
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
	[HinhAnh] [text] NOT NULL,
	[TrangThai] [int] NULL,
	[NgayDang] [datetime] NULL,
	[HinhAnh1] [text] NULL,
	[HinhAnh2] [text] NULL,
	[HinhAnh3] [text] NULL,
	[HinhAnh4] [text] NULL,
	[Cout] [int] NULL,
 CONSTRAINT [PK_BaiDang] PRIMARY KEY CLUSTERED 
(
	[MaBaiDang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuoiHoiThoai]    Script Date: 7/15/2021 2:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuoiHoiThoai](
	[MaHoiThoai] [int] IDENTITY(1,1) NOT NULL,
	[NguoiGui] [varchar](200) NULL,
	[NguoiNhan] [varchar](200) NULL,
	[NoiDung] [ntext] NULL,
	[ThoiGianGui] [datetime] NULL,
	[Hinh] [text] NULL,
 CONSTRAINT [PK_CuoiHoiThoai] PRIMARY KEY CLUSTERED 
(
	[MaHoiThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 7/15/2021 2:13:46 PM ******/
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
/****** Object:  Table [dbo].[DSYeuThich]    Script Date: 7/15/2021 2:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DSYeuThich](
	[MaTinYT] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](200) NULL,
	[MaBaiDang] [int] NULL,
 CONSTRAINT [PK_DSYeuThich] PRIMARY KEY CLUSTERED 
(
	[MaTinYT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 7/15/2021 2:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](50) NULL,
	[MaDanhMuc] [int] NULL,
	[Hinh] [text] NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuangCao]    Script Date: 7/15/2021 2:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuangCao](
	[MaQuangCao] [int] IDENTITY(1,1) NOT NULL,
	[MaBaiDang] [int] NULL,
	[NgayHetHan] [datetime] NULL,
	[NgayMua] [datetime] NULL,
	[SoTien] [int] NULL,
 CONSTRAINT [PK_QuangCao] PRIMARY KEY CLUSTERED 
(
	[MaQuangCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 7/15/2021 2:13:46 PM ******/
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
	[Email] [nvarchar](200) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaiDang] ON 

INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (3, N'yen', 2, N'Cần bán điện thoại SamSung', 3000000, 0, N'Hello', N'/Images/anvat.jpg', 3, NULL, N'/Images/1-1_1523988105.jpg', N'/Images/anvat.jpg', N'/Images/1-1_1523988105.jpg', N'/Images/1-1_1523988105.jpg', 1)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (4, N'yen', 5, N'Đồ ăn vặt Hàn Quốc', 35000, 1, N'Đồ ăn thơm ngon. ', N'/Images/anvat.jpg', 0, CAST(N'2021-07-07T11:53:00.000' AS DateTime), NULL, NULL, NULL, NULL, 34)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (5, N'vi', 2, N'Cần bán điện thoại SamSung', 1200000, 0, N'Điện thoại mới sử dụng 1 tháng, fix mạnh cho anh em thiện chí', N'/Images/1-1_1523988105.jpg', 0, CAST(N'2021-07-07T11:53:00.000' AS DateTime), NULL, NULL, NULL, NULL, 32)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (7, N'yen', 2, N'Bán điện thoại di động', 3500000, 1, N'4', N'/Images/samsung.jpg', 0, NULL, N'/Images/anvat.jpg', N'/Images/ung-dung-cua-mvc-trong-lap-trinh.jpg', NULL, NULL, 32)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (8, N'yen', 2, N'Điện thoại Samsung đời mới', 2300000, 1, N'45', N'/Images/1-1_1523988105.jpg', 0, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (11, N'yen', 1, N'Bán điện thoại di động', 30000, 1, N'llll', N'/Images/anvat.jpg', 0, CAST(N'2021-07-03T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, 3)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (13, N'yen', 1, N'Bán điện thoại di động', 30000, 1, N'lklkl', N'/Images/1-1_1523988105.jpg', 1, CAST(N'2021-07-05T13:34:20.960' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (14, N'thuong', 2, N'Samsung Galaxy A32 còn rất mới', 6690000, 1, NULL, N'/Images/samsung.jpg', 0, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BaiDang] ([MaBaiDang], [Username], [MaLoaiSP], [TieuDe], [Gia], [TinhTrang], [MoTa], [HinhAnh], [TrangThai], [NgayDang], [HinhAnh1], [HinhAnh2], [HinhAnh3], [HinhAnh4], [Cout]) VALUES (15, N'yen', 2, N'Samsung còn rất mới', 1000000, 1, NULL, N'/Images/samsung.jpg', 0, NULL, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BaiDang] OFF
GO
SET IDENTITY_INSERT [dbo].[CuoiHoiThoai] ON 

INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (1, N'vi', N'yen', N'Bạn ơi, điện thoại iphone bạn còn mới không', CAST(N'2021-07-09T01:52:15.183' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (3, N'yen', N'thuong', N'Còn mới lắm nha bạn', CAST(N'2021-07-09T17:52:15.183' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (26, N'thuong', N'vi', N'Kêu chơi thôi', CAST(N'2021-07-09T17:52:15.183' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (27, N'yen', N'vi', N'Alo', CAST(N'2021-07-09T21:13:05.493' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (28, N'vi', N'yen', N'Alo', CAST(N'2021-07-09T21:24:06.667' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (29, N'vi', N'yen', N'Yen oi', CAST(N'2021-07-09T21:24:17.300' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (30, N'yen', N'vi', N'alossssss', CAST(N'2021-07-09T21:32:57.697' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (31, N'yen', N'vi', N'alooo', CAST(N'2021-07-09T21:35:41.600' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (32, N'yen', N'vi', N'ssssss', CAST(N'2021-07-09T21:35:51.170' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (33, N'yen', N'thuong', N'sssssssssssssss', CAST(N'2021-07-09T21:35:56.543' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (34, N'yen', N'vi', N'ssssssssss', CAST(N'2021-07-09T21:37:07.893' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (35, N'yen', N'vi', N'alololol', CAST(N'2021-07-09T21:46:06.593' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (36, N'vi', N'yen', N'lo', CAST(N'2021-07-09T21:46:36.990' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (37, N'yen', N'thuong', N'alo', CAST(N'2021-07-09T21:46:49.737' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (38, N'thuong', N'vi', N'âs', CAST(N'2021-07-09T21:47:34.370' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (39, N'vi', N'yen', N'Hi Yen', CAST(N'2021-07-09T22:06:20.610' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (40, N'yen', N'thuong', N'Hi Thuong', CAST(N'2021-07-09T22:07:13.017' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (41, N'thuong', N'yen', N'hi yen', CAST(N'2021-07-09T22:07:38.203' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (43, N'yen', N'vi', N'hi', CAST(N'2021-07-09T22:39:01.510' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (46, N'yen', N'thuong', N'hi Thương', CAST(N'2021-07-09T22:42:35.770' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (47, N'vi', N'yen', N'Alo', CAST(N'2021-07-10T08:52:51.420' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (51, N'yen', N'vi', NULL, CAST(N'2021-07-10T09:38:24.417' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (55, N'yen', N'vi', N'Alo Vi', CAST(N'2021-07-10T22:45:36.757' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (59, N'yen', N'vi', N'âs', CAST(N'2021-07-13T22:28:34.177' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (60, N'yen', N'vi', N'Hi', CAST(N'2021-07-13T22:41:40.993' AS DateTime), N'/Images/samsung.jpg')
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (62, N'yen', N'vi', N'Hi', CAST(N'2021-07-13T23:03:24.780' AS DateTime), NULL)
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (63, N'yen', N'vi', NULL, CAST(N'2021-07-13T23:03:58.003' AS DateTime), N'/Images/LogoUTC.jpg')
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (64, N'vi', N'yen', NULL, CAST(N'2021-07-13T23:04:21.777' AS DateTime), N'/Images/202361828_350454709755244_5789621102996721854_n.jpg')
INSERT [dbo].[CuoiHoiThoai] ([MaHoiThoai], [NguoiGui], [NguoiNhan], [NoiDung], [ThoiGianGui], [Hinh]) VALUES (65, N'yen', N'vi', NULL, CAST(N'2021-07-13T23:23:42.403' AS DateTime), N'/Images/samsung.jpg')
SET IDENTITY_INSERT [dbo].[CuoiHoiThoai] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (1, N'Điện thoại', N'https://static.chotot.com/storage/c2cCategories/5010.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (2, N'Máy tính', N'https://static.chotot.com/storage/c2cCategories/5030.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (3, N'Xe', N'https://static.chotot.com/storage/new-logos/VEH/2020.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (4, N'Ăn uống', N'https://static.chotot.com/storage/c2cCategories/14020.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (5, N'Đồ gia dụng', N'https://static.chotot.com/storage/c2cCategories/14030.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (6, N'Sách', N'https://static.chotot.com/storage/c2cCategories/4070.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (7, N'Thời trang', N'https://static.chotot.com/storage/c2cCategories/3030.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (8, N'Thú cưng', N'https://static.chotot.com/storage/c2cCategories/12050.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (9, N'Giải trí', N'https://static.chotot.com/storage/c2cCategories/4040.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (10, N'Mẹ và bé', N'https://static.chotot.com/storage/c2cCategories/12050.svg')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc], [Hinh]) VALUES (11, N'Văn phòng ', N'https://static.chotot.com/storage/c2cCategories/8010.svg')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[DSYeuThich] ON 

INSERT [dbo].[DSYeuThich] ([MaTinYT], [Username], [MaBaiDang]) VALUES (23, N'yen', 5)
INSERT [dbo].[DSYeuThich] ([MaTinYT], [Username], [MaBaiDang]) VALUES (25, N'yen', 11)
INSERT [dbo].[DSYeuThich] ([MaTinYT], [Username], [MaBaiDang]) VALUES (26, N'yen', 7)
SET IDENTITY_INSERT [dbo].[DSYeuThich] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc], [Hinh]) VALUES (1, N'Iphone', 1, NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc], [Hinh]) VALUES (2, N'Điện thoại Android', 1, NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc], [Hinh]) VALUES (3, N'Máy tính để bàn', 2, NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc], [Hinh]) VALUES (4, N'Máy tính xách tay', 2, NULL)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc], [Hinh]) VALUES (5, N'Đồ ăn vặt', 4, N'/Images/anvat.jpg')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSP], [TenLoaiSP], [MaDanhMuc], [Hinh]) VALUES (6, N'Sách tham khảo', 6, NULL)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[QuangCao] ON 

INSERT [dbo].[QuangCao] ([MaQuangCao], [MaBaiDang], [NgayHetHan], [NgayMua], [SoTien]) VALUES (2, 7, CAST(N'2021-07-08T22:09:01.450' AS DateTime), CAST(N'2021-07-05T20:41:10.853' AS DateTime), 1000)
INSERT [dbo].[QuangCao] ([MaQuangCao], [MaBaiDang], [NgayHetHan], [NgayMua], [SoTien]) VALUES (3, 5, CAST(N'2021-07-20T22:09:01.450' AS DateTime), CAST(N'2021-07-05T20:41:10.853' AS DateTime), 1000)
INSERT [dbo].[QuangCao] ([MaQuangCao], [MaBaiDang], [NgayHetHan], [NgayMua], [SoTien]) VALUES (4, 4, CAST(N'2021-07-20T22:09:01.450' AS DateTime), CAST(N'2021-07-05T22:09:01.450' AS DateTime), 1000)
INSERT [dbo].[QuangCao] ([MaQuangCao], [MaBaiDang], [NgayHetHan], [NgayMua], [SoTien]) VALUES (5, 7, CAST(N'2021-07-20T22:09:01.450' AS DateTime), CAST(N'2021-07-05T20:41:10.853' AS DateTime), 1000)
SET IDENTITY_INSERT [dbo].[QuangCao] OFF
GO
INSERT [dbo].[TaiKhoan] ([Username], [Password], [NgayThamGia], [DiaChi], [SDT], [Hinh], [Quyen], [TenNguoiDung], [Email]) VALUES (N'1274512559633689', NULL, CAST(N'2021-07-13' AS Date), NULL, NULL, NULL, NULL, N'Phạm Huỳnh  Hải Yến', N'phamhuynhhaiyen1107@gmail.com')
INSERT [dbo].[TaiKhoan] ([Username], [Password], [NgayThamGia], [DiaChi], [SDT], [Hinh], [Quyen], [TenNguoiDung], [Email]) VALUES (N'Admin', N'202CB962AC59075B964B07152D234B70', CAST(N'2021-06-25' AS Date), NULL, NULL, NULL, 1, N'Admin', NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [NgayThamGia], [DiaChi], [SDT], [Hinh], [Quyen], [TenNguoiDung], [Email]) VALUES (N'hoa', N'202CB962AC59075B964B07152D234B70', CAST(N'2021-07-11' AS Date), NULL, N'0123      ', NULL, NULL, N'Văn Hoa', NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [NgayThamGia], [DiaChi], [SDT], [Hinh], [Quyen], [TenNguoiDung], [Email]) VALUES (N'thuong', N'202CB962AC59075B964B07152D234B70', CAST(N'2021-06-25' AS Date), NULL, N'0231456987', NULL, NULL, N'Võ Thị Diệu Thương', NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [NgayThamGia], [DiaChi], [SDT], [Hinh], [Quyen], [TenNguoiDung], [Email]) VALUES (N'vi', N'202CB962AC59075B964B07152D234B70', CAST(N'2021-06-25' AS Date), NULL, N'0123456789', NULL, NULL, N'Lê Thị Tường Vi', NULL)
INSERT [dbo].[TaiKhoan] ([Username], [Password], [NgayThamGia], [DiaChi], [SDT], [Hinh], [Quyen], [TenNguoiDung], [Email]) VALUES (N'yen', N'202CB962AC59075B964B07152D234B70', CAST(N'2021-06-25' AS Date), N'Đồng Nai', N'0776989265', N'/Images/myphoto.jpg', NULL, N'Phạm Huỳnh Hải Yến', N'phamhuynhhaiyen1107@gmail.com')
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
ALTER TABLE [dbo].[QuangCao]  WITH CHECK ADD  CONSTRAINT [FK_QuangCao_BaiDang] FOREIGN KEY([MaBaiDang])
REFERENCES [dbo].[BaiDang] ([MaBaiDang])
GO
ALTER TABLE [dbo].[QuangCao] CHECK CONSTRAINT [FK_QuangCao_BaiDang]
GO
USE [master]
GO
ALTER DATABASE [WebRaoVat] SET  READ_WRITE 
GO
