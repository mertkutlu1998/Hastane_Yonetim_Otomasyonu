USE [MCI_Hospital]
GO
/****** Object:  Table [dbo].[tbl_Hasta]    Script Date: 6.11.2022 21:23:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Hasta](
	[Hasta_id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[Cinsiyet] [nvarchar](50) NOT NULL,
	[Tc] [nvarchar](11) NOT NULL,
	[Doğum_Tarihi] [nvarchar](10) NOT NULL,
	[Telefon] [nvarchar](18) NOT NULL,
	[Ssk_Durum] [nvarchar](50) NULL,
	[Parola] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Hasta] PRIMARY KEY CLUSTERED 
(
	[Hasta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Kasa]    Script Date: 6.11.2022 21:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Kasa](
	[Kasa_id] [int] IDENTITY(1,1) NOT NULL,
	[total] [float] NOT NULL,
	[P_id_Muhasebe] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Kasa] PRIMARY KEY CLUSTERED 
(
	[Kasa_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Maas]    Script Date: 6.11.2022 21:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Maas](
	[Maas_id] [int] IDENTITY(1,1) NOT NULL,
	[Personel_id] [int] NOT NULL,
	[Maas] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Maas] PRIMARY KEY CLUSTERED 
(
	[Maas_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Malzemeler]    Script Date: 6.11.2022 21:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Malzemeler](
	[M_id] [int] IDENTITY(1,1) NOT NULL,
	[Tedarik_id] [int] NOT NULL,
	[Adı] [nvarchar](max) NOT NULL,
	[Adet] [int] NOT NULL,
	[Ucret] [float] NOT NULL,
	[Detay] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Malzemeler] PRIMARY KEY CLUSTERED 
(
	[M_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Personel]    Script Date: 6.11.2022 21:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Personel](
	[Personel_id] [int] IDENTITY(1,1) NOT NULL,
	[P_Ad] [nvarchar](50) NOT NULL,
	[P_Soyad] [nvarchar](50) NOT NULL,
	[P_Dogum_Tarihi] [nvarchar](10) NOT NULL,
	[P_TC] [nvarchar](11) NOT NULL,
	[P_Görev] [nvarchar](50) NOT NULL,
	[Yetki] [int] NOT NULL,
	[P_Telefon] [nvarchar](14) NOT NULL,
	[P_Adres] [nvarchar](max) NOT NULL,
	[sifre] [nvarchar](50) NOT NULL,
	[Durum] [int] NULL,
 CONSTRAINT [PK_tbl_Personel] PRIMARY KEY CLUSTERED 
(
	[Personel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Randevular]    Script Date: 6.11.2022 21:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Randevular](
	[Randevu_id] [int] IDENTITY(1,1) NOT NULL,
	[Hasta_id] [int] NOT NULL,
	[Doktor_id] [int] NOT NULL,
	[R_Saat] [nvarchar](5) NOT NULL,
	[R_Gun] [nvarchar](10) NOT NULL,
	[Sikayet] [nvarchar](50) NOT NULL,
	[Ucret] [float] NOT NULL,
 CONSTRAINT [PK_tbl_Randevular] PRIMARY KEY CLUSTERED 
(
	[Randevu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Receteler]    Script Date: 6.11.2022 21:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Receteler](
	[Recete_id] [int] IDENTITY(1,1) NOT NULL,
	[Randevu_id] [int] NOT NULL,
	[Acıklama] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Receteler] PRIMARY KEY CLUSTERED 
(
	[Recete_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Tedarikciler]    Script Date: 6.11.2022 21:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Tedarikciler](
	[Tedarikci_id] [int] IDENTITY(1,1) NOT NULL,
	[T_Ad] [nvarchar](50) NOT NULL,
	[T_Adres] [nvarchar](max) NOT NULL,
	[T_Telefon] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Tedarikciler] PRIMARY KEY CLUSTERED 
(
	[Tedarikci_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Hasta] ON 

INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (3, N'İclal', N'Akkoyun', N'K', N'11111111110', N'01-01-1990', N'111', N'Aktif     ', N'1')
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (4, N'Ali', N'Kutlu', N'E', N'11111111111', N'10-10-195', N'112     ', N'Aktif', N'3')
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (5, N'Rana', N'Altın', N'K', N'11111111112', N'10-05-1995', N'113', N'Pasif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (6, N'Halim', N'Aral', N'E', N'11111111113', N'10-01-1995', N'114', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (7, N'Fatih', N'Köle', N'E', N'11111111114', N'09-07-1995', N'115', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (8, N'Ebubekir', N'Sezer', N'E', N'11111111115', N'25-05-1998', N'116', N'Pasif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (9, N'Elif', N'Sezer', N'K', N'11111111116', N'17-05-1992', N'117', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (10, N'Tuğba', N'Fındık', N'K', N'11111111117', N'15-11-1997', N'118', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (11, N'Furkan', N'Kutlu', N'E', N'11111111118', N'14-03-1989', N'119', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (12, N'Ali', N'Yüce', N'E', N'11111111119', N'14-10-2000', N'120', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (15, N'mehmet ', N'Karahasan', N'K', N'12145785424', N'10-10-2000', N'101 010 1010', N'evet', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (18, N'mehmet ', N'ali veli', N'K', N'12145785424', N'10-10-2000', N'101 010 1010', N'evet', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (19, N'ilker', N'yüce', N'E', N'26056519915', N'19-10-2011', N'555 555 5555', N'Aktif', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (20, N'Yaren', N'Çoban', N'E', N'41422659610', N'08-17-1998', N'507 000 0000', N'Aktif', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (21, N'ali', N'Yüce', N'E', N'14000000014', N'14-04-2002', N'111 222 5552', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (22, N'Cihat', N'Toparlak', N'E', N'12365478900', N'01-01-1998', N'123 654 7892', N'Aktif     ', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (23, N'Ebubekir', N'Sıddık', N'E', N'34567890098', N'12-10-1990', N'111 111 1111', N'Aktif', NULL)
INSERT [dbo].[tbl_Hasta] ([Hasta_id], [Ad], [Soyad], [Cinsiyet], [Tc], [Doğum_Tarihi], [Telefon], [Ssk_Durum], [Parola]) VALUES (1023, N'İlker', N'asd', N'K', N'11111111177', N'25-11-2000', N'055 555 5555', N'Aktif', N'asdf')
SET IDENTITY_INSERT [dbo].[tbl_Hasta] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Kasa] ON 

INSERT [dbo].[tbl_Kasa] ([Kasa_id], [total], [P_id_Muhasebe]) VALUES (1, 39998075, 11)
SET IDENTITY_INSERT [dbo].[tbl_Kasa] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Maas] ON 

INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (1, 1, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (2, 4, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (3, 5, 19500)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (4, 6, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (7, 7, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (9, 9, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (10, 10, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (11, 11, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (12, 12, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (13, 13, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (15, 14, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (16, 15, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (17, 16, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (18, 17, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (19, 18, 20000)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (20, 19, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (21, 20, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (32, 21, 9850)
INSERT [dbo].[tbl_Maas] ([Maas_id], [Personel_id], [Maas]) VALUES (33, 31, 31000)
SET IDENTITY_INSERT [dbo].[tbl_Maas] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Malzemeler] ON 

INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (1, 1, N'Temizlik', 50, 5000, NULL)
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (2, 2, N'Önlük', 50, 2000, NULL)
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (3, 2, N'Ayakkabı', 50, 1000, NULL)
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (4, 1, N'Maske', 500, 1000, NULL)
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (5, 3, N'Ameliyat malzemeleri ', 50, 8000, NULL)
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (6, 3, N'Çarşaf', 100, 1000, NULL)
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (1003, 1, N'Peçete', 212, 100, N'Çok Para')
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (1004, 1, N'deneme', 14, 12, N'deneme')
INSERT [dbo].[tbl_Malzemeler] ([M_id], [Tedarik_id], [Adı], [Adet], [Ucret], [Detay]) VALUES (1005, 1, N'adad', 45, 45, N'sretdf')
SET IDENTITY_INSERT [dbo].[tbl_Malzemeler] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Personel] ON 

INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (1, N'Burak', N'Karaküçük', N'05-05-1990', N'12365478911', N'Kalp ve Damar', 1, N'1453', N'Çankaya', N'123', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (4, N'Cihat ', N'Toparlak', N'05-05-1990', N'12345789321', N'Üroloji', 1, N'3654', N'Beykoz', N'456', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (5, N'Mert', N'Kutlu', N'05-05-1990', N'44505063985', N'Başhekim Yard.', 4, N'6987', N'Pendik', N'789', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (6, N'Mehmet', N'Akkuş', N'05-05-1990', N'45698714785', N'Başhekim', 4, N'7896', N'Adana', N'101', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (7, N'Neval', N'Türk', N'05-05-1990', N'14789632587', N'Sekreter', 2, N'78965', N'Üsküdar', N'121', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (9, N'Mısra', N'Mısır', N'05-05-1990', N'14785231458', N'Sekreter', 2, N'14752', N'Sultanbeyli', N'141', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (10, N'Devrim', N'Pattaban', N'05-05-1990', N'14785963257', N'IT', 0, N'1478', N'Kastamonu', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (11, N'Büşra', N'Söyünmez', N'05-05-1990', N'14789541789', N'Muhasebe', 3, N'1474', N'Mecidiyeköy', N'181', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (12, N'Sena', N'Ekincioğlu', N'05-05-1990', N'14589674122', N'Hemşire', 5, N'1245', N'Beşiktaş', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (13, N'Muhammet', N'Bedir', N'05-05-1990', N'12345688711', N'Hemşire', 5, N'1998', N'Şişli', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (14, N'Burak', N'Alkan', N'05-05-1990', N'12030054787', N'Temizlikçi', 0, N'14733', N'Erzincan', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (15, N'Murat', N'Fındık', N'05-05-1990', N'12589674125', N'ATT Çalışanı', 0, N'1258', N'Çankırı', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (16, N'İbrahim', N'Kutlu', N'05-05-1990', N'12547896322', N'Dahiliye', 1, N'5589', N'Erizncan', N'232', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (17, N'Mehmet Mert', N'Tutunmaz', N'05-05-1990', N'12547852410', N'Dahiliye', 1, N'2200', N'Beyliküdüzü', N'252', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (18, N'İlker', N'Yüce', N'05-05-1990', N'12563241025', N'Çocuk', 1, N'1112', N'Gaziosmanpaşa', N'272', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (19, N'Berkcan', N'Araz', N'05-05-1990', N'12365897411', N'Çocuk', 1, N'1002', N'Yalova', N'293', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (20, N'Erhan', N'Sessiz', N'05-05-1990', N'14523652411', N'Kalp ve Damar', 1, N'1199', N'Tuzla', N'313', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (21, N'Mürüt', N'Özdemir', N'22-02-1975', N'11111111111', N'Üroloji', 1, N'(212) 397-4852', N'Pendik', N'160', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (22, N'Mehmet', N'Ercan', N'22-10-1995', N'45699778555', N'Güvenlik', 0, N'87854512', N'Ankara', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (23, N'Ali', N'Veli', N'11-10-1988', N'98796856355', N'Güvenlik', 0, N'(312) 328-4425', N'A sokak', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (27, N'Rıza', N'Kaya', N'01-01-1955', N'77777777777', N'Ortopedi', 1, N'(888) 888-8888', N'Fransa', N'--', 0)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (28, N'Kaya', N'Koçol', N'14-10-1955', N'77777777778', N'Göz', 1, N'(129) 547-8512', N'Kastamonu', N'--', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (30, N'Mahmut', N'Ertem', N'05-05-1853', N'55555555555', N'Çocuk', 1, N'05-05-1853', N'Tuzla', N'159', 1)
INSERT [dbo].[tbl_Personel] ([Personel_id], [P_Ad], [P_Soyad], [P_Dogum_Tarihi], [P_TC], [P_Görev], [Yetki], [P_Telefon], [P_Adres], [sifre], [Durum]) VALUES (31, N'Bedirhan', N'Çetin', N'21-06-1997', N'45464545464', N'Başhekim Yard.', 4, N'(541) 435-2833', N'Kadıköy', N'5431', 1)
SET IDENTITY_INSERT [dbo].[tbl_Personel] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Randevular] ON 

INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (6, 3, 1, N'08:00', N'10-11-2022', N'Kalp Krizi', 500)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (8, 4, 1, N'08:30', N'10-09-2022', N'Kalp Krizi', 500)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (9, 5, 4, N'08:30', N'10-10-2022', N'İdrar Kaçağı', 800)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (13, 6, 16, N'14:00', N'10-05-2022', N'Karın Ağrısı', 300)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (16, 7, 18, N'09:00', N'09-05-2022', N'Ateş', 150)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (17, 8, 17, N'09:30', N'09-05-2022', N'İnce Hastalık', 200)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (18, 9, 20, N'10:00', N'09-05-2022', N'Kalp Sıkışması', 350)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (19, 10, 19, N'08:30', N'09-05-2022', N'Kızamık', 150)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (21, 11, 19, N'11:00', N'09-05-2022', N'Ateş', 250)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (22, 12, 4, N'09:00', N'09-05-2022', N'Testis Taraması', 500)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (23, 9, 1, N'11:00', N'09-05-2022', N'Kalp Pili', 1500)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (24, 10, 1, N'10:00', N'10-10-2022', N'', 1111)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (25, 20, 18, N'10:00', N'30-12-2022', N'Ateş', 0)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (26, 10, 1, N'08:00', N'29-10-2022', N'Kalp', 500)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (27, 4, 1, N'08:00', N'10-10-2022', N'', 1111)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (28, 21, 4, N'08:00', N'30-10-2022', N'', 10)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (29, 11, 18, N'16:00', N'03-11-2022', N'Çocuğum kusuyor', 1500)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (30, 23, 18, N'15:00', N'03-11-2022', N'Kusmasın', 1500)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (1031, 4, 19, N'08:00', N'22-02-2022', N'Karın ağrısı', 100)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (1032, 4, 16, N'08:00', N'21-10-2022', N'10', 100)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (1035, 4, 19, N'08:00', N'10-02-2022', N'10', 100)
INSERT [dbo].[tbl_Randevular] ([Randevu_id], [Hasta_id], [Doktor_id], [R_Saat], [R_Gun], [Sikayet], [Ucret]) VALUES (1036, 4, 18, N'', N'10-02-2022', N'10', 100)
SET IDENTITY_INSERT [dbo].[tbl_Randevular] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Receteler] ON 

INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (1, 6, N'Dolarjin -ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (2, 8, N'Azarga -ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (3, 9, N'qq')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (4, 13, N'Ciloxan-ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (5, 17, N'Desferal-ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (6, 16, N'Dıovan-ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (7, 18, N'Exelon-ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (8, 19, N'Femara-ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (9, 21, N'Galvus-ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (10, 22, N'ILarıs-ilaç')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (12, 8, N'Ameliyat Edilecek')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (13, 6, N'sadf')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (14, 23, N'deneme')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (15, 23, N'deneme')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (16, 26, N'ülker')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (17, 30, N'Akut faranjit -Calpol ve Parol ')
INSERT [dbo].[tbl_Receteler] ([Recete_id], [Randevu_id], [Acıklama]) VALUES (18, 28, N'ilaç')
SET IDENTITY_INSERT [dbo].[tbl_Receteler] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Tedarikciler] ON 

INSERT [dbo].[tbl_Tedarikciler] ([Tedarikci_id], [T_Ad], [T_Adres], [T_Telefon]) VALUES (1, N'Fulla', N'ankara', N'1245')
INSERT [dbo].[tbl_Tedarikciler] ([Tedarikci_id], [T_Ad], [T_Adres], [T_Telefon]) VALUES (2, N'Seyhan ltd', N'adana', N'7895')
INSERT [dbo].[tbl_Tedarikciler] ([Tedarikci_id], [T_Ad], [T_Adres], [T_Telefon]) VALUES (3, N'koç holding', N'İstanbul', N'111 111 1111')
INSERT [dbo].[tbl_Tedarikciler] ([Tedarikci_id], [T_Ad], [T_Adres], [T_Telefon]) VALUES (4, N'Kutlu Ticaret', N'Kavakpınar', N'000 000 0000')
SET IDENTITY_INSERT [dbo].[tbl_Tedarikciler] OFF
GO
ALTER TABLE [dbo].[tbl_Kasa]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Kasa_tbl_Personel] FOREIGN KEY([P_id_Muhasebe])
REFERENCES [dbo].[tbl_Personel] ([Personel_id])
GO
ALTER TABLE [dbo].[tbl_Kasa] CHECK CONSTRAINT [FK_tbl_Kasa_tbl_Personel]
GO
ALTER TABLE [dbo].[tbl_Maas]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Maas_tbl_Personel] FOREIGN KEY([Personel_id])
REFERENCES [dbo].[tbl_Personel] ([Personel_id])
GO
ALTER TABLE [dbo].[tbl_Maas] CHECK CONSTRAINT [FK_tbl_Maas_tbl_Personel]
GO
ALTER TABLE [dbo].[tbl_Malzemeler]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Malzemeler_tbl_Tedarikciler] FOREIGN KEY([Tedarik_id])
REFERENCES [dbo].[tbl_Tedarikciler] ([Tedarikci_id])
GO
ALTER TABLE [dbo].[tbl_Malzemeler] CHECK CONSTRAINT [FK_tbl_Malzemeler_tbl_Tedarikciler]
GO
ALTER TABLE [dbo].[tbl_Randevular]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Randevular_tbl_Hasta] FOREIGN KEY([Hasta_id])
REFERENCES [dbo].[tbl_Hasta] ([Hasta_id])
GO
ALTER TABLE [dbo].[tbl_Randevular] CHECK CONSTRAINT [FK_tbl_Randevular_tbl_Hasta]
GO
ALTER TABLE [dbo].[tbl_Randevular]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Randevular_tbl_Personel] FOREIGN KEY([Doktor_id])
REFERENCES [dbo].[tbl_Personel] ([Personel_id])
GO
ALTER TABLE [dbo].[tbl_Randevular] CHECK CONSTRAINT [FK_tbl_Randevular_tbl_Personel]
GO
ALTER TABLE [dbo].[tbl_Receteler]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Receteler_tbl_Randevular] FOREIGN KEY([Randevu_id])
REFERENCES [dbo].[tbl_Randevular] ([Randevu_id])
GO
ALTER TABLE [dbo].[tbl_Receteler] CHECK CONSTRAINT [FK_tbl_Receteler_tbl_Randevular]
GO
