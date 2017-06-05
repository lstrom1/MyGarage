/* Check if database already exists and delete it if it does exist*/
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'mygarage') 

DROP DATABASE[mygarage] 
GO

CREATE DATABASE [mygarage]
GO

USE [mygarage]
GO

/**** Object: Create Table [dbo].[owner] ****/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[owner]
(
   [ownerID] int IDENTITY(1, 1)  NOT NULL,
   [lastName] varchar(45)  NOT NULL,
   [firstName] varchar(45)  NOT NULL,
   [streetAddress] varchar(75)  NOT NULL,
   [city] varchar(65)  NOT NULL,
   [state] varchar(2)  NOT NULL,
   [zip] varchar(5)  NOT NULL,
   [phoneNumber] varchar(12)  NOT NULL,
   [emailAddress] varchar(150) NOT NULL,
CONSTRAINT [PK_owner_ownerID] PRIMARY KEY CLUSTERED ([ownerID])
)

GO

/**** Object: Create Table [dbo].[vehicle] ****/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[vehicle]
(
   [vehicleID] int IDENTITY(1, 1)  NOT NULL,
   [vin] varchar(17)  NOT NULL,
   [make] varchar(45)  NOT NULL,
   [model] varchar(45)  NOT NULL,
   [vehicleYear] varchar(4)  NOT NULL,
CONSTRAINT [PK_vehicle_vehicleID] PRIMARY KEY CLUSTERED ([vehicleID])
)

GO

/**** Object: Create Table [dbo].[ownerVehicle] ****/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ownerVehicle]
(
   [ownerVehicleID] int IDENTITY(1, 1)  NOT NULL,
   [ownerID] int  NOT NULL,
   [vehicleID] int NOT NULL,
CONSTRAINT [PK_ownerVehicle_ownerVehicleID] PRIMARY KEY CLUSTERED ([ownerVehicleID]),
CONSTRAINT [fk_ownerVehicle_ownerID] FOREIGN KEY ([ownerID]) REFERENCES owner ([ownerID]),
CONSTRAINT [fk_ownerVehicle_vehicleID] FOREIGN KEY ([vehicleID]) REFERENCES vehicle ([vehicleID])  
)

GO

/**** Object: Create Table [dbo].[serviceCategory] ****/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[serviceCategory]
(
   [serviceCategoryID] int IDENTITY(1, 1)  NOT NULL,
   [categoryName] varchar(45)  NOT NULL,
   [numberOfDays] INT  NOT NULL,
   [mileageInterval] INT  NOT NULL,
CONSTRAINT [PK_serviceCategory_serviceCategoryID] PRIMARY KEY CLUSTERED ([serviceCategoryID])
)

GO

/**** Object: Create Table [dbo].[serviceRecord] ****/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[serviceRecord]
(
   [serviceRecordID] int IDENTITY(1, 1)  NOT NULL,
   [vehicleID] int NOT NULL,
   [dateOfService] date NOT NULL,
   [mileage] INT NOT NULL,
CONSTRAINT [PK_serviceRecord_serviceRecordID] PRIMARY KEY CLUSTERED ([serviceRecordID]),
CONSTRAINT [fk_serviceRecord_vehicleID] FOREIGN KEY ([vehicleID]) REFERENCES vehicle ([vehicleID]) 
)

GO
/**** Object: Create Table [dbo].[serviceRecordType] ****/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[serviceRecordType]
(
   [serviceRecordTypeID] int IDENTITY(1, 1)  NOT NULL,
   [serviceRecordID] int NOT NULL,
   [serviceCategoryID] int NOT NULL,
CONSTRAINT [PK_serviceRecordType_serviceRecordTypeID] PRIMARY KEY CLUSTERED ([serviceRecordTypeID]),
CONSTRAINT [fk_serviceRecordType_serviceRecordID] FOREIGN KEY ([serviceRecordID]) REFERENCES serviceRecord ([serviceRecordID]),
CONSTRAINT [fk_serviceRecordType_serviceCategoryID] FOREIGN KEY ([serviceCategoryID]) REFERENCES serviceCategory ([serviceCategoryID])
) 