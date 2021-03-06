USE [master]
GO
/****** Object:  Database [webnangcao]    Script Date: 13/12/2020 4:52:07 CH ******/
CREATE DATABASE [webnangcao]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'webnangcao', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\webnangcao.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'webnangcao_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\webnangcao_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [webnangcao] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [webnangcao].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [webnangcao] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [webnangcao] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [webnangcao] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [webnangcao] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [webnangcao] SET ARITHABORT OFF 
GO
ALTER DATABASE [webnangcao] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [webnangcao] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [webnangcao] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [webnangcao] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [webnangcao] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [webnangcao] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [webnangcao] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [webnangcao] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [webnangcao] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [webnangcao] SET  DISABLE_BROKER 
GO
ALTER DATABASE [webnangcao] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [webnangcao] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [webnangcao] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [webnangcao] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [webnangcao] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [webnangcao] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [webnangcao] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [webnangcao] SET RECOVERY FULL 
GO
ALTER DATABASE [webnangcao] SET  MULTI_USER 
GO
ALTER DATABASE [webnangcao] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [webnangcao] SET DB_CHAINING OFF 
GO
ALTER DATABASE [webnangcao] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [webnangcao] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [webnangcao] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'webnangcao', N'ON'
GO
USE [webnangcao]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardDoHoa]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CardDoHoa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [varchar](50) NULL,
	[Brand] [varchar](50) NULL,
 CONSTRAINT [PK_CardDoHoa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Chip_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chip_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaCore] [nchar](10) NULL,
	[Brand] [nchar](10) NULL,
	[DongChip] [nvarchar](50) NULL,
	[XungNhip] [varchar](50) NULL,
	[Cache] [int] NULL,
 CONSTRAINT [PK_Chip_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChiTietHD]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SanPhamID] [int] NULL,
	[HoaDonID] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietHD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NhanVien_ID] [int] NULL,
	[KhachHang_ID] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_HoaDon_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SoDienThoai] [varchar](20) NULL,
 CONSTRAINT [PK_KhachHang_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Loai_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Loai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loai_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ManHinh_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ManHinh_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KichThuoc] [float] NULL,
	[DoPhanGiai] [varchar](50) NULL,
	[TiLeManHinh] [varchar](50) NULL,
 CONSTRAINT [PK_ManHinh_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[ChucVu] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaSanXuat_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhaSanXuat_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaSanXuat] [varchar](50) NULL,
 CONSTRAINT [PK_NhaSanXuat_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OCung_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OCung_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DungLuong] [int] NULL,
	[Loai] [varchar](50) NULL,
	[Brand] [varchar](50) NULL,
 CONSTRAINT [PK_OCung_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RAM_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RAM_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DungLuong] [int] NULL,
	[Bus] [int] NULL,
	[Loai] [nchar](10) NULL,
	[Brand] [varchar](50) NULL,
 CONSTRAINT [PK_RAM_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SanPham_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SanPham_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[Gia] [int] NULL,
	[NhaSanXuat_ID] [int] NULL,
	[Loai_ID] [int] NULL,
	[ManHinh_ID] [int] NULL,
	[Ram_ID] [int] NULL,
	[OCung_ID] [int] NULL,
	[Chip_ID] [int] NULL,
	[TinhTrang_ID] [int] NULL,
	[SoLuong] [int] NULL,
	[CardDoHoa_ID] [int] NULL,
	[Cong] [nvarchar](50) NULL,
	[image] [varchar](250) NULL,
 CONSTRAINT [PK_SanPham_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TinhTrang_ID]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhTrang_ID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_TinhTrang_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password]) VALUES (1, N'123                           ', N'123                           ')
INSERT [dbo].[Account] ([ID], [Username], [Password]) VALUES (2, N'234                           ', N'234                           ')
INSERT [dbo].[Account] ([ID], [Username], [Password]) VALUES (3, N'345                           ', N'345                           ')
INSERT [dbo].[Account] ([ID], [Username], [Password]) VALUES (4, N'456                           ', N'456                           ')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[CardDoHoa] ON 

INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (1, N'Radeon Pro 580X with 8GB of GDDR5 memory', N'AMD')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (2, N'Intel UHD 620', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (3, N'GeForce RTX 3080 Mobile ', N'NVIDIA')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (4, N'Quadro RTX 6000 (Laptop)', N'NVIDIA ')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (5, N'GeForce RTX 3070 Mobile', N'NVIDIA')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (6, N'GeForce RTX 2080 Super Mobile', N'NVIDIA ')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (7, N'GeForce RTX 2080 Mobile ', N'NVIDIA ')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (8, N'GeForce GTX 1080 SLI (Laptop)', N'NVIDIA ')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (9, N'GeForce GTX 1070 SLI (Laptop)', N'NVIDIA')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (10, N'Quadro RTX 5000 (Laptop)', N' NVIDIA')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (11, N'GeForce RTX 3060 Mobile', N'NVIDIA ')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (12, N'Radeon Pro Vega 20', N'AMD')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (13, N'Radeon Pro Vega 16', N'AMD')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (14, N'Vega M GL / 870', N'AMD')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (15, N'FirePro W7170M', N'AMD')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (16, N'Radeon R9 M395', N'AMD')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (17, N' Iris Xe G7 96EUs', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (18, N'Xe MAX ', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (19, N'Tiger Lake-U Xe G7 80EUs', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (20, N'Iris Plus Graphics G7 (Ice Lake 64 EU)', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (21, N'Iris Pro Graphics P580', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (22, N'Iris Pro Graphics 580 ', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (23, N'Iris Plus Graphics 650', N'Intel')
INSERT [dbo].[CardDoHoa] ([ID], [Ten], [Brand]) VALUES (26, N'm1graphic', N'apple')
SET IDENTITY_INSERT [dbo].[CardDoHoa] OFF
SET IDENTITY_INSERT [dbo].[Chip_ID] ON 

INSERT [dbo].[Chip_ID] ([ID], [MaCore], [Brand], [DongChip], [XungNhip], [Cache]) VALUES (8, N'1130G7    ', N'intel     ', N'i5', N'1.8Ghz-4.0Ghz', 3)
INSERT [dbo].[Chip_ID] ([ID], [MaCore], [Brand], [DongChip], [XungNhip], [Cache]) VALUES (9, N'1135G7    ', N'intel     ', N'i5', N'2.4Ghz-4.2Ghz', 3)
INSERT [dbo].[Chip_ID] ([ID], [MaCore], [Brand], [DongChip], [XungNhip], [Cache]) VALUES (10, N'1145G7    ', N'intel     ', N'i5', N'2.6Ghz-4.4Ghz', 3)
INSERT [dbo].[Chip_ID] ([ID], [MaCore], [Brand], [DongChip], [XungNhip], [Cache]) VALUES (11, N'10210u    ', N'intel     ', N'i5', N'1.60Ghz-4.2Ghz', 3)
INSERT [dbo].[Chip_ID] ([ID], [MaCore], [Brand], [DongChip], [XungNhip], [Cache]) VALUES (12, N'10210y    ', N'intel     ', N'i5', N'1.0Ghz-4.0Ghz', 3)
INSERT [dbo].[Chip_ID] ([ID], [MaCore], [Brand], [DongChip], [XungNhip], [Cache]) VALUES (13, N'10300H    ', N'intel     ', N'i5', N'2.5Ghz-4.5Ghz', 3)
INSERT [dbo].[Chip_ID] ([ID], [MaCore], [Brand], [DongChip], [XungNhip], [Cache]) VALUES (14, N'm1        ', N'apple     ', N'SOC', N'2.3Ghz', 3)
SET IDENTITY_INSERT [dbo].[Chip_ID] OFF
SET IDENTITY_INSERT [dbo].[KhachHang_ID] ON 

INSERT [dbo].[KhachHang_ID] ([ID], [HoTen], [DiaChi], [SoDienThoai]) VALUES (1, N'Bui Chi Bao', N'234 Hoang Quoc Viet', N'0335670934')
INSERT [dbo].[KhachHang_ID] ([ID], [HoTen], [DiaChi], [SoDienThoai]) VALUES (2, N'Bui Thi Hai Yen', N'NG HD', N'0122121212')
SET IDENTITY_INSERT [dbo].[KhachHang_ID] OFF
SET IDENTITY_INSERT [dbo].[Loai_ID] ON 

INSERT [dbo].[Loai_ID] ([ID], [Loai]) VALUES (1, N'2 In 1')
INSERT [dbo].[Loai_ID] ([ID], [Loai]) VALUES (2, N'180 độ ')
INSERT [dbo].[Loai_ID] ([ID], [Loai]) VALUES (3, N'workstation')
SET IDENTITY_INSERT [dbo].[Loai_ID] OFF
SET IDENTITY_INSERT [dbo].[ManHinh_ID] ON 

INSERT [dbo].[ManHinh_ID] ([ID], [KichThuoc], [DoPhanGiai], [TiLeManHinh]) VALUES (1, 16, N'Retina (2k)', N'16 : 10')
INSERT [dbo].[ManHinh_ID] ([ID], [KichThuoc], [DoPhanGiai], [TiLeManHinh]) VALUES (2, 14, N'2k', N'16 : 10')
SET IDENTITY_INSERT [dbo].[ManHinh_ID] OFF
SET IDENTITY_INSERT [dbo].[NhanVien_ID] ON 

INSERT [dbo].[NhanVien_ID] ([ID], [HoTen], [ChucVu]) VALUES (1, N'Bui Ngoc Hung', N'Nhan Vien')
SET IDENTITY_INSERT [dbo].[NhanVien_ID] OFF
SET IDENTITY_INSERT [dbo].[NhaSanXuat_ID] ON 

INSERT [dbo].[NhaSanXuat_ID] ([ID], [TenNhaSanXuat]) VALUES (1, N'Lenovo')
INSERT [dbo].[NhaSanXuat_ID] ([ID], [TenNhaSanXuat]) VALUES (2, N'Apple')
INSERT [dbo].[NhaSanXuat_ID] ([ID], [TenNhaSanXuat]) VALUES (3, N'Google')
INSERT [dbo].[NhaSanXuat_ID] ([ID], [TenNhaSanXuat]) VALUES (4, N'LG')
INSERT [dbo].[NhaSanXuat_ID] ([ID], [TenNhaSanXuat]) VALUES (5, N'Samsung')
INSERT [dbo].[NhaSanXuat_ID] ([ID], [TenNhaSanXuat]) VALUES (6, N'DELL')
INSERT [dbo].[NhaSanXuat_ID] ([ID], [TenNhaSanXuat]) VALUES (7, N'microsoft')
SET IDENTITY_INSERT [dbo].[NhaSanXuat_ID] OFF
SET IDENTITY_INSERT [dbo].[OCung_ID] ON 

INSERT [dbo].[OCung_ID] ([ID], [DungLuong], [Loai], [Brand]) VALUES (1, 128, N'sata 3', N'kingstone')
SET IDENTITY_INSERT [dbo].[OCung_ID] OFF
SET IDENTITY_INSERT [dbo].[RAM_ID] ON 

INSERT [dbo].[RAM_ID] ([ID], [DungLuong], [Bus], [Loai], [Brand]) VALUES (1, 4, 2666, N'DDR4      ', N'kingstone')
INSERT [dbo].[RAM_ID] ([ID], [DungLuong], [Bus], [Loai], [Brand]) VALUES (2, 8, 2400, N'DDR4      ', N'Intel')
INSERT [dbo].[RAM_ID] ([ID], [DungLuong], [Bus], [Loai], [Brand]) VALUES (3, 8, 2400, N'DDR4      ', N'onboard')
INSERT [dbo].[RAM_ID] ([ID], [DungLuong], [Bus], [Loai], [Brand]) VALUES (4, 16, 2400, N'DDR4      ', N'onboard')
INSERT [dbo].[RAM_ID] ([ID], [DungLuong], [Bus], [Loai], [Brand]) VALUES (5, 32, 2400, N'DDR4      ', N'onboard')
INSERT [dbo].[RAM_ID] ([ID], [DungLuong], [Bus], [Loai], [Brand]) VALUES (6, 64, 2400, N'DDR4      ', N'onboard')
SET IDENTITY_INSERT [dbo].[RAM_ID] OFF
SET IDENTITY_INSERT [dbo].[SanPham_ID] ON 

INSERT [dbo].[SanPham_ID] ([ID], [TenSanPham], [Gia], [NhaSanXuat_ID], [Loai_ID], [ManHinh_ID], [Ram_ID], [OCung_ID], [Chip_ID], [TinhTrang_ID], [SoLuong], [CardDoHoa_ID], [Cong], [image]) VALUES (13, N'Macbook Air 2020 m1', 29000000, 2, 1, 1, 1, 1, 14, 1, 122, 18, N'thunder Bolt 3', N'airm1.png')
INSERT [dbo].[SanPham_ID] ([ID], [TenSanPham], [Gia], [NhaSanXuat_ID], [Loai_ID], [ManHinh_ID], [Ram_ID], [OCung_ID], [Chip_ID], [TinhTrang_ID], [SoLuong], [CardDoHoa_ID], [Cong], [image]) VALUES (14, N'Custom Thinkpad x380', 3000000, 1, 1, 1, 1, 1, 8, 1, 122, 1, N'HDMI , thunder bolt 4 , type c có PD', N'1.png')
INSERT [dbo].[SanPham_ID] ([ID], [TenSanPham], [Gia], [NhaSanXuat_ID], [Loai_ID], [ManHinh_ID], [Ram_ID], [OCung_ID], [Chip_ID], [TinhTrang_ID], [SoLuong], [CardDoHoa_ID], [Cong], [image]) VALUES (15, N'LG Gram', 24000000, 4, 2, 2, 1, 1, 8, 1, 10, 1, N'HDMI , thunder bolt 4 , type c có PD', N'gram.png')
SET IDENTITY_INSERT [dbo].[SanPham_ID] OFF
SET IDENTITY_INSERT [dbo].[TinhTrang_ID] ON 

INSERT [dbo].[TinhTrang_ID] ([ID], [TinhTrang]) VALUES (1, N'new full seal')
INSERT [dbo].[TinhTrang_ID] ([ID], [TinhTrang]) VALUES (4, N'Hàng New , Full Box , Chính Hãng')
INSERT [dbo].[TinhTrang_ID] ([ID], [TinhTrang]) VALUES (5, N'Hàng New Sealed, Nhập khẩu')
INSERT [dbo].[TinhTrang_ID] ([ID], [TinhTrang]) VALUES (6, N'Hàng New, Outlet, Nhập khẩu')
INSERT [dbo].[TinhTrang_ID] ([ID], [TinhTrang]) VALUES (7, N'Hàng Used, Nhập khẩu')
SET IDENTITY_INSERT [dbo].[TinhTrang_ID] OFF
ALTER TABLE [dbo].[ChiTietHD]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHD_HoaDon_ID] FOREIGN KEY([HoaDonID])
REFERENCES [dbo].[HoaDon_ID] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHD] CHECK CONSTRAINT [FK_ChiTietHD_HoaDon_ID]
GO
ALTER TABLE [dbo].[ChiTietHD]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHD_SanPham_ID] FOREIGN KEY([SanPhamID])
REFERENCES [dbo].[SanPham_ID] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHD] CHECK CONSTRAINT [FK_ChiTietHD_SanPham_ID]
GO
ALTER TABLE [dbo].[HoaDon_ID]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_ID_KhachHang_ID] FOREIGN KEY([KhachHang_ID])
REFERENCES [dbo].[KhachHang_ID] ([ID])
GO
ALTER TABLE [dbo].[HoaDon_ID] CHECK CONSTRAINT [FK_HoaDon_ID_KhachHang_ID]
GO
ALTER TABLE [dbo].[HoaDon_ID]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_ID_NhanVien_ID] FOREIGN KEY([NhanVien_ID])
REFERENCES [dbo].[NhanVien_ID] ([ID])
GO
ALTER TABLE [dbo].[HoaDon_ID] CHECK CONSTRAINT [FK_HoaDon_ID_NhanVien_ID]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_CardDoHoa] FOREIGN KEY([CardDoHoa_ID])
REFERENCES [dbo].[CardDoHoa] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_CardDoHoa]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_Chip_ID] FOREIGN KEY([Chip_ID])
REFERENCES [dbo].[Chip_ID] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_Chip_ID]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_Loai_ID] FOREIGN KEY([Loai_ID])
REFERENCES [dbo].[Loai_ID] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_Loai_ID]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_ManHinh_ID] FOREIGN KEY([ManHinh_ID])
REFERENCES [dbo].[ManHinh_ID] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_ManHinh_ID]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_NhaSanXuat_ID] FOREIGN KEY([NhaSanXuat_ID])
REFERENCES [dbo].[NhaSanXuat_ID] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_NhaSanXuat_ID]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_OCung_ID] FOREIGN KEY([OCung_ID])
REFERENCES [dbo].[OCung_ID] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_OCung_ID]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_RAM_ID] FOREIGN KEY([Ram_ID])
REFERENCES [dbo].[RAM_ID] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_RAM_ID]
GO
ALTER TABLE [dbo].[SanPham_ID]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ID_TinhTrang_ID] FOREIGN KEY([TinhTrang_ID])
REFERENCES [dbo].[TinhTrang_ID] ([ID])
GO
ALTER TABLE [dbo].[SanPham_ID] CHECK CONSTRAINT [FK_SanPham_ID_TinhTrang_ID]
GO
/****** Object:  StoredProcedure [dbo].[sp_Account_Login]    Script Date: 13/12/2020 4:52:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Account_Login]
	@UserName nvarchar(30),
	@Password nvarchar(30)
as
begin
	declare @count int
	declare @res bit
	select @count = count(*) from Account where Username = @UserName and Password = @Password
	if @count > 0 
		set @res = 1
	else
		set @res = 0

	select @res
end
GO
USE [master]
GO
ALTER DATABASE [webnangcao] SET  READ_WRITE 
GO
