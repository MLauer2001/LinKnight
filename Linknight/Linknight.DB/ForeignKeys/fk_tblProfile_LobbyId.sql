ALTER TABLE [dbo].[tblProfile]
	ADD CONSTRAINT [fk_tblProfile_LobbyId]
	FOREIGN KEY (LobbyId)
	REFERENCES [tblLobby] (Id)
