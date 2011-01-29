CREATE DATABASE test
USE [test]
GO
/****** 对象:  User [lctmui]    脚本日期: 11/30/2008 17:36:56 ******/
CREATE USER [lctmui] FOR LOGIN [lctmui] WITH DEFAULT_SCHEMA=[lctmui]
GO
/****** 对象:  Schema [lctmui]    脚本日期: 11/30/2008 17:36:56 ******/
CREATE SCHEMA [lctmui] AUTHORIZATION [lctmui]
GO
/****** 对象:  Table [dbo].[usr]    脚本日期: 11/30/2008 17:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usr](
	[UID] [int] IDENTITY(10000,1) NOT NULL,
	[usr_nm] [nchar](20) NOT NULL,
	[usr_pwd] [nchar](64) NOT NULL,
	[usr_mail] [nchar](50) NOT NULL,
	[usr_snm] [nchar](20) NULL,
 CONSTRAINT [PK_usr] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_usr] ON [dbo].[usr] 
(
	[usr_nm] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[log]    脚本日期: 11/30/2008 17:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[usr_nm] [nchar](20) NULL,
	[txt] [nchar](50) NULL,
	[dat] [datetime] NULL,
 CONSTRAINT [PK_log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_log] ON [dbo].[log] 
(
	[dat] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[adm]    脚本日期: 11/30/2008 17:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adm](
	[AID] [int] IDENTITY(10000,1) NOT NULL,
	[adm_nm] [nchar](20) NOT NULL,
	[adm_pwd] [nchar](64) NOT NULL,
 CONSTRAINT [PK_adm] PRIMARY KEY CLUSTERED 
(
	[AID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_adm] ON [dbo].[adm] 
(
	[adm_nm] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
