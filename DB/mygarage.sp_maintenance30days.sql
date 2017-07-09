USE [CS6920-team5];
GO

IF OBJECT_ID('usp_maintenanceNeededNumber30Days') IS NOT NULL
	DROP PROC usp_maintenanceNeededNumber30Days;
GO

CREATE PROCEDURE usp_maintenanceNeededNumber30Days

AS

	SELECT 	
		main1.Service, main1.FirstName, main1.LastName, main1.PhoneNumber, main1.EmailAddress,
		main1.VIN, main1.Model, main1.Make, main1.VehicleYear,
		MAX ( main1.Mileage ) AS MileageOnLastServiceDate,
		MAX ( main1.NextMileageOfService) AS MileageForService,
		MAX ( main1.LastServiceDate) AS ServiceDate,
		MAX (main1.EstimatedNextDateForService) AS EstimateDateNextService
	FROM 
		(SELECT
			SC.categoryName AS Service, O.firstName AS FirstName, O.lastName AS LastName, O.emailAddress AS EmailAddress,
			O.phoneNumber AS PhoneNumber, V.vin AS VIN, V.model AS Model, V.make AS Make, V.vehicleYear AS VehicleYear,
			SR.dateOfService AS LastServiceDate,
			DATEADD(dd, SC.numberOfdays, SR.dateOfService) AS EstimatedNextDateForService,
			SR.mileage AS Mileage,
		    (SR.mileage + SC.mileageInterval) AS NextMileageOfService	
		FROM
			serviceRecordType SRT
			JOIN serviceCategory SC ON SRT.serviceCategoryID = SC.serviceCategoryID
			JOIN serviceRecord SR ON SRT.serviceRecordID = SR.serviceRecordID
			JOIN vehicle V ON SR.vehicleID = V.vehicleID
			LEFT JOIN ownerVehicle OV ON V.vehicleID = OV.vehicleID
			LEFT JOIN owner O ON OV.ownerID = O.ownerID
		) main1
	WHERE main1.EstimatedNextDateForService < GETDATE() OR main1.EstimatedNextDateForService < DATEADD(dd, 30, GETDATE())
	GROUP BY
		main1.VIN, main1.Service, main1.FirstName, main1.LastName, main1.PhoneNumber, main1.EmailAddress,
		main1.Model, main1.Make, main1.VehicleYear
GO