USE [master]
GO
/****** Object:  Database [ShopManager]    Script Date: 2/16/2025 8:04:19 PM ******/
CREATE DATABASE [ShopManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopManager] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopManager] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ShopManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopManager] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShopManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShopManager] SET  MULTI_USER 
GO
ALTER DATABASE [ShopManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopManager] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopManager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopManager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/16/2025 8:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 2/16/2025 8:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopClients]    Script Date: 2/16/2025 8:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[RegistrationDate] [date] NOT NULL,
 CONSTRAINT [PK_ShopClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopProducts]    Script Date: 2/16/2025 8:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ShopProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopProductShopPurchase]    Script Date: 2/16/2025 8:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopProductShopPurchase](
	[ProductsId] [int] NOT NULL,
	[PurchasesId] [int] NOT NULL,
 CONSTRAINT [PK_ShopProductShopPurchase] PRIMARY KEY CLUSTERED 
(
	[ProductsId] ASC,
	[PurchasesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopPurchases]    Script Date: 2/16/2025 8:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopPurchases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Number] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
 CONSTRAINT [PK_ShopPurchases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250216140758_Create', N'9.0.2')
GO
SET IDENTITY_INSERT [dbo].[ProductCategories] ON 

INSERT [dbo].[ProductCategories] ([Id], [Name]) VALUES (1, N'Бакалія')
INSERT [dbo].[ProductCategories] ([Id], [Name]) VALUES (2, N'Канцелярські товари')
INSERT [dbo].[ProductCategories] ([Id], [Name]) VALUES (3, N'Рослинні олії')
INSERT [dbo].[ProductCategories] ([Id], [Name]) VALUES (4, N'Побутова техніка')
INSERT [dbo].[ProductCategories] ([Id], [Name]) VALUES (5, N'Верхній одяг')
SET IDENTITY_INSERT [dbo].[ProductCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[ShopClients] ON 

INSERT [dbo].[ShopClients] ([Id], [FullName], [DateOfBirth], [RegistrationDate]) VALUES (1, N'Кондратюк Юлія Сергіївна', CAST(N'1990-01-14' AS Date), CAST(N'2024-12-06' AS Date))
INSERT [dbo].[ShopClients] ([Id], [FullName], [DateOfBirth], [RegistrationDate]) VALUES (2, N'Микулин Арсен Петрович', CAST(N'1995-02-16' AS Date), CAST(N'2025-01-06' AS Date))
INSERT [dbo].[ShopClients] ([Id], [FullName], [DateOfBirth], [RegistrationDate]) VALUES (3, N'Шевченко Марія Василівна', CAST(N'1996-02-16' AS Date), CAST(N'2025-02-14' AS Date))
INSERT [dbo].[ShopClients] ([Id], [FullName], [DateOfBirth], [RegistrationDate]) VALUES (4, N'Ткаченко Василь Володимирович', CAST(N'1994-03-13' AS Date), CAST(N'2024-11-19' AS Date))
INSERT [dbo].[ShopClients] ([Id], [FullName], [DateOfBirth], [RegistrationDate]) VALUES (5, N'Мельник Ірина Валеріївна', CAST(N'2005-12-18' AS Date), CAST(N'2025-02-15' AS Date))
SET IDENTITY_INSERT [dbo].[ShopClients] OFF
GO
SET IDENTITY_INSERT [dbo].[ShopProducts] ON 

INSERT [dbo].[ShopProducts] ([Id], [Code], [Name], [Price], [CategoryId]) VALUES (1, N'DR-123', N'Цукор ваговий, 1кг', 44.5, 1)
INSERT [dbo].[ShopProducts] ([Id], [Code], [Name], [Price], [CategoryId]) VALUES (2, N'FT-123', N'Ручка гелієва', 15.25, 2)
INSERT [dbo].[ShopProducts] ([Id], [Code], [Name], [Price], [CategoryId]) VALUES (3, N'QE-123', N'Олія соняшникова, 1л', 55.75, 3)
INSERT [dbo].[ShopProducts] ([Id], [Code], [Name], [Price], [CategoryId]) VALUES (4, N'DC-123', N'Блендер', 2000, 4)
INSERT [dbo].[ShopProducts] ([Id], [Code], [Name], [Price], [CategoryId]) VALUES (5, N'ML-123', N'Куртка зимова', 2500, 5)
SET IDENTITY_INSERT [dbo].[ShopProducts] OFF
GO
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (1, 1)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (2, 1)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (3, 2)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (5, 2)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (1, 3)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (4, 3)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (1, 4)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (3, 4)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (4, 5)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (5, 5)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (2, 6)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (3, 6)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (1, 7)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (3, 7)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (2, 8)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (5, 8)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (1, 9)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (3, 9)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (1, 10)
INSERT [dbo].[ShopProductShopPurchase] ([ProductsId], [PurchasesId]) VALUES (5, 10)
GO
SET IDENTITY_INSERT [dbo].[ShopPurchases] ON 

INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (1, CAST(N'2025-02-15T16:27:11.0336414' AS DateTime2), 1, 1)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (2, CAST(N'2025-02-14T16:27:11.0336414' AS DateTime2), 2, 1)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (3, CAST(N'2025-02-15T16:27:11.0336414' AS DateTime2), 3, 2)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (4, CAST(N'2025-02-13T16:27:11.0336414' AS DateTime2), 4, 2)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (5, CAST(N'2025-02-15T16:27:11.0336414' AS DateTime2), 5, 3)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (6, CAST(N'2025-02-14T16:27:11.0336414' AS DateTime2), 6, 3)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (7, CAST(N'2025-02-14T16:27:11.0336414' AS DateTime2), 7, 4)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (8, CAST(N'2025-02-06T16:27:11.0336414' AS DateTime2), 8, 4)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (9, CAST(N'2025-02-08T16:27:11.0336414' AS DateTime2), 9, 5)
INSERT [dbo].[ShopPurchases] ([Id], [Date], [Number], [ClientId]) VALUES (10, CAST(N'2025-02-10T16:27:11.0336414' AS DateTime2), 10, 5)
SET IDENTITY_INSERT [dbo].[ShopPurchases] OFF
GO
/****** Object:  Index [IX_ShopProducts_CategoryId]    Script Date: 2/16/2025 8:04:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_ShopProducts_CategoryId] ON [dbo].[ShopProducts]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShopProductShopPurchase_PurchasesId]    Script Date: 2/16/2025 8:04:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_ShopProductShopPurchase_PurchasesId] ON [dbo].[ShopProductShopPurchase]
(
	[PurchasesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShopPurchases_ClientId]    Script Date: 2/16/2025 8:04:20 PM ******/
CREATE NONCLUSTERED INDEX [IX_ShopPurchases_ClientId] ON [dbo].[ShopPurchases]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ShopProducts]  WITH CHECK ADD  CONSTRAINT [FK_ShopProducts_ProductCategories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShopProducts] CHECK CONSTRAINT [FK_ShopProducts_ProductCategories_CategoryId]
GO
ALTER TABLE [dbo].[ShopProductShopPurchase]  WITH CHECK ADD  CONSTRAINT [FK_ShopProductShopPurchase_ShopProducts_ProductsId] FOREIGN KEY([ProductsId])
REFERENCES [dbo].[ShopProducts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShopProductShopPurchase] CHECK CONSTRAINT [FK_ShopProductShopPurchase_ShopProducts_ProductsId]
GO
ALTER TABLE [dbo].[ShopProductShopPurchase]  WITH CHECK ADD  CONSTRAINT [FK_ShopProductShopPurchase_ShopPurchases_PurchasesId] FOREIGN KEY([PurchasesId])
REFERENCES [dbo].[ShopPurchases] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShopProductShopPurchase] CHECK CONSTRAINT [FK_ShopProductShopPurchase_ShopPurchases_PurchasesId]
GO
ALTER TABLE [dbo].[ShopPurchases]  WITH CHECK ADD  CONSTRAINT [FK_ShopPurchases_ShopClients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[ShopClients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShopPurchases] CHECK CONSTRAINT [FK_ShopPurchases_ShopClients_ClientId]
GO
USE [master]
GO
ALTER DATABASE [ShopManager] SET  READ_WRITE 
GO
