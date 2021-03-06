USE [auto_repair]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 9/25/2016 3:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[mechanic_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mechanics]    Script Date: 9/25/2016 3:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mechanics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[mechanicId] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [mechanic_id]) VALUES (3, N'1111', 11)
INSERT [dbo].[clients] ([id], [name], [mechanic_id]) VALUES (4, N'2222', 10)
INSERT [dbo].[clients] ([id], [name], [mechanic_id]) VALUES (5, N'', 10)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[mechanics] ON 

INSERT [dbo].[mechanics] ([id], [name], [mechanicId]) VALUES (10, N'mike', NULL)
INSERT [dbo].[mechanics] ([id], [name], [mechanicId]) VALUES (11, N'russ', NULL)
SET IDENTITY_INSERT [dbo].[mechanics] OFF
