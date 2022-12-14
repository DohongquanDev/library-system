USE [master]
GO
/****** Object:  Database [Libarary]    Script Date: 11/13/2022 12:51:02 AM ******/
CREATE DATABASE [Libarary]
GO
ALTER DATABASE [Libarary] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Libarary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Libarary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Libarary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Libarary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Libarary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Libarary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Libarary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Libarary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Libarary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Libarary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Libarary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Libarary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Libarary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Libarary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Libarary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Libarary] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Libarary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Libarary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Libarary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Libarary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Libarary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Libarary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Libarary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Libarary] SET RECOVERY FULL 
GO
ALTER DATABASE [Libarary] SET  MULTI_USER 
GO
ALTER DATABASE [Libarary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Libarary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Libarary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Libarary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Libarary] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Libarary] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Libarary', N'ON'
GO
ALTER DATABASE [Libarary] SET QUERY_STORE = OFF
GO
USE [Libarary]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/13/2022 12:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[bookNumber] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](100) NULL,
	[author] [varchar](100) NULL,
	[publisher] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[bookNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 11/13/2022 12:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrower](
	[borrowerNumber] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[sex] [bit] NULL,
	[address] [varchar](100) NULL,
	[telephone] [varchar](100) NULL,
	[email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[borrowerNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CirculatedCopy]    Script Date: 11/13/2022 12:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CirculatedCopy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[copyNumber] [int] NULL,
	[borrowerNumber] [int] NULL,
	[borrowedDate] [date] NULL,
	[dueDate] [date] NULL,
	[returnedDate] [date] NULL,
	[fineAmount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Copy]    Script Date: 11/13/2022 12:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Copy](
	[copyNumber] [int] IDENTITY(1,1) NOT NULL,
	[bookNumber] [int] NULL,
	[sequenceNumber] [int] NULL,
	[type] [varchar](100) NULL,
	[price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[copyNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 11/13/2022 12:51:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[borrowerNumber] [int] NULL,
	[bookNumber] [int] NULL,
	[date] [date] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (1, N'The Lord of the Rings', N'Huu Dai', N'DatLT')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (2, N'The Hobbit', N'J.R.R. Tolkien', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (3, N'The Silmarillion', N'Thanh', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (4, N'The Fellowship of the Ring', N'J.R.R. Tolkien', N'DatLT')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (5, N'The Two Towers', N'Thanh', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (6, N'The Return of the King', N'Huu Dai', N'Phuong')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (7, N'The Children of Húrin', N'Thanh', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (8, N'The History of Middle-earth', N'Huu Dai', N'Phuong')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (9, N'The Book of Lost Tales', N'J.R.R. Tolkien', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (10, N'The Book of Lost Tales, Part Two', N'Huu Dai', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (11, N'The Book of Lost Tales, Part Three', N'J.R.R. Tolkien', N'Phuong')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (12, N'The Lays of Beleriand', N'J.R.R. Tolkien', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (13, N'The Shaping of Middle-earth', N'Huu Dai', N'Bang Huu')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (14, N'The Lost Road and Other Writings', N'J.R.R. Tolkien', N'Ronaldo')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (15, N'The Adventures of Tom Bombadil', N'DatLT', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (16, N'The Road Goes Ever On', N'DatLT', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (17, N'The Legend of Sigurd and Gudrún', N'J.R.R. Tolkien', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (18, N'The Fall of Arthur', N'DatLT', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (19, N'The Homecoming of Beorhtnoth Beorhthelm''s Son', N'J.R.R. Tolkien', N'Allen & Unwin')
INSERT [dbo].[Book] ([bookNumber], [title], [author], [publisher]) VALUES (20, N'The Adventures of Tom Bombadil', N'DatLT', N'Allen & Unwin')
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Borrower] ON 

INSERT [dbo].[Borrower] ([borrowerNumber], [name], [sex], [address], [telephone], [email]) VALUES (1, N'Johnny Dang', 1, N'America', N'0123456789', N'borrower1@gmail.com')
INSERT [dbo].[Borrower] ([borrowerNumber], [name], [sex], [address], [telephone], [email]) VALUES (2, N'Leo Ronaldo', 0, N'China', N'0123456789', N'borrower2@gmail.com')
INSERT [dbo].[Borrower] ([borrowerNumber], [name], [sex], [address], [telephone], [email]) VALUES (3, N'Soobin', 0, N'VietNam', N'0123456789', N'borrower3@gmail.com')
INSERT [dbo].[Borrower] ([borrowerNumber], [name], [sex], [address], [telephone], [email]) VALUES (4, N'Touliver', 1, N'VietNam', N'0123456789', N'borrower4@gmail.com')
INSERT [dbo].[Borrower] ([borrowerNumber], [name], [sex], [address], [telephone], [email]) VALUES (5, N'Nguyen Van Yeah', 1, N'UK', N'0123456789', N'borrower5@gmail.com')
SET IDENTITY_INSERT [dbo].[Borrower] OFF
GO
SET IDENTITY_INSERT [dbo].[CirculatedCopy] ON 

INSERT [dbo].[CirculatedCopy] ([ID], [copyNumber], [borrowerNumber], [borrowedDate], [dueDate], [returnedDate], [fineAmount]) VALUES (1, 57, 1, CAST(N'2022-10-01' AS Date), CAST(N'2022-10-15' AS Date), CAST(N'2022-10-11' AS Date), 0)
INSERT [dbo].[CirculatedCopy] ([ID], [copyNumber], [borrowerNumber], [borrowedDate], [dueDate], [returnedDate], [fineAmount]) VALUES (2, 59, 2, CAST(N'2022-10-02' AS Date), CAST(N'2022-10-16' AS Date), CAST(N'2022-10-20' AS Date), 4)
INSERT [dbo].[CirculatedCopy] ([ID], [copyNumber], [borrowerNumber], [borrowedDate], [dueDate], [returnedDate], [fineAmount]) VALUES (3, 14, 1, CAST(N'2022-10-24' AS Date), CAST(N'2022-11-07' AS Date), NULL, NULL)
INSERT [dbo].[CirculatedCopy] ([ID], [copyNumber], [borrowerNumber], [borrowedDate], [dueDate], [returnedDate], [fineAmount]) VALUES (4, 11, 2, CAST(N'2022-10-27' AS Date), CAST(N'2022-11-10' AS Date), NULL, NULL)
INSERT [dbo].[CirculatedCopy] ([ID], [copyNumber], [borrowerNumber], [borrowedDate], [dueDate], [returnedDate], [fineAmount]) VALUES (5, 16, 1, CAST(N'2022-11-10' AS Date), CAST(N'2022-11-24' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[CirculatedCopy] OFF
GO
SET IDENTITY_INSERT [dbo].[Copy] ON 

INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (1, 8, 1, N'available', 34)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (2, 1, 1, N'available', 63)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (3, 1, 2, N'available', 23)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (4, 1, 3, N'available', 87)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (5, 1, 4, N'read only', 45)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (6, 1, 5, N'read only', 88)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (7, 1, 6, N'read only', 27)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (8, 1, 7, N'read only', 12)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (9, 20, 1, N'read only', 42)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (10, 19, 1, N'unavailable', 63)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (11, 17, 1, N'unavailable', 12)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (12, 16, 1, N'read only', 78)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (13, 1, 8, N'read only', 35)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (14, 15, 1, N'unavailable', 62)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (15, 14, 1, N'read only', 72)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (16, 13, 1, N'unavailable', 26)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (17, 12, 1, N'read only', 24)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (18, 18, 1, N'read only', 64)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (19, 6, 7, N'available', 12)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (20, 3, 5, N'read only', 53)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (21, 11, 1, N'unavailable', 86)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (22, 11, 1, N'unavailable', 68)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (23, 10, 1, N'read only', 35)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (24, 9, 1, N'read only', 68)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (25, 1, 9, N'read only', 46)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (26, 1, 10, N'read only', 86)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (27, 1, 11, N'read only', 24)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (28, 1, 12, N'read only', 68)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (29, 7, 1, N'read only', 57)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (30, 7, 2, N'read only', 68)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (31, 7, 3, N'read only', 12)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (32, 7, 4, N'read only', 14)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (33, 6, 1, N'available', 51)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (34, 6, 2, N'available', 63)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (35, 6, 3, N'available', 47)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (36, 6, 4, N'available', 97)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (37, 6, 5, N'available', 12)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (38, 6, 6, N'available', 53)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (39, 3, 1, N'read only', 32)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (40, 3, 2, N'read only', 24)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (41, 3, 3, N'read only', 68)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (42, 3, 4, N'read only', 72)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (43, 3, 6, N'read only', 86)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (44, 5, 1, N'read only', 45)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (45, 5, 2, N'read only', 86)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (46, 5, 3, N'read only', 97)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (47, 5, 4, N'read only', 45)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (48, 5, 5, N'read only', 32)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (49, 4, 1, N'available', 86)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (50, 4, 2, N'available', 34)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (51, 4, 3, N'available', 75)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (52, 4, 4, N'available', 85)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (53, 4, 5, N'available', 23)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (54, 4, 6, N'available', 12)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (55, 2, 1, N'available', 64)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (56, 2, 2, N'available', 75)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (57, 2, 3, N'available', 35)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (58, 2, 4, N'available', 65)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (59, 2, 5, N'available', 97)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (60, 2, 6, N'available', 34)
INSERT [dbo].[Copy] ([copyNumber], [bookNumber], [sequenceNumber], [type], [price]) VALUES (61, 2, 7, N'available', 12)
SET IDENTITY_INSERT [dbo].[Copy] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([ID], [borrowerNumber], [bookNumber], [date], [status]) VALUES (1, 4, 3, CAST(N'2022-11-01' AS Date), 1)
INSERT [dbo].[Reservation] ([ID], [borrowerNumber], [bookNumber], [date], [status]) VALUES (2, 5, 2, CAST(N'2022-11-04' AS Date), 1)
INSERT [dbo].[Reservation] ([ID], [borrowerNumber], [bookNumber], [date], [status]) VALUES (3, 3, 2, CAST(N'2022-11-06' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
ALTER TABLE [dbo].[CirculatedCopy]  WITH CHECK ADD FOREIGN KEY([borrowerNumber])
REFERENCES [dbo].[Borrower] ([borrowerNumber])
GO
ALTER TABLE [dbo].[CirculatedCopy]  WITH CHECK ADD FOREIGN KEY([copyNumber])
REFERENCES [dbo].[Copy] ([copyNumber])
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD FOREIGN KEY([bookNumber])
REFERENCES [dbo].[Book] ([bookNumber])
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD FOREIGN KEY([bookNumber])
REFERENCES [dbo].[Book] ([bookNumber])
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD FOREIGN KEY([borrowerNumber])
REFERENCES [dbo].[Borrower] ([borrowerNumber])
GO
USE [master]
GO
ALTER DATABASE [Libarary] SET  READ_WRITE 
GO
