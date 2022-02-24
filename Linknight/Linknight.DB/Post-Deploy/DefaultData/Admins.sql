BEGIN
	INSERT INTO dbo.tblAdmin (Id, FirstName, LastName, UserName, Password)
	VALUES
	(NEWID(), 'Matthew', 'Lauer', 'Lumineux', 'lauerm'),
	(NEWID(), 'Liz', 'Richardson', 'Simple', 'richardsonl'),
	(NEWID(), 'Zach', 'Dorschner', 'Zachman65', 'dorschnerz'),
	(NEWID(), 'Jacob', 'Krause', 'Killercobrak', 'krausej')
END