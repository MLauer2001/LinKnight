BEGIN
	INSERT INTO dbo.tblLobby(Id,LobbyKey)
	VALUES
	(NEWID(), 'Test'),
	(NEWID(), 'Lobby')
END