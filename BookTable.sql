USE [ReadingCorp]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 28/06/2021 09:46:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[Book_id] [int] IDENTITY(1,1) NOT NULL,
	[Book_name] [nvarchar](50) NULL,
	[Author] [nvarchar](25) NULL,
	[RegistrationTime] [datetime] NULL,
	[Category] [nvarchar](10) NULL,
	[Book_description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

