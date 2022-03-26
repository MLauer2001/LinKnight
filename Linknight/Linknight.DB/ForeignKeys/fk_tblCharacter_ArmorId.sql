ALTER TABLE [dbo].[tblProfile]
	ADD CONSTRAINT [fk_tblProfile_ArmorId]
	FOREIGN KEY (ArmorId)
	REFERENCES [tblArmor] (Id)
