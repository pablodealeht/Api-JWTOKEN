USE [master]
GO
/****** Object:  Database [Login]    Script Date: 28/11/2023 03:05:16 ******/
CREATE DATABASE [Login]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Login', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Login.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Login_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Login_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Login] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Login].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Login] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Login] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Login] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Login] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Login] SET ARITHABORT OFF 
GO
ALTER DATABASE [Login] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Login] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Login] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Login] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Login] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Login] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Login] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Login] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Login] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Login] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Login] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Login] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Login] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Login] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Login] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Login] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Login] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Login] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Login] SET  MULTI_USER 
GO
ALTER DATABASE [Login] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Login] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Login] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Login] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Login] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Login] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Login] SET QUERY_STORE = OFF
GO
USE [Login]
GO
/****** Object:  Schema [SINIESTROS]    Script Date: 28/11/2023 03:05:16 ******/
CREATE SCHEMA [SINIESTROS]
GO
/****** Object:  Schema [USUARIOS]    Script Date: 28/11/2023 03:05:16 ******/
CREATE SCHEMA [USUARIOS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 28/11/2023 03:05:16 ******/
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
/****** Object:  Table [SINIESTROS].[SINIESTROS]    Script Date: 28/11/2023 03:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SINIESTROS].[SINIESTROS](
	[Id] [uniqueidentifier] NOT NULL,
	[Numero] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Estado] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Localidad] [nvarchar](max) NOT NULL,
	[Provincia] [nvarchar](max) NOT NULL,
	[Pais] [nvarchar](max) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_SINIESTROS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SINIESTROS].[TERCEROS]    Script Date: 28/11/2023 03:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SINIESTROS].[TERCEROS](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Dni] [int] NOT NULL,
	[Tipo] [int] NOT NULL,
	[SiniestroId] [uniqueidentifier] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TERCEROS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [USUARIOS].[PERSONAL]    Script Date: 28/11/2023 03:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [USUARIOS].[PERSONAL](
	[Id] [uniqueidentifier] NOT NULL,
	[idEmployee] [int] NOT NULL,
	[registerType] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Sexo] [int] NOT NULL,
	[businessLocation] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PERSONAL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [USUARIOS].[USUARIOS]    Script Date: 28/11/2023 03:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [USUARIOS].[USUARIOS](
	[Id] [uniqueidentifier] NOT NULL,
	[User] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Numero] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230831175117_initialMigration', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231121225245_LoginMigration', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231128045536_PersonalMigration', N'7.0.9')
GO
SET IDENTITY_INSERT [SINIESTROS].[SINIESTROS] ON 

INSERT [SINIESTROS].[SINIESTROS] ([Id], [Numero], [Descripcion], [Fecha], [Estado], [Tipo], [Direccion], [Localidad], [Provincia], [Pais], [FechaCreacion]) VALUES (N'c9015d5e-eb49-4896-a525-6e8cf8d5dff6', 6, N'Lo choqué 😨', CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), 1, 2, N'Av. Corrientes 1234', N'CABA', N'CABA', N'Argentina', CAST(N'2023-03-02T00:00:00.0000000' AS DateTime2))
INSERT [SINIESTROS].[SINIESTROS] ([Id], [Numero], [Descripcion], [Fecha], [Estado], [Tipo], [Direccion], [Localidad], [Provincia], [Pais], [FechaCreacion]) VALUES (N'666b3523-ce67-4122-b8e4-9a6e573e2282', 5, N'Me chocaron 😔', CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), 1, 2, N'Av. Corrientes 1234', N'CABA', N'CABA', N'Argentina', CAST(N'2023-03-02T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [SINIESTROS].[SINIESTROS] OFF
GO
INSERT [USUARIOS].[PERSONAL] ([Id], [idEmployee], [registerType], [Nombre], [Apellido], [Sexo], [businessLocation], [FechaCreacion]) VALUES (N'46415406-8cf4-48bf-93a0-3a28fb8f70b6', 0, N'string', N'string', N'string', 0, 0, CAST(N'2023-11-28T01:56:41.3057348' AS DateTime2))
GO
SET IDENTITY_INSERT [USUARIOS].[USUARIOS] ON 

INSERT [USUARIOS].[USUARIOS] ([Id], [User], [Password], [Numero]) VALUES (N'ed88bfeb-17b4-43ff-b939-34091e908d30', N'a@a.com', N'1234', 1)
SET IDENTITY_INSERT [USUARIOS].[USUARIOS] OFF
GO
/****** Object:  Index [IX_TERCEROS_SiniestroId]    Script Date: 28/11/2023 03:05:16 ******/
CREATE NONCLUSTERED INDEX [IX_TERCEROS_SiniestroId] ON [SINIESTROS].[TERCEROS]
(
	[SiniestroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [SINIESTROS].[TERCEROS]  WITH CHECK ADD  CONSTRAINT [FK_TERCEROS_SINIESTROS_SiniestroId] FOREIGN KEY([SiniestroId])
REFERENCES [SINIESTROS].[SINIESTROS] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [SINIESTROS].[TERCEROS] CHECK CONSTRAINT [FK_TERCEROS_SINIESTROS_SiniestroId]
GO
USE [master]
GO
ALTER DATABASE [Login] SET  READ_WRITE 
GO
