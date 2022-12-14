USE [master]
GO
/****** Object:  Database [InventoryManagement]    Script Date: 10/29/2022 7:30:13 AM ******/
CREATE DATABASE [InventoryManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventory Management', FILENAME = N'D:\InventoryManagement\InventoryManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventory Management_log', FILENAME = N'D:\InventoryManagement\InventoryManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [InventoryManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventoryManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventoryManagement] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InventoryManagement] SET QUERY_STORE = OFF
GO
USE [InventoryManagement]
GO
/****** Object:  Table [dbo].[Dia Diem]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dia Diem](
	[ms dia diem] [int] IDENTITY(0,1) NOT NULL,
	[dia_chi] [nvarchar](50) NULL,
	[msvn] [int] NOT NULL,
 CONSTRAINT [PK_Dia Diem] PRIMARY KEY CLUSTERED 
(
	[ms dia diem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[ms_kho] [int] IDENTITY(0,1) NOT NULL,
	[ten_kho] [nvarchar](100) NULL,
	[sdt_kho] [varchar](10) NULL,
	[ms_dia_diem] [int] NOT NULL,
	[msnv] [int] NOT NULL,
	[ms_loai_hang] [int] NOT NULL,
 CONSTRAINT [PK_Kho] PRIMARY KEY CLUSTERED 
(
	[ms_kho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai Hang]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai Hang](
	[ms_loai_hang] [int] IDENTITY(0,1) NOT NULL,
	[ten_loai_hang] [nvarchar](50) NULL,
 CONSTRAINT [PK_Loai Hang] PRIMARY KEY CLUSTERED 
(
	[ms_loai_hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mat Hang]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mat Hang](
	[ms_mat_hang] [int] IDENTITY(0,1) NOT NULL,
	[ms_loai_hang] [int] NOT NULL,
	[ten_hang] [varchar](50) NULL,
 CONSTRAINT [PK_Mat Hang] PRIMARY KEY CLUSTERED 
(
	[ms_mat_hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhan Vien]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhan Vien](
	[msvn] [int] IDENTITY(0,1) NOT NULL,
	[tai_khoan] [varchar](50) NULL,
	[mat_khau] [varchar](50) NULL,
	[ten_nv] [nvarchar](50) NULL,
	[tuoi] [varchar](10) NULL,
	[sdt] [varchar](10) NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_Nhan Vien] PRIMARY KEY CLUSTERED 
(
	[msvn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieu Nhap Hang]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieu Nhap Hang](
	[ms_phieu_nhap] [int] IDENTITY(0,1) NOT NULL,
	[ngay_lap_phieu_nhap] [date] NULL,
	[ms_kho] [int] NOT NULL,
	[msnv] [int] NOT NULL,
	[ms_mat_hang] [int] NOT NULL,
	[sl_nhap] [int] NULL,
 CONSTRAINT [PK_Phieu Nhap Hang] PRIMARY KEY CLUSTERED 
(
	[ms_phieu_nhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieu Xuat Hang]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieu Xuat Hang](
	[ms_phieu_xuat] [int] IDENTITY(0,1) NOT NULL,
	[ngay_lap_phieu_xuat] [date] NULL,
	[ms_kho] [int] NOT NULL,
	[msnv] [int] NOT NULL,
	[ms_mat_hang] [int] NOT NULL,
	[sl_xuat] [int] NULL,
 CONSTRAINT [PK_Phieu Xuat Hang] PRIMARY KEY CLUSTERED 
(
	[ms_phieu_xuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vai Tro]    Script Date: 10/29/2022 7:30:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vai Tro](
	[role_id] [int] IDENTITY(0,1) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_Vai Tro] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dia Diem] ON 

INSERT [dbo].[Dia Diem] ([ms dia diem], [dia_chi], [msvn]) VALUES (0, N'45 Le Van Viet, Thu Duc', 0)
INSERT [dbo].[Dia Diem] ([ms dia diem], [dia_chi], [msvn]) VALUES (1, N'68 Vo Thi Sau, Q.3', 1)
SET IDENTITY_INSERT [dbo].[Dia Diem] OFF
GO
SET IDENTITY_INSERT [dbo].[Kho] ON 

INSERT [dbo].[Kho] ([ms_kho], [ten_kho], [sdt_kho], [ms_dia_diem], [msnv], [ms_loai_hang]) VALUES (0, N'Duc', N'123', 1, 0, 0)
INSERT [dbo].[Kho] ([ms_kho], [ten_kho], [sdt_kho], [ms_dia_diem], [msnv], [ms_loai_hang]) VALUES (1, N'Trung', N'456', 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Kho] OFF
GO
SET IDENTITY_INSERT [dbo].[Loai Hang] ON 

INSERT [dbo].[Loai Hang] ([ms_loai_hang], [ten_loai_hang]) VALUES (0, N'hang de vo')
INSERT [dbo].[Loai Hang] ([ms_loai_hang], [ten_loai_hang]) VALUES (1, N'hang gia tri')
SET IDENTITY_INSERT [dbo].[Loai Hang] OFF
GO
SET IDENTITY_INSERT [dbo].[Mat Hang] ON 

INSERT [dbo].[Mat Hang] ([ms_mat_hang], [ms_loai_hang], [ten_hang]) VALUES (0, 0, N'ly')
INSERT [dbo].[Mat Hang] ([ms_mat_hang], [ms_loai_hang], [ten_hang]) VALUES (1, 1, N'dt')
SET IDENTITY_INSERT [dbo].[Mat Hang] OFF
GO
SET IDENTITY_INSERT [dbo].[Nhan Vien] ON 

INSERT [dbo].[Nhan Vien] ([msvn], [tai_khoan], [mat_khau], [ten_nv], [tuoi], [sdt], [role_id]) VALUES (0, N'duc', N'1', N'Duc', N'21', N'123', 0)
INSERT [dbo].[Nhan Vien] ([msvn], [tai_khoan], [mat_khau], [ten_nv], [tuoi], [sdt], [role_id]) VALUES (1, N'trung', N'1', N'Trung', N'21', N'456', 1)
INSERT [dbo].[Nhan Vien] ([msvn], [tai_khoan], [mat_khau], [ten_nv], [tuoi], [sdt], [role_id]) VALUES (2, N'nam', N'1', N'Nam', N'21', N'1234', NULL)
SET IDENTITY_INSERT [dbo].[Nhan Vien] OFF
GO
SET IDENTITY_INSERT [dbo].[Phieu Nhap Hang] ON 

INSERT [dbo].[Phieu Nhap Hang] ([ms_phieu_nhap], [ngay_lap_phieu_nhap], [ms_kho], [msnv], [ms_mat_hang], [sl_nhap]) VALUES (0, CAST(N'2022-10-19' AS Date), 0, 1, 0, 2)
INSERT [dbo].[Phieu Nhap Hang] ([ms_phieu_nhap], [ngay_lap_phieu_nhap], [ms_kho], [msnv], [ms_mat_hang], [sl_nhap]) VALUES (1, CAST(N'2022-05-25' AS Date), 1, 0, 1, 4)
SET IDENTITY_INSERT [dbo].[Phieu Nhap Hang] OFF
GO
SET IDENTITY_INSERT [dbo].[Phieu Xuat Hang] ON 

INSERT [dbo].[Phieu Xuat Hang] ([ms_phieu_xuat], [ngay_lap_phieu_xuat], [ms_kho], [msnv], [ms_mat_hang], [sl_xuat]) VALUES (0, CAST(N'2022-03-25' AS Date), 0, 0, 0, 3)
INSERT [dbo].[Phieu Xuat Hang] ([ms_phieu_xuat], [ngay_lap_phieu_xuat], [ms_kho], [msnv], [ms_mat_hang], [sl_xuat]) VALUES (1, CAST(N'2022-09-02' AS Date), 1, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Phieu Xuat Hang] OFF
GO
SET IDENTITY_INSERT [dbo].[Vai Tro] ON 

INSERT [dbo].[Vai Tro] ([role_id], [name]) VALUES (0, N'admin')
INSERT [dbo].[Vai Tro] ([role_id], [name]) VALUES (1, N'NV')
SET IDENTITY_INSERT [dbo].[Vai Tro] OFF
GO
ALTER TABLE [dbo].[Dia Diem]  WITH CHECK ADD  CONSTRAINT [NV Phu Trach] FOREIGN KEY([msvn])
REFERENCES [dbo].[Nhan Vien] ([msvn])
GO
ALTER TABLE [dbo].[Dia Diem] CHECK CONSTRAINT [NV Phu Trach]
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD  CONSTRAINT [Kho Chua] FOREIGN KEY([ms_loai_hang])
REFERENCES [dbo].[Loai Hang] ([ms_loai_hang])
GO
ALTER TABLE [dbo].[Kho] CHECK CONSTRAINT [Kho Chua]
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD  CONSTRAINT [Kho tai] FOREIGN KEY([ms_dia_diem])
REFERENCES [dbo].[Dia Diem] ([ms dia diem])
GO
ALTER TABLE [dbo].[Kho] CHECK CONSTRAINT [Kho tai]
GO
ALTER TABLE [dbo].[Mat Hang]  WITH CHECK ADD  CONSTRAINT [Loai] FOREIGN KEY([ms_loai_hang])
REFERENCES [dbo].[Loai Hang] ([ms_loai_hang])
GO
ALTER TABLE [dbo].[Mat Hang] CHECK CONSTRAINT [Loai]
GO
ALTER TABLE [dbo].[Nhan Vien]  WITH CHECK ADD  CONSTRAINT [FK_Nhan Vien_Vai Tro] FOREIGN KEY([role_id])
REFERENCES [dbo].[Vai Tro] ([role_id])
GO
ALTER TABLE [dbo].[Nhan Vien] CHECK CONSTRAINT [FK_Nhan Vien_Vai Tro]
GO
ALTER TABLE [dbo].[Phieu Nhap Hang]  WITH CHECK ADD  CONSTRAINT [FK_Phieu Nhap Hang_Mat Hang] FOREIGN KEY([ms_mat_hang])
REFERENCES [dbo].[Mat Hang] ([ms_mat_hang])
GO
ALTER TABLE [dbo].[Phieu Nhap Hang] CHECK CONSTRAINT [FK_Phieu Nhap Hang_Mat Hang]
GO
ALTER TABLE [dbo].[Phieu Nhap Hang]  WITH CHECK ADD  CONSTRAINT [Nhap tai Kho] FOREIGN KEY([ms_kho])
REFERENCES [dbo].[Kho] ([ms_kho])
GO
ALTER TABLE [dbo].[Phieu Nhap Hang] CHECK CONSTRAINT [Nhap tai Kho]
GO
ALTER TABLE [dbo].[Phieu Nhap Hang]  WITH CHECK ADD  CONSTRAINT [NV Nhap Hang] FOREIGN KEY([msnv])
REFERENCES [dbo].[Nhan Vien] ([msvn])
GO
ALTER TABLE [dbo].[Phieu Nhap Hang] CHECK CONSTRAINT [NV Nhap Hang]
GO
ALTER TABLE [dbo].[Phieu Xuat Hang]  WITH CHECK ADD  CONSTRAINT [FK_Phieu Xuat Hang_Mat Hang] FOREIGN KEY([ms_mat_hang])
REFERENCES [dbo].[Mat Hang] ([ms_mat_hang])
GO
ALTER TABLE [dbo].[Phieu Xuat Hang] CHECK CONSTRAINT [FK_Phieu Xuat Hang_Mat Hang]
GO
ALTER TABLE [dbo].[Phieu Xuat Hang]  WITH CHECK ADD  CONSTRAINT [NV Xuat hang] FOREIGN KEY([msnv])
REFERENCES [dbo].[Nhan Vien] ([msvn])
GO
ALTER TABLE [dbo].[Phieu Xuat Hang] CHECK CONSTRAINT [NV Xuat hang]
GO
ALTER TABLE [dbo].[Phieu Xuat Hang]  WITH CHECK ADD  CONSTRAINT [Xuat Kho] FOREIGN KEY([ms_kho])
REFERENCES [dbo].[Kho] ([ms_kho])
GO
ALTER TABLE [dbo].[Phieu Xuat Hang] CHECK CONSTRAINT [Xuat Kho]
GO
USE [master]
GO
ALTER DATABASE [InventoryManagement] SET  READ_WRITE 
GO
