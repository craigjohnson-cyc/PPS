	USE [Learn1]
	GO

	/****** Object:  Table [dbo].[clientFinancial]    Script Date: 12/18/2024 3:46:39 PM ******/
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[clientFinancial]') AND type in (N'U'))
	DROP TABLE [dbo].[clientFinancial]
	GO

	/****** Object:  Table [dbo].[clientFinancial]    Script Date: 12/18/2024 3:46:39 PM ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[clientFinancial](
		[id] [int] NOT NULL,
		[AccountNumber] [char](20) NOT NULL,
		[Balance] [float] NOT NULL,
		[BankName] [char](30) NOT NULL,
		[CoSigner] [char](20) NOT NULL,
		[Statement] [char](20) NOT NULL,
		[AccountType] [char](20) NOT NULL,
		[ClientKey] [int] NOT NULL,
	 CONSTRAINT [PK_clientFinancial] PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO

--  Create ClientDetails table



