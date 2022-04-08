BEGIN
	INSERT INTO tblUser (Id, Username, FirstName, LastName, Password)
	VALUES
	(NEWID(), 'User1', 'John', 'Smith', 'jsmith'),
	(NEWID(), 'User2', 'Sarah', 'Baker', 'sbaker'),
	(NEWID(), 'User3', 'Robert', 'Tanner', 'rtanner')
END