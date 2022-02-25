BEGIN
	DECLARE @LobbyId UNIQUEIDENTIFIER;
	SELECT @LobbyId = Id from tblLobby where LobbyKey = 'Test'

	INSERT INTO dbo.tblProfile(Id, Name, LobbyId, CharacterId)
	VALUES
	(NEWID(), 'Testing', @LobbyId, 1),
	(NEWID(), 'NotTest', @LobbyId, 3)

	SELECT @LobbyId = Id from tblLobby where LobbyKey = 'Lobby'

	INSERT INTO dbo.tblProfile(Id, Name, LobbyId, CharacterId)
	VALUES
	(NEWID(), 'Lobby2', @LobbyId, 2),
	(NEWID(), 'AlsoSecond', @LobbyId, 4)
END