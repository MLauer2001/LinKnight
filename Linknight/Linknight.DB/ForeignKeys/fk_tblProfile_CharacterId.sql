ALTER TABLE [dbo].[tblProfile]
	ADD CONSTRAINT [fk_tblProfile_ColorId]
	FOREIGN KEY (CharacterId)
	REFERENCES [tblCharacter] (Id)
