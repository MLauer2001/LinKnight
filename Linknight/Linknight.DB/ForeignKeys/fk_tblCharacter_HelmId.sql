ALTER TABLE [dbo].[tblCharacter]
	ADD CONSTRAINT [fk_tblCharacter_HelmId]
	FOREIGN KEY (HelmId)
	REFERENCES [tblHelm] (Id)
