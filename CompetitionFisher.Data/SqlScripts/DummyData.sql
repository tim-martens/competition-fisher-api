
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- GENERATE TEST DATA

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------


use [competition-fisher-test]

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

declare @championshipName nvarchar(50)
declare @championshipId uniqueidentifier

declare @competitionName nvarchar(50)
declare @competitionId1  uniqueidentifier
declare @competitionId2  uniqueidentifier

declare @firstName nvarchar(50)
declare @lastName nvarchar(50)
declare @competitorId1 uniqueidentifier
declare @competitorId2 uniqueidentifier
declare @competitorId3 uniqueidentifier
declare @competitorId4 uniqueidentifier
declare @competitorId5 uniqueidentifier
declare @competitorId6 uniqueidentifier

declare @adminId1 uniqueidentifier
declare @adminId2 uniqueidentifier

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

print CHAR(13);
print N'##################################################'
print N'###                                            ###'
print N'###            GENERATING TEST DATA            ###'
print N'###                                            ###'
print N'##################################################'
print CHAR(13);

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

print N'###  1. ADDING CHAMPIONSHIP  ###'

set @championshipName = 'Umicore 2016'
IF NOT EXISTS (SELECT * FROM [Championship] WHERE [Name] = @championshipName)
	BEGIN
		insert into [Championship] ([Id],[Name]) 
		values (NEWID(), @championshipName)
	END
ELSE
	BEGIN
		print '  ### Championship "' + @championshipName + '"' + N' already exists'
	END
set @championshipId = ( select id from [Championship] where [Name] = @championshipName )
print '  ### Championship "' + @championshipName + '"' + N' - Id: ' + cast(@championshipId as nvarchar(200))

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

print CHAR(13);
IF @championshipId Is null
	BEGIN
		Print '!!! AN ERROR OCCURRED #1 !!!'
	END
ELSE
	BEGIN
		print N'###  2. ADDING COMPETITIONS TO CHAMPIONSHIP ###'
		set @competitionName = 'Wedstrijd 1'
		IF NOT EXISTS (SELECT * FROM [Competition] WHERE [ChampionshipId] = @championshipId and [Name] = @competitionName)
			BEGIN
					insert into [Competition] ([Id], [ChampionshipId], [Date], [Name])
					values (NEWID(), @championshipId, '20170118', @competitionName);
			END
		ELSE
			BEGIN
				print '  ### Competition "' + @competitionName + + '"' + N' already exists'
			END
		set @competitionId1 = ( select id from [Competition] where Name = @competitionName and [ChampionshipId] = @championshipId )
		print '  ### Competition "' + @competitionName + '"' + N' - Id: ' + cast(@competitionId1 as nvarchar(200))
		----------------------------------------------------------------------------------------------------------------------------
		set @competitionName = 'Wedstrijd 2'
		IF NOT EXISTS (SELECT * FROM [Competition] WHERE [ChampionshipId] = @championshipId and [Name] = @competitionName)
			BEGIN
					insert into [Competition] ([Id], [ChampionshipId], [Date], [Name])
					values (NEWID(), @championshipId, '20170314', @competitionName);
			END
		ELSE
			BEGIN
				print '  ### Competition "' + @competitionName + '"' + N' already exists'
			END
		set @competitionId2 = ( select id from [Competition] where Name = @competitionName and [ChampionshipId] = @championshipId )
		print '  ### Competition "' + @competitionName + '"' + N' - Id: ' + cast(@competitionId2 as nvarchar(200))


	END

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

print CHAR(13);
print N'###  3. ADDING FISHERMEN  ###'

set @firstName = 'Tim'
set @lastName = 'Martens'

IF NOT EXISTS (SELECT * FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [Competitor] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' already exists'

set @competitorId1 = (SELECT [Id] FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@competitorId1 as nvarchar(200))

--

SET @firstName = 'Peter'
SET @lastName = 'Martens'

IF NOT EXISTS (SELECT * FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [Competitor] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' already exists'

SET @competitorId2 = (SELECT [Id] FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@competitorId2 as nvarchar(200))

--

SET @firstName = 'Eddy'
SET @lastName = 'Pauwels'

IF NOT EXISTS (SELECT * FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [Competitor] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' already exists'

SET @competitorId3 = (SELECT [Id] FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@competitorId3 as nvarchar(200))

--

SET @firstName = 'Johan'
SET @lastName = 'Van Ginderen'

IF NOT EXISTS (SELECT * FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [Competitor] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' already exists'

SET @competitorId4 = (SELECT [Id] FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@competitorId4 as nvarchar(200))

--

SET @firstName = 'Patrick'
SET @lastName = 'Vanotterdyck'

IF NOT EXISTS (SELECT * FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [Competitor] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' already exists'

SET @competitorId5 = (SELECT [Id] FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@competitorId5 as nvarchar(200))

--

SET @firstName = 'Werner'
SET @lastName = 'Janssens'

IF NOT EXISTS (SELECT * FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [Competitor] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' already exists'

SET @competitorId6 = (SELECT [Id] FROM [Competitor] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### Competitor "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@competitorId6 as nvarchar(200))

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

print CHAR(13);
print N'###  4. ADDING USERS  ###'

SET @firstName = 'Tim'
SET @lastName = 'Martens'

IF NOT EXISTS (SELECT * FROM [ApplicationUser] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [ApplicationUser] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### User "' + @firstName + ' ' + @lastName + '"' + N' already exists'

SET @adminId1 = (SELECT [Id] FROM [ApplicationUser] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### User "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@adminId1 as nvarchar(200))

--

SET @firstName = 'Eddy'
SET @lastName = 'Pauwels'

IF NOT EXISTS (SELECT * FROM [ApplicationUser] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
	INSERT INTO [ApplicationUser] ([Id], [FirstName], [LastName]) VALUES (NEWID(), @firstName, @lastName)
ELSE
	PRINT '  ### User "' + @firstName + ' ' + @lastName + '"' + N' already exists'

SET @adminId2 = (SELECT [Id] FROM [ApplicationUser] WHERE [FirstName] = @firstName AND [LastName] = @lastName)
PRINT '  ### User "' + @firstName + ' ' + @lastName + '"' + N' - Id: ' + CAST(@adminId2 as nvarchar(200))

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

print CHAR(13);
IF @championshipId Is null
	PRINT '!!! AN ERROR OCCURRED #1 !!!'
ELSE
	BEGIN
		
		PRINT N'###  5. ADDING ADMINS FOR CHAMPIONSHIP ' + @championshipName + ' ###'

		IF NOT EXISTS (SELECT * FROM [AdminsPerChampionship] WHERE [ChampionshipId] = @championshipId AND [ApplicationUserId] = @adminId1)
			INSERT INTO [AdminsPerChampionship] ([ChampionshipId], [ApplicationUserId]) VALUES (@championshipId, @adminId1)
		ELSE
			PRINT '  ### User "' + CAST(@adminId1 as nvarchar(200)) + '"' + N' already added as admin for ' + @championshipName
		
		
		IF NOT EXISTS (SELECT * FROM [AdminsPerChampionship] WHERE [ChampionshipId] = @championshipId AND [ApplicationUserId] = @adminId2)
			INSERT INTO [AdminsPerChampionship] ([ChampionshipId], [ApplicationUserId]) VALUES (@championshipId, @adminId2)
		ELSE
			PRINT '  ### User "' + CAST(@adminId2 as nvarchar(200)) + '"' + N' already added as admin for ' + @championshipName
	END


