USE [Hywin]
GO
/****** Object:  Table [dbo].[Office]    Script Date: 01/12/2015 04:46:10 ******/
SET IDENTITY_INSERT [dbo].[Office] ON
INSERT [dbo].[Office] ([Id], [phoneNumber], [Area], [FKCompanyID], [buildingName], [type]) VALUES (1, N'323232', N'333', 3, N'B1', 0)
INSERT [dbo].[Office] ([Id], [phoneNumber], [Area], [FKCompanyID], [buildingName], [type]) VALUES (2, N'52343', N'222', 3, N'W1', 1)
INSERT [dbo].[Office] ([Id], [phoneNumber], [Area], [FKCompanyID], [buildingName], [type]) VALUES (3, N'43234', N'111', 2, N'W2', 1)
INSERT [dbo].[Office] ([Id], [phoneNumber], [Area], [FKCompanyID], [buildingName], [type]) VALUES (5, N'3333', N'34', 2, N'ww2', 0)
SET IDENTITY_INSERT [dbo].[Office] OFF
/****** Object:  Table [dbo].[Company]    Script Date: 01/12/2015 04:46:10 ******/
SET IDENTITY_INSERT [dbo].[Company] ON
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (1, N'af', N'Available Fabric Ltd', N'1212121', NULL, NULL, NULL, 0, NULL, 0, N'USA')
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (2, N'fgadf', N'hhhsdfhjj;jkjkjk', N'66868686', NULL, NULL, NULL, 0, NULL, 1, N'Canada')
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (3, N'fdd', N'yadjm', N'5323', NULL, NULL, NULL, 0, NULL, 2, N'Canada')
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (4, N'fadf', N'hh', N'666', NULL, NULL, CAST(0x0000A41B00000000 AS DateTime), 1, NULL, 3, N'China')
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (6, N'yh', N'yong he textile', N'431234134', NULL, NULL, NULL, 0, NULL, 4, N'USA')
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (7, N'cg', N'ChuanGang Textile Ltd', N'8888888', NULL, NULL, CAST(0x0000A41700000000 AS DateTime), 0, NULL, 1, N'Canada')
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (10, N'yy', N'yy Company', N'3333', NULL, NULL, NULL, 0, NULL, 0, N'China')
INSERT [dbo].[Company] ([Id], [BriefName], [FullName], [Phone], [Email], [WebSite], [DateSince], [IsActive], [logo], [companyType], [country]) VALUES (11, N'zz', N'zz Compnay', N'8888', NULL, NULL, NULL, 0, NULL, 4, N'Canada')
SET IDENTITY_INSERT [dbo].[Company] OFF
/****** Object:  Table [dbo].[Address]    Script Date: 01/12/2015 04:46:10 ******/
INSERT [dbo].[Address] ([Address_Id], [Number], [Street], [City], [State], [Country], [ZipCode], [addressType]) VALUES (1, N'43', N'aaafbadf', N'adf', N'adf', N'USA', N'134', NULL)
INSERT [dbo].[Address] ([Address_Id], [Number], [Street], [City], [State], [Country], [ZipCode], [addressType]) VALUES (2, N'44', N'gag', N'adf', N'adf', N'Canada', N'134', NULL)
INSERT [dbo].[Address] ([Address_Id], [Number], [Street], [City], [State], [Country], [ZipCode], [addressType]) VALUES (3, N'45', N'ggg', N'hhh', N'hhh', N'China', N'333', NULL)
INSERT [dbo].[Address] ([Address_Id], [Number], [Street], [City], [State], [Country], [ZipCode], [addressType]) VALUES (5, N'5555', N'oooooopppp', N'asdf', N'had', N'China', N'333', NULL)
/****** Object:  Table [dbo].[Person]    Script Date: 01/12/2015 04:46:10 ******/
SET IDENTITY_INSERT [dbo].[Person] ON
INSERT [dbo].[Person] ([Id], [Title], [FKOfficeID], [FirstName], [LastName], [MobilePhone], [Email], [photo]) VALUES (2, N'Buyer', 1, N'Mike', N'Qiang', N'1431413', N'info@xxx.com', NULL)
INSERT [dbo].[Person] ([Id], [Title], [FKOfficeID], [FirstName], [LastName], [MobilePhone], [Email], [photo]) VALUES (4, N'Associate', 2, N'Wenli', N'Wang', N'4134', N'xxxx@xxx.com', NULL)
INSERT [dbo].[Person] ([Id], [Title], [FKOfficeID], [FirstName], [LastName], [MobilePhone], [Email], [photo]) VALUES (5, N'Buyer', 3, N'xxx', N'yyyy', N'431531', N'xxxx@yyy.com', NULL)
INSERT [dbo].[Person] ([Id], [Title], [FKOfficeID], [FirstName], [LastName], [MobilePhone], [Email], [photo]) VALUES (6, N'GM', 5, N'yyyy', N'zzzz', N'5135135', N'yyyy@xxxxx.com', NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
