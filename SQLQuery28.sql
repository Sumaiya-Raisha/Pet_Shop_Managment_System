USE [Pet_Shop]
GO

/****** Object:  Table [dbo].[Pet_list]    Script Date: 9/28/2025 4:19:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pet_list](
	[PetID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Type] [varchar](30) NOT NULL,
	[Breed] [varchar](50) NULL,
	[Age] [int] NULL,
	[Gender] [varchar](10) NULL,
	[HealthStatus] [varchar](100) NULL,
	[DateAdded] [datetime] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[VendorID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pet_list] ADD  DEFAULT (getdate()) FOR [DateAdded]
GO

ALTER TABLE [dbo].[Pet_list] ADD  DEFAULT ((0)) FOR [Price]
GO




