BEGIN
	INSERT INTO dbo.tblAdmin (Id, FirstName, LastName, UserName, Password)
	VALUES
	(NEWID(), 'Matthew', 'Lauer', 'Lumineux', 'wfAEKl5XmuSj8yrEu8z80+BPgpk='),
	(NEWID(), 'Liz', 'Richardson', 'Simple', 'WtQZampxp68p2zZ2lVUcI2eAQ8U='),
	(NEWID(), 'Zach', 'Dorschner', 'Zachman65', 'BsxGKtGgSqUOpmuHuyx7/OlMjaI='),
	(NEWID(), 'Jacob', 'Krause', 'Killercobrak', 'kzsCSXyYlrSeH2tHkLLo6RNQBu0=')
END