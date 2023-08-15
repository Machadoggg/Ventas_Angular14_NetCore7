USE [Ventas_Angular14]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 15/08/2023 16:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[idDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[idVenta] [int] NULL,
	[idProducto] [int] NULL,
	[cantidad] [int] NULL,
	[precio] [decimal](10, 2) NULL,
	[total] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[idMenu] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[icono] [varchar](50) NULL,
	[url] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuRol]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuRol](
	[idMenuRol] [int] IDENTITY(1,1) NOT NULL,
	[idMenu] [int] NULL,
	[idRol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMenuRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumeroDocumento]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumeroDocumento](
	[idNumeroDocumento] [int] IDENTITY(1,1) NOT NULL,
	[ultimo_Numero] [int] NOT NULL,
	[fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idNumeroDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[idCategoria] [int] NULL,
	[stock] [int] NULL,
	[precio] [decimal](10, 2) NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreCompleto] [varchar](100) NULL,
	[correo] [varchar](40) NULL,
	[idRol] [int] NULL,
	[clave] [varchar](40) NULL,
	[esActivo] [bit] NULL,
	[fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 15/08/2023 16:14:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[numeroDocumento] [varchar](40) NULL,
	[tipoPago] [varchar](50) NULL,
	[total] [decimal](10, 2) NULL,
	[fechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([idCategoria], [nombre], [esActivo], [fechaRegistro]) VALUES (1, N'Laptops', 1, CAST(N'2023-08-05T21:10:49.350' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [esActivo], [fechaRegistro]) VALUES (2, N'Monitores', 1, CAST(N'2023-08-05T21:10:49.350' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [esActivo], [fechaRegistro]) VALUES (3, N'Teclados', 1, CAST(N'2023-08-05T21:10:49.350' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [esActivo], [fechaRegistro]) VALUES (4, N'Auriculares', 1, CAST(N'2023-08-05T21:10:49.350' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [esActivo], [fechaRegistro]) VALUES (5, N'Memorias', 1, CAST(N'2023-08-05T21:10:49.350' AS DateTime))
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [esActivo], [fechaRegistro]) VALUES (6, N'Accesorios', 1, CAST(N'2023-08-05T21:10:49.350' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleVenta] ON 

INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (1, 1, 5, 4, CAST(140000.00 AS Decimal(10, 2)), CAST(560000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (2, 2, 15, 4, CAST(20000.00 AS Decimal(10, 2)), CAST(80000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (3, 3, 14, 4, CAST(20000.00 AS Decimal(10, 2)), CAST(80000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (4, 3, 13, 4, CAST(20000.00 AS Decimal(10, 2)), CAST(80000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (5, 4, 12, 4, CAST(95000.00 AS Decimal(10, 2)), CAST(380000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (6, 5, 12, 4, CAST(95000.00 AS Decimal(10, 2)), CAST(380000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (7, 6, 12, 4, CAST(95000.00 AS Decimal(10, 2)), CAST(380000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (8, 7, 12, 4, CAST(95000.00 AS Decimal(10, 2)), CAST(380000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (9, 8, 3, 3, CAST(210000.00 AS Decimal(10, 2)), CAST(630000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (10, 9, 3, 3, CAST(210000.00 AS Decimal(10, 2)), CAST(630000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (11, 9, 3, 4, CAST(210000.00 AS Decimal(10, 2)), CAST(840000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (12, 9, 14, 654, CAST(20000.00 AS Decimal(10, 2)), CAST(13080000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (13, 10, 3, 3, CAST(210000.00 AS Decimal(10, 2)), CAST(630000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (14, 10, 3, 4, CAST(210000.00 AS Decimal(10, 2)), CAST(840000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (15, 10, 14, 654, CAST(20000.00 AS Decimal(10, 2)), CAST(13080000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (16, 11, 3, 3, CAST(210000.00 AS Decimal(10, 2)), CAST(630000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (17, 11, 3, 4, CAST(210000.00 AS Decimal(10, 2)), CAST(840000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (18, 11, 14, 654, CAST(20000.00 AS Decimal(10, 2)), CAST(13080000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (19, 12, 3, 3, CAST(210000.00 AS Decimal(10, 2)), CAST(630000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (20, 12, 3, 4, CAST(210000.00 AS Decimal(10, 2)), CAST(840000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (21, 12, 14, 654, CAST(20000.00 AS Decimal(10, 2)), CAST(13080000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (22, 13, 2, 3, CAST(220000.00 AS Decimal(10, 2)), CAST(660000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (23, 14, 2, 3, CAST(220000.00 AS Decimal(10, 2)), CAST(660000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (24, 15, 2, 3, CAST(220000.00 AS Decimal(10, 2)), CAST(660000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (25, 16, 6, 5, CAST(135000.00 AS Decimal(10, 2)), CAST(675000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (26, 17, 6, 5, CAST(135000.00 AS Decimal(10, 2)), CAST(675000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (27, 18, 4, 5, CAST(105000.00 AS Decimal(10, 2)), CAST(525000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (28, 19, 5, 3, CAST(140000.00 AS Decimal(10, 2)), CAST(420000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (29, 20, 8, 3, CAST(100000.00 AS Decimal(10, 2)), CAST(300000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (30, 21, 7, 4, CAST(80000.00 AS Decimal(10, 2)), CAST(320000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (31, 22, 7, 4, CAST(80000.00 AS Decimal(10, 2)), CAST(320000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (32, 23, 7, 5, CAST(80000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (33, 24, 7, 5, CAST(80000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (34, 25, 7, 5, CAST(80000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (35, 26, 7, 5, CAST(80000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (36, 27, 7, 5, CAST(80000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (37, 28, 12, 4, CAST(95000.00 AS Decimal(10, 2)), CAST(380000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (38, 29, 10, 4, CAST(80000.00 AS Decimal(10, 2)), CAST(320000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (39, 30, 9, 4, CAST(100000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (40, 31, 2, 5, CAST(220000.00 AS Decimal(10, 2)), CAST(1100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (41, 32, 9, 4, CAST(100000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (42, 33, 12, 4, CAST(95000.00 AS Decimal(10, 2)), CAST(380000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (43, 34, 4, 4, CAST(105000.00 AS Decimal(10, 2)), CAST(420000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (44, 35, 5, 4, CAST(140000.00 AS Decimal(10, 2)), CAST(560000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (45, 36, 8, 4, CAST(100000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (46, 37, 12, 3, CAST(95000.00 AS Decimal(10, 2)), CAST(285000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (47, 37, 5, 6, CAST(140000.00 AS Decimal(10, 2)), CAST(840000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (48, 38, 12, 3, CAST(95000.00 AS Decimal(10, 2)), CAST(285000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (49, 38, 5, 6, CAST(140000.00 AS Decimal(10, 2)), CAST(840000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (50, 39, 12, 3, CAST(95000.00 AS Decimal(10, 2)), CAST(285000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (51, 39, 5, 6, CAST(140000.00 AS Decimal(10, 2)), CAST(840000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (52, 39, 1, 4, CAST(250000.00 AS Decimal(10, 2)), CAST(1000000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (53, 40, 9, 5, CAST(100000.00 AS Decimal(10, 2)), CAST(500000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (54, 41, 2, 3, CAST(220000.00 AS Decimal(10, 2)), CAST(660000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (55, 42, 2, 3, CAST(220000.00 AS Decimal(10, 2)), CAST(660000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (56, 43, 2, 5, CAST(220000.00 AS Decimal(10, 2)), CAST(1100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (57, 44, 8, 4, CAST(100000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (58, 45, 8, 4, CAST(100000.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (59, 45, 2, 4, CAST(220000.00 AS Decimal(10, 2)), CAST(880000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (60, 46, 15, 5, CAST(20000.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (61, 47, 2, 5, CAST(220000.00 AS Decimal(10, 2)), CAST(1100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (62, 48, 10, 1, CAST(80000.00 AS Decimal(10, 2)), CAST(80000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (63, 49, 4, 1, CAST(105000.00 AS Decimal(10, 2)), CAST(105000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (64, 50, 4, 1, CAST(105000.00 AS Decimal(10, 2)), CAST(105000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (65, 51, 1, 1, CAST(250000.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (66, 52, 2, 1, CAST(220000.00 AS Decimal(10, 2)), CAST(220000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (67, 52, 3, 3, CAST(210000.00 AS Decimal(10, 2)), CAST(630000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (68, 53, 14, 1, CAST(20000.00 AS Decimal(10, 2)), CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (69, 54, 12, 3, CAST(95000.00 AS Decimal(10, 2)), CAST(285000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (70, 55, 9, 1, CAST(100000.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (71, 56, 9, 1, CAST(100000.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (72, 57, 9, 2, CAST(100000.00 AS Decimal(10, 2)), CAST(200000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (73, 58, 9, 2, CAST(100000.00 AS Decimal(10, 2)), CAST(200000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (74, 59, 10, 1, CAST(80000.00 AS Decimal(10, 2)), CAST(80000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (75, 59, 9, 1, CAST(100000.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (76, 60, 9, 1, CAST(100000.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (77, 61, 4, 2, CAST(105000.00 AS Decimal(10, 2)), CAST(210000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (78, 62, 1, 1, CAST(250000.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (79, 63, 1, 1, CAST(250000.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (80, 63, 2, 1, CAST(220000.00 AS Decimal(10, 2)), CAST(220000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (81, 64, 1, 1, CAST(250000.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (82, 65, 1, 1, CAST(250000.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (83, 66, 5, 3, CAST(140000.00 AS Decimal(10, 2)), CAST(420000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (84, 66, 13, 2, CAST(20000.00 AS Decimal(10, 2)), CAST(40000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (85, 66, 15, 5, CAST(20000.00 AS Decimal(10, 2)), CAST(100000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (86, 67, 3, 3, CAST(210000.00 AS Decimal(10, 2)), CAST(630000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (87, 67, 8, 3, CAST(100000.00 AS Decimal(10, 2)), CAST(300000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (88, 68, 3, 1, CAST(210000.00 AS Decimal(10, 2)), CAST(210000.00 AS Decimal(10, 2)))
INSERT [dbo].[DetalleVenta] ([idDetalleVenta], [idVenta], [idProducto], [cantidad], [precio], [total]) VALUES (89, 69, 12, 2, CAST(95000.00 AS Decimal(10, 2)), CAST(190000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[DetalleVenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([idMenu], [nombre], [icono], [url]) VALUES (1, N'DashBoard', N'dashboard', N'/pages/dashboard')
INSERT [dbo].[Menu] ([idMenu], [nombre], [icono], [url]) VALUES (2, N'Usuarios', N'group', N'/pages/usuarios')
INSERT [dbo].[Menu] ([idMenu], [nombre], [icono], [url]) VALUES (3, N'Productos', N'collections_bookmark', N'/pages/productos')
INSERT [dbo].[Menu] ([idMenu], [nombre], [icono], [url]) VALUES (4, N'Venta', N'currency_exchange', N'/pages/venta')
INSERT [dbo].[Menu] ([idMenu], [nombre], [icono], [url]) VALUES (5, N'Historial Ventas', N'edit_note', N'/pages/historial_venta')
INSERT [dbo].[Menu] ([idMenu], [nombre], [icono], [url]) VALUES (6, N'Reportes', N'receipt', N'/pages/reportes')
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuRol] ON 

INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (1, 1, 1)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (2, 2, 1)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (3, 3, 1)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (4, 4, 1)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (5, 5, 1)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (6, 6, 1)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (7, 4, 2)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (8, 5, 2)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (9, 3, 3)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (10, 4, 3)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (11, 5, 3)
INSERT [dbo].[MenuRol] ([idMenuRol], [idMenu], [idRol]) VALUES (12, 6, 3)
SET IDENTITY_INSERT [dbo].[MenuRol] OFF
GO
SET IDENTITY_INSERT [dbo].[NumeroDocumento] ON 

INSERT [dbo].[NumeroDocumento] ([idNumeroDocumento], [ultimo_Numero], [fechaRegistro]) VALUES (1, 69, CAST(N'2023-08-15T08:51:31.743' AS DateTime))
SET IDENTITY_INSERT [dbo].[NumeroDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (1, N'laptop samsung book pro', 1, 11, CAST(2500.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (2, N'laptop lenovo idea pad', 1, 8, CAST(2200.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (3, N'laptop asus zenbook duo', 1, 3, CAST(2100.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (4, N'monitor teros gaming te-2', 2, 12, CAST(1050.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (5, N'monitor samsung curvos', 2, 11, CAST(1400.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (6, N'monitor huawei gamer', 2, 20, CAST(1350.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (7, N'teclado seisen gamer', 3, 23, CAST(800.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (8, N'teclado antryx gamer', 3, 12, CAST(1000.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (9, N'teclado logitech', 3, 5, CAST(1000.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (10, N'auricular logitech gamer', 4, 9, CAST(800.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (11, N'auricular hyperx gamer', 4, 20, CAST(680.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (12, N'auricular redragon rgb', 4, 13, CAST(950.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (13, N'memoria kingston rgb', 5, 4, CAST(200.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (14, N'ventilador cooler master', 6, 25, CAST(200.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (15, N'mini ventilador lenono', 6, 1, CAST(200.00 AS Decimal(10, 2)), 1, CAST(N'2023-08-05T21:10:49.357' AS DateTime))
INSERT [dbo].[Producto] ([idProducto], [nombre], [idCategoria], [stock], [precio], [esActivo], [fechaRegistro]) VALUES (17, N'Auriculares Gamers Classiccs', 4, 45, CAST(430.00 AS Decimal(10, 2)), 0, CAST(N'2023-08-12T23:11:01.097' AS DateTime))
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([idRol], [nombre], [fechaRegistro]) VALUES (1, N'Administrador', CAST(N'2023-08-05T21:10:49.340' AS DateTime))
INSERT [dbo].[Rol] ([idRol], [nombre], [fechaRegistro]) VALUES (2, N'Empleado', CAST(N'2023-08-05T21:10:49.340' AS DateTime))
INSERT [dbo].[Rol] ([idRol], [nombre], [fechaRegistro]) VALUES (3, N'Supervisor', CAST(N'2023-08-05T21:10:49.340' AS DateTime))
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (1, N'codigo estudiantes', N'code@example.com', 1, N'123', 1, CAST(N'2023-08-05T21:10:49.347' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (2, N'Jorge Machado', N'm@gmail.com', 1, N'123', 1, CAST(N'2023-08-11T01:12:20.293' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (4, N'ana lopez', N'al@j.com', 2, N'', 1, CAST(N'2023-08-12T15:04:11.313' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (5, N'MARIA', N'maria@example.com', 2, N'123', 1, CAST(N'2023-08-12T15:52:21.943' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (6, N'JULIO JARAMILLO', N'julio@example.com', 3, N'123', 1, CAST(N'2023-08-12T15:52:50.837' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (7, N'JORGE GIRALDO', N'jorgeg@example.com', 1, N'123', 1, CAST(N'2023-08-12T15:53:23.930' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (8, N'CLAUDIA QUINTERO', N'quintero@gmail.com.com', 1, N'123', 1, CAST(N'2023-08-12T15:54:08.353' AS DateTime))
INSERT [dbo].[Usuario] ([idUsuario], [nombreCompleto], [correo], [idRol], [clave], [esActivo], [fechaRegistro]) VALUES (9, N'dsad', N'dsa@example.com', 3, N'123', 1, CAST(N'2023-08-12T15:56:25.690' AS DateTime))
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Venta] ON 

INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (1, N'0001', N'Efectivo', CAST(560000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:14:48.283' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (2, N'0002', N'Efectivo', CAST(1200000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:18:30.433' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (3, N'0003', N'Efectivo', CAST(13510000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:19:24.377' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (4, N'0004', N'Efectivo', CAST(380000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:21:59.430' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (5, N'0005', N'Efectivo', CAST(380000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:22:04.153' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (6, N'0006', N'Efectivo', CAST(380000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:22:05.343' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (7, N'0007', N'Efectivo', CAST(380000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:22:06.597' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (8, N'0008', N'Efectivo', CAST(630000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:23:16.703' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (9, N'0009', N'Tarjeta', CAST(14550000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:24:46.607' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (10, N'0010', N'Tarjeta', CAST(14550000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:24:49.573' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (11, N'0011', N'Tarjeta', CAST(14550000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:24:50.303' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (12, N'0012', N'Tarjeta', CAST(14550000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:24:51.057' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (13, N'0013', N'Efectivo', CAST(660000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:26:56.150' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (14, N'0014', N'Efectivo', CAST(660000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:32:32.790' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (15, N'0015', N'Efectivo', CAST(660000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:32:35.467' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (16, N'0016', N'Efectivo', CAST(675000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:37:35.397' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (17, N'0017', N'Efectivo', CAST(675000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:37:44.933' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (18, N'0018', N'Efectivo', CAST(525000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:41:05.323' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (19, N'0019', N'Efectivo', CAST(420000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:42:15.823' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (20, N'0020', N'Efectivo', CAST(300000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:46:33.317' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (21, N'0021', N'Efectivo', CAST(320000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:47:15.007' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (22, N'0022', N'Efectivo', CAST(320000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:47:28.647' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (23, N'0023', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:49:29.943' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (24, N'0024', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:49:34.227' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (25, N'0025', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:49:35.817' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (26, N'0026', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:49:36.807' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (27, N'0027', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T01:49:37.840' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (28, N'0028', N'Efectivo', CAST(380000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:10:09.187' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (29, N'0029', N'Efectivo', CAST(320000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:11:57.010' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (30, N'0030', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:16:40.807' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (31, N'0031', N'Efectivo', CAST(1100000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:17:36.220' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (32, N'0032', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:18:05.253' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (33, N'0033', N'Efectivo', CAST(380000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:19:18.740' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (34, N'0034', N'Efectivo', CAST(420000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:21:48.420' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (35, N'0035', N'Efectivo', CAST(560000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:22:56.643' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (36, N'0036', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:30:39.057' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (37, N'0037', N'Efectivo', CAST(1125000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:34:22.653' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (38, N'0038', N'Efectivo', CAST(1125000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:37:35.070' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (39, N'0039', N'Efectivo', CAST(2125000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:49:08.643' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (40, N'0040', N'Efectivo', CAST(500000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:49:37.230' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (41, N'0041', N'Efectivo', CAST(660000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:56:35.490' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (42, N'0042', N'Efectivo', CAST(660000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T02:57:49.487' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (43, N'0043', N'Efectivo', CAST(1100000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:03:57.693' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (44, N'0044', N'Efectivo', CAST(400000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:04:58.773' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (45, N'0045', N'Efectivo', CAST(1280000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:05:42.373' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (46, N'0046', N'Efectivo', CAST(100000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:06:26.463' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (47, N'0047', N'Efectivo', CAST(1100000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:11:36.943' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (48, N'0048', N'Efectivo', CAST(1180000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:13:21.073' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (49, N'0049', N'Efectivo', CAST(105000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:19:24.707' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (50, N'0050', N'Efectivo', CAST(105000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:20:41.773' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (51, N'0051', N'Efectivo', CAST(250000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:24:53.150' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (52, N'0052', N'Efectivo', CAST(850000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:26:04.827' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (53, N'0053', N'Efectivo', CAST(20000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:27:22.963' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (54, N'0054', N'Efectivo', CAST(285000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T03:32:40.103' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (55, N'0055', N'Efectivo', CAST(100000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:06:10.180' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (56, N'0056', N'Efectivo', CAST(100000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:09:14.733' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (57, N'0057', N'Efectivo', CAST(200000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:14:55.063' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (58, N'0058', N'Efectivo', CAST(200000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:17:37.130' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (59, N'0059', N'Efectivo', CAST(180000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:20:56.453' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (60, N'0060', N'Efectivo', CAST(100000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:22:56.573' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (61, N'0061', N'Efectivo', CAST(210000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:29:00.827' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (62, N'0062', N'Efectivo', CAST(250000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:32:40.197' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (63, N'0063', N'Efectivo', CAST(470000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:40:35.543' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (64, N'0064', N'Efectivo', CAST(250000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:45:14.847' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (65, N'0065', N'Efectivo', CAST(250000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T12:48:06.827' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (66, N'0066', N'Efectivo', CAST(560000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T13:06:35.580' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (67, N'0067', N'Efectivo', CAST(930000.00 AS Decimal(10, 2)), CAST(N'2023-08-14T22:39:29.387' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (68, N'0068', N'Efectivo', CAST(210000.00 AS Decimal(10, 2)), CAST(N'2023-08-15T01:28:32.927' AS DateTime))
INSERT [dbo].[Venta] ([idVenta], [numeroDocumento], [tipoPago], [total], [fechaRegistro]) VALUES (69, N'0069', N'Efectivo', CAST(190000.00 AS Decimal(10, 2)), CAST(N'2023-08-15T08:51:31.827' AS DateTime))
SET IDENTITY_INSERT [dbo].[Venta] OFF
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((1)) FOR [esActivo]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[NumeroDocumento] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((1)) FOR [esActivo]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Rol] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [esActivo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[Venta] ADD  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([idVenta])
REFERENCES [dbo].[Venta] ([idVenta])
GO
ALTER TABLE [dbo].[MenuRol]  WITH CHECK ADD FOREIGN KEY([idMenu])
REFERENCES [dbo].[Menu] ([idMenu])
GO
ALTER TABLE [dbo].[MenuRol]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
