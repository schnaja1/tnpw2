USE [master]
GO
/****** Object:  Database [Knihovna]    Script Date: 15. 3. 2015 21:15:34 ******/
CREATE DATABASE [Knihovna]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Knihovna', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Knihovna.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Knihovna_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\Knihovna_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Knihovna] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Knihovna].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Knihovna] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Knihovna] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Knihovna] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Knihovna] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Knihovna] SET ARITHABORT OFF 
GO
ALTER DATABASE [Knihovna] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Knihovna] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Knihovna] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Knihovna] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Knihovna] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Knihovna] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Knihovna] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Knihovna] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Knihovna] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Knihovna] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Knihovna] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Knihovna] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Knihovna] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Knihovna] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Knihovna] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Knihovna] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Knihovna] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Knihovna] SET RECOVERY FULL 
GO
ALTER DATABASE [Knihovna] SET  MULTI_USER 
GO
ALTER DATABASE [Knihovna] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Knihovna] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Knihovna] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Knihovna] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Knihovna] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Knihovna', N'ON'
GO
USE [Knihovna]
GO
/****** Object:  Table [dbo].[book]    Script Date: 15. 3. 2015 21:15:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](200) NOT NULL,
	[author] [varchar](100) NOT NULL,
	[published_year] [int] NOT NULL,
	[description] [varchar](max) NULL,
	[image_name] [varchar](60) NULL,
	[category_id] [int] NOT NULL,
 CONSTRAINT [PK_book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[book_category]    Script Date: 15. 3. 2015 21:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[book_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[description] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_book_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[knihovna_role]    Script Date: 15. 3. 2015 21:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[knihovna_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[identificator] [varchar](50) NOT NULL,
	[role_description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_knihovna_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[knihovna_user]    Script Date: 15. 3. 2015 21:15:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[knihovna_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_knihovna_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[book] ON 

INSERT [dbo].[book] ([id], [name], [author], [published_year], [description], [image_name], [category_id]) VALUES (1, N'Encyklopedie vesmíru', N'Jan Novák', 2014, N'Zajímavá kniha o celém vesmíru', NULL, 3)
INSERT [dbo].[book] ([id], [name], [author], [published_year], [description], [image_name], [category_id]) VALUES (2, N'Zahrada pro každého', N'Karel Trávníček', 2000, N'Kniha o zakládání a udržování zahrádky', NULL, 2)
SET IDENTITY_INSERT [dbo].[book] OFF
SET IDENTITY_INSERT [dbo].[book_category] ON 

INSERT [dbo].[book_category] ([id], [name], [description]) VALUES (1, N'Informační technologie', N'Knihy zabývající se tématikou informačních technologií')
INSERT [dbo].[book_category] ([id], [name], [description]) VALUES (2, N'Kutilství', N'Knihy pro kutily')
INSERT [dbo].[book_category] ([id], [name], [description]) VALUES (3, N'Vesmír', N'Knihy o vesmíru')
INSERT [dbo].[book_category] ([id], [name], [description]) VALUES (4, N'Beletrie', N'Beletristická literatura')
INSERT [dbo].[book_category] ([id], [name], [description]) VALUES (5, N'Učebnice', N'Naučná literatura pro žáky')
SET IDENTITY_INSERT [dbo].[book_category] OFF
SET IDENTITY_INSERT [dbo].[knihovna_role] ON 

INSERT [dbo].[knihovna_role] ([role_id], [identificator], [role_description]) VALUES (1, N'knihovnik', N'Knihovník')
INSERT [dbo].[knihovna_role] ([role_id], [identificator], [role_description]) VALUES (2, N'ctenar', N'Čtenář')
SET IDENTITY_INSERT [dbo].[knihovna_role] OFF
SET IDENTITY_INSERT [dbo].[knihovna_user] ON 

INSERT [dbo].[knihovna_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (1, N'Jiří', N'Štěpánek', N'jirka', N'jirka', 1)
INSERT [dbo].[knihovna_user] ([user_id], [name], [surname], [login], [password], [role_id]) VALUES (2, N'Jan', N'Novák', N'novak', N'novak', 2)
SET IDENTITY_INSERT [dbo].[knihovna_user] OFF
ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_book_book_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[book_category] ([id])
GO
ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_book_book_category]
GO
ALTER TABLE [dbo].[knihovna_user]  WITH CHECK ADD  CONSTRAINT [FK_knihovna_user_knihovna_user] FOREIGN KEY([role_id])
REFERENCES [dbo].[knihovna_role] ([role_id])
GO
ALTER TABLE [dbo].[knihovna_user] CHECK CONSTRAINT [FK_knihovna_user_knihovna_user]
GO
USE [master]
GO
ALTER DATABASE [Knihovna] SET  READ_WRITE 
GO
