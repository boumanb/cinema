USE [master]
GO
/****** Object:  Database [Concrete.BioscoopModel]    Script Date: 31-3-2017 12:32:05 ******/
CREATE DATABASE [Concrete.BioscoopModel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Concrete.BioscoopModel', FILENAME = N'C:\Users\billy\Concrete.BioscoopModel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Concrete.BioscoopModel_log', FILENAME = N'C:\Users\billy\Concrete.BioscoopModel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Concrete.BioscoopModel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Concrete.BioscoopModel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET  MULTI_USER 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Concrete.BioscoopModel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Concrete.BioscoopModel] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Concrete.BioscoopModel]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Email] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[WantsNewsletter] [bit] NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[AccountType] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
	[StreetNumber] [int] NOT NULL,
	[City] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HallLayouts]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HallLayouts](
	[HallLayoutID] [int] IDENTITY(1,1) NOT NULL,
	[Rows] [int] NOT NULL,
	[SeatsPerRow] [int] NOT NULL,
 CONSTRAINT [PK_dbo.HallLayouts] PRIMARY KEY CLUSTERED 
(
	[HallLayoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HallMovies]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HallMovies](
	[HallMovieID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[HallID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[DateTimeEnd] [datetime] NOT NULL,
	[LadiesNight] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.HallMovies] PRIMARY KEY CLUSTERED 
(
	[HallMovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Halls]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[HallID] [int] IDENTITY(1,1) NOT NULL,
	[Capacity] [int] NOT NULL,
	[HallLayoutID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Halls] PRIMARY KEY CLUSTERED 
(
	[HallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movies]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Length] [int] NOT NULL,
	[ThreeD] [bit] NOT NULL,
	[Language] [nvarchar](max) NOT NULL,
	[Subtitles] [bit] NOT NULL,
	[Genre] [nvarchar](max) NOT NULL,
	[Age] [nvarchar](max) NOT NULL,
	[RunTime] [datetime] NOT NULL,
	[Director] [nvarchar](max) NOT NULL,
	[Actor] [nvarchar](max) NOT NULL,
	[Imdb] [nvarchar](max) NULL,
	[Trailer] [nvarchar](max) NULL,
	[Site] [nvarchar](max) NULL,
	[ImgUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[StudentTickets] [int] NOT NULL,
	[ElderlyTickets] [int] NOT NULL,
	[ChildTickets] [int] NOT NULL,
	[NormalTickets] [int] NOT NULL,
	[TotalTickets] [int] NOT NULL,
	[PopcornArrangement] [int] NOT NULL,
	[StudentTicketsPrice] [decimal](18, 2) NOT NULL,
	[ChildTicketsPrice] [decimal](18, 2) NOT NULL,
	[ElderlyTicketsPrice] [decimal](18, 2) NOT NULL,
	[NormalTicketsPrice] [decimal](18, 2) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[PopcornArrangementPrice] [decimal](18, 2) NOT NULL,
	[PrintID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Surveys]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Surveys](
	[SurveyID] [int] IDENTITY(1,1) NOT NULL,
	[ScoreQ] [int] NOT NULL,
	[MultipleChoiceQ] [nvarchar](max) NULL,
	[OpenQ] [nvarchar](max) NULL,
	[OpenQIsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Surveys] PRIMARY KEY CLUSTERED 
(
	[SurveyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 31-3-2017 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[HallMovieID] [int] NOT NULL,
	[Type] [nvarchar](max) NULL,
	[Seat] [int] NOT NULL,
	[Row] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_HallID]    Script Date: 31-3-2017 12:32:05 ******/
CREATE NONCLUSTERED INDEX [IX_HallID] ON [dbo].[HallMovies]
(
	[HallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovieID]    Script Date: 31-3-2017 12:32:05 ******/
CREATE NONCLUSTERED INDEX [IX_MovieID] ON [dbo].[HallMovies]
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_HallLayoutID]    Script Date: 31-3-2017 12:32:05 ******/
CREATE NONCLUSTERED INDEX [IX_HallLayoutID] ON [dbo].[Halls]
(
	[HallLayoutID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HallMovies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HallMovies_dbo.Halls_HallID] FOREIGN KEY([HallID])
REFERENCES [dbo].[Halls] ([HallID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HallMovies] CHECK CONSTRAINT [FK_dbo.HallMovies_dbo.Halls_HallID]
GO
ALTER TABLE [dbo].[HallMovies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.HallMovies_dbo.Movies_MovieID] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HallMovies] CHECK CONSTRAINT [FK_dbo.HallMovies_dbo.Movies_MovieID]
GO
ALTER TABLE [dbo].[Halls]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Halls_dbo.HallLayouts_HallLayoutID] FOREIGN KEY([HallLayoutID])
REFERENCES [dbo].[HallLayouts] ([HallLayoutID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Halls] CHECK CONSTRAINT [FK_dbo.Halls_dbo.HallLayouts_HallLayoutID]
GO
USE [master]
GO
ALTER DATABASE [Concrete.BioscoopModel] SET  READ_WRITE 
GO
