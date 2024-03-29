USE [database1]
GO
/****** Object:  Table [dbo].[Authority]    Script Date: 18.07.2017 17:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Authority](
	[Id] [int] NOT NULL,
	[Authority] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Authority] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 18.07.2017 17:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 18.07.2017 17:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Department] [varchar](50) NOT NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FingerPrint]    Script Date: 18.07.2017 17:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FingerPrint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User1_UserName] [varchar](50) NOT NULL,
	[Data] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FingerPrint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User1]    Script Date: 18.07.2017 17:38:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User1](
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Gender] [varchar](6) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Country_Id] [int] NOT NULL,
	[Department_Id] [int] NOT NULL,
	[Authority_Id] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User1_1] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Authority] ([Id], [Authority]) VALUES (0, N'Admin')
INSERT [dbo].[Authority] ([Id], [Authority]) VALUES (1, N'User')
INSERT [dbo].[Authority] ([Id], [Authority]) VALUES (99, N'Super Admin')
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (1, N'Adana')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (2, N'Adıyaman')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (3, N'Afyon')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (4, N'Ağrı')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (5, N'Amasya')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (6, N'Ankara')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (7, N'Antalya')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (8, N'Artvin')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (9, N'Aydın')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (10, N'Balıkesir')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (11, N'Bilecik')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (12, N'Bingöl')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (13, N'Bitlis')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (14, N'Bolu')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (15, N'Burdur')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (16, N'Bursa')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (17, N'Çanakkale')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (18, N'Çankırı')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (19, N'Çorum')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (20, N'Denizli')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (21, N'Diyarbakır')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (22, N'Edirne')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (23, N'Elazığ')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (24, N'Erzincan')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (25, N'Erzurum')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (26, N'Eşkişehir')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (27, N'Gaziantep')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (28, N'Giresun')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (29, N'Gümüşhane')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (30, N'Hakkari')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (31, N'Hatay')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (32, N'Isparta')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (33, N'İçel')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (34, N'İstanbul')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (35, N'İzmir')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (36, N'Kars')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (37, N'Kastamonu')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (38, N'Kayseri')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (39, N'Kırklareli')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (40, N'Kırşehir')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (41, N'Kocaeli')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (42, N'Konya')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (43, N'Kütahya')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (44, N'Malatya')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (45, N'Manisa')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (46, N'Kahramanmaraş')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (47, N'Mardin')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (48, N'Muğla')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (49, N'Muş')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (50, N'Nevşehir')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (51, N'Niğde')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (52, N'Ordu')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (53, N'Rize')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (54, N'Sakarya')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (55, N'Samsun')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (56, N'Siirt')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (57, N'Sinop')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (58, N'Sivas')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (59, N'Tekirdağ')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (60, N'Tokat')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (61, N'Trabzon')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (62, N'Tunceli')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (63, N'Şanlıurfa')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (64, N'Uşak')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (65, N'Van')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (66, N'Yozgat')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (67, N'Zonguldak')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (68, N'Aksaray')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (69, N'Bayburt')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (70, N'Karaman')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (71, N'Kırıkkale')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (72, N'Batman')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (73, N'Şırnak')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (74, N'Bartın')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (75, N'Ardahan')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (76, N'Iğdır')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (77, N'Yalova')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (78, N'Karabük')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (79, N'Kilis')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (80, N'Osmaniye')
INSERT [dbo].[Country] ([Id], [CountryName]) VALUES (81, N'Düzce')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (0, N'Stajyer', N'Closed')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (1, N'Öğrenci', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (2, N'Bilgisayar Mühendisi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (3, N'Yazılım Mühendisi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (4, N'Memur', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (5, N'Sekreter', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (6, N'Otomotiv Mühendisi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (7, N'Çevre Mühendisi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (8, N'Biyomedikal Mühendisi', N'Closed')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (9, N'Bilgi İşlem Yöneticisi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (10, N'Genel Müdür', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (11, N'CEO', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (12, N'CTO', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (13, N'Müdür', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (14, N'Yönetici', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (15, N'Elektrik-Elektronik Mühendisi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (16, N'Tekniker', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (17, N'Endüstri Mühendisi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (18, N'Biolog', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (19, N'Temizlikçi', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (20, N'Grafiker', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (21, N'IT müdürü', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (22, N'Genel Müdür yardımcısı', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (23, N'Deneme', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (24, N'Pazarlamacı', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (25, N'Halkla ilişkiler Sorumlusu', N'Open')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (26, N'x', N'Closed')
INSERT [dbo].[Department] ([Id], [Department], [Status]) VALUES (27, N'ddd', N'Closed')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[FingerPrint] ON 

INSERT [dbo].[FingerPrint] ([Id], [User1_UserName], [Data]) VALUES (1020, N'sa', N'asd')
INSERT [dbo].[FingerPrint] ([Id], [User1_UserName], [Data]) VALUES (1023, N'd', N'qewqeqw')
INSERT [dbo].[FingerPrint] ([Id], [User1_UserName], [Data]) VALUES (1027, N'saa', N'asdasdas')
INSERT [dbo].[FingerPrint] ([Id], [User1_UserName], [Data]) VALUES (1030, N'qq', N'qwe')
SET IDENTITY_INSERT [dbo].[FingerPrint] OFF
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'gizem', N'dördü', N'Male', CAST(0x0A3D0B00 AS Date), N'(555) 555-5555', 15, 20, 1, N'a', N'e10adc3949ba59abbe56e057f20f883e')
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'mertalp', N'taşdelen', N'Male', CAST(0x0E3D0B00 AS Date), N'(444) 444-4444', 20, 15, 0, N'aaaa', N'e10adc3949ba59abbe56e057f20f883e')
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'Deniz Doğa', N'Turna', N'Female', CAST(0x251D0B00 AS Date), N'(532) 267-1919', 20, 11, 0, N'd', N'e10adc3949ba59abbe56e057f20f883e')
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'deneme', N'deneme', N'Male', CAST(0x0F3D0B00 AS Date), N'(444) 444-4444', 3, 0, 0, N'deneme', N'e10adc3949ba59abbe56e057f20f883e')
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'gizem', N'd', N'Male', CAST(0x0F3D0B00 AS Date), N'(555) 555-5555', 1, 2, 0, N'g', N'9cafeef08db2dd477098a0293e71f90a')
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'Ali Mert', N'Özhayta', N'Male', CAST(0x0E3D0B00 AS Date), N'(444) 444-4444', 26, 2, 1, N'qq', N'e10adc3949ba59abbe56e057f20f883e')
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'Süleyman', N'Avcu', N'Male', CAST(0xA4170B00 AS Date), N'(553) 251-8222', 35, 2, 99, N'sa', N'c4ca4238a0b923820dcc509a6f75849b')
INSERT [dbo].[User1] ([Name], [Surname], [Gender], [DateOfBirth], [PhoneNumber], [Country_Id], [Department_Id], [Authority_Id], [UserName], [Password]) VALUES (N'süleyman', N'avcu', N'Male', CAST(0xDC170B00 AS Date), N'(423) 142-5685', 35, 6, 1, N'saa', N'e10adc3949ba59abbe56e057f20f883e')
ALTER TABLE [dbo].[FingerPrint]  WITH CHECK ADD  CONSTRAINT [FK_FingerPrint_User1] FOREIGN KEY([User1_UserName])
REFERENCES [dbo].[User1] ([UserName])
GO
ALTER TABLE [dbo].[FingerPrint] CHECK CONSTRAINT [FK_FingerPrint_User1]
GO
ALTER TABLE [dbo].[User1]  WITH CHECK ADD  CONSTRAINT [FK_User1_Authority] FOREIGN KEY([Authority_Id])
REFERENCES [dbo].[Authority] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User1] CHECK CONSTRAINT [FK_User1_Authority]
GO
ALTER TABLE [dbo].[User1]  WITH CHECK ADD  CONSTRAINT [FK_User1_Country] FOREIGN KEY([Country_Id])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[User1] CHECK CONSTRAINT [FK_User1_Country]
GO
ALTER TABLE [dbo].[User1]  WITH CHECK ADD  CONSTRAINT [FK_User1_Department] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Department] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User1] CHECK CONSTRAINT [FK_User1_Department]
GO
