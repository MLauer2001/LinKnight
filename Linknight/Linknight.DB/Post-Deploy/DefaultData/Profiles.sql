BEGIN
	DECLARE @LobbyId UNIQUEIDENTIFIER;
	SELECT @LobbyId = Id from tblLobby where LobbyKey = 'Test'

	INSERT INTO dbo.tblProfile(Id, Name, LobbyId, HelmId, ArmorId, ColorId)
	VALUES
	(NEWID(), 'Testing', @LobbyId, 1, 1, 1),
	(NEWID(), 'NotTest', @LobbyId, 3, 2, 4)

	SELECT @LobbyId = Id from tblLobby where LobbyKey = 'Lobby'

	INSERT INTO dbo.tblProfile(Id, Name, LobbyId, HelmId, ArmorId, ColorId)
	VALUES
	(NEWID(), 'Lobby2', @LobbyId, 2, 1, 3),
	(NEWID(), 'AlsoSecond', @LobbyId, 1, 2, 4)
END