USE [master]
GO
/****** Object:  Database [FireDepart]    Script Date: 21.06.2023 9:11:09 ******/
CREATE DATABASE [FireDepart]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FireDepart', FILENAME = N'C:\Users\Максим\FireDepart.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FireDepart_log', FILENAME = N'C:\Users\Максим\FireDepart_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FireDepart] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FireDepart].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FireDepart] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FireDepart] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FireDepart] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FireDepart] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FireDepart] SET ARITHABORT OFF 
GO
ALTER DATABASE [FireDepart] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FireDepart] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FireDepart] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FireDepart] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FireDepart] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FireDepart] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FireDepart] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FireDepart] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FireDepart] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FireDepart] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FireDepart] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FireDepart] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FireDepart] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FireDepart] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FireDepart] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FireDepart] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FireDepart] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FireDepart] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FireDepart] SET  MULTI_USER 
GO
ALTER DATABASE [FireDepart] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FireDepart] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FireDepart] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FireDepart] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FireDepart] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FireDepart] SET QUERY_STORE = OFF
GO
USE [FireDepart]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [FireDepart]
GO
/****** Object:  Table [dbo].[AlignmentFoces]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlignmentFoces](
	[AlignmentFoceId] [int] IDENTITY(1,1) NOT NULL,
	[AlignmentFoceName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_AlignmentFoces] PRIMARY KEY CLUSTERED 
(
	[AlignmentFoceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BarrelTypes]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BarrelTypes](
	[BarrelTypeId] [int] IDENTITY(1,1) NOT NULL,
	[BarrelTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_SteamTypes] PRIMARY KEY CLUSTERED 
(
	[BarrelTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Broadcasts]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Broadcasts](
	[BroadcastId] [int] IDENTITY(1,1) NOT NULL,
	[BroadcastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Broadcasts] PRIMARY KEY CLUSTERED 
(
	[BroadcastId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BurnTypes]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BurnTypes](
	[BurnTypeId] [int] IDENTITY(1,1) NOT NULL,
	[BurnTypeName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_BurnTypes] PRIMARY KEY CLUSTERED 
(
	[BurnTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CombatAreas]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CombatAreas](
	[CombatAreaId] [int] IDENTITY(1,1) NOT NULL,
	[CombatAreaName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CombatAreas] PRIMARY KEY CLUSTERED 
(
	[CombatAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CombatDepForces]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CombatDepForces](
	[CombatDepForceId] [int] IDENTITY(1,1) NOT NULL,
	[CombatDepForceName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_CombatDepForces] PRIMARY KEY CLUSTERED 
(
	[CombatDepForceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartureAreas]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartureAreas](
	[DepartureAreaId] [int] IDENTITY(1,1) NOT NULL,
	[SettlementId] [int] NOT NULL,
	[DepartureAreaName] [nvarchar](200) NULL,
 CONSTRAINT [PK_DepartureAreas] PRIMARY KEY CLUSTERED 
(
	[DepartureAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartureBurns]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartureBurns](
	[DepartureBurnId] [int] IDENTITY(1,1) NOT NULL,
	[DepartureId] [int] NOT NULL,
	[BurnTypeId] [int] NOT NULL,
 CONSTRAINT [PK_DepartureBurns] PRIMARY KEY CLUSTERED 
(
	[DepartureBurnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeparturePositions]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeparturePositions](
	[DeparturePositionId] [int] IDENTITY(1,1) NOT NULL,
	[DepartureId] [int] NOT NULL,
	[PositionTypeId] [int] NOT NULL,
	[DateTimeArrival] [datetime] NOT NULL,
 CONSTRAINT [PK_DeparturePositions] PRIMARY KEY CLUSTERED 
(
	[DeparturePositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departures]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departures](
	[DepartureId] [int] IDENTITY(1,1) NOT NULL,
	[DateTimeDepart] [datetime] NOT NULL,
	[DepartureAreaId] [int] NOT NULL,
	[StreetId] [int] NOT NULL,
	[NumHouse] [nvarchar](10) NULL,
	[NumCorp] [nvarchar](5) NULL,
	[NumAppart] [nvarchar](5) NULL,
	[Landmark] [nvarchar](500) NULL,
	[ApplicantPhone] [nvarchar](17) NULL,
	[AdditionalInfo] [nvarchar](1000) NULL,
	[ExternalSignsInfo] [nvarchar](50) NULL,
	[ExternalSignAddInfo] [nvarchar](500) NULL,
	[ThreatPeopleInfo] [nvarchar](50) NULL,
	[ThreatPeopleCount] [tinyint] NULL,
	[ThreatPeopleAddInfo] [nvarchar](500) NULL,
	[AffectedInfo] [nvarchar](50) NULL,
	[AffectedCount] [tinyint] NULL,
	[AffectedAddInfo] [nvarchar](500) NULL,
	[StatePeopleInfo] [nvarchar](50) NULL,
	[StatePeopleAddInfo] [nvarchar](500) NULL,
	[PeopleLocationInfo] [nvarchar](100) NULL,
	[PeopleLocationAddInfo] [nvarchar](500) NULL,
	[ThreatFireInfo] [nvarchar](100) NULL,
	[ThreatFireAddInfo] [nvarchar](500) NULL,
	[NearbyObjectInfo] [nvarchar](150) NULL,
	[NearbyObjectAddInfo] [nvarchar](500) NULL,
	[PlaceInfo] [nvarchar](50) NULL,
	[PlaceAddInfo] [nvarchar](500) NULL,
	[BarrierInfo] [nvarchar](100) NULL,
	[BarrierAddInfo] [nvarchar](500) NULL,
	[MeetMCSInfo] [nvarchar](50) NULL,
	[MeetMCSAddInfo] [nvarchar](500) NULL,
	[WhyApplicantInfo] [nvarchar](50) NULL,
	[WhyApplicantAddInfo] [nvarchar](500) NULL,
	[FIOApplicant] [nvarchar](100) NULL,
	[IsFireContainment] [bit] NOT NULL,
	[DateTimeFireContainment] [datetime] NULL,
	[IsOpenBurning] [bit] NOT NULL,
	[DateTimeOpenBurn] [datetime] NULL,
	[IsAftermathFire] [bit] NOT NULL,
	[DateTimeAftermath] [datetime] NULL,
	[FireAreaCount] [int] NULL,
	[BarrelCount] [smallint] NULL,
 CONSTRAINT [PK_Departures] PRIMARY KEY CLUSTERED 
(
	[DepartureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartureServices]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartureServices](
	[DepartureServiceId] [int] IDENTITY(1,1) NOT NULL,
	[CountPeople] [smallint] NULL,
	[CountTechnics] [smallint] NULL,
	[ServiceTypeId] [int] NOT NULL,
	[DepartureId] [int] NOT NULL,
	[DateTimeDeparture] [datetime] NOT NULL,
	[DateTimeArrival] [datetime] NULL,
 CONSTRAINT [PK_DepartureServices] PRIMARY KEY CLUSTERED 
(
	[DepartureServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartureSubdivisions]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartureSubdivisions](
	[DepartureSubdivisionId] [int] IDENTITY(1,1) NOT NULL,
	[SubdivisionId] [int] NOT NULL,
	[DepartureId] [int] NOT NULL,
	[DateTimeDeparture] [datetime] NOT NULL,
	[DateTimeArrival] [datetime] NULL,
	[CountPeople] [smallint] NULL,
 CONSTRAINT [PK_DepartureDivisions] PRIMARY KEY CLUSTERED 
(
	[DepartureSubdivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisions](
	[DivisionId] [int] IDENTITY(1,1) NOT NULL,
	[DivisionName] [nvarchar](100) NOT NULL,
	[DivisionDescription] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FireInfo]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FireInfo](
	[FireInfoId] [int] IDENTITY(1,1) NOT NULL,
	[DateTimeEntry] [datetime] NOT NULL,
	[DepartureId] [int] NOT NULL,
	[BroadcastId] [int] NULL,
	[BarrelTypeId] [int] NULL,
	[BarrelCount] [tinyint] NULL,
	[CombatAreaId] [int] NULL,
	[MissionTypeId] [int] NULL,
	[WorkAreaId] [int] NULL,
	[InfoPlace] [nvarchar](4000) NULL,
	[WorkVariety] [nvarchar](4000) NULL,
	[AddInfo] [nvarchar](2000) NULL,
	[FireAreaCount] [int] NULL,
 CONSTRAINT [PK_FireInfo] PRIMARY KEY CLUSTERED 
(
	[FireInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FireInfoSubdivisions]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FireInfoSubdivisions](
	[FireInfoSubdivisionId] [int] IDENTITY(1,1) NOT NULL,
	[FireInfoId] [int] NULL,
	[SubdivisionId] [int] NULL,
 CONSTRAINT [PK_FireInfoSubdivisions] PRIMARY KEY CLUSTERED 
(
	[FireInfoSubdivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MissionTypes]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MissionTypes](
	[MissionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[MissionTypeName] [nvarchar](200) NOT NULL,
	[MissionTypeDescription] [nvarchar](2000) NULL,
 CONSTRAINT [PK_MissionTypes] PRIMARY KEY CLUSTERED 
(
	[MissionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionTypes]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionTypes](
	[PositionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[PositionTypeName] [nvarchar](100) NOT NULL,
	[PositionTypeDescription] [nvarchar](1000) NULL,
 CONSTRAINT [PK_PositionTypes] PRIMARY KEY CLUSTERED 
(
	[PositionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceTypes]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceTypes](
	[ServiceTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceTypeName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ServiceTypes] PRIMARY KEY CLUSTERED 
(
	[ServiceTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settlements]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settlements](
	[SettlementId] [int] IDENTITY(1,1) NOT NULL,
	[SettlementName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Settlements] PRIMARY KEY CLUSTERED 
(
	[SettlementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Streets]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Streets](
	[StreetId] [int] IDENTITY(1,1) NOT NULL,
	[StreetName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Streets] PRIMARY KEY CLUSTERED 
(
	[StreetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subdivisions]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subdivisions](
	[SubdivisionId] [int] IDENTITY(1,1) NOT NULL,
	[DivisionId] [int] NOT NULL,
	[TechnicId] [int] NOT NULL,
	[DepartureAreaId] [int] NOT NULL,
	[FireRank] [tinyint] NOT NULL,
 CONSTRAINT [PK_Subdivisions] PRIMARY KEY CLUSTERED 
(
	[SubdivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechnicDivisions]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnicDivisions](
	[TechnicDivisionId] [int] IDENTITY(1,1) NOT NULL,
	[TechnicId] [int] NOT NULL,
	[DivisionId] [int] NOT NULL,
	[CountTechnic] [smallint] NOT NULL,
 CONSTRAINT [PK_TechnicDivisions] PRIMARY KEY CLUSTERED 
(
	[TechnicDivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Technics]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technics](
	[TechnicId] [int] IDENTITY(1,1) NOT NULL,
	[TechnicName] [nvarchar](200) NOT NULL,
	[TechnicDescription] [nvarchar](1000) NULL,
	[TechnicImage] [varbinary](max) NULL,
 CONSTRAINT [PK_Technics] PRIMARY KEY CLUSTERED 
(
	[TechnicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkAreas]    Script Date: 21.06.2023 9:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkAreas](
	[WorkAreaId] [int] IDENTITY(1,1) NOT NULL,
	[WorkAreaName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_WorkAreas] PRIMARY KEY CLUSTERED 
(
	[WorkAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AlignmentFoces] ON 

INSERT [dbo].[AlignmentFoces] ([AlignmentFoceId], [AlignmentFoceName]) VALUES (1, N'Организую установку дополнительно 1 АЦ на ПГ (ПВ)')
INSERT [dbo].[AlignmentFoces] ([AlignmentFoceId], [AlignmentFoceName]) VALUES (2, N'Отделению организовать дополнительную подачу ствола на тушение пожара в составе звена ГДЗС')
INSERT [dbo].[AlignmentFoces] ([AlignmentFoceId], [AlignmentFoceName]) VALUES (3, N'Отделению организовать дополнительную подачу ствола на защиту в составе звена ГДЗС')
SET IDENTITY_INSERT [dbo].[AlignmentFoces] OFF
GO
SET IDENTITY_INSERT [dbo].[BarrelTypes] ON 

INSERT [dbo].[BarrelTypes] ([BarrelTypeId], [BarrelTypeName]) VALUES (1, N'УРСК-50')
INSERT [dbo].[BarrelTypes] ([BarrelTypeId], [BarrelTypeName]) VALUES (2, N'УРСК-70')
INSERT [dbo].[BarrelTypes] ([BarrelTypeId], [BarrelTypeName]) VALUES (3, N'ПЛС')
INSERT [dbo].[BarrelTypes] ([BarrelTypeId], [BarrelTypeName]) VALUES (4, N'СВД')
INSERT [dbo].[BarrelTypes] ([BarrelTypeId], [BarrelTypeName]) VALUES (5, N'СВП')
INSERT [dbo].[BarrelTypes] ([BarrelTypeId], [BarrelTypeName]) VALUES (6, N'ПУРГА (ГПС)')
SET IDENTITY_INSERT [dbo].[BarrelTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Broadcasts] ON 

INSERT [dbo].[Broadcasts] ([BroadcastId], [BroadcastName]) VALUES (1, N'РТП')
INSERT [dbo].[Broadcasts] ([BroadcastId], [BroadcastName]) VALUES (2, N'ШТАБ')
SET IDENTITY_INSERT [dbo].[Broadcasts] OFF
GO
SET IDENTITY_INSERT [dbo].[BurnTypes] ON 

INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (1, N'Автомобиль')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (1002, N'Балкон')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (1003, N'Гараж')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (1004, N'Дом')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (2002, N'Заброшенный дом')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (2003, N'Лес')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (2004, N'Баня')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (2005, N'Коридор')
INSERT [dbo].[BurnTypes] ([BurnTypeId], [BurnTypeName]) VALUES (2006, N'Кровля')
SET IDENTITY_INSERT [dbo].[BurnTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[CombatAreas] ON 

INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (1, N'БУ-1')
INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (2, N'БУ-2')
INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (3, N'БУ-3')
INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (4, N'БУ-4')
INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (5, N'БУ-5')
INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (6, N'БУ-6')
INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (7, N'БУ-7')
INSERT [dbo].[CombatAreas] ([CombatAreaId], [CombatAreaName]) VALUES (8, N'БУ-8')
SET IDENTITY_INSERT [dbo].[CombatAreas] OFF
GO
SET IDENTITY_INSERT [dbo].[CombatDepForces] ON 

INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (1, N'Организовать спасение людей')
INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (2, N'Подать стволы на предотвращение взрыва')
INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (3, N'Подать ствол в составе звена ГДЗС на тушение пожара')
INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (4, N'Подать ствол в составе звена ГДЗС на защиту здания (помещения)')
INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (5, N'Подать ствол с применением СИЗОД на тушение')
INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (6, N'Подать ствол с применением СИЗОД на защиту')
INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (7, N'Установить АЦ на ПГ (ПВ)')
INSERT [dbo].[CombatDepForces] ([CombatDepForceId], [CombatDepForceName]) VALUES (8, N'Проложить магистральную линию от ПГ (ПВ)')
SET IDENTITY_INSERT [dbo].[CombatDepForces] OFF
GO
SET IDENTITY_INSERT [dbo].[DepartureAreas] ON 

INSERT [dbo].[DepartureAreas] ([DepartureAreaId], [SettlementId], [DepartureAreaName]) VALUES (1, 2, N'Зеленодольск')
INSERT [dbo].[DepartureAreas] ([DepartureAreaId], [SettlementId], [DepartureAreaName]) VALUES (2, 2, N'Завод А.М.Горького')
INSERT [dbo].[DepartureAreas] ([DepartureAreaId], [SettlementId], [DepartureAreaName]) VALUES (3, 1, N'Айша')
INSERT [dbo].[DepartureAreas] ([DepartureAreaId], [SettlementId], [DepartureAreaName]) VALUES (2004, 2002, N'Васильево')
INSERT [dbo].[DepartureAreas] ([DepartureAreaId], [SettlementId], [DepartureAreaName]) VALUES (3006, 2002, N'Тест')
SET IDENTITY_INSERT [dbo].[DepartureAreas] OFF
GO
SET IDENTITY_INSERT [dbo].[DepartureBurns] ON 

INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (1063, 3, 1)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (1064, 3, 1002)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (1065, 3, 1004)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (2065, 4, 2002)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (2066, 4, 2003)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (7068, 1004, 2004)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (7069, 1004, 2006)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (9093, 1, 1002)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (9094, 1, 1003)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (9095, 1, 1004)
INSERT [dbo].[DepartureBurns] ([DepartureBurnId], [DepartureId], [BurnTypeId]) VALUES (10075, 2, 1)
SET IDENTITY_INSERT [dbo].[DepartureBurns] OFF
GO
SET IDENTITY_INSERT [dbo].[DeparturePositions] ON 

INSERT [dbo].[DeparturePositions] ([DeparturePositionId], [DepartureId], [PositionTypeId], [DateTimeArrival]) VALUES (1059, 3, 3, CAST(N'2023-06-03T23:39:17.277' AS DateTime))
INSERT [dbo].[DeparturePositions] ([DeparturePositionId], [DepartureId], [PositionTypeId], [DateTimeArrival]) VALUES (2058, 4, 1, CAST(N'2023-06-05T10:16:51.213' AS DateTime))
INSERT [dbo].[DeparturePositions] ([DeparturePositionId], [DepartureId], [PositionTypeId], [DateTimeArrival]) VALUES (2059, 4, 3, CAST(N'2023-06-05T10:16:48.343' AS DateTime))
INSERT [dbo].[DeparturePositions] ([DeparturePositionId], [DepartureId], [PositionTypeId], [DateTimeArrival]) VALUES (7060, 1004, 1, CAST(N'2023-06-16T10:13:10.227' AS DateTime))
INSERT [dbo].[DeparturePositions] ([DeparturePositionId], [DepartureId], [PositionTypeId], [DateTimeArrival]) VALUES (9068, 1, 3, CAST(N'2023-06-05T08:55:22.370' AS DateTime))
INSERT [dbo].[DeparturePositions] ([DeparturePositionId], [DepartureId], [PositionTypeId], [DateTimeArrival]) VALUES (10062, 4006, 2, CAST(N'2023-06-20T12:28:29.677' AS DateTime))
INSERT [dbo].[DeparturePositions] ([DeparturePositionId], [DepartureId], [PositionTypeId], [DateTimeArrival]) VALUES (11062, 2, 1, CAST(N'2023-06-21T02:56:52.703' AS DateTime))
SET IDENTITY_INSERT [dbo].[DeparturePositions] OFF
GO
SET IDENTITY_INSERT [dbo].[Departures] ON 

INSERT [dbo].[Departures] ([DepartureId], [DateTimeDepart], [DepartureAreaId], [StreetId], [NumHouse], [NumCorp], [NumAppart], [Landmark], [ApplicantPhone], [AdditionalInfo], [ExternalSignsInfo], [ExternalSignAddInfo], [ThreatPeopleInfo], [ThreatPeopleCount], [ThreatPeopleAddInfo], [AffectedInfo], [AffectedCount], [AffectedAddInfo], [StatePeopleInfo], [StatePeopleAddInfo], [PeopleLocationInfo], [PeopleLocationAddInfo], [ThreatFireInfo], [ThreatFireAddInfo], [NearbyObjectInfo], [NearbyObjectAddInfo], [PlaceInfo], [PlaceAddInfo], [BarrierInfo], [BarrierAddInfo], [MeetMCSInfo], [MeetMCSAddInfo], [WhyApplicantInfo], [WhyApplicantAddInfo], [FIOApplicant], [IsFireContainment], [DateTimeFireContainment], [IsOpenBurning], [DateTimeOpenBurn], [IsAftermathFire], [DateTimeAftermath], [FireAreaCount], [BarrelCount]) VALUES (1, CAST(N'2023-06-14T18:48:16.930' AS DateTime), 2, 1, N'1', NULL, N'74', N'Около детского сада', N'89019301341', N'Какая-то доп информация', N'Сильное выделение дыма', N'1', N'Имеется угроза людям', 3, N'2', N'Пострадавших нет', 11, N'3', N'Не знаю,Без сознания,', N'4', NULL, NULL, N'Имеется', N'5', N'Социально - значимые,С массовым пребыванием,Производственные,Социально - значимых объектов рядом нет,', N'6', N'На объекте', N'7', N'Есть', N'8', N'Нет', N'9', N'Арендатор', N'10', N'Иванов Иван Иванович', 1, CAST(N'2023-06-04T23:22:51.627' AS DateTime), 1, CAST(N'2023-06-09T16:02:04.623' AS DateTime), 1, CAST(N'2023-06-04T23:25:00.000' AS DateTime), 15, 8)
INSERT [dbo].[Departures] ([DepartureId], [DateTimeDepart], [DepartureAreaId], [StreetId], [NumHouse], [NumCorp], [NumAppart], [Landmark], [ApplicantPhone], [AdditionalInfo], [ExternalSignsInfo], [ExternalSignAddInfo], [ThreatPeopleInfo], [ThreatPeopleCount], [ThreatPeopleAddInfo], [AffectedInfo], [AffectedCount], [AffectedAddInfo], [StatePeopleInfo], [StatePeopleAddInfo], [PeopleLocationInfo], [PeopleLocationAddInfo], [ThreatFireInfo], [ThreatFireAddInfo], [NearbyObjectInfo], [NearbyObjectAddInfo], [PlaceInfo], [PlaceAddInfo], [BarrierInfo], [BarrierAddInfo], [MeetMCSInfo], [MeetMCSAddInfo], [WhyApplicantInfo], [WhyApplicantAddInfo], [FIOApplicant], [IsFireContainment], [DateTimeFireContainment], [IsOpenBurning], [DateTimeOpenBurn], [IsAftermathFire], [DateTimeAftermath], [FireAreaCount], [BarrelCount]) VALUES (2, CAST(N'2023-06-04T22:13:54.150' AS DateTime), 2004, 1, N'ввв', NULL, N'ааа', NULL, N'пппп', N'4444', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 0, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[Departures] ([DepartureId], [DateTimeDepart], [DepartureAreaId], [StreetId], [NumHouse], [NumCorp], [NumAppart], [Landmark], [ApplicantPhone], [AdditionalInfo], [ExternalSignsInfo], [ExternalSignAddInfo], [ThreatPeopleInfo], [ThreatPeopleCount], [ThreatPeopleAddInfo], [AffectedInfo], [AffectedCount], [AffectedAddInfo], [StatePeopleInfo], [StatePeopleAddInfo], [PeopleLocationInfo], [PeopleLocationAddInfo], [ThreatFireInfo], [ThreatFireAddInfo], [NearbyObjectInfo], [NearbyObjectAddInfo], [PlaceInfo], [PlaceAddInfo], [BarrierInfo], [BarrierAddInfo], [MeetMCSInfo], [MeetMCSAddInfo], [WhyApplicantInfo], [WhyApplicantAddInfo], [FIOApplicant], [IsFireContainment], [DateTimeFireContainment], [IsOpenBurning], [DateTimeOpenBurn], [IsAftermathFire], [DateTimeAftermath], [FireAreaCount], [BarrelCount]) VALUES (3, CAST(N'2023-06-05T00:39:54.233' AS DateTime), 3, 2, N'55', NULL, N'555', NULL, N'3333', N'777', N'Вырывающиеся языки пламени', NULL, NULL, NULL, NULL, N'Пострадавших нет', NULL, NULL, NULL, NULL, NULL, NULL, N'Не знаю', NULL, N'Рядом объектов нет,', NULL, N'Рядом с объектом', NULL, N'Шлагбаум', NULL, N'Нет', NULL, N'Очевидец', NULL, NULL, 0, NULL, 0, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[Departures] ([DepartureId], [DateTimeDepart], [DepartureAreaId], [StreetId], [NumHouse], [NumCorp], [NumAppart], [Landmark], [ApplicantPhone], [AdditionalInfo], [ExternalSignsInfo], [ExternalSignAddInfo], [ThreatPeopleInfo], [ThreatPeopleCount], [ThreatPeopleAddInfo], [AffectedInfo], [AffectedCount], [AffectedAddInfo], [StatePeopleInfo], [StatePeopleAddInfo], [PeopleLocationInfo], [PeopleLocationAddInfo], [ThreatFireInfo], [ThreatFireAddInfo], [NearbyObjectInfo], [NearbyObjectAddInfo], [PlaceInfo], [PlaceAddInfo], [BarrierInfo], [BarrierAddInfo], [MeetMCSInfo], [MeetMCSAddInfo], [WhyApplicantInfo], [WhyApplicantAddInfo], [FIOApplicant], [IsFireContainment], [DateTimeFireContainment], [IsOpenBurning], [DateTimeOpenBurn], [IsAftermathFire], [DateTimeAftermath], [FireAreaCount], [BarrelCount]) VALUES (4, CAST(N'2023-06-05T10:05:46.220' AS DateTime), 3006, 2, N'5', NULL, N'45', N'Около больницы', N'89049010329', N'п', N'Вырывающиеся языки пламени', N'1', N'Имеется угроза людям', 5, N'2', N'Да, в количестве', 3, N'3', N'Получили ожоги,', N'4', N'Самостоятельно эвакуируются,', N'5', N'Имеется', N'6', N'Социально - значимые,Производственные,', N'7', N'На объекте', N'8', N'Котлованы', N'9', N'Имеется', N'10', N'Очевидец', N'11', N'Иванов Петр Сергеевич', 1, CAST(N'2023-06-05T10:13:59.760' AS DateTime), 1, CAST(N'2023-06-04T21:12:00.000' AS DateTime), 1, CAST(N'2023-06-08T02:06:00.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Departures] ([DepartureId], [DateTimeDepart], [DepartureAreaId], [StreetId], [NumHouse], [NumCorp], [NumAppart], [Landmark], [ApplicantPhone], [AdditionalInfo], [ExternalSignsInfo], [ExternalSignAddInfo], [ThreatPeopleInfo], [ThreatPeopleCount], [ThreatPeopleAddInfo], [AffectedInfo], [AffectedCount], [AffectedAddInfo], [StatePeopleInfo], [StatePeopleAddInfo], [PeopleLocationInfo], [PeopleLocationAddInfo], [ThreatFireInfo], [ThreatFireAddInfo], [NearbyObjectInfo], [NearbyObjectAddInfo], [PlaceInfo], [PlaceAddInfo], [BarrierInfo], [BarrierAddInfo], [MeetMCSInfo], [MeetMCSAddInfo], [WhyApplicantInfo], [WhyApplicantAddInfo], [FIOApplicant], [IsFireContainment], [DateTimeFireContainment], [IsOpenBurning], [DateTimeOpenBurn], [IsAftermathFire], [DateTimeAftermath], [FireAreaCount], [BarrelCount]) VALUES (1004, CAST(N'2023-06-16T10:11:37.690' AS DateTime), 3, 1, N'44', N'22', N'11', N'1', N'44444', NULL, N'Вырывающиеся языки пламени', NULL, N'Имеется угроза людям', 3, NULL, N'Да, в количестве', NULL, NULL, N'Получили ожоги,', NULL, N'В зоне воздействия,', NULL, N'Не знаю', NULL, N'Социально - значимые,', NULL, N'На объекте', NULL, N'Есть', NULL, N'Имеется', NULL, N'Собственник', NULL, N'Max', 0, NULL, 1, CAST(N'2023-06-16T10:13:17.730' AS DateTime), 0, NULL, NULL, NULL)
INSERT [dbo].[Departures] ([DepartureId], [DateTimeDepart], [DepartureAreaId], [StreetId], [NumHouse], [NumCorp], [NumAppart], [Landmark], [ApplicantPhone], [AdditionalInfo], [ExternalSignsInfo], [ExternalSignAddInfo], [ThreatPeopleInfo], [ThreatPeopleCount], [ThreatPeopleAddInfo], [AffectedInfo], [AffectedCount], [AffectedAddInfo], [StatePeopleInfo], [StatePeopleAddInfo], [PeopleLocationInfo], [PeopleLocationAddInfo], [ThreatFireInfo], [ThreatFireAddInfo], [NearbyObjectInfo], [NearbyObjectAddInfo], [PlaceInfo], [PlaceAddInfo], [BarrierInfo], [BarrierAddInfo], [MeetMCSInfo], [MeetMCSAddInfo], [WhyApplicantInfo], [WhyApplicantAddInfo], [FIOApplicant], [IsFireContainment], [DateTimeFireContainment], [IsOpenBurning], [DateTimeOpenBurn], [IsAftermathFire], [DateTimeAftermath], [FireAreaCount], [BarrelCount]) VALUES (4006, CAST(N'2023-06-20T12:27:47.717' AS DateTime), 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Имеется', NULL, N'Производственные,', NULL, N'Рядом с объектом', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 1, CAST(N'2023-06-20T12:28:51.940' AS DateTime), 0, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Departures] OFF
GO
SET IDENTITY_INSERT [dbo].[DepartureServices] ON 

INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (1032, 1, 1, 1, 3, CAST(N'2023-06-03T23:39:12.607' AS DateTime), CAST(N'2023-06-03T23:39:13.313' AS DateTime))
INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (2034, 4, 2, 1, 4, CAST(N'2023-06-05T10:12:35.247' AS DateTime), CAST(N'2023-06-05T10:12:38.263' AS DateTime))
INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (2035, 2, 1, 2, 4, CAST(N'2023-06-05T10:12:48.723' AS DateTime), CAST(N'2023-06-05T10:12:49.573' AS DateTime))
INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (7036, 4, 1, 1009, 1004, CAST(N'2023-06-16T10:12:54.697' AS DateTime), CAST(N'2023-06-16T10:12:56.473' AS DateTime))
INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (9053, 20, 10, 2, 1, CAST(N'2023-06-03T23:16:50.440' AS DateTime), CAST(N'2023-06-03T23:16:51.080' AS DateTime))
INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (9054, 1, 1, 1011, 1, CAST(N'2023-06-09T11:41:18.260' AS DateTime), CAST(N'2023-06-09T11:41:19.330' AS DateTime))
INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (10041, 1, 1, 1006, 4006, CAST(N'2023-06-20T12:28:16.410' AS DateTime), CAST(N'2023-06-20T12:28:17.820' AS DateTime))
INSERT [dbo].[DepartureServices] ([DepartureServiceId], [CountPeople], [CountTechnics], [ServiceTypeId], [DepartureId], [DateTimeDeparture], [DateTimeArrival]) VALUES (11041, 1, 1, 1, 2, CAST(N'2023-06-03T23:42:40.087' AS DateTime), CAST(N'2023-06-21T02:54:37.503' AS DateTime))
SET IDENTITY_INSERT [dbo].[DepartureServices] OFF
GO
SET IDENTITY_INSERT [dbo].[DepartureSubdivisions] ON 

INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (1124, 21, 3, CAST(N'2023-06-03T23:39:04.457' AS DateTime), CAST(N'2023-06-03T23:39:06.567' AS DateTime), 41)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (1125, 22, 3, CAST(N'2023-06-03T23:39:04.457' AS DateTime), CAST(N'2023-06-03T23:39:06.567' AS DateTime), 22)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (2129, 1014, 4, CAST(N'2023-06-05T10:11:50.310' AS DateTime), CAST(N'2023-06-05T10:11:54.287' AS DateTime), 4)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (2130, 1015, 4, CAST(N'2023-06-05T10:11:51.087' AS DateTime), CAST(N'2023-06-05T10:11:56.360' AS DateTime), 3)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (2131, 1016, 4, CAST(N'2023-06-05T10:12:06.620' AS DateTime), CAST(N'2023-06-05T10:12:07.270' AS DateTime), 5)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (2132, 1018, 4, CAST(N'2023-06-05T10:12:18.717' AS DateTime), CAST(N'2023-06-05T10:12:19.223' AS DateTime), 3)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (2133, 1020, 4, CAST(N'2023-06-05T10:12:15.630' AS DateTime), CAST(N'2023-06-05T10:12:16.270' AS DateTime), 2)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (7129, 21, 1004, CAST(N'2023-06-16T10:12:33.067' AS DateTime), CAST(N'2023-06-16T10:12:33.610' AS DateTime), 5)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (7130, 22, 1004, CAST(N'2023-06-16T10:12:32.527' AS DateTime), CAST(N'2023-06-16T10:12:34.090' AS DateTime), 4)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (7131, 23, 1004, CAST(N'2023-06-16T10:12:45.330' AS DateTime), CAST(N'2023-06-16T10:12:45.793' AS DateTime), 2)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (9144, 8, 1, CAST(N'2023-06-09T16:01:24.343' AS DateTime), CAST(N'2023-06-09T16:01:25.020' AS DateTime), 5)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (9145, 9, 1, CAST(N'2023-06-09T16:01:36.090' AS DateTime), CAST(N'2023-06-09T16:01:36.643' AS DateTime), 2)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (10132, 12, 4006, CAST(N'2023-06-20T12:28:10.613' AS DateTime), CAST(N'2023-06-20T12:28:11.163' AS DateTime), 1)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (11132, 14, 2, CAST(N'2023-06-04T22:14:07.523' AS DateTime), CAST(N'2023-06-04T22:14:08.460' AS DateTime), 5)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (11133, 15, 2, CAST(N'2023-06-04T22:14:07.833' AS DateTime), CAST(N'2023-06-04T22:14:08.770' AS DateTime), 6)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (11134, 16, 2, CAST(N'2023-06-04T22:14:00.730' AS DateTime), CAST(N'2023-06-04T22:14:01.140' AS DateTime), 2)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (11135, 17, 2, CAST(N'2023-06-04T22:13:59.913' AS DateTime), CAST(N'2023-06-04T22:14:01.553' AS DateTime), 2)
INSERT [dbo].[DepartureSubdivisions] ([DepartureSubdivisionId], [SubdivisionId], [DepartureId], [DateTimeDeparture], [DateTimeArrival], [CountPeople]) VALUES (11136, 19, 2, CAST(N'2023-06-04T22:13:59.203' AS DateTime), CAST(N'2023-06-21T02:53:50.017' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[DepartureSubdivisions] OFF
GO
SET IDENTITY_INSERT [dbo].[Divisions] ON 

INSERT [dbo].[Divisions] ([DivisionId], [DivisionName], [DivisionDescription]) VALUES (1, N'ПСЧ - 53', N'test2')
INSERT [dbo].[Divisions] ([DivisionId], [DivisionName], [DivisionDescription]) VALUES (1002, N'ПСЧ - 34', N'dd')
INSERT [dbo].[Divisions] ([DivisionId], [DivisionName], [DivisionDescription]) VALUES (2002, N'ПСЧ - 72', N'1')
INSERT [dbo].[Divisions] ([DivisionId], [DivisionName], [DivisionDescription]) VALUES (2004, N'ПСЧ - 89', NULL)
SET IDENTITY_INSERT [dbo].[Divisions] OFF
GO
SET IDENTITY_INSERT [dbo].[FireInfo] ON 

INSERT [dbo].[FireInfo] ([FireInfoId], [DateTimeEntry], [DepartureId], [BroadcastId], [BarrelTypeId], [BarrelCount], [CombatAreaId], [MissionTypeId], [WorkAreaId], [InfoPlace], [WorkVariety], [AddInfo], [FireAreaCount]) VALUES (1, CAST(N'2023-06-12T19:56:58.993' AS DateTime), 1, 2, 1, 3, 2, 1, 2, N'По результатам разведки места пожара - Расстановка прибывающих сил и средств', N'Организовать спасение людей, Подать ствол в составе звена ГДЗС на тушение пожара, Отделению организовать дополнительную подачу ствола на тушение пожара в составе звена ГДЗС', N'1', NULL)
INSERT [dbo].[FireInfo] ([FireInfoId], [DateTimeEntry], [DepartureId], [BroadcastId], [BarrelTypeId], [BarrelCount], [CombatAreaId], [MissionTypeId], [WorkAreaId], [InfoPlace], [WorkVariety], [AddInfo], [FireAreaCount]) VALUES (2, CAST(N'2023-06-16T10:13:30.260' AS DateTime), 1004, 1, 3, 5, 1, 1, 2, N'Силам, следующим к месту пожара', N'Отбой, возвращайтесь в часть', N'0', NULL)
INSERT [dbo].[FireInfo] ([FireInfoId], [DateTimeEntry], [DepartureId], [BroadcastId], [BarrelTypeId], [BarrelCount], [CombatAreaId], [MissionTypeId], [WorkAreaId], [InfoPlace], [WorkVariety], [AddInfo], [FireAreaCount]) VALUES (5, CAST(N'2023-06-16T10:15:05.987' AS DateTime), 1004, 1, NULL, NULL, NULL, NULL, NULL, N'Продолжить движение к месту пожара', N'', NULL, NULL)
INSERT [dbo].[FireInfo] ([FireInfoId], [DateTimeEntry], [DepartureId], [BroadcastId], [BarrelTypeId], [BarrelCount], [CombatAreaId], [MissionTypeId], [WorkAreaId], [InfoPlace], [WorkVariety], [AddInfo], [FireAreaCount]) VALUES (6, CAST(N'2023-06-16T10:15:47.220' AS DateTime), 1004, 1, NULL, NULL, NULL, 2, NULL, N'Запрос уточняющей информации с места пожара', N'', NULL, NULL)
INSERT [dbo].[FireInfo] ([FireInfoId], [DateTimeEntry], [DepartureId], [BroadcastId], [BarrelTypeId], [BarrelCount], [CombatAreaId], [MissionTypeId], [WorkAreaId], [InfoPlace], [WorkVariety], [AddInfo], [FireAreaCount]) VALUES (11, CAST(N'2023-06-17T21:47:03.503' AS DateTime), 1, 2, 2, 5, 8, 1, 2, N'По результатам разведки места пожара - Характеристика здания (объекта) уточненная - Объект пожара: Здания, помещения здравоохранения и социального обслуживания населения - Учреждение социального обслуживания населения со стационаром (попечительское учреждение, дом-интернат для престарелых и инвалидов, психоневрологический интернат, геронтологический центр и др.), этажность здания: 2, степень огнестойкости: 1, наружные стены: кирпичные, обшивка здания: фанера (OSB) плита, перекрытие: железобетонное, кровля: металлическая односкатная, обрешетка кровли (основание): деревянная, наличие подвала: имеется, наличие чердачного помещения: имеется, геометрические размеры в плане: 44 х 22, здание газифицировно: да, здание электрифицировано: да, отопление: отопление отсутствует, доп. инф-ция: ffffff', N'', N'7', NULL)
INSERT [dbo].[FireInfo] ([FireInfoId], [DateTimeEntry], [DepartureId], [BroadcastId], [BarrelTypeId], [BarrelCount], [CombatAreaId], [MissionTypeId], [WorkAreaId], [InfoPlace], [WorkVariety], [AddInfo], [FireAreaCount]) VALUES (1014, CAST(N'2023-06-18T19:36:54.413' AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, N'По результатам разведки места пожара - Площадь пожара: 15 м2', N'', NULL, 15)
SET IDENTITY_INSERT [dbo].[FireInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[FireInfoSubdivisions] ON 

INSERT [dbo].[FireInfoSubdivisions] ([FireInfoSubdivisionId], [FireInfoId], [SubdivisionId]) VALUES (1014, 1, 8)
INSERT [dbo].[FireInfoSubdivisions] ([FireInfoSubdivisionId], [FireInfoId], [SubdivisionId]) VALUES (2014, 11, 8)
INSERT [dbo].[FireInfoSubdivisions] ([FireInfoSubdivisionId], [FireInfoId], [SubdivisionId]) VALUES (2015, 11, 9)
SET IDENTITY_INSERT [dbo].[FireInfoSubdivisions] OFF
GO
SET IDENTITY_INSERT [dbo].[MissionTypes] ON 

INSERT [dbo].[MissionTypes] ([MissionTypeId], [MissionTypeName], [MissionTypeDescription]) VALUES (1, N'Поиск и спасение людей', NULL)
INSERT [dbo].[MissionTypes] ([MissionTypeId], [MissionTypeName], [MissionTypeDescription]) VALUES (2, N'Тушение пожара', NULL)
INSERT [dbo].[MissionTypes] ([MissionTypeId], [MissionTypeName], [MissionTypeDescription]) VALUES (3, N'Защита конструкций и помещений', NULL)
SET IDENTITY_INSERT [dbo].[MissionTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[PositionTypes] ON 

INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (1, N'801 (НО)', N'')
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (2, N'802 (ЗНО)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3, N'804 (Н СПТ)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3002, N'805 (СПТ)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3003, N'653 (НЧ ПСЧ-53)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3004, N'753 (ЗНЧ ПСЧ-53)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3005, N'634 (НЧ ПСЧ-34)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3006, N'734 (ЗНЧ ПСЧ-34)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3007, N'934 (ОП ПСЧ-34)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3008, N'53 (ОНД)', NULL)
INSERT [dbo].[PositionTypes] ([PositionTypeId], [PositionTypeName], [PositionTypeDescription]) VALUES (3009, N'652 (НЧ ПСЧ-52)', NULL)
SET IDENTITY_INSERT [dbo].[PositionTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceTypes] ON 

INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1, N'МВД')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (2, N'ФСБ')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1002, N'Газовая служба')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1003, N'Служба водоканала')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1004, N'Минлесхоз (ПХС)')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1005, N'Энергослужба')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1006, N'Аварийная ЖКХ')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1007, N'Тепловые сети')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1008, N'Администрация')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1009, N'Скорая помощь')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1010, N'Следственный комитет')
INSERT [dbo].[ServiceTypes] ([ServiceTypeId], [ServiceTypeName]) VALUES (1011, N'Прокуратура')
SET IDENTITY_INSERT [dbo].[ServiceTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Settlements] ON 

INSERT [dbo].[Settlements] ([SettlementId], [SettlementName]) VALUES (1, N'Айша')
INSERT [dbo].[Settlements] ([SettlementId], [SettlementName]) VALUES (2, N'Зеленодольск')
INSERT [dbo].[Settlements] ([SettlementId], [SettlementName]) VALUES (2002, N'Васильево')
SET IDENTITY_INSERT [dbo].[Settlements] OFF
GO
SET IDENTITY_INSERT [dbo].[Streets] ON 

INSERT [dbo].[Streets] ([StreetId], [StreetName]) VALUES (1, N'Ленина')
INSERT [dbo].[Streets] ([StreetId], [StreetName]) VALUES (2, N'Энгельса')
INSERT [dbo].[Streets] ([StreetId], [StreetName]) VALUES (3, N'Тургенева')
SET IDENTITY_INSERT [dbo].[Streets] OFF
GO
SET IDENTITY_INSERT [dbo].[Subdivisions] ON 

INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (2, 2004, 1, 1, 2)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (4, 1002, 3, 1, 6)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (5, 2002, 1002, 1, 5)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (8, 1, 1, 2, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (9, 2002, 1003, 2, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (10, 1, 1, 2, 2)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (11, 1, 1, 1, 3)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (12, 2002, 1002, 1, 4)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (13, 2002, 1, 1, 2)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (14, 1, 1, 2004, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (15, 1, 1, 2004, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (16, 1, 1, 2004, 2)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (17, 2002, 3, 2004, 3)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (18, 2004, 1, 2004, 4)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (19, 2002, 1003, 2004, 5)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (20, 1002, 3, 2004, 6)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (21, 1, 1, 3, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (22, 2002, 1, 3, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (23, 2002, 3, 3, 2)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (24, 2004, 1, 3, 3)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (25, 1, 1, 3, 4)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (26, 2002, 1002, 3, 5)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (27, 2004, 1, 3, 6)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1014, 1, 1, 3006, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1015, 1, 1, 3006, 1)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1016, 1002, 3, 3006, 2)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1017, 1002, 1, 3006, 3)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1018, 2004, 1002, 3006, 3)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1019, 2002, 1003, 3006, 4)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1020, 2002, 1, 3006, 4)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1021, 2004, 1, 3006, 5)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1022, 1002, 3, 3006, 6)
INSERT [dbo].[Subdivisions] ([SubdivisionId], [DivisionId], [TechnicId], [DepartureAreaId], [FireRank]) VALUES (1023, 2004, 1, 3006, 6)
SET IDENTITY_INSERT [dbo].[Subdivisions] OFF
GO
SET IDENTITY_INSERT [dbo].[TechnicDivisions] ON 

INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2023, 1, 1, 3)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2024, 1, 1002, 7)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2025, 3, 1002, 2)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2026, 1, 2002, 1)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2027, 3, 2002, 55)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2028, 1002, 2002, 1)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2029, 1003, 2002, 1)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2030, 1, 2004, 1)
INSERT [dbo].[TechnicDivisions] ([TechnicDivisionId], [TechnicId], [DivisionId], [CountTechnic]) VALUES (2031, 1002, 2004, 1)
SET IDENTITY_INSERT [dbo].[TechnicDivisions] OFF
GO
SET IDENTITY_INSERT [dbo].[Technics] ON 

INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (1, N'АЦЛ', N'тест', NULL)
INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (3, N'АР', N'444', 0x89504E470D0A1A0A0000000D4948445200000080000000800806000000C33E61CB0000000473424954080808087C08648800000009704859730000251E0000251E01A4FBD8A00000001974455874536F667477617265007777772E696E6B73636170652E6F72679BEE3C1A00000F7449444154789CED9D799015C519C07F0B2C87DC780B8A510E358A57B0BC228AB7468346CAA3F088071A8D48450D318965C523264483898962625031314113AD7810232A870645A2250808468DA21115010516D8658FFCF1CDAB9D9DD733DD33AFFBCDACF4AFEAABDAF7B6CF997E7D7CFDF5D7E0F1783C1E8FC7E3F1783C1E8FC7E3F1783C1E8FE7CB4C4DDE0570C00EC031C041C02E40F70AD3AB03DE07E603CF021F57989EC7011D81D1C02CA0096871248DC0F3C019419EED1EDB3D402DB01FD03B63FC66E05DE0BD14718E077E050CCD9867569601E38067AA9C6F61190BACC4CE2FED2960574D7EB5C05D96F2AB447E1394658BE62AEC3FD877817E31F9D5008F3AC833AB3CC297733E65443F603D6E1EEC5D31795EE128BF4AE4B2D44FAE0074B290C691543ED38E63143053F1FD3847F955C2786095A5B43621AB8F35C80A64B5A574CBB0D16D8D011EB4908E279ECF8045C82A672630175991148253C8BFFBDDD2E413601230CCE0FD38632FE021DCAEBBBD244B33B2623A54F3AEACB23DFEC51751A601FD13DE9B1546019FE65C512FF1B216B830F6ED554037E0DE0254D08B993C88C595590F6046012AE5259DBC026CAB789FA9D806F877012AE3259BBC09EC54F6564324E901FA00FF4266FB697913E935E6229B26CB8175C0E60C696D89D4023D91EDECA1C82CFF38608F0C69BD018C40944AC674409617695ADB46E06E6437D0E386FD9167BC8974EF660E311B56713DC04DC08F0D0BD5024C05AE03562484DB0AE8629866163600F50ED30FD305A98F2BEA91FAC4B113702B702EE6DADCDB816B4C029E8828184C5AD647C0D18A34B6062E41F4054B8106C3F4B2C81CE04CAABB255B1BE439C7623DA2D2803CBB3F0117A3DE193D06F9D199A4D78CBCDB44BA006F1B26381F31BF0AD31F592ED63B7C30A5CA3C04ECABAB90A27E43800391867B6A204707DF0D063AA74C73DFA02CA63F9AACB209F81DE593BA1D309FA8BF87A6E7BACE30A11790494A89CEC0CDC80E96CB87D0824C2E0F48AA444037E4C5DE0C4C471A76A341FA8D41D8A790A1F0E8202D1D07529DE5721D70236D7BBC9E98F746B7C455A03F3253D725B000592194D806985D858A2F074E8A2B7C406FE022E039D24F9492642362107A21D04B538693800FAAF03C6622CFBE441F60A141BC3A449D5FC62483C86B912EB4C4EE88E58EEBCA4E21D9CEF020A41BDE5085B26C40C6E5E109E5E90DDC5785B2BC03EC16CA7777E0738378B7460BDC0B79B9BA88E745E22C765CC135C876731C2310A34CD70F3A4E9E06BE9E50BE53833AB82CC322DAF64AE71BC4F99CC8B0F66D8348B3695D7264D113A49565C45BFAF647969E79BDF8A83C41BC11EB1EC05B55C8BF43905F0D66F381B3C285FCA74184704B37696595C80CA0AFE261764226AAD5986CA695F5C00F509BD9F5C5FD04F1DC507E4718847FB214B83BFA09D3DC50E25D113B355715998E5A613400B7EB6E5B321BF5BE7C67E03187F97E40DB6EFD254DF8BAD2733EC120F1B1A184C73BACC4DF51AFC34FC0DE99836AC8A7C88195289D81C71DE63B3E94D7A506E14780A87C930235D176B9B1C451E19F44FDF22FC26CFD9E54FE579155CEC5C8503610E9963B06D237F8EE8820CCA4204E25564F9B511B6774467A3917CF7071289FEDD02BA77E0872A82129D0EBA144873A2AF812D4CBBCEB0C2A11F7D29F412C96E30E9798D00F195B6790AD313423F382283D315BB36791C1A17C1668C24E0551E926059A124AF01207055E49DBB56C89EB33A455879C13DC45915EA5EC02FC9A6CBA86EB15E9ED86987BDB7E9E9784F298A2093B0FF49B09134209DE61B9B04DC048C5C3B92C433A93916ECF35DB233AF9B43DC2A58AB446664847277784D29FA009BB1CF44BAAF038A61B2ED2CAED8A87721AE9C6FC858826D0946EC0DEC051C03702392AF8CE44E75FE260C4D8C2B49C8DC03715E9DC9E220D13F96B28ED8B3461D780BE059E194AF01F160BBA94F2076EAACA2CC954F4FBF2BD9171FC7E44759A34A7680AC2DC1FC4D11D73EF8A0C39A6E58DAAD2099EC1D21469E8247C5C7DB4266C2306099E114AD096DAB509F90585E982CCBC4DE2C7CDB0C30C07FE8C6CE4642DE7C6208D24BD3FC8B86BDA6BCDA75CCF7130F68682E742E99E6E103E9706F080E221DE66187703A2638F636FCC349B61D98478FEF83D700FA2B0F95F24CCD3C05713F21D8579639BA8886F4BB55DF806504FF9AC7F6FCCAC861A8093150F0F647DFD33C374C23205B16052311C69ACA55F674390479CD1C8C948EFA4CB7333E5C62C03B0B39B59F806F0CB48C56B80170DE235D356DF1D6657644993B62C8FC5A417E520DA6E7BCF4314472A2EC04C77F102E5F67CA6BDA0B5065013FC91C4685A67963B926EA6AC6205D25596381BD9CBD7711B70ADE2FB6148F7BC6386B29C42685344C34E4843FD4AF07905A2A25EA8083B89B66AD938CE06FE12FADC158D1DBF011B6935CE3D1DF89B2E429A1EC03635982DA5E6A1EE76F7A7B2FDF6B8E1248E1191F86B823244A94536D074F92FA6751BD705D68700DB9C66907F3DEA031183109F7D957497F7662873742FE46364F91A6508666669A33294C194C23700935FC94D8A78DD48A784899346821DB1143CAB486701EAA1F1568332CC55C4B345A11B80C9C6D20AD48A9EC906714DE573C4BEDE849E881F20553A772BC27747BC79E8CAE0CAC761A11BC02D0679AB267D8763DF06BF097981490E167A91BC97DF0C1CA68867626AAFEAE56C50D80650831C5248CA770D6DCF1E94E2BD6E50E6ACB219D9ABBF1659211C83D4FF17989DC0798DF2A55D2FF4EAEDFFA6787669286C03D8CB20DFC98A782693C6BC45B5E163E25CC3C530A06D002E9720491C651066AAE23BD59050342628BE3371A3A7DA16774E511BC00AC4A831CC10E01037C5B1CA21942F5BE720768249A80ED93A27AF06A0DBBF9F49303E8518E3A82C2E382BF2B905B5C7D330696C1AAC914703E88E6C7C24314BF1DDB1F68BE20C5559750D6000EE5CEEC69247031882DEA94154BFDE03F89A9BE2386138E52FF30D4D9C1ADA1A7456853C1AC0208330CB229FF7C48E63EB6A514BF93C60A941BC2DA201A88E7C855985AC9BC344CDA8DA03D165DD6AF48E9A2A3161CF441E0D4077BEFE0BC577514F24ED015599D76AE244155FCEC9A301F4D0FC7F7D86384544D5D07D03403F96AB7C09B6A7F1BF84CA6995CE4F62D5EF1ECAA301D469FEAFFAB5EBE21491758AEF74BF70551CA7E4D1007495543DA4545E2E0B4274220BBE0100FA71705BCABBC2771C95C525FF897CEE4CDB53D62AB68806F081E6FFB5949B8D9BACA18B4654973108FD5CE67D476589258F06107D302AF68C7CFE901C1E4E052C47CA1CC6C4D1F35B0ECA92481E0DE023F4C380CAB26696FDA238E379C577876BE2AC25D9D7B213F2DA0D5CA4F9BF6A6FFC5117057184CA165FB7DFBF88F21D50E7E4D5006669FEBF1FE5073DA6230696456725723631CC00F457BCE9760B9D905703D055B603704EE4BB46C43143D1994CB9C2E71CF43BA0AA61A32AE46113D80DFD49DA058A785B63E6CF382F5987FAA0A9EE0CC306E458986D0A6B13B811FD99BC61949B49AD42E1E7B640DC42F9FDC1C723A79F93781C3945940B79F4002067FC7579ABBAC5CEC89D4479FFDAA3B204F5F94513E79669CF289A5258B37010858FC9A999E3147187511DCFE0A6B209F51D062719C4FD04779B40851D0240264A2693BADF523E3E2E04AEB25EA2EC7C17391412A60B724C5C876AD25855F2EA01C07C52177774EA4645D83781718847D011C8099F1F21CB481397F869E5C698B2991C0C8D9B34DAA2D043400913AF184DC45B05FF34123649E3D60DF1E0F1B2419E261237211D8999D3A89F2794D506EDA2016C87D8CBE9CAB102D839268D2B69F5CD63BA4A184DB92328536940BA7D1503319BDBAC42BF3B5829EDA201007CC7A01C2DC866499C37D0436975637F3566F7E9F523BD6FA1F783BC546C8DF90A656C4C1A3669370DA0037A9FC525799978CBE29E88E7CDCD88DFFE7D0CF21E885977DD800C5771461D691AD33CAAA3856D370D004459627A13C81B249FE51F44EBFD85B310556C9F98B0FD4976ED561FA4A57203536267CCEF4FAA23D9DFA04D8C1A80CED942B51A0088F74FD3AE7839FAC3A2DB22F383179017B910F10B3811B8019886DAE3474310E74AF457B01F8EECFD9B96FB024D7A36D1358066D02B54E27CF3B9228DC7CC06E4C8B84977DA0359495C05DC093C8C2C0DA7077FDF19FCEF58CCCCD03B2277019838862CC9FD06E9DA648CA63CEB41EF692B6EB6EB8ACEA47748F91AE5BE875D7200E9278F33717B79B68A2B34655A017A4FD551CF9ED5A017F252D33CE026E44247DDC64B25EC83388F4EEBD8F935F427A25CA07345BF0464572E2950D4B8A15A6C8FFECA93B886F004F02DECFCE2BA22F3A027C9E69C6A013157B5A66430F03DE42EE431981D257F5A53B6C741DF4AD691C38995803E54762FF16AC415EB58E4B06647833C3B06612F4526899578229D4DFCEA230D3750BE54FD9064A7129DD0ABBE27827EA2D082994F1F5774C3DE4D25F588EDDD53C8CBBD279069C1778B833036F27A183B461EE727E4F129F17B09230DCA780E8873625DC03F58A848A58CC5DECB71290D88A328134DA409BA399ACA2915E82F8C6A21E4985A97491DD5B99049C770E45C41DE2F394E9602075AACEF5606794E53C4DB0EBD526D31B4AE9F5589440B7275F67A58633E32CB1F8FFA18795E6C047E825C02F1AAC5741B08EEF5496083E2BB6BD0DFA5F470F8C320F433DC7ADCF9B4CDC26EC83D0395DC2A5AA934027F24FEE6701BE866F2518F6483D11BDC36A3506DABBC6047650EC53BAB3F1819EFD25E155389D423F322137F4795B22FF1DDF92CDAAE6C3A212A6C5DF967A832329935B62077E61491BEC844F145EC3B930E8F9B13B0B3AE4FC370DADEA8568F5C701555594FC4AC1E47C6656472774F0B70B98D5A3964106263F00895DD3ABE3248E332AAF36BD73110B9A144A555BC1CB33ACD0A478A2E5586212D4DD7CDB700DF47F6C78B4E0D72EFEF10640E3308F9E5F4A2F562C82F10A5C97AE06D64A5F116B2E3D852E5F266611C6280AADB146B447A93D79302A5B9095365B1EBA91E5D49777986D1BECE56A4BB8E6501EDC389F3978DC34877057DDCB5364AF642BA43D3C49B109DBBEE04ACA77286217A9B3413DD759839A868C3C9645B5ACD45C6A4A8970F4F76F6449EE94BA47F1F0DC0897109EBF4D5E701F791DD80711532A1FA10B5D72C4F3C7D10BF0243C97E78A419314133B9B02296D3A9EC066E2FF9483D7233A9158E25FEBA342FC593CF707003C9CE982B8ABCE427AFD07ABFB1756A1105509A158297EAC83AC442BA2A7B35BB20138B3426D15EDCC866E001F4D7F03861774413A5BB18D18B7D5903DC45B957D55CE80A9C89ECCF9BDCB0E9259B7C8498BE8FC6920ADE96DD5A943D10CB9D21C80E565FE45065D16C098A4A2332A6AF4636A496215BD1EDD167B2C7E3F1783C1E8FC7E3F1783C1E8FC7E3F1783C9E1CF93F90FA69ECB8D930540000000049454E44AE426082)
INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (1002, N'АЦ', NULL, NULL)
INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (1003, N'АНР', NULL, NULL)
INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (1004, N'АЛ', NULL, NULL)
INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (1005, N'АКП', NULL, NULL)
INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (1006, N'ПНС', NULL, NULL)
INSERT [dbo].[Technics] ([TechnicId], [TechnicName], [TechnicDescription], [TechnicImage]) VALUES (1007, N'АПТ', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Technics] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkAreas] ON 

INSERT [dbo].[WorkAreas] ([WorkAreaId], [WorkAreaName]) VALUES (1, N'На кровлю')
INSERT [dbo].[WorkAreas] ([WorkAreaId], [WorkAreaName]) VALUES (2, N'На чердак')
INSERT [dbo].[WorkAreas] ([WorkAreaId], [WorkAreaName]) VALUES (3, N'На этажи')
INSERT [dbo].[WorkAreas] ([WorkAreaId], [WorkAreaName]) VALUES (4, N'В подвал (цоколь)')
INSERT [dbo].[WorkAreas] ([WorkAreaId], [WorkAreaName]) VALUES (5, N'Смежное помещение (участок)')
INSERT [dbo].[WorkAreas] ([WorkAreaId], [WorkAreaName]) VALUES (6, N'Смежное здание')
SET IDENTITY_INSERT [dbo].[WorkAreas] OFF
GO
ALTER TABLE [dbo].[Departures] ADD  CONSTRAINT [DF_Departures_IsFireContainment]  DEFAULT ((0)) FOR [IsFireContainment]
GO
ALTER TABLE [dbo].[Departures] ADD  CONSTRAINT [DF_Departures_IsOpenBurning]  DEFAULT ((0)) FOR [IsOpenBurning]
GO
ALTER TABLE [dbo].[Departures] ADD  CONSTRAINT [DF_Departures_IsAftermathFire]  DEFAULT ((0)) FOR [IsAftermathFire]
GO
ALTER TABLE [dbo].[DepartureAreas]  WITH CHECK ADD  CONSTRAINT [FK_DepartureAreas_Settlements] FOREIGN KEY([SettlementId])
REFERENCES [dbo].[Settlements] ([SettlementId])
GO
ALTER TABLE [dbo].[DepartureAreas] CHECK CONSTRAINT [FK_DepartureAreas_Settlements]
GO
ALTER TABLE [dbo].[DepartureBurns]  WITH CHECK ADD  CONSTRAINT [FK_DepartureBurns_BurnTypes] FOREIGN KEY([BurnTypeId])
REFERENCES [dbo].[BurnTypes] ([BurnTypeId])
GO
ALTER TABLE [dbo].[DepartureBurns] CHECK CONSTRAINT [FK_DepartureBurns_BurnTypes]
GO
ALTER TABLE [dbo].[DepartureBurns]  WITH CHECK ADD  CONSTRAINT [FK_DepartureBurns_Departures] FOREIGN KEY([DepartureId])
REFERENCES [dbo].[Departures] ([DepartureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartureBurns] CHECK CONSTRAINT [FK_DepartureBurns_Departures]
GO
ALTER TABLE [dbo].[DeparturePositions]  WITH CHECK ADD  CONSTRAINT [FK_DeparturePositions_Departures] FOREIGN KEY([DepartureId])
REFERENCES [dbo].[Departures] ([DepartureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeparturePositions] CHECK CONSTRAINT [FK_DeparturePositions_Departures]
GO
ALTER TABLE [dbo].[DeparturePositions]  WITH CHECK ADD  CONSTRAINT [FK_DeparturePositions_PositionTypes] FOREIGN KEY([PositionTypeId])
REFERENCES [dbo].[PositionTypes] ([PositionTypeId])
GO
ALTER TABLE [dbo].[DeparturePositions] CHECK CONSTRAINT [FK_DeparturePositions_PositionTypes]
GO
ALTER TABLE [dbo].[Departures]  WITH CHECK ADD  CONSTRAINT [FK_Departures_DepartureAreas] FOREIGN KEY([DepartureAreaId])
REFERENCES [dbo].[DepartureAreas] ([DepartureAreaId])
GO
ALTER TABLE [dbo].[Departures] CHECK CONSTRAINT [FK_Departures_DepartureAreas]
GO
ALTER TABLE [dbo].[Departures]  WITH CHECK ADD  CONSTRAINT [FK_Departures_Streets] FOREIGN KEY([StreetId])
REFERENCES [dbo].[Streets] ([StreetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Departures] CHECK CONSTRAINT [FK_Departures_Streets]
GO
ALTER TABLE [dbo].[DepartureServices]  WITH CHECK ADD  CONSTRAINT [FK_DepartureServices_Departures] FOREIGN KEY([DepartureId])
REFERENCES [dbo].[Departures] ([DepartureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartureServices] CHECK CONSTRAINT [FK_DepartureServices_Departures]
GO
ALTER TABLE [dbo].[DepartureServices]  WITH CHECK ADD  CONSTRAINT [FK_DepartureServices_ServiceTypes] FOREIGN KEY([ServiceTypeId])
REFERENCES [dbo].[ServiceTypes] ([ServiceTypeId])
GO
ALTER TABLE [dbo].[DepartureServices] CHECK CONSTRAINT [FK_DepartureServices_ServiceTypes]
GO
ALTER TABLE [dbo].[DepartureSubdivisions]  WITH CHECK ADD  CONSTRAINT [FK_DepartureDivisions_Departures] FOREIGN KEY([DepartureId])
REFERENCES [dbo].[Departures] ([DepartureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartureSubdivisions] CHECK CONSTRAINT [FK_DepartureDivisions_Departures]
GO
ALTER TABLE [dbo].[DepartureSubdivisions]  WITH CHECK ADD  CONSTRAINT [FK_DepartureSubdivisions_Subdivisions] FOREIGN KEY([SubdivisionId])
REFERENCES [dbo].[Subdivisions] ([SubdivisionId])
GO
ALTER TABLE [dbo].[DepartureSubdivisions] CHECK CONSTRAINT [FK_DepartureSubdivisions_Subdivisions]
GO
ALTER TABLE [dbo].[FireInfo]  WITH CHECK ADD  CONSTRAINT [FK_FireInfo_BarrelTypes] FOREIGN KEY([BarrelTypeId])
REFERENCES [dbo].[BarrelTypes] ([BarrelTypeId])
GO
ALTER TABLE [dbo].[FireInfo] CHECK CONSTRAINT [FK_FireInfo_BarrelTypes]
GO
ALTER TABLE [dbo].[FireInfo]  WITH CHECK ADD  CONSTRAINT [FK_FireInfo_Broadcasts] FOREIGN KEY([BroadcastId])
REFERENCES [dbo].[Broadcasts] ([BroadcastId])
GO
ALTER TABLE [dbo].[FireInfo] CHECK CONSTRAINT [FK_FireInfo_Broadcasts]
GO
ALTER TABLE [dbo].[FireInfo]  WITH CHECK ADD  CONSTRAINT [FK_FireInfo_CombatAreas] FOREIGN KEY([CombatAreaId])
REFERENCES [dbo].[CombatAreas] ([CombatAreaId])
GO
ALTER TABLE [dbo].[FireInfo] CHECK CONSTRAINT [FK_FireInfo_CombatAreas]
GO
ALTER TABLE [dbo].[FireInfo]  WITH CHECK ADD  CONSTRAINT [FK_FireInfo_Departures] FOREIGN KEY([DepartureId])
REFERENCES [dbo].[Departures] ([DepartureId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FireInfo] CHECK CONSTRAINT [FK_FireInfo_Departures]
GO
ALTER TABLE [dbo].[FireInfo]  WITH CHECK ADD  CONSTRAINT [FK_FireInfo_MissionTypes] FOREIGN KEY([MissionTypeId])
REFERENCES [dbo].[MissionTypes] ([MissionTypeId])
GO
ALTER TABLE [dbo].[FireInfo] CHECK CONSTRAINT [FK_FireInfo_MissionTypes]
GO
ALTER TABLE [dbo].[FireInfo]  WITH CHECK ADD  CONSTRAINT [FK_FireInfo_WorkAreas] FOREIGN KEY([WorkAreaId])
REFERENCES [dbo].[WorkAreas] ([WorkAreaId])
GO
ALTER TABLE [dbo].[FireInfo] CHECK CONSTRAINT [FK_FireInfo_WorkAreas]
GO
ALTER TABLE [dbo].[FireInfoSubdivisions]  WITH CHECK ADD  CONSTRAINT [FK_FireInfoSubdivisions_FireInfo] FOREIGN KEY([FireInfoId])
REFERENCES [dbo].[FireInfo] ([FireInfoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FireInfoSubdivisions] CHECK CONSTRAINT [FK_FireInfoSubdivisions_FireInfo]
GO
ALTER TABLE [dbo].[FireInfoSubdivisions]  WITH CHECK ADD  CONSTRAINT [FK_FireInfoSubdivisions_Subdivisions] FOREIGN KEY([SubdivisionId])
REFERENCES [dbo].[Subdivisions] ([SubdivisionId])
GO
ALTER TABLE [dbo].[FireInfoSubdivisions] CHECK CONSTRAINT [FK_FireInfoSubdivisions_Subdivisions]
GO
ALTER TABLE [dbo].[Subdivisions]  WITH CHECK ADD  CONSTRAINT [FK_Subdivisions_DepartureAreas] FOREIGN KEY([DepartureAreaId])
REFERENCES [dbo].[DepartureAreas] ([DepartureAreaId])
GO
ALTER TABLE [dbo].[Subdivisions] CHECK CONSTRAINT [FK_Subdivisions_DepartureAreas]
GO
ALTER TABLE [dbo].[Subdivisions]  WITH CHECK ADD  CONSTRAINT [FK_Subdivisions_Divisions] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Divisions] ([DivisionId])
GO
ALTER TABLE [dbo].[Subdivisions] CHECK CONSTRAINT [FK_Subdivisions_Divisions]
GO
ALTER TABLE [dbo].[Subdivisions]  WITH CHECK ADD  CONSTRAINT [FK_Subdivisions_Technics] FOREIGN KEY([TechnicId])
REFERENCES [dbo].[Technics] ([TechnicId])
GO
ALTER TABLE [dbo].[Subdivisions] CHECK CONSTRAINT [FK_Subdivisions_Technics]
GO
ALTER TABLE [dbo].[TechnicDivisions]  WITH CHECK ADD  CONSTRAINT [FK_TechnicDivisions_Divisions] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[Divisions] ([DivisionId])
GO
ALTER TABLE [dbo].[TechnicDivisions] CHECK CONSTRAINT [FK_TechnicDivisions_Divisions]
GO
ALTER TABLE [dbo].[TechnicDivisions]  WITH CHECK ADD  CONSTRAINT [FK_TechnicDivisions_Technics] FOREIGN KEY([TechnicId])
REFERENCES [dbo].[Technics] ([TechnicId])
GO
ALTER TABLE [dbo].[TechnicDivisions] CHECK CONSTRAINT [FK_TechnicDivisions_Technics]
GO
USE [master]
GO
ALTER DATABASE [FireDepart] SET  READ_WRITE 
GO
