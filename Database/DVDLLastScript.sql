--CREATE DATABASE [DVLD_DB]
--USE [DVLD_DB];

GO
/****** Object:  Table [dbo].[People]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[NationalNo] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[SecondName] [nvarchar](20) NOT NULL,
	[ThirdName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Gendor] [tinyint] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[NationalityCountryID] [int] NOT NULL,
	[ImagePath] [nvarchar](250) NULL,
 CONSTRAINT [PK_PersonID] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[DriverID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_DriverID] PRIMARY KEY CLUSTERED 
(
	[DriverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Licenses]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licenses](
	[LicenseID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NOT NULL,
	[DriverID] [int] NOT NULL,
	[LicenseClassID] [int] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[PaidFees] [smallmoney] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IssueReason] [tinyint] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
 CONSTRAINT [PK_LicenseID] PRIMARY KEY CLUSTERED 
(
	[LicenseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Drivers_View]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Drivers_View] AS
SELECT 
	D.DriverID, P.PersonID, P.NationalNo,
	CONCAT(P.FirstName, ' ', P.SecondName, ' ',ISNULL(P.ThirdName,''), ' ', P.LastName) AS FullName,
	D.CreatedDate,
	(
		SELECT COUNT(L.LicenseID) FROM Licenses L WHERE L.DriverID = D.DriverID AND IsActive = 1
	) AS NumberOfActiveLicenses
FROM
	Drivers D JOIN People P
ON	D.PersonID = P.PersonID;


GO
/****** Object:  Table [dbo].[Applications]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationPersonID] [int] NOT NULL,
	[ApplicationDate] [datetime] NOT NULL,
	[ApplicationTypeID] [int] NOT NULL,
	[ApplicationStatus] [tinyint] NOT NULL,
	[LastStatusDate] [datetime] NOT NULL,
	[PaidFees] [smallmoney] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
 CONSTRAINT [PK_ApplicationID] PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseClasses]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseClasses](
	[LicenseClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[ClassDescription] [nvarchar](500) NOT NULL,
	[MinimunAllowedAge] [tinyint] NOT NULL,
	[DefaultValidityLength] [tinyint] NOT NULL,
	[ClassFees] [smallmoney] NOT NULL,
 CONSTRAINT [PK_LicenseClassID] PRIMARY KEY CLUSTERED 
(
	[LicenseClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalDrivingLicenseApplications]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalDrivingLicenseApplications](
	[LocalDrivingLicenseApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationID] [int] NOT NULL,
	[LicenseClassID] [int] NOT NULL,
 CONSTRAINT [PK_LocalDrivingLicenseApplicationID] PRIMARY KEY CLUSTERED 
(
	[LocalDrivingLicenseApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestAppointments]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestAppointments](
	[TestAppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[TestTypeID] [int] NOT NULL,
	[LocalDrivingLicenseApplicationID] [int] NOT NULL,
	[AppointmentDate] [smalldatetime] NOT NULL,
	[PaidFees] [smallmoney] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[RetakeTestApplicationID] [int] NULL,
 CONSTRAINT [PK_TestAppointmentID] PRIMARY KEY CLUSTERED 
(
	[TestAppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[TestID] [int] IDENTITY(1,1) NOT NULL,
	[TestAppointmentID] [int] NOT NULL,
	[TestResult] [bit] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[CreatedByUserID] [int] NOT NULL,
 CONSTRAINT [PK_TestID] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[LocalDrivingLicenseApplications_View]    Script Date: 11/28/2025 4:49:34 PM ******/
CREATE VIEW [dbo].[LocalDrivingLicenseApplications_View] AS
SELECT        
LDLA.LocalDrivingLicenseApplicationID, 
LC.ClassName, 
P.NationalNo, 
CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName, 
A.ApplicationDate,
(SELECT        COUNT(*) AS Expr1
FROM            dbo.TestAppointments AS TA
JOIN Tests T
ON TA.TestAppointmentID = T.TestAppointmentID
WHERE        
((LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID) AND (T.TestResult = 1))
) AS PassedTestCount, 
CASE 
	WHEN A.ApplicationStatus = 1 THEN 'New' 
	WHEN A.ApplicationStatus = 2 THEN 'Canceled' 
	WHEN A.ApplicationStatus = 3 THEN 'Completed' 
	ELSE 'None' 
	END AS Status
FROM            
dbo.Applications AS A INNER JOIN
dbo.People AS P ON A.ApplicationPersonID = P.PersonID INNER JOIN
dbo.LocalDrivingLicenseApplications AS LDLA ON A.ApplicationID = LDLA.ApplicationID INNER JOIN
dbo.LicenseClasses AS LC ON LDLA.LicenseClassID = LC.LicenseClassID;
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 11/28/2025 4:49:34 PM ******/
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CountryID] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MasterPeople_View]    Script Date: 11/28/2025 4:49:34 PM ******/
CREATE VIEW [dbo].[MasterPeople_View] AS
SELECT    
P.PersonID, P.NationalNo, P.FirstName, P.SecondName, P.ThirdName, P.LastName, CASE WHEN P.Gendor = 0 THEN 'Male' ELSE 'Female' END AS Gendor, P.DateOfBirth, C.CountryName AS Nationality, P.Phone, P.Email
FROM            dbo.People AS P INNER JOIN
                         dbo.Countries AS C ON P.NationalityCountryID = C.CountryID
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO 
/****** Object:  View [dbo].[MasterUsers_View]    Script Date: 11/28/2025 4:49:34 PM ******/
CREATE VIEW [dbo].[MasterUsers_View] AS
SELECT 
	U.UserID,
	U.PersonID,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName,
	U.UserName,
	U.IsActive
FROM 
	Users U
JOIN
	People P
ON
	U.PersonID = P.PersonID;
GO
/****** Object:  Table [dbo].[ApplicationTypes]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationTypes](
	[ApplicationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationTypeTitle] [nvarchar](150) NOT NULL,
	[ApplicationFees] [smallmoney] NOT NULL,
 CONSTRAINT [PK_ApplicationTypeID] PRIMARY KEY CLUSTERED 
(
	[ApplicationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetainedLicenses]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetainedLicenses](
	[DetainID] [int] IDENTITY(1,1) NOT NULL,
	[LicenseID] [int] NOT NULL,
	[DetainDate] [smalldatetime] NOT NULL,
	[FineFees] [smallmoney] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[IsReleased] [bit] NOT NULL,
	[ReleaseDate] [smalldatetime] NULL,
	[ReleasedByUserID] [int] NULL,
	[ReleaseApplicationID] [int] NULL,
 CONSTRAINT [PK_DetainID] PRIMARY KEY CLUSTERED 
(
	[DetainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestTypes]    Script Date: 11/28/2025 4:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTypes](
	[TestTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TestTypeTitle] [nvarchar](100) NOT NULL,
	[TestTypeDescription] [nvarchar](500) NOT NULL,
	[TestTypeFees] [smallmoney] NOT NULL,
 CONSTRAINT [PK_TestTypeID] PRIMARY KEY CLUSTERED 
(
	[TestTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[ApplicationTypes] ON 
GO 
INSERT [dbo].[ApplicationTypes] ([ApplicationTypeTitle], [ApplicationFees]) VALUES (N'New Local Driving License Service', 15.0000)
GO
INSERT [dbo].[ApplicationTypes] ([ApplicationTypeTitle], [ApplicationFees]) VALUES (N'Renew Driving License Service', 5.0000)
GO
INSERT [dbo].[ApplicationTypes] ([ApplicationTypeTitle], [ApplicationFees]) VALUES (N'Replacement for a Lost Driving License', 10.0000)
GO
INSERT [dbo].[ApplicationTypes] ([ApplicationTypeTitle], [ApplicationFees]) VALUES (N'Replacement for a Damaged Driving License', 5.0000)
GO
INSERT [dbo].[ApplicationTypes] ([ApplicationTypeTitle], [ApplicationFees]) VALUES (N'Release Detained Driving Licsense', 15000.0000)
GO
INSERT [dbo].[ApplicationTypes] ([ApplicationTypeTitle], [ApplicationFees]) VALUES (N'New International License', 50.0000)
GO
INSERT [dbo].[ApplicationTypes] ([ApplicationTypeTitle], [ApplicationFees]) VALUES (N'Retake Test', 5.0000)
GO
SET IDENTITY_INSERT [dbo].[ApplicationTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
GO 
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Afghanistan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Albania')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Algeria')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Andorra')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Angola')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Antigua and Barbuda')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Argentina')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Armenia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Austria')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Azerbaijan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Bahrain')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Bangladesh')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Barbados')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Belarus')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Belgium')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Belize')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Benin')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Bhutan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Bolivia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Bosnia and Herzegovina')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Botswana')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Brazil')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Brunei')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Bulgaria')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Burkina Faso')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Burundi')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Cabo Verde')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Cambodia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Cameroon')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Canada')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Central African Republic')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Chad')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Channel Islands')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Chile')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'China')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Colombia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Comoros')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Congo')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Costa Rica')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Côte d''Ivoire')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Croatia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Cuba')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Cyprus')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Czech Republic')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Denmark')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Djibouti')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Dominica')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Dominican Republic')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'DR Congo')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Ecuador')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Egypt')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'El Salvador')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Equatorial Guinea')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Eritrea')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Estonia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Eswatini')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Ethiopia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Faeroe Islands')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Finland')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'France')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'French Guiana')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Gabon')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Gambia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Georgia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Germany')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Ghana')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Gibraltar')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Greece')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Grenada')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Guatemala')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Guinea')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Guinea-Bissau')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Guyana')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Haiti')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Holy See')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Honduras')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Hong Kong')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Hungary')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Iceland')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'India')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Indonesia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Iran')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Iraq')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Ireland')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Isle of Man')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Israel')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Italy')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Jamaica')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Japan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Jordan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Kazakhstan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Kenya')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Kuwait')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Kyrgyzstan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Laos')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Latvia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Lebanon')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Lesotho')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES (N'Liberia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Libya')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Liechtenstein')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Lithuania')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Luxembourg')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Macao')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Madagascar')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Malawi')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Malaysia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Maldives')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Mali')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Malta')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Mauritania')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Mauritius')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Mayotte')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Mexico')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Moldova')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Monaco')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Mongolia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Montenegro')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Morocco')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Mozambique')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Myanmar')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Namibia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Nepal')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Netherlands')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Nicaragua')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Niger')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Nigeria')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'North Korea')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'North Macedonia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Norway')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Oman')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Pakistan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Panama')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Paraguay')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Peru')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Philippines')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Poland')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Portugal')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Qatar')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Réunion')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Romania')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Russia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Rwanda')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Saint Helena')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Saint Kitts and Nevis')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Saint Lucia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Saint Vincent and the Grenadines')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'San Marino')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Sao Tome & Principe')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Saudi Arabia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Senegal')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Serbia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Seychelles')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Sierra Leone')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Singapore')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Slovakia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Slovenia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Somalia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'South Africa')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'South Korea')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'South Sudan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Spain')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Sri Lanka')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'State of Palestine')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Sudan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Suriname')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Sweden')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Switzerland')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Syria')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Taiwan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Tajikistan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Tanzania')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Thailand')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'The Bahamas')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Timor-Leste')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Togo')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Trinidad and Tobago')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Tunisia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Turkey')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Turkmenistan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Uganda')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Ukraine')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'United Arab Emirates')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'United Kingdom')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'United States')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Uruguay')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Uzbekistan')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Venezuela')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Vietnam')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Western Sahara')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Yemen')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Zambia')
GO
INSERT [dbo].[Countries] ([CountryName]) VALUES ( N'Zimbabwe')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF

INSERT [dbo].[LicenseClasses] ([ClassName], [ClassDescription], [MinimunAllowedAge], [DefaultValidityLength], [ClassFees]) VALUES (N'Class 1 - Small Motorcycle', N'It allows the driver to drive small motorcycles, It is suitable for motorcycles with small capacity and limited power.', 18, 5, 15.0000)
GO
INSERT [dbo].[LicenseClasses] ([ClassName], [ClassDescription], [MinimunAllowedAge], [DefaultValidityLength], [ClassFees]) VALUES (N'Class 2 - Heavy Motorcycle License', N'Heavy Motorcycle License (Large Motorcycle License)', 21, 5, 30.0000)
GO
INSERT [dbo].[LicenseClasses] ([ClassName], [ClassDescription], [MinimunAllowedAge], [DefaultValidityLength], [ClassFees]) VALUES (N'Class 3 - Ordinary driving license', N'Ordinary driving license (car licence)', 18, 10, 20.0000)
GO
INSERT [dbo].[LicenseClasses] ([ClassName], [ClassDescription], [MinimunAllowedAge], [DefaultValidityLength], [ClassFees]) VALUES (N'Class 4 - Commercial', N'Commercial driving license (taxi/limousine)', 21, 10, 200.0000)
GO
INSERT [dbo].[LicenseClasses] ([ClassName], [ClassDescription], [MinimunAllowedAge], [DefaultValidityLength], [ClassFees]) VALUES (N'Class 5 - Agricultural', N'Agricultural and work vehicles used in farming or construction, (tractors / tillage machinery)', 21, 10, 50.0000)
GO
INSERT [dbo].[LicenseClasses] ([ClassName], [ClassDescription], [MinimunAllowedAge], [DefaultValidityLength], [ClassFees]) VALUES (N'Class 6 - Small and medium bus', N'Small and medium bus license', 21, 10, 250.0000)
GO
INSERT [dbo].[LicenseClasses] ([ClassName], [ClassDescription], [MinimunAllowedAge], [DefaultValidityLength], [ClassFees]) VALUES (N'Class 7 - Truck and heavy vehicle', N'Truck and heavy vehicle license', 21, 10, 300.0000)

INSERT [dbo].[TestTypes] ([TestTypeTitle], [TestTypeDescription], [TestTypeFees]) VALUES ('Vision Test', N'This assesses the applicants visual acuity to ensure they have sufficient vision to drive safely.', 10.0000)
INSERT [dbo].[TestTypes] (TestTypeID,[TestTypeTitle], [TestTypeDescription], [TestTypeFees]) VALUES (2,'Written (Theory) Test', N'This test assesses the applicants knowledge of traffic rules, road signs, and driving regulations. It typically consists of multiple-choice questions, and the applicant must select the correct answer(s). The written test aims to ensure that the applicant understands the rules of the road and can apply them in various driving scenarios.', 20.0000)
INSERT [dbo].[TestTypes] (TestTypeID,[TestTypeTitle], [TestTypeDescription], [TestTypeFees]) VALUES (3,'Practical (Street) Test', N'This test evaluates the applicants driving skills and ability to operate a motor vehicle safely on public roads. A licensed examiner accompanies the applicant in the vehicle and observes their driving performance.', 30.0000)

ALTER TABLE [dbo].[Applications] ADD  CONSTRAINT [DF_Applications_ApplicationStatus]  DEFAULT ((1)) FOR [ApplicationStatus]
GO
ALTER TABLE [dbo].[DetainedLicenses] ADD  CONSTRAINT [DF_DetainedLicenses_IsReleased]  DEFAULT ((0)) FOR [IsReleased]
GO
ALTER TABLE [dbo].[LicenseClasses] ADD  CONSTRAINT [DF_LicenseClasses_Age]  DEFAULT ((18)) FOR [MinimunAllowedAge]
GO
ALTER TABLE [dbo].[LicenseClasses] ADD  CONSTRAINT [DF_LicenseClasses_DefaultPeriodLength]  DEFAULT ((1)) FOR [DefaultValidityLength]
GO
ALTER TABLE [dbo].[LicenseClasses] ADD  CONSTRAINT [DF_LicenseClasses_ClassFees]  DEFAULT ((0)) FOR [ClassFees]
GO
ALTER TABLE [dbo].[Licenses] ADD  CONSTRAINT [DF_Licenses_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Licenses] ADD  CONSTRAINT [DF_Licenses_IssueReason]  DEFAULT ((1)) FOR [IssueReason]
GO
ALTER TABLE [dbo].[People] ADD  DEFAULT ((0)) FOR [Gendor]
GO
ALTER TABLE [dbo].[TestAppointments] ADD  CONSTRAINT [DF_TestAppointments_AppointmentLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_ApplicationPersonID] FOREIGN KEY([ApplicationPersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_ApplicationPersonID]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_ApplicationTypeID] FOREIGN KEY([ApplicationTypeID])
REFERENCES [dbo].[ApplicationTypes] ([ApplicationTypeID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_ApplicationTypeID]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [FK_Applications_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [FK_Applications_CreatedByUserID]
GO
ALTER TABLE [dbo].[DetainedLicenses]  WITH CHECK ADD  CONSTRAINT [FK_DetainedLicenses_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[DetainedLicenses] CHECK CONSTRAINT [FK_DetainedLicenses_CreatedByUserID]
GO
ALTER TABLE [dbo].[DetainedLicenses]  WITH CHECK ADD  CONSTRAINT [FK_DetainedLicenses_LicenseID] FOREIGN KEY([LicenseID])
REFERENCES [dbo].[Licenses] ([LicenseID])
GO
ALTER TABLE [dbo].[DetainedLicenses] CHECK CONSTRAINT [FK_DetainedLicenses_LicenseID]
GO
ALTER TABLE [dbo].[DetainedLicenses]  WITH CHECK ADD  CONSTRAINT [FK_DetainedLicenses_ReleaseApplicationID] FOREIGN KEY([ReleaseApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[DetainedLicenses] CHECK CONSTRAINT [FK_DetainedLicenses_ReleaseApplicationID]
GO
ALTER TABLE [dbo].[DetainedLicenses]  WITH CHECK ADD  CONSTRAINT [FK_DetainedLicenses_ReleasedByUserID] FOREIGN KEY([ReleasedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[DetainedLicenses] CHECK CONSTRAINT [FK_DetainedLicenses_ReleasedByUserID]
GO
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [FK_Drivers_CreatedByUserID]
GO
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [FK_Drivers_PersonID]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [FK_Licenses_ApplicationID] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [FK_Licenses_ApplicationID]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [FK_Licenses_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [FK_Licenses_CreatedByUserID]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [FK_Licenses_DriverID] FOREIGN KEY([DriverID])
REFERENCES [dbo].[Drivers] ([DriverID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [FK_Licenses_DriverID]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [FK_Licenses_LicenseClassID] FOREIGN KEY([LicenseClassID])
REFERENCES [dbo].[LicenseClasses] ([LicenseClassID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [FK_Licenses_LicenseClassID]
GO
ALTER TABLE [dbo].[LocalDrivingLicenseApplications]  WITH CHECK ADD  CONSTRAINT [FK_LocalDrivingLicenseApplications_ApplicationID] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenseApplications] CHECK CONSTRAINT [FK_LocalDrivingLicenseApplications_ApplicationID]
GO
ALTER TABLE [dbo].[LocalDrivingLicenseApplications]  WITH CHECK ADD  CONSTRAINT [FK_LocalDrivingLicenseApplications_LicenseClassID] FOREIGN KEY([LicenseClassID])
REFERENCES [dbo].[LicenseClasses] ([LicenseClassID])
GO
ALTER TABLE [dbo].[LocalDrivingLicenseApplications] CHECK CONSTRAINT [FK_LocalDrivingLicenseApplications_LicenseClassID]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_NationalityCountryID] FOREIGN KEY([NationalityCountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_NationalityCountryID]
GO
ALTER TABLE [dbo].[TestAppointments]  WITH CHECK ADD  CONSTRAINT [FK_TestAppointments_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[TestAppointments] CHECK CONSTRAINT [FK_TestAppointments_CreatedByUserID]
GO
ALTER TABLE [dbo].[TestAppointments]  WITH CHECK ADD  CONSTRAINT [FK_TestAppointments_LocalDrivingLicenseApplicationID] FOREIGN KEY([LocalDrivingLicenseApplicationID])
REFERENCES [dbo].[LocalDrivingLicenseApplications] ([LocalDrivingLicenseApplicationID])
GO
ALTER TABLE [dbo].[TestAppointments] CHECK CONSTRAINT [FK_TestAppointments_LocalDrivingLicenseApplicationID]
GO
ALTER TABLE [dbo].[TestAppointments]  WITH CHECK ADD  CONSTRAINT [FK_TestAppointments_RetakeTestApplicationID] FOREIGN KEY([RetakeTestApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[TestAppointments] CHECK CONSTRAINT [FK_TestAppointments_RetakeTestApplicationID]
GO
ALTER TABLE [dbo].[TestAppointments]  WITH CHECK ADD  CONSTRAINT [FK_TestAppointments_TestTypeID] FOREIGN KEY([TestTypeID])
REFERENCES [dbo].[TestTypes] ([TestTypeID])
GO
ALTER TABLE [dbo].[TestAppointments] CHECK CONSTRAINT [FK_TestAppointments_TestTypeID]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_CreatedByUserID] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_CreatedByUserID]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [FK_Tests_TestAppointmentID] FOREIGN KEY([TestAppointmentID])
REFERENCES [dbo].[TestAppointments] ([TestAppointmentID])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [FK_Tests_TestAppointmentID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PersonID]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-New, 2-Canceled, 3-Completed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Applications', @level2type=N'COLUMN',@level2name=N'ApplicationStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-FirstTime, 2-Renew, 3-Replacement for Damaged, 4- Replacement for Lost.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Licenses', @level2type=N'COLUMN',@level2name=N'IssueReason'
GO
