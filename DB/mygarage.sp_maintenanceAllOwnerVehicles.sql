USE [CS6920-team5];
GO

IF OBJECT_ID('usp_maintenanceAllOwnerVehicles') IS NOT NULL
	DROP PROC usp_maintenanceAllOwnerVehicles;
GO

CREATE PROCEDURE usp_maintenanceAllOwnerVehicles
	@ownerID INT

AS

	IF @ownerID = ' ' 
		THROW 50001, 'Owner must be selected', 1;
	IF @ownerID IS NULL
		THROW 50001, 'Owner cannot be null', 1;
	
	SELECT
		O.firstName,
		O.lastName,
		O.phoneNumber,
		O.emailAddress,
		V.vin,
		V.make,
		V.model,
		SR.dateOfService,
		SR.mileage,
		SC.categoryName 
	FROM
		owner O
		LEFT JOIN ownerVehicle OV ON O.ownerID = OV.ownerID
		LEFT JOIN vehicle V ON OV.vehicleID = V.vehicleID
		LEFT OUTER JOIN serviceRecord SR ON V.vehicleID = SR.vehicleID
		LEFT OUTER JOIN serviceRecordType SRT ON SR.serviceRecordID = SRT.serviceRecordID
		LEFT JOIN serviceCategory SC ON SRT.serviceCategoryID = SRT.serviceCategoryID 
	WHERE
		O.ownerID = @ownerID
	GROUP BY
		O.firstName,
		O.lastName,
		O.phoneNumber,
		O.emailAddress,
		V.vin,
		V.make,
		V.model,
		SR.dateOfService,
		SR.mileage,
		SC.categoryName 	
	ORDER BY
		SR.dateOfService DESC
GO
