
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/11/2019 00:39:30
-- Generated from EDMX file: F:\SPAEMSGIT\SMS.Core\SPADataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_SPADevelopement];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[Academic].[Class]', 'U') IS NOT NULL
    DROP TABLE [Academic].[Class];
GO
IF OBJECT_ID(N'[Academic].[ClassTeacherAllocation]', 'U') IS NOT NULL
    DROP TABLE [Academic].[ClassTeacherAllocation];
GO
IF OBJECT_ID(N'[Academic].[Section]', 'U') IS NOT NULL
    DROP TABLE [Academic].[Section];
GO
IF OBJECT_ID(N'[Master].[AcademicMaster]', 'U') IS NOT NULL
    DROP TABLE [Master].[AcademicMaster];
GO
IF OBJECT_ID(N'[Master].[BloodGroup]', 'U') IS NOT NULL
    DROP TABLE [Master].[BloodGroup];
GO
IF OBJECT_ID(N'[Master].[CasteMaster]', 'U') IS NOT NULL
    DROP TABLE [Master].[CasteMaster];
GO
IF OBJECT_ID(N'[Master].[Category]', 'U') IS NOT NULL
    DROP TABLE [Master].[Category];
GO
IF OBJECT_ID(N'[Master].[GenderMaster]', 'U') IS NOT NULL
    DROP TABLE [Master].[GenderMaster];
GO
IF OBJECT_ID(N'[Master].[ReligionMaster]', 'U') IS NOT NULL
    DROP TABLE [Master].[ReligionMaster];
GO
IF OBJECT_ID(N'[Setting].[InstituteDetail]', 'U') IS NOT NULL
    DROP TABLE [Setting].[InstituteDetail];
GO
IF OBJECT_ID(N'[Student].[DepositThrough]', 'U') IS NOT NULL
    DROP TABLE [Student].[DepositThrough];
GO
IF OBJECT_ID(N'[Student].[FeeHeadMaster]', 'U') IS NOT NULL
    DROP TABLE [Student].[FeeHeadMaster];
GO
IF OBJECT_ID(N'[Student].[StudentClassMapping]', 'U') IS NOT NULL
    DROP TABLE [Student].[StudentClassMapping];
GO
IF OBJECT_ID(N'[Student].[StudentFeeAllocation]', 'U') IS NOT NULL
    DROP TABLE [Student].[StudentFeeAllocation];
GO
IF OBJECT_ID(N'[Student].[StudentFeeAllocationMaster]', 'U') IS NOT NULL
    DROP TABLE [Student].[StudentFeeAllocationMaster];
GO
IF OBJECT_ID(N'[Student].[StudentFeeDeposit]', 'U') IS NOT NULL
    DROP TABLE [Student].[StudentFeeDeposit];
GO
IF OBJECT_ID(N'[Student].[StudentMaster]', 'U') IS NOT NULL
    DROP TABLE [Student].[StudentMaster];
GO
IF OBJECT_ID(N'[Subject].[SubjectMaster]', 'U') IS NOT NULL
    DROP TABLE [Subject].[SubjectMaster];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(200)  NULL,
    [Code] varchar(50)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'ClassTeacherAllocations'
CREATE TABLE [dbo].[ClassTeacherAllocations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassId] int  NULL,
    [SectionId] int  NULL,
    [TeacherId] int  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'Sections'
CREATE TABLE [dbo].[Sections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClassId] int  NOT NULL,
    [Name] varchar(200)  NULL,
    [Code] varchar(50)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'InstituteDetails'
CREATE TABLE [dbo].[InstituteDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Address] varchar(500)  NOT NULL,
    [Phone] varchar(20)  NULL,
    [Mobile] varchar(20)  NULL,
    [EmailAddress] varchar(20)  NULL,
    [AdminContactPersonName] varchar(50)  NULL,
    [AdminPhone] varchar(20)  NULL,
    [InstituteImage] varchar(200)  NULL,
    [InstituteCode] varchar(50)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [Createddate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'SubjectMasters'
CREATE TABLE [dbo].[SubjectMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [SubjectCode] varchar(50)  NULL,
    [Description] varchar(500)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'AcademicMasters'
CREATE TABLE [dbo].[AcademicMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [IsActive] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdateDate] datetime  NULL,
    [UpdatedBy] int  NULL
);
GO

-- Creating table 'BloodGroups'
CREATE TABLE [dbo].[BloodGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdateDate] datetime  NULL,
    [UpdatedBy] int  NULL
);
GO

-- Creating table 'CasteMasters'
CREATE TABLE [dbo].[CasteMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdateDate] datetime  NULL,
    [UpdatedBy] int  NULL
);
GO

-- Creating table 'GenderMasters'
CREATE TABLE [dbo].[GenderMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdateDate] datetime  NULL,
    [UpdatedBy] int  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'StudentClassMappings'
CREATE TABLE [dbo].[StudentClassMappings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [classId] int  NOT NULL,
    [sectionId] int  NOT NULL,
    [StudentId] int  NOT NULL,
    [AcademicYear] int  NOT NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'StudentMasters'
CREATE TABLE [dbo].[StudentMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(200)  NOT NULL,
    [FatherName] varchar(200)  NULL,
    [MotherName] varchar(200)  NULL,
    [RegistrationNumber] varchar(50)  NULL,
    [RollNumber] varchar(50)  NULL,
    [DateOfBirth] datetime  NULL,
    [GenderId] int  NULL,
    [BloodGroup] int  NULL,
    [CategoryId] int  NULL,
    [CastId] int  NULL,
    [ReligionId] int  NULL,
    [AdharCardNumber] varchar(100)  NULL,
    [FatherPhone] varchar(20)  NULL,
    [ContactPhone] varchar(20)  NULL,
    [EmailId] varchar(100)  NULL,
    [ClassId] int  NOT NULL,
    [SectionId] int  NOT NULL,
    [Adddress] varchar(500)  NULL,
    [AcademicYear] int  NOT NULL,
    [IsActive] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdateDate] datetime  NULL,
    [UpdatedBy] int  NULL
);
GO

-- Creating table 'FeeHeadMasters'
CREATE TABLE [dbo].[FeeHeadMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HeadName] varchar(100)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Updatedby] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'ReligionMasters'
CREATE TABLE [dbo].[ReligionMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [UpdateDate] datetime  NULL,
    [UpdatedBy] int  NULL
);
GO

-- Creating table 'StudentFeeAllocationMasters'
CREATE TABLE [dbo].[StudentFeeAllocationMasters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AllocationTypeId] int  NOT NULL,
    [AllocationOn] int  NOT NULL,
    [HeadTypeId] int  NOT NULL,
    [Amount] decimal(18,2)  NOT NULL,
    [DiscountPercenatge] decimal(18,2)  NULL,
    [DiscountAmount] decimal(18,2)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [UpdatedBy] int  NULL,
    [UpDatedDate] datetime  NULL,
    [FeeType] int  NULL
);
GO

-- Creating table 'StudentFeeAllocations'
CREATE TABLE [dbo].[StudentFeeAllocations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NOT NULL,
    [HeadTypeId] int  NOT NULL,
    [AllotedAmount] decimal(18,2)  NOT NULL,
    [DiscountAmount] decimal(18,2)  NOT NULL,
    [DiscountPercentage] decimal(18,2)  NOT NULL,
    [NetFeeAmount] decimal(38,6)  NULL,
    [PaymentFeeType] int  NOT NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [Updatedby] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'DepositThroughs'
CREATE TABLE [dbo].[DepositThroughs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentFeeDepositId] int  NULL,
    [DepositFor] varchar(100)  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- Creating table 'StudentFeeDeposits'
CREATE TABLE [dbo].[StudentFeeDeposits] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StudentId] int  NULL,
    [HeadTypeId] int  NULL,
    [AmountDeposit] decimal(18,2)  NULL,
    [AdditionalDiscount] decimal(18,2)  NULL,
    [DiscountDescription] varchar(500)  NULL,
    [DepositThrough] int  NULL,
    [DepositFor] int  NULL,
    [IsActive] int  NOT NULL,
    [CreatedBy] int  NOT NULL,
    [CreatedDate] datetime  NULL,
    [UpdatedBy] int  NULL,
    [UpdatedDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassTeacherAllocations'
ALTER TABLE [dbo].[ClassTeacherAllocations]
ADD CONSTRAINT [PK_ClassTeacherAllocations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [PK_Sections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InstituteDetails'
ALTER TABLE [dbo].[InstituteDetails]
ADD CONSTRAINT [PK_InstituteDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubjectMasters'
ALTER TABLE [dbo].[SubjectMasters]
ADD CONSTRAINT [PK_SubjectMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AcademicMasters'
ALTER TABLE [dbo].[AcademicMasters]
ADD CONSTRAINT [PK_AcademicMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BloodGroups'
ALTER TABLE [dbo].[BloodGroups]
ADD CONSTRAINT [PK_BloodGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CasteMasters'
ALTER TABLE [dbo].[CasteMasters]
ADD CONSTRAINT [PK_CasteMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GenderMasters'
ALTER TABLE [dbo].[GenderMasters]
ADD CONSTRAINT [PK_GenderMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentClassMappings'
ALTER TABLE [dbo].[StudentClassMappings]
ADD CONSTRAINT [PK_StudentClassMappings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentMasters'
ALTER TABLE [dbo].[StudentMasters]
ADD CONSTRAINT [PK_StudentMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeeHeadMasters'
ALTER TABLE [dbo].[FeeHeadMasters]
ADD CONSTRAINT [PK_FeeHeadMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReligionMasters'
ALTER TABLE [dbo].[ReligionMasters]
ADD CONSTRAINT [PK_ReligionMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentFeeAllocationMasters'
ALTER TABLE [dbo].[StudentFeeAllocationMasters]
ADD CONSTRAINT [PK_StudentFeeAllocationMasters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentFeeAllocations'
ALTER TABLE [dbo].[StudentFeeAllocations]
ADD CONSTRAINT [PK_StudentFeeAllocations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DepositThroughs'
ALTER TABLE [dbo].[DepositThroughs]
ADD CONSTRAINT [PK_DepositThroughs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentFeeDeposits'
ALTER TABLE [dbo].[StudentFeeDeposits]
ADD CONSTRAINT [PK_StudentFeeDeposits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------