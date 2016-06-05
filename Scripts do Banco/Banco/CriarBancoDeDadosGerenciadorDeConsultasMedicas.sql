USE [master]
GO

/****** Object:  Database [GerenciadorConsultasMedicas]    Script Date: 04/06/2016 20:55:03 ******/
CREATE DATABASE [GerenciadorConsultasMedicas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GerenciadorConsultasMedicas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GerenciadorConsultasMedicas.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GerenciadorConsultasMedicas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GerenciadorConsultasMedicas_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GerenciadorConsultasMedicas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET ARITHABORT OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET  ENABLE_BROKER 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET  MULTI_USER 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET DB_CHAINING OFF 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [GerenciadorConsultasMedicas] SET  READ_WRITE 
GO


