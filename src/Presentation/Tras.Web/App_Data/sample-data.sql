
--dbo.Ranks
insert dbo.Ranks(Name,Deleted) values
				('colonel',0),
				('lieutenant colonel',0),
				('Major',0),
				('Captain',0),
				('MWO',0),
				('Master warrant officer',0),
				('warrant officer',0),
				('Sargent',0),
				('CSO-1',0 ),
				('CSO-2',0),
				('CSO-3',0)
--dbo.ArmsDepartments				
insert dbo.Departments(Name,Deleted) values
				('AC',0),
				('ARTY',0),
				('SIG',0),
				('ASC',0),
				('AM',0),
				('INF',0)
			
--dbo.Directors			
insert dbo.Directors(Name,Deleted) values
				('MT Director',0),
				('MO Director',0),
				('CAS Director',0)
--dbo.Cantonments
insert dbo.Units(Name,Deleted) values
				('Dhaka Cantonment',0),
				('Mirpur Cantonment',0),
				('Savar Cantonment',0),
				('Bagura Cantonment',0),
				('Rangpur Cantonment',0),
				('Comilla Cantonment',0),
				('Chittagonj Cantonment',0)
				
-- dbo.Sys_Lookup
				
insert dbo.Sys_Lookup(LookupType,[Key],Value,[Description],[Order],Deleted) values
				('PERSON_TYPE','1','Army','N/A',1,0),
				('PERSON_TYPE','2','Civil','N/A',2,0),
				('CATEGORY','1','Officer','N/A',1,0),
				('CATEGORY','2','Soldier','N/A',2,0),
				
				('JOB_TYPE','1','Posted','N/A',1,0),
				('JOB_TYPE','2','Attested','N/A',2,0),
				('JOB_TYPE','3','Getting Ration','N/A',3,0),
				('JOB_TYPE','4','Mission','N/A',4,0),
				('FAMILY_TYPE','1','Separate','N/A',1,0),
				('FAMILY_TYPE','2','Join Family','N/A',2,0),
				('MARITAL_STATUS','1','Married','N/A',1,0),
				('MARITAL_STATUS','2','Unmarried','N/A',2,0),
				('GENDER','1','Male','N/A',1,0),
				('GENDER','2','Female','N/A',2,0)
				


-- Person data
INSERT INTO [dbo].[Person]
           ([PersonalNo],[PersonTypeKey],[CategoryKey],[FullName],[JoiningDate],[DepartmentId],[RankId],[DirectorId]
           ,[StdP1No],[StdP1NoDate],[FamilyTypeKey],[GenderKey],[MaritalStatusKey],[UnitId],[JobTypeKey],[Deleted])
     VALUES
           ('10001','1','1','Md. Shafiul Islam','2015-03-01',1,3,1,'STD-001','2015-03-01','2','1','1',1,'1',0),
           ('10002','1','1','Md.Mahmuddullah Sarker','2015-03-01',2,2,1,'STD-002','2015-03-01','2','1','1',1,'1',0),
           ('10003','1','1','Md.Mezbah Uddin Khan','2015-03-01',3,1,2,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10004','1','1','Md. Monjurul Islam','2015-03-01',4,3,2,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10005','1','1','Md. Monjurul Islam','2015-03-01',4,3,2,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10006','1','1','Md.Shahin Mandal','2015-03-01',4,4,3,'STD-003','2015-03-01','2','1','1',1,'1',0),
           
           ('10007','1','1','Abdus Samad','2015-03-01',4,5,3,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10008','1','1','Md.Bazlur Rashid','2015-03-01',4,6,3,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10009','1','1','Mr.Ziaur Rahman','2015-03-01',4,6,3,'STD-003','2015-03-01','2','1','1',1,'1',0),
           
           ('10010','1','1','Md. Abu Bakor Siddiq','2015-03-01',3,5,2,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10011','1','1','Md.Jahangir Hossain','2015-03-01',3,6,2,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10012','1','1','Md.Habibur Rahman','2015-03-01',3,6,2,'STD-003','2015-03-01','2','1','1',1,'1',0),
           
           ('10013','1','1','Md. Sanowar Hossain','2015-03-01',2,5,1,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10014','1','1','Md.Shahidul Islam','2015-03-01',2,6,1,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10015','1','1','Md.Delwar Hossain','2015-03-01',2,6,1,'STD-003','2015-03-01','2','1','1',1,'1',0),
           
           ('10016','2','','Md.Zakir Hossen','2015-03-01',2,9,1,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10017','2','','Md.Radwanur Rasid','2015-03-01',4,10,1,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10018','2','','Md. Rafiqul Islam','2015-03-01',3,11,1,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10019','2','','Md.Abdur Razzak','2015-03-01',1,9,1,'STD-003','2015-03-01','2','1','1',1,'1',0),
           ('10020','2','','Md.Abdul Wadud Talukder','2015-03-01',5,10,1,'STD-003','2015-03-01','2','1','1',1,'1',0)

--  Family Info
INSERT INTO [dbo].[FamilyInfos]([PersonId],[Own],[Spouse],[KidsMinor],[KidsHalf],[KidsAdult],[BatMan],[Deleted])
     VALUES(1,1,1,0,1,1,1,0),
           (2,1,1,1,1,0,1,0),
           (3,1,1,0,1,1,1,0),
           (4,1,1,1,1,1,1,0),
           (5,1,1,0,1,1,1,0),
           (6,1,1,0,1,1,1,0),
           (7,1,1,0,1,1,0,0),
           (8,1,1,0,1,1,0,0),
           (9,1,1,0,2,1,0,0),
           (10,1,1,0,1,1,0,0),
           (11,1,1,0,1,1,0,0),
           (12,1,1,0,1,2,0,0),
           (13,1,1,0,1,1,0,0),
           (14,1,1,0,1,1,0,0),
           (15,1,1,0,1,1,0,0),
           (16,1,1,0,2,1,0,0),
           (17,1,1,0,1,1,0,0),
           (18,1,1,0,2,1,0,0),
           (19,1,1,0,2,1,0,0),
           (20,1,1,1,1,1,0,0)

-- Ration Category
GO
SET IDENTITY_INSERT [dbo].[RationItemCategories] ON
INSERT [dbo].[RationItemCategories] ([CategoryId], [CategoryName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, N'Ration Item', NULL, 0, NULL, NULL)
INSERT [dbo].[RationItemCategories] ([CategoryId], [CategoryName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, N'Ration Spicy Item', NULL, 0, NULL, NULL)
INSERT [dbo].[RationItemCategories] ([CategoryId], [CategoryName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (3, N'Ration Fresh Item', NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RationItemCategories] OFF


/****** Object:  Table [dbo].[RationHeads]    Script Date: 09/22/2015 00:30:24 ******/
GO
SET IDENTITY_INSERT [dbo].[RationHeads] ON
INSERT [dbo].[RationHeads] ([HeadId], [HeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, N'Free', NULL, 0, NULL, NULL)
INSERT [dbo].[RationHeads] ([HeadId], [HeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, N'Subsidy', NULL, 0, NULL, NULL)
INSERT [dbo].[RationHeads] ([HeadId], [HeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (3, N'Normal', NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RationHeads] OFF


/****** Object:  Table [dbo].[RationItems]    Script Date: 09/22/2015 00:30:24 ******/
GO
SET IDENTITY_INSERT [dbo].[RationItems] ON
INSERT [dbo].[RationItems] ([ItemId], [CategoryId], [ItemName], [SoldierQty], [GeneralQty], [HalfQty], [MinorQty], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, 1, N'Rice', CAST(483.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(225.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL)
INSERT [dbo].[RationItems] ([ItemId], [CategoryId], [ItemName], [SoldierQty], [GeneralQty], [HalfQty], [MinorQty], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, 1, N'Atta', CAST(280.00 AS Decimal(18, 2)), CAST(260.00 AS Decimal(18, 2)), CAST(130.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL)
INSERT [dbo].[RationItems] ([ItemId], [CategoryId], [ItemName], [SoldierQty], [GeneralQty], [HalfQty], [MinorQty], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (3, 1, N'E.Oil', CAST(90.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL)
INSERT [dbo].[RationItems] ([ItemId], [CategoryId], [ItemName], [SoldierQty], [GeneralQty], [HalfQty], [MinorQty], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (4, 1, N'Sugar', CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL)
INSERT [dbo].[RationItems] ([ItemId], [CategoryId], [ItemName], [SoldierQty], [GeneralQty], [HalfQty], [MinorQty], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (5, 1, N'Dal', CAST(70.00 AS Decimal(18, 2)), CAST(70.00 AS Decimal(18, 2)), CAST(35.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RationItems] OFF

/****** Object:  Table [dbo].[RationSubHeads]    Script Date: 09/22/2015 00:30:24 ******/
GO
SET IDENTITY_INSERT [dbo].[RationSubHeads] ON
INSERT [dbo].[RationSubHeads] ([SubHeadId], [HeadId], [SubHeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, 1, N'Free for Mess', NULL, 0, NULL, NULL)
INSERT [dbo].[RationSubHeads] ([SubHeadId], [HeadId], [SubHeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, 1, N'Free for Home', NULL, 0, NULL, NULL)
INSERT [dbo].[RationSubHeads] ([SubHeadId], [HeadId], [SubHeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (3, 2, N'Subsidy Officer Single', NULL, 0, NULL, NULL)
INSERT [dbo].[RationSubHeads] ([SubHeadId], [HeadId], [SubHeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (4, 2, N'Subsidy Officer Married Family', NULL, 0, NULL, NULL)
INSERT [dbo].[RationSubHeads] ([SubHeadId], [HeadId], [SubHeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (5, 2, N'Subsidy Soldier Family', NULL, 0, NULL, NULL)
INSERT [dbo].[RationSubHeads] ([SubHeadId], [HeadId], [SubHeadName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (6, 3, N'Normal For Civilian', NULL, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[RationSubHeads] OFF

/****** Object:  Table [dbo].[Packages]    Script Date: 09/22/2015 00:30:24 ******/
GO
SET IDENTITY_INSERT [dbo].[Packages] ON
INSERT [dbo].[Packages] ([PackageId], [PackageCode], [SubHeadId], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, N'Officer-01', 4, 1, 0, NULL, NULL)
INSERT [dbo].[Packages] ([PackageId], [PackageCode], [SubHeadId], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, N'S.Fly-02  ', 5, 1, 0, NULL, NULL)
INSERT [dbo].[Packages] ([PackageId], [PackageCode], [SubHeadId], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (3, N'Civil-03  ', 6, 1, 0, NULL, NULL)
INSERT [dbo].[Packages] ([PackageId], [PackageCode], [SubHeadId], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (4, N'S.Home-04 ', 2, 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Packages] OFF

/****** Object:  Table [dbo].[PackageItems]    Script Date: 09/22/2015 00:30:24 ******/
GO
SET IDENTITY_INSERT [dbo].[PackageItems] ON
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (1, 1, 1, CAST(2.50 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (2, 2, 1, CAST(3.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (3, 3, 1, CAST(6.50 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (4, 4, 1, CAST(8.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (6, 5, 1, CAST(3.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (7, 1, 2, CAST(2.50 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (8, 2, 2, CAST(3.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (9, 3, 2, CAST(6.50 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (10, 4, 2, CAST(8.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (13, 1, 3, CAST(14.50 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (14, 2, 3, CAST(15.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (15, 3, 3, CAST(18.50 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
INSERT [dbo].[PackageItems] ([PackageItemId], [RationItemId], [PackageId], [Price], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId],[IsApplicableForBatMan]) VALUES (16, 4, 3, CAST(20.00 AS Decimal(18, 2)), NULL, 0, NULL, NULL,0)
SET IDENTITY_INSERT [dbo].[PackageItems] OFF

-- Person Package
INSERT INTO [dbo].[PersonPackages]
           ([PersonId],[PackageId],[StartDate],[IsApproved],[Deleted])
     VALUES
           (1,1,'2015-01-01',1,0),
           (2,1,'2015-04-01',1,0),
           (3,1,'2015-04-01',1,0),
           (4,1,'2015-04-01',1,0),
           (17,3,'2015-04-01',1,0),
           (18,3,'2015-04-01',1,0),
           (19,3,'2015-04-01',1,0)

GO
SET IDENTITY_INSERT [dbo].[Messes] ON
INSERT [dbo].[Messes] ([MessId], [MessName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, N'Mess No One', 1, 0, NULL, NULL)
INSERT [dbo].[Messes] ([MessId], [MessName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, N'Mess No Two', 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Messes] OFF

GO
SET IDENTITY_INSERT [dbo].[Rooms] ON
INSERT [dbo].[Rooms] ([RoomId], [MessId], [RoomName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, 1, N'Rome-01', 1, 0, NULL, NULL)
INSERT [dbo].[Rooms] ([RoomId], [MessId], [RoomName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, 1, N'Rome-02', 1, 0, NULL, NULL)
INSERT [dbo].[Rooms] ([RoomId], [MessId], [RoomName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (3, 2, N'Rome-01', 1, 0, NULL, NULL)
INSERT [dbo].[Rooms] ([RoomId], [MessId], [RoomName], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (4, 2, N'Rome-02', 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Rooms] OFF

GO
SET IDENTITY_INSERT [dbo].[Allotments] ON
INSERT [dbo].[Allotments] ([AllotmentId], [PersonId], [RoomId], [StarDate], [EndDate], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (1, 16, 1, CAST(0x0000A4E700000000 AS DateTime), CAST(0x0000A67200000000 AS DateTime), 1, 0, NULL, NULL)
INSERT [dbo].[Allotments] ([AllotmentId], [PersonId], [RoomId], [StarDate], [EndDate], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (2, 15, 2, CAST(0x0000A4E700000000 AS DateTime), CAST(0x0000A67200000000 AS DateTime), 1, 0, NULL, NULL)
INSERT [dbo].[Allotments] ([AllotmentId], [PersonId], [RoomId], [StarDate], [EndDate], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (3, 14, 3, CAST(0x0000A4E700000000 AS DateTime), CAST(0x0000A67200000000 AS DateTime), 1, 0, NULL, NULL)
INSERT [dbo].[Allotments] ([AllotmentId], [PersonId], [RoomId], [StarDate], [EndDate], [Active], [Deleted], [LastUpdatedDate], [LastUpdatedUserId]) VALUES (4, 13, 4, CAST(0x0000A4E700000000 AS DateTime), CAST(0x0000A67200000000 AS DateTime), 1, 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Allotments] OFF
