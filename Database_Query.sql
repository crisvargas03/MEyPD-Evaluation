USE [master]
GO
/****** Object:  Database [meydp]    Script Date: 12/7/2022 12:30:17 AM ******/
CREATE DATABASE [meydp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'meydp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\meydp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'meydp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\meydp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [meydp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [meydp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [meydp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [meydp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [meydp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [meydp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [meydp] SET ARITHABORT OFF 
GO
ALTER DATABASE [meydp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [meydp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [meydp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [meydp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [meydp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [meydp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [meydp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [meydp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [meydp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [meydp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [meydp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [meydp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [meydp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [meydp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [meydp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [meydp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [meydp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [meydp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [meydp] SET  MULTI_USER 
GO
ALTER DATABASE [meydp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [meydp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [meydp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [meydp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [meydp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [meydp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [meydp] SET QUERY_STORE = OFF
GO
USE [meydp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/7/2022 12:30:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 12/7/2022 12:30:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[Id] [int] IDENTITY(1001,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[IsPresent] [bit] NOT NULL,
	[Justification] [nvarchar](200) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradesBook]    Script Date: 12/7/2022 12:30:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradesBook](
	[Id] [int] IDENTITY(1001,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Grade] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GradesBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/7/2022 12:30:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1001,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Birthdate] [datetime2](7) NOT NULL,
	[CardnetNumber] [nvarchar](8) NOT NULL,
	[Condition] [nvarchar](20) NULL,
	[Gender] [nvarchar](2) NULL,
	[Address] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[TeacherId] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 12/7/2022 12:30:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1001,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/7/2022 12:30:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1001,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](70) NOT NULL,
	[Password] [nvarchar](15) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221125040550_Initial', N'7.0.0')
GO
SET IDENTITY_INSERT [dbo].[Attendance] ON 
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1004, 1016, 1, NULL, CAST(N'2022-12-06T21:32:36.1266667' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1005, 1016, 0, NULL, CAST(N'2022-12-06T21:33:37.9833333' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1007, 1009, 1, NULL, CAST(N'2022-12-06T23:59:22.6620593' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1008, 1009, 1, NULL, CAST(N'2022-12-07T00:01:27.0740625' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1009, 1009, 1, NULL, CAST(N'2022-12-07T00:02:05.5663743' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1010, 1012, 1, NULL, CAST(N'2022-12-07T00:02:10.5548739' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1011, 1013, 1, NULL, CAST(N'2022-12-07T00:02:13.0184546' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1012, 1016, 1, NULL, CAST(N'2022-12-07T00:02:16.8027512' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1013, 1009, 1, NULL, CAST(N'2022-12-07T00:02:52.2414222' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1014, 1012, 1, NULL, CAST(N'2022-12-07T00:02:55.8385012' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1015, 1013, 1, NULL, CAST(N'2022-12-07T00:02:55.8489025' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1016, 1016, 1, NULL, CAST(N'2022-12-07T00:02:55.8544177' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1017, 1009, 1, NULL, CAST(N'2022-12-07T00:04:19.0718500' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1018, 1012, 1, NULL, CAST(N'2022-12-07T00:04:19.3355559' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1019, 1009, 1, NULL, CAST(N'2022-12-07T00:08:59.7309674' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1020, 1009, 1, NULL, CAST(N'2022-12-07T00:10:19.5234909' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1021, 1009, 1, NULL, CAST(N'2022-12-07T00:10:32.0346814' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1022, 1009, 1, NULL, CAST(N'2022-12-07T00:12:27.2046952' AS DateTime2), 0)
GO
INSERT [dbo].[Attendance] ([Id], [StudentId], [IsPresent], [Justification], [CreationDate], [IsDeleted]) VALUES (1023, 1009, 1, NULL, CAST(N'2022-12-07T00:12:55.0192453' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[Attendance] OFF
GO
SET IDENTITY_INSERT [dbo].[GradesBook] ON 
GO
INSERT [dbo].[GradesBook] ([Id], [StudentId], [SubjectId], [Grade], [CreationDate], [IsDeleted]) VALUES (1001, 1009, 1003, 87, CAST(N'2022-12-04T21:47:13.4207924' AS DateTime2), 0)
GO
INSERT [dbo].[GradesBook] ([Id], [StudentId], [SubjectId], [Grade], [CreationDate], [IsDeleted]) VALUES (1002, 1009, 1001, 90, CAST(N'2022-12-04T21:49:53.4295967' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[GradesBook] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1006, N'Jaime David', N'Sanchez', CAST(N'2000-12-12T00:00:00.0000000' AS DateTime2), N'23-4321', N'NORMAL', N'M', N'SUMMER AV. #15', N'809-000-0000', 1001, CAST(N'2022-12-04T14:33:13.9333177' AS DateTime2), 1)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1007, N'Jenny Marie', N'Lopez', CAST(N'2012-02-12T00:00:00.0000000' AS DateTime2), N'23-9876', N'NORMAL', N'F', N'Calle Winter ', N'809-212-1002', 1001, CAST(N'2022-12-04T15:02:29.1188169' AS DateTime2), 1)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1008, N'Raul Federico', N'Alvarez', CAST(N'2011-11-05T00:00:00.0000000' AS DateTime2), N'23-1111', N'NORMAL', N'M', N'Calle Sprint', N'809-000-1515', 1001, CAST(N'2022-12-04T14:35:14.6064700' AS DateTime2), 1)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1009, N'Rosita', N'Reyes Perez', CAST(N'2014-03-21T00:00:00.0000000' AS DateTime2), N'23-1144', N'NORMAL', N'F', N'CALLE SEGUNDA', NULL, 1001, CAST(N'2022-12-06T22:29:44.6472101' AS DateTime2), 0)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1011, N'pedrito', N'aquiles', CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), N'23-0000', N'NORMAL', N'M', N'Calle primavera', NULL, 1001, CAST(N'2022-11-30T01:18:24.7013938' AS DateTime2), 1)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1012, N'Isaac', N'Vargas', CAST(N'2013-12-02T00:00:00.0000000' AS DateTime2), N'23-1972', N'NORMAL', N'M', N'Calle primavera', N'809-000-1212', 1001, CAST(N'2022-12-04T14:49:08.1935899' AS DateTime2), 0)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1013, N'Isaias', N'Garcia', CAST(N'2001-12-23T00:00:00.0000000' AS DateTime2), N'23-3820', N'NORMAL', N'M', N'Calle primavera', N'809-000-1212', 1001, CAST(N'2022-11-30T01:30:00.4121607' AS DateTime2), 0)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1014, N'awwqeeq', N'qweqweq', CAST(N'2002-12-23T00:00:00.0000000' AS DateTime2), N'23-2514', N'NORMAL', N'X', N'asdddddddddddddd', N'809-000-1212', 1001, CAST(N'2022-11-30T01:45:48.8797407' AS DateTime2), 1)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1015, N'pedro', N'peter', CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), N'23-5207', N'NORMAL', N'M', N'sdfsdsd', N'809-000-1212', 1001, CAST(N'2022-11-30T10:51:22.8522440' AS DateTime2), 1)
GO
INSERT [dbo].[Student] ([Id], [Name], [Lastname], [Birthdate], [CardnetNumber], [Condition], [Gender], [Address], [PhoneNumber], [TeacherId], [CreationDate], [IsDeleted]) VALUES (1016, N'Julia', N'Garcia', CAST(N'2013-09-07T00:00:00.0000000' AS DateTime2), N'23-7952', N'NORMAL', N'F', N'Calle Cafe #1', N'809-000-1212', 1001, CAST(N'2022-12-04T14:36:19.7152416' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 
GO
INSERT [dbo].[Subject] ([Id], [Name], [CreationDate], [IsDeleted]) VALUES (1001, N'Lengua Española', CAST(N'2022-11-26T22:42:09.5633333' AS DateTime2), 0)
GO
INSERT [dbo].[Subject] ([Id], [Name], [CreationDate], [IsDeleted]) VALUES (1002, N'Matemáticas', CAST(N'2022-11-26T22:42:09.5633333' AS DateTime2), 0)
GO
INSERT [dbo].[Subject] ([Id], [Name], [CreationDate], [IsDeleted]) VALUES (1003, N'Ciencias Sociales', CAST(N'2022-11-26T22:42:09.5633333' AS DateTime2), 0)
GO
INSERT [dbo].[Subject] ([Id], [Name], [CreationDate], [IsDeleted]) VALUES (1004, N'Ciencias Naturales', CAST(N'2022-11-26T22:42:09.5633333' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 
GO
INSERT [dbo].[Teacher] ([Id], [Name], [Lastname], [Email], [Password], [CreationDate], [IsDeleted]) VALUES (1001, N'Pedro', N'Martinez', N'pmartinez@mail.com', N'@pm12345', CAST(N'2022-11-25T22:52:31.9433333' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
/****** Object:  Index [IX_Attendance_StudentId]    Script Date: 12/7/2022 12:30:18 AM ******/
CREATE NONCLUSTERED INDEX [IX_Attendance_StudentId] ON [dbo].[Attendance]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GradesBook_StudentId]    Script Date: 12/7/2022 12:30:18 AM ******/
CREATE NONCLUSTERED INDEX [IX_GradesBook_StudentId] ON [dbo].[GradesBook]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GradesBook_SubjectId]    Script Date: 12/7/2022 12:30:18 AM ******/
CREATE NONCLUSTERED INDEX [IX_GradesBook_SubjectId] ON [dbo].[GradesBook]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_TeacherId]    Script Date: 12/7/2022 12:30:18 AM ******/
CREATE NONCLUSTERED INDEX [IX_Student_TeacherId] ON [dbo].[Student]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Student_StudentId]
GO
ALTER TABLE [dbo].[GradesBook]  WITH CHECK ADD  CONSTRAINT [FK_GradesBook_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GradesBook] CHECK CONSTRAINT [FK_GradesBook_Student_StudentId]
GO
ALTER TABLE [dbo].[GradesBook]  WITH CHECK ADD  CONSTRAINT [FK_GradesBook_Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GradesBook] CHECK CONSTRAINT [FK_GradesBook_Subject_SubjectId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Teacher_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Teacher_TeacherId]
GO
USE [master]
GO
ALTER DATABASE [meydp] SET  READ_WRITE 
GO
