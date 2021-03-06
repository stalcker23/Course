USE [Hotel]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id_category] [int] NOT NULL,
	[legend] [text] NULL,
	[sum_places] [int] NULL,
 CONSTRAINT [PK_Categoty] PRIMARY KEY CLUSTERED 
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id_client] [int] NOT NULL,
	[FIO] [text] NULL,
	[pasport] [float] NULL ,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelRoom]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelRoom](
	[id_room] [int] NOT NULL,
	[tax_room] [real] NULL,
	[id_category] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_HotelRoom] PRIMARY KEY CLUSTERED 
(
	[id_room] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[List_services]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List_services](
	[id_list] [int] NOT NULL,
	[id_service] [int] NULL,
	[date_begin] [datetime] NULL,
	[date_end] [datetime] NULL,
	[id_client] [int] NULL,
	[summary] [real] NULL,
 CONSTRAINT [PK_List_services] PRIMARY KEY CLUSTERED 
(
	[id_list] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reserve]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserve](
	[id_reserve] [int] NOT NULL,
	[id_client] [int] NULL,
	[id_category] [int] NULL,
	[date_begin] [date] NULL,
	[date_end] [date] NULL,
 CONSTRAINT [PK_Reserve] PRIMARY KEY CLUSTERED 
(
	[id_reserve] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id_service] [int] NOT NULL,
	[tax_service] [real] NULL,
	[legend] [text] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id_service] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Summary]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Summary](
	[id_summa] [int] NOT NULL,
	[id_list] [int] NULL,
	[id_zakaz] [int] NULL,
	[summary] [real] NULL,
 CONSTRAINT [PK_Summary] PRIMARY KEY CLUSTERED 
(
	[id_summa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zakaz]    Script Date: 20.03.2016 19:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zakaz](
	[id_zakaz] [int] NOT NULL,
	[date_begin] [datetime] NULL,
	[date_end] [datetime] NULL,
	[id_room] [int] NULL,
	[id_client] [int] NULL,
	[summary] [real] NULL,
 CONSTRAINT [PK_Zakaz] PRIMARY KEY CLUSTERED 
(
	[id_zakaz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[HotelRoom]  WITH CHECK ADD  CONSTRAINT [FK_HotelRoom_Category] FOREIGN KEY([id_category])
REFERENCES [dbo].[Category] ([id_category])
GO
ALTER TABLE [dbo].[HotelRoom] CHECK CONSTRAINT [FK_HotelRoom_Category]
GO
ALTER TABLE [dbo].[List_services]  WITH CHECK ADD  CONSTRAINT [FK_List_services_Client] FOREIGN KEY([id_client])
REFERENCES [dbo].[Client] ([id_client])
GO
ALTER TABLE [dbo].[List_services] CHECK CONSTRAINT [FK_List_services_Client]
GO
ALTER TABLE [dbo].[List_services]  WITH CHECK ADD  CONSTRAINT [FK_List_services_Service] FOREIGN KEY([id_service])
REFERENCES [dbo].[Service] ([id_service])
GO
ALTER TABLE [dbo].[List_services] CHECK CONSTRAINT [FK_List_services_Service]
GO
ALTER TABLE [dbo].[Reserve]  WITH CHECK ADD  CONSTRAINT [FK_Reserve_Category] FOREIGN KEY([id_category])
REFERENCES [dbo].[Category] ([id_category])
GO
ALTER TABLE [dbo].[Reserve] CHECK CONSTRAINT [FK_Reserve_Category]
GO
ALTER TABLE [dbo].[Reserve]  WITH CHECK ADD  CONSTRAINT [FK_Reserve_Client1] FOREIGN KEY([id_client])
REFERENCES [dbo].[Client] ([id_client])
GO
ALTER TABLE [dbo].[Reserve] CHECK CONSTRAINT [FK_Reserve_Client1]
GO
ALTER TABLE [dbo].[Summary]  WITH CHECK ADD  CONSTRAINT [FK_Summary_List_services] FOREIGN KEY([id_list])
REFERENCES [dbo].[List_services] ([id_list])
GO
ALTER TABLE [dbo].[Summary] CHECK CONSTRAINT [FK_Summary_List_services]
GO
ALTER TABLE [dbo].[Summary]  WITH CHECK ADD  CONSTRAINT [FK_Summary_Zakaz1] FOREIGN KEY([id_zakaz])
REFERENCES [dbo].[Zakaz] ([id_zakaz])
GO
ALTER TABLE [dbo].[Summary] CHECK CONSTRAINT [FK_Summary_Zakaz1]
GO
ALTER TABLE [dbo].[Zakaz]  WITH CHECK ADD  CONSTRAINT [FK_Zakaz_Client] FOREIGN KEY([id_client])
REFERENCES [dbo].[Client] ([id_client])
GO
ALTER TABLE [dbo].[Zakaz] CHECK CONSTRAINT [FK_Zakaz_Client]
GO
ALTER TABLE [dbo].[Zakaz]  WITH CHECK ADD  CONSTRAINT [FK_Zakaz_HotelRoom] FOREIGN KEY([id_room])
REFERENCES [dbo].[HotelRoom] ([id_room])
GO
ALTER TABLE [dbo].[Zakaz] CHECK CONSTRAINT [FK_Zakaz_HotelRoom]
GO
