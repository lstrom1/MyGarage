USE [CS6920-team5]
GO
/*** Owner Data ***/
INSERT [dbo].[owner] ([lastName], [firstName], [streetAddress], [city], [state], [zip], [phoneNumber], [emailAddress]) VALUES (N'Smith', N'Jeff', N'87 Cow Drive', N'Atlanta', N'GA', N'30332', N'555-555-5554', N'jeff.smith@gmail.com')
INSERT [dbo].[owner] ([lastName], [firstName], [streetAddress], [city], [state], [zip], [phoneNumber], [emailAddress]) VALUES (N'Simpson', N'Homer', N'742 Evergreen Terrace', N'Springfield', N'GA', N'30332', N'555-555-5544', N'homer.simpson@gmail.com')
INSERT [dbo].[owner] ([lastName], [firstName], [streetAddress], [city], [state], [zip], [phoneNumber], [emailAddress]) VALUES (N'Flanders', N'Ned', N'740 Evergreen Terrace', N'Springfield', N'GA', N'30332', N'555-555-3054', N'ned.flanders@gmail.com')
INSERT [dbo].[owner] ([lastName], [firstName], [streetAddress], [city], [state], [zip], [phoneNumber], [emailAddress]) VALUES (N'Burns', N'Mr.', N'87 Terrace', N'Springfield', N'GA', N'30332', N'555-555-6666', N'mr.burns@gmail.com')
INSERT [dbo].[owner] ([lastName], [firstName], [streetAddress], [city], [state], [zip], [phoneNumber], [emailAddress]) VALUES (N'Smithers', N'Waylon', N'87 Cow Drive', N'Springfield', N'GA', N'30332', N'555-555-6554', N'waylon.smithers@gmail.com')
INSERT [dbo].[owner] ([lastName], [firstName], [streetAddress], [city], [state], [zip], [phoneNumber], [emailAddress]) VALUES (N'Szslak', N'Moe', N'Moes Tavern', N'Springfield', N'GA', N'30332', N'555-555-5784', N'jeff.smith@gmail.com')
/*** Vehicle Data ***/
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'HONDAACCORDTEST01', N'Honda', N'Accord', N'2006')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'HONDAODYSSEYTEST2', N'Honda', N'Odyssey', N'2007')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'HONDACIVICTEST003', N'Honda', N'Civic', N'2008')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'HONDAPILOTTEST004', N'Honda', N'Pilot', N'2009')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'HONDACRVTEST00005', N'Honda', N'CRV', N'2010')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'HONDAELEMENT00006', N'Honda', N'Element', N'2011')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'NISSANMAXIMATEST7', N'Nissan', N'Maxima', N'2012')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'NISSANALTIMATEST8', N'Nissan', N'Altima', N'2013')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'NISSANMURANOTEST9', N'Nissan', N'Murano', N'2014')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'NISSAN350ZTEST010', N'Nissan', N'350Z', N'2015')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'VOLVOS60TEST00011', N'Volvo', N'S60', N'2006')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'VOLVOS40TEST00012', N'Volvo', N'S40', N'2007')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'VOLVOV70TEST00013', N'Volvo', N'S70', N'2008')
INSERT [dbo].[vehicle] ([vin], [make], [model], [vehicleYear]) VALUES (N'MINICOOPERTEST014', N'Mini', N'Cooper', N'2009')

/*** OwnerVehicle Data ***/
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (1, 1)
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (1, 2)
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (2, 3)
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (3, 4)
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (4, 5)
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (5, 6)
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (5, 11)
INSERT [dbo].[ownerVehicle] ([ownerID], [vehicleID]) VALUES (5, 10) 
/*** serviceCategory Data ***/
INSERT [dbo].[serviceCategory] ([categoryName], [numberOfDays], [mileageInterval]) VALUES (N'Oil Change', 90, 5000)
INSERT [dbo].[serviceCategory] ([categoryName], [numberOfDays], [mileageInterval]) VALUES (N'Tire Rotation', 180, 10000)
INSERT [dbo].[serviceCategory] ([categoryName], [numberOfDays], [mileageInterval]) VALUES (N'Replace Brake Pads', 365, 70000)
INSERT [dbo].[serviceCategory] ([categoryName], [numberOfDays], [mileageInterval]) VALUES (N'Replace Air Filter', 270, 30000)
INSERT [dbo].[serviceCategory] ([categoryName], [numberOfDays], [mileageInterval]) VALUES (N'Replace Rotors', 365, 70000)
INSERT [dbo].[serviceCategory] ([categoryName], [numberOfDays], [mileageInterval]) VALUES (N'Replace Battery', 270, 35000)
/*** serviceRecord Data ***/
INSERT [dbo].[serviceRecord] ([vehicleID], [dateOfService], [mileage]) VALUES (1, '2016-05-15', 200000)
INSERT [dbo].[serviceRecord] ([vehicleID], [dateOfService], [mileage]) VALUES (11, '2016-06-01', 180000)
INSERT [dbo].[serviceRecord] ([vehicleID], [dateOfService], [mileage]) VALUES (1, '2016-08-14', 205000)
INSERT [dbo].[serviceRecord] ([vehicleID], [dateOfService], [mileage]) VALUES (11, '2016-09-15', 185000)
INSERT [dbo].[serviceRecord] ([vehicleID], [dateOfService], [mileage]) VALUES (2, '2017-01-10', 176000)
/*** serviceRecordType ***/
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (1, 1)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (2, 1)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (3, 1)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (3, 2)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (4, 1)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (4, 2)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (5, 1)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (5, 2)
INSERT [dbo].[serviceRecordType] ([serviceRecordID], [serviceCategoryID]) VALUES (5, 4)