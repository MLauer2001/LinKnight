ALTER TABLE [dbo].[tblCharacter]
	ADD CONSTRAINT [fk_tblCharacter_ArmorId]
	FOREIGN KEY (ArmorId)
	REFERENCES [tblArmor] (Id)
