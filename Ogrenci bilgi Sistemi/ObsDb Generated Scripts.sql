USE [ObsDb]
GO
/****** Object:  Table [dbo].[Bolum]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolum](
	[BolumID] [int] IDENTITY(1,1) NOT NULL,
	[BolumAd] [varchar](150) NOT NULL,
	[PersonelID] [int] NULL,
	[FakulteID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BolumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[calisir]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[calisir](
	[OgrtID] [char](10) NULL,
	[BolumID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ders](
	[DersKodu] [char](5) NOT NULL,
	[Yariyil] [char](1) NULL,
	[DersAdi] [varchar](100) NULL,
	[Dil] [varchar](15) NULL,
	[Kredi] [float] NULL,
	[Akts] [float] NULL,
	[BolumID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DersKodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DersSecme]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DersSecme](
	[DersSecID] [int] IDENTITY(1,1) NOT NULL,
	[OgrNo] [char](9) NULL,
	[BolumID] [int] NULL,
	[DersKodu] [char](5) NULL,
 CONSTRAINT [PK__DersSecm__9D82EE63660A7125] PRIMARY KEY CLUSTERED 
(
	[DersSecID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fakulte]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fakulte](
	[FakulteID] [int] IDENTITY(1,1) NOT NULL,
	[FakulteAd] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FakulteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KayitOnaylar]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KayitOnaylar](
	[OgrtID] [char](10) NULL,
	[DersKodu] [char](5) NULL,
	[OnayTarihi] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Not_]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Not_](
	[NotID] [int] IDENTITY(1,1) NOT NULL,
	[vize] [int] NULL,
	[final] [int] NULL,
	[ortalama] [float] NULL,
	[harfnotu] [char](2) NULL,
	[OgrtID] [char](10) NULL,
	[DersKodu] [char](5) NULL,
	[OgrNo] [char](9) NULL,
PRIMARY KEY CLUSTERED 
(
	[NotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[OgrNo] [char](9) NOT NULL,
	[OgrAd] [varchar](30) NOT NULL,
	[OgrSoyad] [varchar](50) NOT NULL,
	[Cinsiyet] [char](1) NULL,
	[DogumTar] [date] NULL,
	[OgrTelNo] [char](10) NULL,
	[Sinif] [varchar](8) NULL,
	[OgrResim] [varchar](250) NULL,
	[OgrMail] [varchar](60) NULL,
	[OgrSifre] [varchar](15) NULL,
	[DanismanID] [char](10) NULL,
	[BolumID] [int] NULL,
	[PersonelID] [int] NULL,
	[OgrYetkiID] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[OgrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciIsleri]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciIsleri](
	[PersonelID] [int] IDENTITY(1,1) NOT NULL,
	[PersonelAd] [varchar](30) NOT NULL,
	[PersonelSoyad] [varchar](50) NOT NULL,
	[PersonelTel] [char](10) NULL,
	[PersonelMail] [varchar](60) NULL,
	[PersonelSifre] [varchar](15) NULL,
	[PersonelYetkiID] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgretimElemani]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgretimElemani](
	[OgrtID] [char](10) NOT NULL,
	[OgrtAd] [varchar](50) NOT NULL,
	[OgrtSoyad] [varchar](50) NOT NULL,
	[Unvan] [varchar](50) NULL,
	[OgrtMail] [varchar](60) NULL,
	[OgrtSifre] [varchar](15) NULL,
	[OgrtYetkiID] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[OgrtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SilinenBolumKayit]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenBolumKayit](
	[BolumID] [int] NULL,
	[BolumAd] [varchar](150) NULL,
	[PersonelID] [int] NULL,
	[FakulteID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SilinenDersKayit]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenDersKayit](
	[DersKodu] [char](5) NULL,
	[Yariyil] [char](1) NULL,
	[DersAdi] [varchar](100) NULL,
	[Dil] [varchar](15) NULL,
	[Kredi] [float] NULL,
	[Akts] [float] NULL,
	[BolumID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SilinenFakulteKayit]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenFakulteKayit](
	[FakulteID] [int] NULL,
	[FakulteAd] [varchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SilinenOgrKayit]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenOgrKayit](
	[OgrNo] [char](9) NULL,
	[OgrAd] [varchar](30) NULL,
	[OgrSoyad] [varchar](50) NULL,
	[Cinsiyet] [char](1) NULL,
	[DogumTar] [date] NULL,
	[OgrTelNo] [char](10) NULL,
	[Sinif] [varchar](8) NULL,
	[OgrResim] [varchar](250) NULL,
	[OgrMail] [varchar](60) NULL,
	[OgrSifre] [varchar](15) NULL,
	[DanismanID] [char](10) NULL,
	[BolumID] [int] NULL,
	[PersonelID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SilinenOgrtKayit]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenOgrtKayit](
	[OgrtID] [char](10) NULL,
	[OgrtAd] [varchar](50) NULL,
	[OgrtSoyad] [varchar](50) NULL,
	[Unvan] [varchar](50) NULL,
	[OgrtMail] [varchar](60) NULL,
	[OgrtSifre] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SilinenPerKayit]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SilinenPerKayit](
	[PersonelID] [int] NULL,
	[PersonelAd] [varchar](30) NULL,
	[PersonelSoyad] [varchar](50) NULL,
	[PersonelTel] [char](10) NULL,
	[PersonelMail] [varchar](60) NULL,
	[PersonelSifre] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yetki]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yetki](
	[Yetkiid] [char](1) NULL,
	[Yetkili] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[YoneticiID] [char](5) NULL,
	[YoneticiSifre] [varchar](15) NULL,
	[YoneticiYetkiID] [char](1) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bolum] ON 
GO
INSERT [dbo].[Bolum] ([BolumID], [BolumAd], [PersonelID], [FakulteID]) VALUES (1, N'Bilgisayar Mühendisliği', 1, 1)
GO
INSERT [dbo].[Bolum] ([BolumID], [BolumAd], [PersonelID], [FakulteID]) VALUES (2, N'Elektronik Mühendisliği', 2, 1)
GO
INSERT [dbo].[Bolum] ([BolumID], [BolumAd], [PersonelID], [FakulteID]) VALUES (3, N'Yazılım Mühendisliği', 3, 1)
GO
INSERT [dbo].[Bolum] ([BolumID], [BolumAd], [PersonelID], [FakulteID]) VALUES (4, N'Biyomedikal Mühendisliği', 4, 1)
GO
INSERT [dbo].[Bolum] ([BolumID], [BolumAd], [PersonelID], [FakulteID]) VALUES (5, N'Makine Mühendisliği', 5, 1)
GO
SET IDENTITY_INSERT [dbo].[Bolum] OFF
GO
INSERT [dbo].[Ders] ([DersKodu], [Yariyil], [DersAdi], [Dil], [Kredi], [Akts], [BolumID]) VALUES (N'BK101', N'1', N'Biyolojik Sistemler', N'Türkçe', 4, 5, 1)
GO
INSERT [dbo].[Ders] ([DersKodu], [Yariyil], [DersAdi], [Dil], [Kredi], [Akts], [BolumID]) VALUES (N'BM104', N'1', N'Algoritma', N'Türkçe', 4, 5, 1)
GO
INSERT [dbo].[Ders] ([DersKodu], [Yariyil], [DersAdi], [Dil], [Kredi], [Akts], [BolumID]) VALUES (N'BM105', N'1', N'Veritabanı Yönetim', N'Türkçe', 3, 5, 1)
GO
INSERT [dbo].[Ders] ([DersKodu], [Yariyil], [DersAdi], [Dil], [Kredi], [Akts], [BolumID]) VALUES (N'BM108', N'1', N'Web Programlama', N'Türkçe', 3, 5, 1)
GO
INSERT [dbo].[Ders] ([DersKodu], [Yariyil], [DersAdi], [Dil], [Kredi], [Akts], [BolumID]) VALUES (N'BM201', N'3', N'İşletim Sistemleri', N'Türkçe', 4, 5, 1)
GO
INSERT [dbo].[Ders] ([DersKodu], [Yariyil], [DersAdi], [Dil], [Kredi], [Akts], [BolumID]) VALUES (N'BM202', N'3', N'İşaretler ve Sistemler', N'Türkçe', 3, 4, 1)
GO
INSERT [dbo].[Ders] ([DersKodu], [Yariyil], [DersAdi], [Dil], [Kredi], [Akts], [BolumID]) VALUES (N'EE105', N'1', N'EDT', N'Türkçe', 3, 5, 2)
GO
SET IDENTITY_INSERT [dbo].[DersSecme] ON 
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (5, N'191001009', 1, N'BM104')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (6, N'191001009', 1, N'BM105')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (7, N'211001301', 1, N'BM104')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (8, N'211001301', 1, N'BM105')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (9, N'191001057', 2, N'EE105')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (10, N'191001057', 1, N'BM108')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (11, N'201001038', 1, N'BM105')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (12, N'201001038', 1, N'BM104')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (13, N'191001057', 1, N'BM104')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (14, N'191001057', 1, N'BM105')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (15, N'191001057', 1, N'BM108')
GO
INSERT [dbo].[DersSecme] ([DersSecID], [OgrNo], [BolumID], [DersKodu]) VALUES (16, N'191001057', 1, N'BM202')
GO
SET IDENTITY_INSERT [dbo].[DersSecme] OFF
GO
SET IDENTITY_INSERT [dbo].[Fakulte] ON 
GO
INSERT [dbo].[Fakulte] ([FakulteID], [FakulteAd]) VALUES (1, N'Mühendislik Fakültesi')
GO
SET IDENTITY_INSERT [dbo].[Fakulte] OFF
GO
SET IDENTITY_INSERT [dbo].[Not_] ON 
GO
INSERT [dbo].[Not_] ([NotID], [vize], [final], [ortalama], [harfnotu], [OgrtID], [DersKodu], [OgrNo]) VALUES (1, 80, 90, 86, N'BA', NULL, N'BM104', N'191001009')
GO
INSERT [dbo].[Not_] ([NotID], [vize], [final], [ortalama], [harfnotu], [OgrtID], [DersKodu], [OgrNo]) VALUES (2, 90, 85, 87, N'BA', NULL, N'EE105', N'191001057')
GO
INSERT [dbo].[Not_] ([NotID], [vize], [final], [ortalama], [harfnotu], [OgrtID], [DersKodu], [OgrNo]) VALUES (3, 53, 84, 71, N'BB', NULL, N'BM104', N'191001057')
GO
INSERT [dbo].[Not_] ([NotID], [vize], [final], [ortalama], [harfnotu], [OgrtID], [DersKodu], [OgrNo]) VALUES (4, 85, 53, 65, N'CB', NULL, N'BM105', N'201001038')
GO
INSERT [dbo].[Not_] ([NotID], [vize], [final], [ortalama], [harfnotu], [OgrtID], [DersKodu], [OgrNo]) VALUES (5, 24, 86, 60, N'CB', NULL, N'BM105', N'191001009')
GO
INSERT [dbo].[Not_] ([NotID], [vize], [final], [ortalama], [harfnotu], [OgrtID], [DersKodu], [OgrNo]) VALUES (6, 84, 75, 78, N'BB', NULL, N'BM105', N'211001301')
GO
INSERT [dbo].[Not_] ([NotID], [vize], [final], [ortalama], [harfnotu], [OgrtID], [DersKodu], [OgrNo]) VALUES (7, 26, 65, 49, N'FF', NULL, N'BM104', N'211001301')
GO
SET IDENTITY_INSERT [dbo].[Not_] OFF
GO
INSERT [dbo].[Ogrenci] ([OgrNo], [OgrAd], [OgrSoyad], [Cinsiyet], [DogumTar], [OgrTelNo], [Sinif], [OgrResim], [OgrMail], [OgrSifre], [DanismanID], [BolumID], [PersonelID], [OgrYetkiID]) VALUES (N'191001001', N'Halil', N'Yıldız', N'E', CAST(N'2003-07-15' AS Date), N'5324765845', N'1', N'', N'halilyalniz@ogr.duzce.edu.tr', N'halil123', N'1234567894', 4, 4, N'4')
GO
INSERT [dbo].[Ogrenci] ([OgrNo], [OgrAd], [OgrSoyad], [Cinsiyet], [DogumTar], [OgrTelNo], [Sinif], [OgrResim], [OgrMail], [OgrSifre], [DanismanID], [BolumID], [PersonelID], [OgrYetkiID]) VALUES (N'191001009', N'Aleyna', N'Genç', N'K', CAST(N'1999-07-24' AS Date), N'5362841516', N'3', NULL, N'aleynagenc@ogr.duzce.edu.tr', N'aleyna123', N'1234567890', 1, 1, N'4')
GO
INSERT [dbo].[Ogrenci] ([OgrNo], [OgrAd], [OgrSoyad], [Cinsiyet], [DogumTar], [OgrTelNo], [Sinif], [OgrResim], [OgrMail], [OgrSifre], [DanismanID], [BolumID], [PersonelID], [OgrYetkiID]) VALUES (N'191001057', N'Gülçin', N'Apaydın', N'K', CAST(N'2000-01-08' AS Date), N'5362457484', N'4', N'C:\Users\LENOVA\Desktop\yeni\telden\IMG-20190630-WA0035.jpg', N'gulcinapaydin@ogr.duzce.edu.tr', N'gülçin123', N'1234567890', 1, 1, N'4')
GO
INSERT [dbo].[Ogrenci] ([OgrNo], [OgrAd], [OgrSoyad], [Cinsiyet], [DogumTar], [OgrTelNo], [Sinif], [OgrResim], [OgrMail], [OgrSifre], [DanismanID], [BolumID], [PersonelID], [OgrYetkiID]) VALUES (N'201001038', N'Ahsen', N'Akova', N'K', CAST(N'2002-01-08' AS Date), N'5341458574', N'3', N'C:\Users\LENOVA\Desktop\yeni\telden\IMG-20190728-WA0004.jpg', N'ahsen@ogr.duzce.edu.tr', N'ahsen123', N'1234567890', 1, 1, N'4')
GO
INSERT [dbo].[Ogrenci] ([OgrNo], [OgrAd], [OgrSoyad], [Cinsiyet], [DogumTar], [OgrTelNo], [Sinif], [OgrResim], [OgrMail], [OgrSifre], [DanismanID], [BolumID], [PersonelID], [OgrYetkiID]) VALUES (N'211001301', N'Meliha', N'Demirci', N'K', CAST(N'2023-01-11' AS Date), N'5362541458', N'3', N'C:\Users\LENOVA\Desktop\yeni\telden\IMG-20181229-WA0003.jpg', N'meliha@ogr.duzce.edu.tr', N'meliha123', N'1234567890', 1, 1, N'4')
GO
SET IDENTITY_INSERT [dbo].[OgrenciIsleri] ON 
GO
INSERT [dbo].[OgrenciIsleri] ([PersonelID], [PersonelAd], [PersonelSoyad], [PersonelTel], [PersonelMail], [PersonelSifre], [PersonelYetkiID]) VALUES (1, N'Leyla', N'Kara', N'5362985857', N'leylakara@duzce.edu.tr', N'123456', N'3')
GO
INSERT [dbo].[OgrenciIsleri] ([PersonelID], [PersonelAd], [PersonelSoyad], [PersonelTel], [PersonelMail], [PersonelSifre], [PersonelYetkiID]) VALUES (2, N'Filiz', N'Ağaç', N'5326895124', N'filizagac@duzce.edu.tr', N'filiz123', N'3')
GO
INSERT [dbo].[OgrenciIsleri] ([PersonelID], [PersonelAd], [PersonelSoyad], [PersonelTel], [PersonelMail], [PersonelSifre], [PersonelYetkiID]) VALUES (3, N'Cüneyt', N'Arkın', N'5698236451', N'cuneytarkin@duzce.edu.tr', N'cüneyt123', N'3')
GO
INSERT [dbo].[OgrenciIsleri] ([PersonelID], [PersonelAd], [PersonelSoyad], [PersonelTel], [PersonelMail], [PersonelSifre], [PersonelYetkiID]) VALUES (4, N'Fahriye', N'Evcen', N'5214789652', N'fahriyeevcen@duzce.edu.tr', N'fahriye123', N'3')
GO
INSERT [dbo].[OgrenciIsleri] ([PersonelID], [PersonelAd], [PersonelSoyad], [PersonelTel], [PersonelMail], [PersonelSifre], [PersonelYetkiID]) VALUES (5, N'Türkan', N'Şoray', N'5321478523', N'turkansoray@duzce.edu.tr', N'türkan123', N'3')
GO
INSERT [dbo].[OgrenciIsleri] ([PersonelID], [PersonelAd], [PersonelSoyad], [PersonelTel], [PersonelMail], [PersonelSifre], [PersonelYetkiID]) VALUES (6, N'Kamil ', N'Fırtına', N'5321478965', N'kamilfirtina@duzce.edu.tr', N'kam,l123', N'3')
GO
INSERT [dbo].[OgrenciIsleri] ([PersonelID], [PersonelAd], [PersonelSoyad], [PersonelTel], [PersonelMail], [PersonelSifre], [PersonelYetkiID]) VALUES (7, N'Jülide', N'Işıklı', N'5324896525', N'julideısıklı@duzce.edu.tr', N'jülide123', N'3')
GO
SET IDENTITY_INSERT [dbo].[OgrenciIsleri] OFF
GO
INSERT [dbo].[OgretimElemani] ([OgrtID], [OgrtAd], [OgrtSoyad], [Unvan], [OgrtMail], [OgrtSifre], [OgrtYetkiID]) VALUES (N'1234567890', N'Nihat', N'Doğan', N'profesör', N'nihatdogan@duzce.edu.tr', N'123456', N'2')
GO
INSERT [dbo].[OgretimElemani] ([OgrtID], [OgrtAd], [OgrtSoyad], [Unvan], [OgrtMail], [OgrtSifre], [OgrtYetkiID]) VALUES (N'1234567891', N'Nisa', N'Akdoğan', N'Araştırma Görevlisi', N'nisaakdogan@duzce.edu.tr', N'nisa123', N'2')
GO
INSERT [dbo].[OgretimElemani] ([OgrtID], [OgrtAd], [OgrtSoyad], [Unvan], [OgrtMail], [OgrtSifre], [OgrtYetkiID]) VALUES (N'1234567892', N'Filiz', N'Akın', N'profesör', N'filizakın@duzce.edu.tr', N'filiz123', N'2')
GO
INSERT [dbo].[OgretimElemani] ([OgrtID], [OgrtAd], [OgrtSoyad], [Unvan], [OgrtMail], [OgrtSifre], [OgrtYetkiID]) VALUES (N'1234567894', N'Gülbahar', N'Karaca', N'Doktor', N'gulbaharkaraca@duzce.edu.tr', N'gulbahar123', N'2')
GO
INSERT [dbo].[Yonetici] ([YoneticiID], [YoneticiSifre], [YoneticiYetkiID]) VALUES (N'admin', N'123456', N'1')
GO
ALTER TABLE [dbo].[Ogrenci] ADD  CONSTRAINT [df_ogryetki]  DEFAULT ('4') FOR [OgrYetkiID]
GO
ALTER TABLE [dbo].[OgrenciIsleri] ADD  CONSTRAINT [df_personelyetki]  DEFAULT ('3') FOR [PersonelYetkiID]
GO
ALTER TABLE [dbo].[OgretimElemani] ADD  CONSTRAINT [df_ogrteyetki]  DEFAULT ('2') FOR [OgrtYetkiID]
GO
ALTER TABLE [dbo].[Yonetici] ADD  CONSTRAINT [df_yoneticiyetki]  DEFAULT ('1') FOR [YoneticiYetkiID]
GO
ALTER TABLE [dbo].[Bolum]  WITH CHECK ADD  CONSTRAINT [fk_fakulte] FOREIGN KEY([FakulteID])
REFERENCES [dbo].[Fakulte] ([FakulteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bolum] CHECK CONSTRAINT [fk_fakulte]
GO
ALTER TABLE [dbo].[Bolum]  WITH CHECK ADD  CONSTRAINT [fk_personel] FOREIGN KEY([PersonelID])
REFERENCES [dbo].[OgrenciIsleri] ([PersonelID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Bolum] CHECK CONSTRAINT [fk_personel]
GO
ALTER TABLE [dbo].[calisir]  WITH CHECK ADD  CONSTRAINT [fk_bolumm] FOREIGN KEY([BolumID])
REFERENCES [dbo].[Bolum] ([BolumID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[calisir] CHECK CONSTRAINT [fk_bolumm]
GO
ALTER TABLE [dbo].[calisir]  WITH CHECK ADD  CONSTRAINT [fk_ogrt] FOREIGN KEY([OgrtID])
REFERENCES [dbo].[OgretimElemani] ([OgrtID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[calisir] CHECK CONSTRAINT [fk_ogrt]
GO
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [fk_bolum] FOREIGN KEY([BolumID])
REFERENCES [dbo].[Bolum] ([BolumID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [fk_bolum]
GO
ALTER TABLE [dbo].[DersSecme]  WITH CHECK ADD  CONSTRAINT [fk_boluumm] FOREIGN KEY([BolumID])
REFERENCES [dbo].[Bolum] ([BolumID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[DersSecme] CHECK CONSTRAINT [fk_boluumm]
GO
ALTER TABLE [dbo].[DersSecme]  WITH CHECK ADD  CONSTRAINT [fk_dersskoduu] FOREIGN KEY([DersKodu])
REFERENCES [dbo].[Ders] ([DersKodu])
GO
ALTER TABLE [dbo].[DersSecme] CHECK CONSTRAINT [fk_dersskoduu]
GO
ALTER TABLE [dbo].[DersSecme]  WITH CHECK ADD  CONSTRAINT [fk_ogrrno] FOREIGN KEY([OgrNo])
REFERENCES [dbo].[Ogrenci] ([OgrNo])
GO
ALTER TABLE [dbo].[DersSecme] CHECK CONSTRAINT [fk_ogrrno]
GO
ALTER TABLE [dbo].[KayitOnaylar]  WITH CHECK ADD  CONSTRAINT [fk_derskodu] FOREIGN KEY([DersKodu])
REFERENCES [dbo].[Ders] ([DersKodu])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KayitOnaylar] CHECK CONSTRAINT [fk_derskodu]
GO
ALTER TABLE [dbo].[KayitOnaylar]  WITH CHECK ADD  CONSTRAINT [fk_ogrtID] FOREIGN KEY([OgrtID])
REFERENCES [dbo].[OgretimElemani] ([OgrtID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KayitOnaylar] CHECK CONSTRAINT [fk_ogrtID]
GO
ALTER TABLE [dbo].[Not_]  WITH CHECK ADD  CONSTRAINT [fk_derskoduu] FOREIGN KEY([DersKodu])
REFERENCES [dbo].[Ders] ([DersKodu])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Not_] CHECK CONSTRAINT [fk_derskoduu]
GO
ALTER TABLE [dbo].[Not_]  WITH CHECK ADD  CONSTRAINT [fk_ogrno] FOREIGN KEY([OgrNo])
REFERENCES [dbo].[Ogrenci] ([OgrNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Not_] CHECK CONSTRAINT [fk_ogrno]
GO
ALTER TABLE [dbo].[Not_]  WITH CHECK ADD  CONSTRAINT [fk_ogrtI] FOREIGN KEY([OgrtID])
REFERENCES [dbo].[OgretimElemani] ([OgrtID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Not_] CHECK CONSTRAINT [fk_ogrtI]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [fk_bolummm] FOREIGN KEY([BolumID])
REFERENCES [dbo].[Bolum] ([BolumID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [fk_bolummm]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [fk_ogrtIDD] FOREIGN KEY([DanismanID])
REFERENCES [dbo].[OgretimElemani] ([OgrtID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [fk_ogrtIDD]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [fk_personell] FOREIGN KEY([PersonelID])
REFERENCES [dbo].[OgrenciIsleri] ([PersonelID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [fk_personell]
GO
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [ck_dersdil] CHECK  (([dil]='İngilizce' OR [dil]='Türkçe'))
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [ck_dersdil]
GO
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [ck_derskodu] CHECK  (([derskodu] like '[A-Z][A-Z][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [ck_derskodu]
GO
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [ck_dersyariyil] CHECK  (([yariyil] like '[0-9]'))
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [ck_dersyariyil]
GO
ALTER TABLE [dbo].[Not_]  WITH CHECK ADD  CONSTRAINT [ck_harfnotu] CHECK  (([harfnotu] like '[A-F][A-F]'))
GO
ALTER TABLE [dbo].[Not_] CHECK CONSTRAINT [ck_harfnotu]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [ck_cinsiyet] CHECK  (([cinsiyet]='K' OR [cinsiyet]='E'))
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [ck_cinsiyet]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [ck_ogrmail] CHECK  (([OgrMail] like '_%@ogr.duzce.edu.tr'))
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [ck_ogrmail]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [ck_ogrno] CHECK  (([ogrno] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [ck_ogrno]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [ck_OgrTelNo] CHECK  (([OgrTelNo] like '[5][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [ck_OgrTelNo]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [ck_oyetki] CHECK  (([OgrYetkiID]='4'))
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [ck_oyetki]
GO
ALTER TABLE [dbo].[Ogrenci]  WITH CHECK ADD  CONSTRAINT [ck_sinif] CHECK  (([Sinif]='4' OR [Sinif]='3' OR [Sinif]='2' OR [Sinif]='1' OR [Sinif]='Hazırlık'))
GO
ALTER TABLE [dbo].[Ogrenci] CHECK CONSTRAINT [ck_sinif]
GO
ALTER TABLE [dbo].[OgrenciIsleri]  WITH CHECK ADD  CONSTRAINT [ck_permail] CHECK  (([PersonelMail] like '_%@duzce.edu.tr'))
GO
ALTER TABLE [dbo].[OgrenciIsleri] CHECK CONSTRAINT [ck_permail]
GO
ALTER TABLE [dbo].[OgrenciIsleri]  WITH CHECK ADD  CONSTRAINT [ck_personeltel] CHECK  (([PersonelTel] like '[5][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[OgrenciIsleri] CHECK CONSTRAINT [ck_personeltel]
GO
ALTER TABLE [dbo].[OgrenciIsleri]  WITH CHECK ADD  CONSTRAINT [ck_pyetki] CHECK  (([PersonelYetkiID]='3'))
GO
ALTER TABLE [dbo].[OgrenciIsleri] CHECK CONSTRAINT [ck_pyetki]
GO
ALTER TABLE [dbo].[OgretimElemani]  WITH CHECK ADD  CONSTRAINT [ck_oeyetki] CHECK  (([OgrtYetkiID]='2'))
GO
ALTER TABLE [dbo].[OgretimElemani] CHECK CONSTRAINT [ck_oeyetki]
GO
ALTER TABLE [dbo].[OgretimElemani]  WITH CHECK ADD  CONSTRAINT [ck_OgrtID] CHECK  (([OgrtID] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[OgretimElemani] CHECK CONSTRAINT [ck_OgrtID]
GO
ALTER TABLE [dbo].[OgretimElemani]  WITH CHECK ADD  CONSTRAINT [ck_OgrtMail] CHECK  (([OgrtMail] like '_%@duzce.edu.tr'))
GO
ALTER TABLE [dbo].[OgretimElemani] CHECK CONSTRAINT [ck_OgrtMail]
GO
ALTER TABLE [dbo].[Yonetici]  WITH CHECK ADD  CONSTRAINT [ck_yyetki] CHECK  (([YoneticiYetkiID]='1'))
GO
ALTER TABLE [dbo].[Yonetici] CHECK CONSTRAINT [ck_yyetki]
GO
/****** Object:  StoredProcedure [dbo].[akademisyenbilgi]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[akademisyenbilgi]
as
select OgrtID, OgrtAd, OgrtSoyad, Unvan, OgrtMail from OgretimElemani
GO
/****** Object:  StoredProcedure [dbo].[Ogrencibil]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Ogrencibil]
AS
Select OgrNO,OgrAd,OgrSoyad, Cinsiyet,DogumTar,OgrTelNo,Sinif,OgrResim,
OgrMail,OgrSifre,DanismanID from Ogrenci
inner join Bolum
on Bolum.BolumID=Ogrenci.BolumID
inner join OgrenciIsleri
on OgrenciIsleri.PersonelID=Ogrenci.PersonelID
inner join OgretimElemani
on OgretimElemani.OgrtID=Ogrenci.DanismanID
GO
/****** Object:  StoredProcedure [dbo].[secilmisdersler]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[secilmisdersler] 
as
select DersSecID, OgrAd, OgrSoyad, Yariyil, DersAdi, Akts, Kredi, BolumAd from DersSecme
inner join Ogrenci
on Ogrenci.OgrNo = DersSecme.OgrNo
inner join Ders
on DersSecme.DersKodu=Ders.DersKodu
inner join Bolum
on Bolum.BolumID=DersSecme.BolumID
GO
/****** Object:  StoredProcedure [dbo].[tbNotlar]    Script Date: 12.01.2023 08:40:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[tbNotlar]
AS
select NotID,Vize,final,ortalama,harfnotu,OgrtID from Not_
inner join Ders
on Not_.DersKodu=Ders.DersKodu
inner join Ogrenci
on Not_.OgrNo=Ogrenci.OgrNo
GO
