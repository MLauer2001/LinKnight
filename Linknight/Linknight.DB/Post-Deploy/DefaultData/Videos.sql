BEGIN
	DECLARE @Lobby UNIQUEIDENTIFIER;
	SELECT @Lobby= Id from tblLobby where LobbyKey = 'Test'

	INSERT INTO dbo.tblVideo(Id, VideoURL, LobbyId)
	VALUES
	(NEWID(), 'https://www.youtube.com/watch?v=dQw4w9WgXcQ', @Lobby),
	(NEWID(), 'https://www.youtube.com/watch?v=yOQHDAgLc5A', @Lobby)

	
	SELECT @Lobby = Id from tblLobby where LobbyKey = 'Lobby'

	INSERT INTO dbo.tblVideo(Id, VideoURL, LobbyId)
	VALUES
	(NEWID(), 'https://www.youtube.com/watch?v=rg6CiPI6h2g', @Lobby),
	(NEWID(), 'https://www.youtube.com/watch?v=QH2-TGUlwu4', @Lobby)
END