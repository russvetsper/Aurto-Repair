USE [auto_repair_test]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 9/25/2016 3:52:16 PM ******/
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
/****** Object:  Table [dbo].[mechanics]    Script Date: 9/25/2016 3:52:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mechanics](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
