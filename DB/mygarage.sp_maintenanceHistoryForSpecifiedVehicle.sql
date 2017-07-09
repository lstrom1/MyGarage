USE [CS6920-team5];
GO

IF OBJECT_ID('usp_maintenanceHistoryForSpecifiedVehicle') IS NOT NULL
	DROP PROC usp_maintenanceHistoryForSpecifiedVehicle;
GO

CREATE PROCEDURE usp_maintenanceHistoryForSpecifiedVehicle
	@vehicleID INT

AS

	IF @vehicleID = ' ' 
		THROW 50001, 'Vehicle must be selected', 1;
	IF @vehicleID IS NULL
		THROW 50001, 'Vehicle cannot be null', 1;
	
	SELECT
		v.make,
		v.model,
		v.vehicleYear,
		v.vin,
		sr.dateOfService,
		sr.mileage,
		sc.categoryName
	FROM
		vehicle AS v
	JOIN serviceRecord AS sr
	ON v.vehicleID = sr.vehicleID 
	JOIN serviceRecordType AS srt
	ON sr.serviceRecordID = srt.serviceRecordID 
	JOIN dbo.serviceCategory AS sc
	ON srt.serviceCategoryID = sc.serviceCategoryID
	WHERE V.vehicleID = @vehicleID
	GROUP BY
		v.make,
		v.model,
		v.vehicleYear,
		v.vin,
		sr.dateOfService,
		sr.mileage,
		sc.categoryName
	ORDER BY sr.dateOfService DESC

GO
	