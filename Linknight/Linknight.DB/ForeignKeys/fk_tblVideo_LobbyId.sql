ALTER TABLE [dbo].[tblVideo]
	ADD CONSTRAINT [fk_tblVideo_LobbyId]
	FOREIGN KEY (LobbyId)
	REFERENCES [tblLobby] (Id)
